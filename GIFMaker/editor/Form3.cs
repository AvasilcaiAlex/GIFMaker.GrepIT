using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.IO;

namespace editor
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            trackBar1.BackColor = System.Drawing.ColorTranslator.FromHtml("#444953");
        }

        int w, h;
        Graphics g;
        Graphics image;
        Bitmap btm,b;
        Color c;
        bool drawing = false;
        Image mainimg;

        private void Form3_Load(object sender, EventArgs e)
        {
            panel1.AutoScroll = true;
            pictureBox10.SizeMode = PictureBoxSizeMode.AutoSize;
            Form2 fi = new Form2();
            pictureBox10.Image = fi.Sandi;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f = new Form1();
            f.Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
  
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 f = new Form2();
            f.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form9 f = new Form9();
            f.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }
        Image prim, sec;
        private void pictureBox7_Click(object sender, EventArgs e)
        {
            /*g = panel1.CreateGraphics();
            OpenFileDialog op = new OpenFileDialog();
            op.ShowDialog();
            b = new Bitmap(op.FileName);
            btm = new Bitmap(b.Width, b.Height);
            image = Graphics.FromImage(btm);
            image.DrawImage(b, new Rectangle(0, 0, panel1.Width, panel1.Height));
            g.DrawImage(btm, Point.Empty);
            panel1.BackgroundImage = btm;*/

            //g = panel1.CreateGraphics();
            OpenFileDialog op = new OpenFileDialog();
            if (op.ShowDialog() == DialogResult.OK)
            {
                prim = Image.FromFile(op.FileName);
                fis.Sandi = Image.FromFile(op.FileName);
                sec = new Bitmap(prim.Width, prim.Height);
                Graphics g = Graphics.FromImage(sec);
                g.DrawImage(prim, 0, 0);
                pictureBox10.Image = sec;
            }
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            cd.ShowDialog();
            c = cd.Color;
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            //int w = panel1.Width;
            //int h = panel1.Height;
            //w = panel1.BackgroundImage.Width;
            //h = panel1.BackgroundImage.Height;
            /*
           Bitmap bm = new Bitmap(w, h);
           panel1.DrawToBitmap(bm, new Rectangle(0, 0, w, h));*/
            //Bitmap imen = new Bitmap(w, h);
            SaveFileDialog sdf = new SaveFileDialog();
            sdf.Filter = "JPEG|*.JPG|PNG|*.PNG|GIF|*.GIF|BMP|*.BMP|All files (*.*)|*.*";
            /*using (Bitmap bmp = new Bitmap(w, h))
            {
                panel1.DrawToBitmap(bmp, new Rectangle(0, 0, w, h));
                if (DialogResult.OK == sdf.ShowDialog())
                    bmp.Save(sdf.FileName, ImageFormat.Jpeg);
            }*/
            if (sdf.ShowDialog() == DialogResult.OK)
            {
                pictureBox10.Image.Save(sdf.FileName,ImageFormat.Bmp);
            }
            MessageBox.Show("Imaginea a fost salvata cu succes!");
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void panel1_MouseUp_1(object sender, MouseEventArgs e)
        {
            
        }

        private void panel1_MouseDown_1(object sender, MouseEventArgs e)
        {
            
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private Point? _Previous = null;
        private Pen _Pen = new Pen(Color.Black,10);
        private void richTextBox1_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void richTextBox1_MouseUp(object sender, MouseEventArgs e)
        {
            _Previous = null;
        }

        private void pictureBox10_MouseUp(object sender, MouseEventArgs e)
        {
            _Previous = null;
        }
        private void pictureBox10_MouseMove(object sender, MouseEventArgs e)
        {
            _Pen.Color = c;
            _Pen.Width = trackBar1.Value;
            if (_Previous != null)
            {
                if (pictureBox10.Image == null)
                {
                    Bitmap bmp = new Bitmap(pictureBox10.Width, pictureBox10.Height);
                    using (Graphics g = Graphics.FromImage(bmp))
                    {
                        g.Clear(c);
                    }
                    pictureBox10.Image = bmp;
                }
                using (Graphics g = Graphics.FromImage(pictureBox10.Image))
                {
                    g.DrawLine(_Pen, _Previous.Value.X, _Previous.Value.Y, e.X,e.Y);
                }
                pictureBox10.Invalidate();
                _Previous = new Point(e.X, e.Y);
            }
            fis.Sandi = pictureBox10.Image;
        }
        Form2 fis = new Form2();
        private void pictureBox10_MouseDown(object sender, MouseEventArgs e)
        {
            _Previous = new Point(e.X, e.Y);
            pictureBox10_MouseMove(sender, e);
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {

        }
    }
}
