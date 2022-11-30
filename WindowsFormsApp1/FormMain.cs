using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Common;
using System.Reflection;
using System.Runtime.InteropServices;
using static WindowsFormsApp1.GameMessage;
using System.Security.Cryptography;

namespace WindowsFormsApp1
{
    public partial class FormMain : Form
    {
        [DllImport("user32.dll")]
        public static extern IntPtr LoadCursorFromFile(string fileName);
        [DllImport("user32.dll")]
        public static extern IntPtr SetCursor(IntPtr cursorHandle);


        Socket socket = null;
        private ArraySegment<byte> receiveBuffer;
        byte[] receiveBytes = new byte[1_024];
        
        int gameViewSize;
        AircraftWarGame game;
        const string signMiss = "r", signHit = "s", signKill = "a";
        enum GameState { Before, Prepare, Gaming };
        GameState gameState;
        bool rivalPrepare;
        void ToBefore()
        {
            btnPrepare.Enabled = true;
            btnRotate.Enabled = true;
            btnRotateInv.Enabled = true;
            gameState = GameState.Before;
            btnPrepare.Text = "准备";
        }
        void ToPrepare()
        {
            btnPrepare.Text = "取消准备";
            btnPrepare.Enabled = true;
            btnRotate.Enabled = false;
            btnRotateInv.Enabled = false;
            if (rivalPrepare)
            {
                ToGaming();
                return;
            }
            gameState = GameState.Prepare;
        }
        void ToGaming()
        {
            AppendText("[系统]: 开始对局！");
            if (RunningState.isServer == true)
            {
                bool headStart = new Random().Next() % 2 == 0;
                SendMessage(GetHeadStartMsg(headStart));
                if (headStart)
                {
                    AppendText("[系统]: 由你先手开始！");
                    ToAttack();
                }
                else
                {
                    AppendText("[系统]: 等待对方先手。");
                    ToWaitBeAttack();
                }
            }
            selfHP = 3;
            rivalHP = 3;
            btnPrepare.Enabled = false;
            gameState = GameState.Gaming;
        }
        enum TurnState { Attack, WaitAttackResult, WaitBeAttack};
        TurnState turnState;
        void ToAttack()
        {
            AppendText("[系统]: 到你行动了！");
            turnState = TurnState.Attack;
            if (currentPlayer == PlayerType.Robot)
            {
                SendAiMessage();
            }
        }
        void ToWaitAttackResult()
        {
            turnState = TurnState.WaitAttackResult;
        }
        void ToWaitBeAttack()
        {
            turnState = TurnState.WaitBeAttack;
        }

        Aircraft[] aircrafts = new Aircraft[4]
        {
            null,
            new Aircraft {direction = Aircraft.Direction.Up, placed = false},
            new Aircraft {direction = Aircraft.Direction.Up, placed = false},
            new Aircraft {direction = Aircraft.Direction.Up, placed = false},
        };
        int onHandId;

        int selfHP, rivalHP;
        void selfBeHit()
        {
            selfHP -= 1;
            if (selfHP == 0) EndGame();
        }
        void rivalBeHit()
        {
            rivalHP -= 1;
            if (rivalHP == 0) EndGame();
        }
        void EndGame()
        {
            if (rivalHP == 0)
            {
                AppendText("[系统]: 你获胜了！");
                MessageBox.Show("你获胜了！", "对局结束");
            }
            else
            {
                AppendText("[系统]: 对方获得了胜利。");
                MessageBox.Show("对方获得了胜利", "对局结束");
            }
            rivalPrepare = false;
            for (int i = 0; i < 10; ++i)
            {
                for (int j = 0; j < 10; ++j)
                {
                    tableLayoutPanelRivalView.GetControlFromPosition(j, i).Text = "";
                    tableLayoutPanelRivalView.GetControlFromPosition(j, i).BackColor = Color.White;
                    tableLayoutPanelSelfView.GetControlFromPosition(j, i).Text = "";
                }
            }
            ToBefore();
        }

        // - - - - - - - - - - - - - - - - - - - - - -
        public FormMain(Socket socket)
        {
            InitializeComponent();
            this.socket = socket;
            ReceiveMessage();
            Init();
            DrawSelfView();
        }

        private void Init()
        {
            gameViewSize = tableLayoutPanelRivalView.RowCount;
            InitGameView(tableLayoutPanelRivalView, self: false);
            InitGameView(tableLayoutPanelSelfView, self: true);
            airportLabel.Text = "QQQ";
            game = new AircraftWarGame();
            ToBefore();
            onHandId = -1;
            rivalPrepare = false;
            ToHuman();
        }

