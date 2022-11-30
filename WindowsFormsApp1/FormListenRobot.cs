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

namespace WindowsFormsApp1
{
    public partial class FormListenRobot : Form
    {
        FormMain formMain;
        public FormListenRobot(FormMain formMain)
        {
            InitializeComponent();
            this.formMain = formMain;
        }

        Socket listener = null;

        private async void buttonStartListen_Click(object sender, EventArgs e)
        {
            if (NetTools.PortInUse(int.Parse(textBoxPort.Text)))
            {
                MessageBox.Show("端口被占用！");
                return;
            }


            textBoxPort.Enabled = false;
            buttonStartListen.Enabled = false;
            buttonStartListen.Text = "等待连接中……";
            IPEndPoint iPEndPoint = new IPEndPoint(
                IPAddress.Any, int.Parse(textBoxPort.Text)
            );
            listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            listener.Bind(iPEndPoint);
            listener.Listen(1);
            try
            {
                Socket handler = await listener.AcceptAsync();
                formMain.ReceiveAiSocket(handler);
                Close();
            }
            catch (SocketException) { } // 关闭窗口取消监听
        }

        private void FormServerLink_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (listener != null)
            {
                listener.Close();
            }
        }
    }
}
