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
    public partial class FormClientLink : Form
    {
        public FormClientLink()
        {
            InitializeComponent();
            RunningState.isServer = false;
        }

        Socket socket = null;

        private async void buttonStartConnect_Click(object sender, EventArgs e)
        {
            textBoxIP.Enabled = false;
            textBoxPort.Enabled = false;
            buttonStartConnect.Enabled = false;
            IPEndPoint ipEndPoint = new IPEndPoint(
                IPAddress.Parse(textBoxIP.Text), int.Parse(textBoxPort.Text)
            );
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                await socket.ConnectAsync(ipEndPoint);
                new FormMain(socket).Show();
                socket = null;
                Program.formStart.Hide();
                Close();
            }
            catch (SocketException) 
            {
                // 连接失败
                textBoxIP.Enabled = true;
                textBoxPort.Enabled = true;
                buttonStartConnect.Enabled = true;
                MessageBox.Show("连接主机失败");
            }
            catch (ObjectDisposedException)
            {
                // 关闭窗口
            }
        }

        private void FormClientLink_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (socket != null)
            {
                socket.Close();
            }
        }
    }
}
