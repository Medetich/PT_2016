using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paintlab
{
    public partial class Paint : Form
    {
        Drawer drawer;
        public Paint()
        {
            InitializeComponent();
            drawer = new Drawer(pictureBox1);
            trackBar1.Maximum = 10;
            trackBar1.Minimum = 1;
        }

       
        private void Pencil(object sender, EventArgs e)
        {
            drawer.tool = Tool.Pencil;
        }

        private void Rect(object sender, EventArgs e)
        {
            drawer.tool = Tool.Rectangle;
        }

        private void Circle(object sender, EventArgs e)
        {
            drawer.tool = Tool.Circle;
        }

        private void Color(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            drawer.pen = new Pen(colorDialog1.Color);
            drawer.width = trackBar1.Value;
            drawer.pen.Width = trackBar1.Value;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left)
            {
                drawer.prev = e.Location;
                drawer.started = true;
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (drawer.started)
            {
                drawer.Draw(e.Location);
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {

            drawer.started = false;
            drawer.savelast();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            drawer.tool = Tool.Eraser;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            drawer.tool = Tool.Line;
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            drawer.g.Clear(System.Drawing.Color.White);
            pictureBox1.Refresh();
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "JPG Files (*.jpg)|*.jpg|PNG Files (*.png)|*.png";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                drawer.SaveImage(saveFileDialog1.FileName);
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                drawer.OpenImage(openFileDialog1.FileName);
            }
        }

        private void newToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            drawer.g.Clear(System.Drawing.Color.White);
            pictureBox1.Refresh();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            drawer.tool = Tool.Triangle;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            drawer.width = trackBar1.Value;
            drawer.pen.Width = trackBar1.Value;
           // trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
           
            //pictureBox1.Refresh();
        }
      
        private void Plus_Minus_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            switch (btn.Text)
            {
                case "+":
                    if (drawer.width < 50)
                    {

                        drawer.width += 20;
                    }
                    break;
                case "-":
                    if (drawer.width > 20)
                    {

                        drawer.width -= 20;
                    }
                    break;
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            drawer.tool = Tool.Fill;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            drawer.tool = Tool.Trapeze;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
        }

    }
}
