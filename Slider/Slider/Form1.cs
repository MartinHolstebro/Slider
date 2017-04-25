using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Slider
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }
        

        //Variable
        Thread t;
        bool isMouseDown = false;
        int x;

        public void Tegn(int xPos)
        {
            int buttonWidth = 10;
            int buttonheight = 10;

            if (xPos > pictureBox1.Width - buttonWidth / 2)
            {
                xPos = pictureBox1.Width - buttonWidth / 2;
            }
            if (xPos < buttonWidth / 2)
            {
                xPos = buttonWidth / 2 ;
            }

            Graphics g = pictureBox1.CreateGraphics();
            g.Clear(Color.LightGoldenrodYellow);
            SolidBrush blueBrush = new SolidBrush(Color.Blue);
            SolidBrush greenBrush = new SolidBrush(Color.Green);

            g.FillRectangle(blueBrush, new Rectangle(xPos - buttonWidth / 2, 0, buttonWidth, buttonheight));
            g.FillRectangle(greenBrush, new Rectangle(0, 0, xPos - buttonWidth / 2, buttonheight));

            x = xPos;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Tegn(pictureBox1.Width / 2);
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            t = new Thread(() => Tegn(e.X));
            t.IsBackground = true;
            if (isMouseDown == true)
            {
                t.Start();
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            isMouseDown = true;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;
        }
    }
}
