using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class FormDraw : Form
    {
        Bitmap bitmap;
        Graphics graphic;
        int size = 5;
        int eraserSize = 10;
        bool isPainting;

        static FormDraw instance;

        public static FormDraw GetInstance()
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new FormDraw();
            }
            return instance;
        }

        private FormDraw()
        {
            InitializeComponent();
            this.TransparencyKey = Color.PaleVioletRed;
            bitmap = new Bitmap(panel1.Width, panel1.Height);
            panel1.CreateGraphics().DrawImage(bitmap, new Point(0, 0));
            graphic = Graphics.FromImage(bitmap);
            radioButton1.Checked = true;
            radioButton7.Checked = true;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            isPainting = true;//开始画画
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            isPainting = false;//结束画画
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (!isPainting) return;

            if (radioButton7.Checked)  // 细
            {
                size = 2;
            }
            else if (radioButton8.Checked)  // 中
            {
                size = 5;
            }
            else if (radioButton9.Checked)  // 粗
            {
                size = 10;
            }
            eraserSize = Math.Max(size * 2, 7);

            if (radioButton6.Checked)  // 橡皮
            {
                graphic.FillRectangle(new SolidBrush(this.TransparencyKey),
                    e.X - eraserSize, e.Y - eraserSize, eraserSize * 2, eraserSize * 2);
                panel1.CreateGraphics().DrawImage(bitmap, new Point(0, 0));
                return;
            }

            SolidBrush solidBrush = null;
            
            if (radioButton1.Checked)  // 红
            {
                solidBrush = new SolidBrush(Color.Red);
            }
            else if (radioButton2.Checked)  // 黄
            {
                solidBrush = new SolidBrush(Color.Yellow);
            }
            else if (radioButton3.Checked)  // 蓝
            {
                solidBrush = new SolidBrush(Color.Blue);
            }
            else if (radioButton4.Checked)  // 绿
            {
                solidBrush = new SolidBrush(Color.Green);
            }
            else if (radioButton5.Checked)  // 黑
            {
                solidBrush = new SolidBrush(Color.Black);
            }

            graphic.FillEllipse(solidBrush, e.X, e.Y, size, size);
            panel1.CreateGraphics().DrawImage(bitmap, new Point(0, 0));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            graphic.Clear(this.TransparencyKey);
            panel1.CreateGraphics().DrawImage(bitmap, new Point(0, 0));
        }
    }
}
