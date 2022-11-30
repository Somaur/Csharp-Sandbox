namespace WindowsFormsApp1
{
    partial class FormMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxMessage = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonSendMessage = new System.Windows.Forms.Button();
            this.richTextBoxLog = new System.Windows.Forms.RichTextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelSelfView = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnPrepare = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanelRivalView = new System.Windows.Forms.TableLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRotate = new System.Windows.Forms.Button();
            this.btnRotateInv = new System.Windows.Forms.Button();
            this.airportLabel = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnDraws = new System.Windows.Forms.Button();
            this.btnListenRobot = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxMessage
            // 
            this.textBoxMessage.Location = new System.Drawing.Point(83, 9);
            this.textBoxMessage.Name = "textBoxMessage";
            this.textBoxMessage.Size = new System.Drawing.Size(249, 25);
            this.textBoxMessage.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(27, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "信息：";
            // 
            // buttonSendMessage
            // 
            this.buttonSendMessage.Location = new System.Drawing.Point(338, 9);
            this.buttonSendMessage.Name = "buttonSendMessage";
            this.buttonSendMessage.Size = new System.Drawing.Size(85, 25);
            this.buttonSendMessage.TabIndex = 3;
            this.buttonSendMessage.Text = "发送";
            this.buttonSendMessage.UseVisualStyleBackColor = true;
            this.buttonSendMessage.Click += new System.EventHandler(this.ButtonSendMessageClick);
            // 
            // richTextBoxLog
            // 
            this.richTextBoxLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxLog.Location = new System.Drawing.Point(503, 3);
            this.richTextBoxLog.Name = "richTextBoxLog";
            this.richTextBoxLog.ReadOnly = true;
            this.tableLayoutPanel1.SetRowSpan(this.richTextBoxLog, 3);
            this.richTextBoxLog.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.richTextBoxLog.Size = new System.Drawing.Size(397, 707);
            this.richTextBoxLog.TabIndex = 5;
            this.richTextBoxLog.Text = "";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.SkyBlue;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanelSelfView, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.richTextBoxLog, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanelRivalView, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(903, 713);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // tableLayoutPanelSelfView
            // 
            this.tableLayoutPanelSelfView.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanelSelfView.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanelSelfView.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanelSelfView.ColumnCount = 10;
            this.tableLayoutPanelSelfView.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanelSelfView.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanelSelfView.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanelSelfView.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanelSelfView.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanelSelfView.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanelSelfView.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanelSelfView.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanelSelfView.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanelSelfView.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanelSelfView.Location = new System.Drawing.Point(100, 351);
            this.tableLayoutPanelSelfView.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelSelfView.Name = "tableLayoutPanelSelfView";
            this.tableLayoutPanelSelfView.RowCount = 10;
            this.tableLayoutPanelSelfView.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanelSelfView.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanelSelfView.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanelSelfView.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanelSelfView.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanelSelfView.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanelSelfView.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanelSelfView.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanelSelfView.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanelSelfView.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanelSelfView.Size = new System.Drawing.Size(300, 300);
            this.tableLayoutPanelSelfView.TabIndex = 14;
            this.tableLayoutPanelSelfView.MouseLeave += new System.EventHandler(this.SelfView_MouseLeave);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnListenRobot);
            this.panel2.Controls.Add(this.btnPrepare);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(403, 337);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(94, 328);
            this.panel2.TabIndex = 13;
            // 
            // btnPrepare
            // 
            this.btnPrepare.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnPrepare.Location = new System.Drawing.Point(16, 227);
            this.btnPrepare.Margin = new System.Windows.Forms.Padding(3, 35, 3, 3);
            this.btnPrepare.Name = "btnPrepare";
            this.btnPrepare.Size = new System.Drawing.Size(64, 64);
            this.btnPrepare.TabIndex = 0;
            this.btnPrepare.Text = "准备";
            this.btnPrepare.UseVisualStyleBackColor = true;
            this.btnPrepare.Click += new System.EventHandler(this.btnPrepare_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.AliceBlue;
            this.tableLayoutPanel1.SetColumnSpan(this.panel1, 3);
            this.panel1.Controls.Add(this.buttonSendMessage);
            this.panel1.Controls.Add(this.textBoxMessage);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 671);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(494, 39);
            this.panel1.TabIndex = 7;
            // 
            // tableLayoutPanelRivalView
            // 
            this.tableLayoutPanelRivalView.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanelRivalView.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanelRivalView.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanelRivalView.ColumnCount = 10;
            this.tableLayoutPanelRivalView.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanelRivalView.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanelRivalView.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanelRivalView.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanelRivalView.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanelRivalView.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanelRivalView.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanelRivalView.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanelRivalView.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanelRivalView.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanelRivalView.Location = new System.Drawing.Point(100, 17);
            this.tableLayoutPanelRivalView.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelRivalView.Name = "tableLayoutPanelRivalView";
            this.tableLayoutPanelRivalView.RowCount = 10;
            this.tableLayoutPanelRivalView.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanelRivalView.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanelRivalView.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanelRivalView.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanelRivalView.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanelRivalView.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanelRivalView.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanelRivalView.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanelRivalView.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanelRivalView.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanelRivalView.Size = new System.Drawing.Size(300, 300);
            this.tableLayoutPanelRivalView.TabIndex = 8;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.btnRotate);
            this.panel3.Controls.Add(this.btnRotateInv);
            this.panel3.Controls.Add(this.airportLabel);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 337);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(94, 328);
            this.panel3.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(-3, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "点击旋转飞机";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "飞机库";
            // 
            // btnRotate
            // 
            this.btnRotate.Font = new System.Drawing.Font("Wingdings 3", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnRotate.Location = new System.Drawing.Point(15, 168);
            this.btnRotate.Name = "btnRotate";
            this.btnRotate.Size = new System.Drawing.Size(60, 60);
            this.btnRotate.TabIndex = 0;
            this.btnRotate.Text = "P";
            this.btnRotate.UseVisualStyleBackColor = true;
            this.btnRotate.Click += new System.EventHandler(this.btnRotate_Click);
            // 
            // btnRotateInv
            // 
            this.btnRotateInv.Font = new System.Drawing.Font("Wingdings 3", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnRotateInv.Location = new System.Drawing.Point(15, 243);
            this.btnRotateInv.Name = "btnRotateInv";
            this.btnRotateInv.Size = new System.Drawing.Size(60, 60);
            this.btnRotateInv.TabIndex = 1;
            this.btnRotateInv.Text = "Q";
            this.btnRotateInv.UseVisualStyleBackColor = true;
            this.btnRotateInv.Click += new System.EventHandler(this.btnRotateInv_Click);
            // 
            // airportLabel
            // 
            this.airportLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.airportLabel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.airportLabel.Font = new System.Drawing.Font("Wingdings", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.airportLabel.Location = new System.Drawing.Point(9, 36);
            this.airportLabel.Name = "airportLabel";
            this.airportLabel.Size = new System.Drawing.Size(75, 75);
            this.airportLabel.TabIndex = 1;
            this.airportLabel.Text = "QQQ";
            this.airportLabel.Click += new System.EventHandler(this.airportLabel_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnDraws);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(94, 328);
            this.panel4.TabIndex = 16;
            // 
            // btnDraws
            // 
            this.btnDraws.Location = new System.Drawing.Point(9, 35);
            this.btnDraws.Name = "btnDraws";
            this.btnDraws.Size = new System.Drawing.Size(75, 76);
            this.btnDraws.TabIndex = 0;
            this.btnDraws.Text = "绘图工具";
            this.btnDraws.UseVisualStyleBackColor = true;
            this.btnDraws.Click += new System.EventHandler(this.btnDraw_Click);
            // 
            // btnListenRobot
            // 
            this.btnListenRobot.Location = new System.Drawing.Point(16, 24);
            this.btnListenRobot.Name = "btnListenRobot";
            this.btnListenRobot.Size = new System.Drawing.Size(64, 62);
            this.btnListenRobot.TabIndex = 1;
            this.btnListenRobot.Text = "接入Ai";
            this.btnListenRobot.UseVisualStyleBackColor = true;
            this.btnListenRobot.Click += new System.EventHandler(this.btnListenRobot_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(903, 713);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormMain";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxMessage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonSendMessage;
        private System.Windows.Forms.RichTextBox richTextBoxLog;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelRivalView;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnRotateInv;
        private System.Windows.Forms.Button btnRotate;
        private System.Windows.Forms.Button btnPrepare;
        private System.Windows.Forms.Label airportLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelSelfView;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnDraws;
        private System.Windows.Forms.Button btnListenRobot;
    }
}