        private void InitGameView(TableLayoutPanel table, bool self)
        {
            Font font = new Font("Webdings", 10F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(2)));
            for (int i = 0; i < gameViewSize; ++i)
            {
                for (int j = 0; j < gameViewSize; ++j)
                {
                    Label label = new Label
                    {
                        Dock = DockStyle.Fill,
                        Font = font,
                        Text = "",
                        TextAlign = ContentAlignment.MiddleCenter,
                        Margin = new Padding(0),
                    };
                    if (self) label.Click += ClickLabelSelf;
                    else label.Click += ClickLabelRival;
                    if (self) label.MouseMove += SelfTable_MouseMove;
                    table.Controls.Add(label, j, i);
                }
            }
        }

        private void DrawSelfView()
        {
            for (int i = 0; i < gameViewSize; ++i)
            {
                for (int j = 0; j < gameViewSize; ++j)
                {
                    Label label = (Label)tableLayoutPanelSelfView.GetControlFromPosition(j, i);
                    int val = game.GetSelfCell(j, i);
                    if (val == 0)
                    {
                        label.BackColor = Color.White;
                    }
                    else if (val < 10)
                    {
                        label.BackColor = Color.Red;
                    }
                    else
                    {
                        label.BackColor = Color.Blue;
                    }
                }
            }
        }

        private void ClickLabelSelf(object sender, EventArgs e)
        {
            // 部署 | 取消飞机
            if (gameState != GameState.Before) return;
            Label label = sender as Label;
            var pos = tableLayoutPanelSelfView.GetCellPosition((Control)sender);
            //AppendText("[ClickSelf]: " + tableLayoutPanelSelfView.GetCellPosition(label));
            if (onHandId != -1)
            {
                if (game.IsLegalAirCraft(pos.Column, pos.Row, aircrafts[onHandId].direction))
                {
                    AppendText("[你]: 部署了一架飞机");
                    game.AddAirCraft(onHandId, pos.Column, pos.Row, aircrafts[onHandId].direction);
                    aircrafts[onHandId].placed = true;
                    ResetCursor();
                    onHandId = -1;
                }
            }
            else
            {
                if (game.GetSelfCell(pos.Column, pos.Row) != 0)
                {
                    AppendText("[你]: 取消了一架飞机的部署");
                    onHandId = game.RemoveAirCraft(pos.Column, pos.Row);
                    aircrafts[onHandId].placed = false;
                    SetCursor();
                }
            }
            
        }
        private void ClickLabelRival(object sender, EventArgs e)
        {
            // 攻击对手
            if (gameState != GameState.Gaming) return;
            if (turnState != TurnState.Attack) return;
            Label label = sender as Label;
            if (label.Text.Length != 0) return;  // 已经攻击过的地方
            var pos = tableLayoutPanelRivalView.GetCellPosition(label);
            AppendText("[你]: 攻击对手的" + pos);
            SendMessage(GetAttackRequestMsg(pos.Column, pos.Row));
            ToWaitAttackResult();
        }

        private void SelfTable_MouseMove(object sender, MouseEventArgs e)
        {
            // 绘制手持的飞机
            if (gameState != GameState.Before) return;
            if (onHandId == -1) return;
            var pos = tableLayoutPanelSelfView.GetCellPosition((Control)sender);
            DrawSelfView();
            int[][] shape = Aircraft.getShape(pos.Column, pos.Row, aircrafts[onHandId].direction);
            if (game.IsLegalAirCraft(pos.Column, pos.Row, aircrafts[onHandId].direction))
            {
                foreach (int[] cell in shape)
                {
                    var lab = tableLayoutPanelSelfView.GetControlFromPosition(cell[0], cell[1]);
                    lab.BackColor = Color.Blue;
                }
                tableLayoutPanelSelfView.GetControlFromPosition(pos.Column, pos.Row).BackColor = Color.Red;
            }
            else
            {
                foreach (int[] cell in shape)
                {
                    if (cell[0] < 0 || cell[1] < 0 || cell[0] > 9 || cell[1] > 9) continue;
                    var lab = tableLayoutPanelSelfView.GetControlFromPosition(cell[0], cell[1]);
                    lab.BackColor = Color.LightGray;
                }
            }
        }
        private void airportLabel_Click(object sender, EventArgs e)
        {
            if (gameState != GameState.Before) return;
            if (onHandId == -1)
            {
                if (airportLabel.Text.Length == 0) return;
                onHandId = GetEmptyId();
                airportLabel.Text = airportLabel.Text.Remove(0, 1);
                SetCursor();
            }
            else
            {
                aircrafts[onHandId].placed = false;
                airportLabel.Text += "Q";
                onHandId = -1;
                ResetCursor();
            }
        }

