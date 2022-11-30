using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class FormServerLink : Form
    {
        public FormServerLink()
        {
            InitializeComponent();
            RunningState.isServer = true;
        }

        Socket listener = null;

        private async void buttonStartListen_Click(object sender, EventArgs e)
        {
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
                new FormMain(handler).Show();
                Program.formStart.Hide();
                Close();
            } catch (SocketException) { } // 关闭窗口取消监听
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
