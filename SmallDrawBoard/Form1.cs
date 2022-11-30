using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace SmallDrawBoard
{
    public partial class Form1 : Form
    {
        Bitmap bm;
        bool paint;
        public Form1()
        {
            InitializeComponent();
            this.TransparencyKey = Color.Peru;
            bm = new Bitmap(panel1.Width, panel1.Height);
            panel1.CreateGraphics().DrawImage(bm, new Point(0, 0));
            TempData.p = Graphics.FromImage(bm);//用bm来创建一个新的画布
            //TempData.p.FillRectangle(new SolidBrush(Color.Peru), 0, 0, panel1.Width, panel1.Height);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            paint = true;//开始画画
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            paint = false;//结束画画
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (paint && radioButton1.Checked)
            {
                TempData.p.FillEllipse(TempData.solidBrush, e.X, e.Y, TempData.size, TempData.size);
                panel1.CreateGraphics().DrawImage(bm, new Point(0, 0));
            }
            else if (paint && radioButton2.Checked)
            {
                TempData.p.FillEllipse(new SolidBrush(Color.Peru), e.X, e.Y, 30, 30);
                panel1.CreateGraphics().DrawImage(bm, new Point(0, 0));
            }
        }

        public class TempData
        {
            //用于多个窗体共同使用的数据
            public static int size = 10;
            public static SolidBrush solidBrush = new SolidBrush(Color.Black);
            public static Graphics p;
        }
    }
}