        private int GetEmptyId()
        {
            for (int i = 1; i <= 3; ++i) if (aircrafts[i].placed == false) return i;
            return -1;
        }

        private void SetCursor()
        {
            Cursor myCursor = new Cursor(Cursor.Current.Handle);
            //AppendText(Environment.CurrentDirectory.ToString());
            IntPtr colorCursorHandle = LoadCursorFromFile("D:\\Projects\\repos\\Csharp-Sandbox\\WindowsFormsApp1\\icons\\mec132.cur");//鼠标图标路径
            myCursor.GetType().InvokeMember(
                "handle",
                BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetField, 
                null, myCursor,
                new object[] { colorCursorHandle }
                );
            Cursor = myCursor;
            ResetCursor();
        }

        private async void ReceiveMessage()
        {
            try
            {
                while (true)
                {
                    receiveBuffer = new ArraySegment<byte>(receiveBytes);
                    int receivedNum = await socket.ReceiveAsync(receiveBuffer, SocketFlags.None);
                    GameMessage msg = GameMessage.ParseArraySegment(receiveBuffer, receivedNum);
                    switch (msg.GetMsgType())
                    {
                        case MsgType.Text:
                            if (receivedNum > 0) AppendText("[对方] 说: " + GetText(msg));
                            break;
                        case MsgType.Prepare:
                            AppendText("[对方]: 已经准备好了。");
                            rivalPrepare = true;
                            if (gameState == GameState.Prepare) ToGaming();
                            break;
                        case MsgType.CanclePrepare:
                            AppendText("[对方]: 取消了准备。");
                            rivalPrepare = false;
                            break;
                        case MsgType.AttackRequest:
                            if (turnState != TurnState.WaitBeAttack)
                            {
                                AppendText("[对方]: <非法的攻击请求>");
                                break;
                            }
                            var (column, row) = GetAttackRequest(msg);
                            AppendText("[对方]: 攻击了 (" + column + ", " + row + ")");

                            tableLayoutPanelSelfView.GetControlFromPosition(column, row).Text = signHit;
                            SendMessage(GetAttackResponseMsg(column, row, game.GetSelfCellType(column, row)));
                            if (game.GetSelfCellType(column, row) == AircraftWarGame.CellType.Kill)
                            {
                                selfBeHit();
                            }
                            if (gameState == GameState.Gaming) ToAttack();
                            break;
                        case MsgType.AttackResponse:
                            if (turnState != TurnState.WaitAttackResult)
                            {
                                AppendText("[对方]: <非法的攻击回复>");
                                break;
                            }
                            var (c, r, type) = GetAttackResponse(msg);
                            switch (type)
                            {
                                case AircraftWarGame.CellType.Kill:
                                    tableLayoutPanelRivalView.GetControlFromPosition(c, r).Text = signKill;
                                    tableLayoutPanelRivalView.GetControlFromPosition(c, r).BackColor = Color.Red;
                                    AppendText("[对方]: 被击毁了一架飞机！");
                                    rivalBeHit();
                                    break;
                                case AircraftWarGame.CellType.Hit:
                                    tableLayoutPanelRivalView.GetControlFromPosition(c, r).Text = signHit;
                                    tableLayoutPanelRivalView.GetControlFromPosition(c, r).BackColor = Color.Blue;
                                    AppendText("[对方]: 被击中了！但没有击毁飞机。");
                                    break;
                                default:
                                    tableLayoutPanelRivalView.GetControlFromPosition(c, r).Text = signMiss;
                                    tableLayoutPanelRivalView.GetControlFromPosition(c, r).BackColor = Color.LightGray;
                                    AppendText("[对方]: 没有被击中！");
                                    break;
                            }
                            ToWaitBeAttack();
                            break;
                        case MsgType.HeadStart:
                            if (GetHeadStart(msg))
                            {
                                AppendText("[系统]: 由你先手开始！");
                                ToAttack();
                            }
                            else
                            {
                                AppendText("[系统]: 等待对方先手。");
                                ToWaitBeAttack();
                            }
                            break;
                    }
                }
            } catch (Exception) 
            {
                try
                {
                    AppendText("[系统]: 连接已断开");
                } catch (Exception) { }
            }
        }

        private void ButtonSendMessageClick(object sender, EventArgs e)
        {
            SendMessage(GetTextMsg(textBoxMessage.Text));
            AppendText("[你] 说: " + textBoxMessage.Text);
            textBoxMessage.ResetText();
        }
        private async void SendMessage(GameMessage msg)
        {
            _ = await socket.SendAsync(msg.GetSendSegments(), SocketFlags.None);
        }

