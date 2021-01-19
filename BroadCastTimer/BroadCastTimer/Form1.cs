using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BroadCastTimer
{
    public partial class Form1 : Form
    {
        private bool TimerCheck = false;
        private Point mousePoint;
        private int Sec =0;

        public Form1()
        {
            InitializeComponent();

            PrivateFontCollection privateFont = new PrivateFontCollection(); 
            privateFont.AddFontFile("LAB디지털.TTF"); 
            Font font = new Font(privateFont.Families[0], 32f); 
            label1.Font = font;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e) // 숫자만 바꾸는 Tick
        {
            if (TimerCheck)
            {
                Sec++;
                TimeDisplay();
            }
        }



        private void form_MouseDown(object sender, MouseEventArgs e)
        {
            mousePoint = new Point(e.X, e.Y);
        }
        // 마우스 클릭시 먼저 선언된 mousePoint변수에 현재 마우스 위치값이 들어갑니다.

        private void form_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                Location = new Point(this.Left - (mousePoint.X - e.X),
                    this.Top - (mousePoint.Y - e.Y));
            }
        }
        // 클릭상태로 마우스를 이동시 이동한 만큼에서 윈도우 위치값을 빼게됩니다.

        private void form_DoubleClick(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)//시작
        {
            TimerCheck = true;
        }

        private void pictureBox3_Click(object sender, EventArgs e)//일시정지
        {
            TimerCheck = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)//중지
        {
            TimerCheck = false;
            Sec = 0;
            TimeDisplay();
        }

        private void TimeDisplay()
        {
            int Hour, Min, Seconds;

            Hour = Sec / 3600;
            Min = Sec / 60;
            Seconds = Sec % 60;

            string ValueString = string.Format("{0} : {1} : {2}", Hour.ToString(), Min.ToString("D2"), Sec.ToString("D2"));

            label1.Text = ValueString;
        }
    }
}