        private void SelfView_MouseLeave(object sender, EventArgs e)
        {
            DrawSelfView();
        }

        private void btnRotate_Click(object sender, EventArgs e)
        {
            if (gameState != GameState.Before) return;
            if (onHandId == -1) return;
            aircrafts[onHandId].direction += 1;
            if (aircrafts[onHandId].direction > Aircraft.Direction.Left)
                aircrafts[onHandId].direction = Aircraft.Direction.Up;
        }

        private void btnRotateInv_Click(object sender, EventArgs e)
        {
            if (gameState != GameState.Before) return;
            if (onHandId == -1) return;
            aircrafts[onHandId].direction -= 1;
            if (aircrafts[onHandId].direction < Aircraft.Direction.Up)
                aircrafts[onHandId].direction = Aircraft.Direction.Left;
        }

        private void btnDraw_Click(object sender, EventArgs e)
        {
            FormDraw.GetInstance().Show();
            FormDraw.GetInstance().Focus();
        }

        private void btnPrepare_Click(object sender, EventArgs e)
        {
            if (gameState == GameState.Before)
            {
                if (GetEmptyId() != -1)
                {
                    AppendText("[系统]: 所有飞机部署完成后才能准备。");
                    return;
                }
                AppendText("[你]: 准备开始游戏！");
                SendMessage(GetPrepareMsg());
                ToPrepare();
            }
            else if (gameState == GameState.Prepare)
            {
                AppendText("[你]: 取消了准备。");
                SendMessage(GetCanclePrepareMsg());
                ToBefore();
            }
        }

        private void AppendText(string text)
        {
            if (richTextBoxLog.Text.Length == 0) richTextBoxLog.Text = text;
            else richTextBoxLog.Text += '\n' + text;

            richTextBoxLog.SelectionStart = richTextBoxLog.TextLength;
            richTextBoxLog.ScrollToCaret();
        }
        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Program.formStart != null && Program.formStart.Visible == false)
            {
                Program.formStart.Visible = true;
            }
            socket.Close();
        }

        Socket aiSocket;
        enum PlayerType { Human, Robot };
        PlayerType currentPlayer;
        void ToHuman()
        {
            currentPlayer = PlayerType.Human;
        }
        void ToRobot()
        {
            currentPlayer = PlayerType.Robot;
        }
        private void btnListenRobot_Click(object sender, EventArgs e)
        {
            if (currentPlayer == PlayerType.Human)
            {
                FormListenRobot form = new FormListenRobot(this);
                form.Show();
            }
            else
            {
                aiSocket.Close();
            }
        }
        public void ReceiveAiSocket(Socket socket)
        {
            AppendText("[系统]: 与AI连接成功，移交控制…… " + socket);
            aiSocket = socket;
            ReceiveAiMessage();
            ToRobot();
            if (gameState == GameState.Gaming && turnState == TurnState.Attack)
            {
                SendAiMessage();
            }
        }

        private async void ReceiveAiMessage()
        {
            byte[] buffer = new byte[2048];
            try
            {
                while (true)
                {
                    ArraySegment<byte> receiveBuffer = new ArraySegment<byte>(buffer);
                    int receivedNum = await aiSocket.ReceiveAsync(receiveBuffer, SocketFlags.None);
                    string msg = Encoding.UTF8.GetString(buffer, 0, receivedNum);
                    AppendText("[Ai]: " + msg);

                    if (gameState == GameState.Gaming && turnState == TurnState.Attack)
                    {
                        var ss = msg.Split();
                        int column = int.Parse(ss[0]), row = int.Parse(ss[1]);
                        SendMessage(GetAttackRequestMsg(column, row));
                        ToWaitAttackResult();
                    }
                }
            }
            catch (Exception)
            {
                try
                {
                    aiSocket.Close();
                    AppendText("[Ai]: 连接已断开");
                    ToHuman();
                }
                catch (Exception) { }
            }
        }
        // 0 Unknown, 1 Miss, 2 Hit, 3 Kill
        private async void SendAiMessage()
        {
            String msg = "";
            for (int r = 0; r < 10; ++r)
            {
                for (int c = 0; c < 10; ++c)
                {
                    switch (tableLayoutPanelRivalView.GetControlFromPosition(c, r).Text)
                    {
                        case signKill: msg += "3 "; break;
                        case signHit: msg += "2 "; break;
                        case signMiss: msg += "1 "; break;
                        default: msg += "0 "; break;
                    }
                }
            }
            _ = await aiSocket.SendAsync(new ArraySegment<byte>(Encoding.UTF8.GetBytes(msg)) , SocketFlags.None);
        }
    }
}
