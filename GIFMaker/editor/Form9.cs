using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace editor
{
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }

        Color c;
        Image bm1, bm2;
        Bitmap bim, bim2;
        Image ImgGl, ImGl2;
        Image imeg, sticki;
        Image imi1, imi2, imi3, imi4, imi5;
        static Image ImUndo;
        Image[] init = new Image[30];
        Stack<Image> undo = new Stack<Image>();
        private void Form9_Load(object sender, EventArgs e)
        {
            foreach (FontFamily font in System.Drawing.FontFamily.Families)
            {
                comboBox1.Items.Add(font.Name);
            }
            Form2 fid = new Form2();
            pictureBox2.Image = fid.Sandi;
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            if (op.ShowDialog() == DialogResult.OK)
            {
                ImgGl = Image.FromFile(op.FileName);
                ImGl2 = Image.FromFile(op.FileName);
                fai.Sandi = Image.FromFile(op.FileName);
                pictureBox2.Image = Image.FromFile(op.FileName);
                for (int f1 = 0; f1 < 30; f1++)
                {
                    init[f1] = Image.FromFile(op.FileName);
                }
            }
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            cd.ShowDialog();
            c = cd.Color;
        }
        Form2 fai = new Form2();
        private void pictureBox10_Click(object sender, EventArgs e)
        {
            Image pozutza;
            undo.Push(pictureBox2.Image);
            imi2 = pictureBox2.Image;
            ImUndo = imi2;
            /*Graphics graf = pictureBox2.CreateGraphics();
            graf.DrawString(textBox1.Text, new Font(comboBox1.Text, Convert.ToInt32(textBox2.Text)), new SolidBrush(c), Convert.ToInt32(textBox3.Text), Convert.ToInt32(textBox4.Text));*/
            pozutza = pictureBox2.Image;
            Bitmap originalBtm = (Bitmap)pozutza;
            Bitmap tempBtm = new Bitmap(pozutza.Width, pozutza.Height);
            Graphics graf = Graphics.FromImage(tempBtm);
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && comboBox1.Text != "Selectati Fontul")
            {
                graf.DrawImage(originalBtm, 0, 0);
                graf.DrawString(textBox1.Text, new Font(comboBox1.Text, Convert.ToInt32(textBox2.Text)), new SolidBrush(c),Convert.ToInt32(textBox3.Text),Convert.ToInt32(textBox4.Text));
                pictureBox2.Image = tempBtm;
                fai.Sandi = (Image)tempBtm;
            }
            else
                MessageBox.Show("Aveti grija sa setati toate valorile textului!");
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            OpenFileDialog ope = new OpenFileDialog();
            if (ope.ShowDialog() == DialogResult.OK)
            {
                sticki = Image.FromFile(ope.FileName);
            }
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            undo.Push(pictureBox2.Image);
            ImgGl = pictureBox2.Image;
            Bitmap obm = (Bitmap)ImgGl;
            Bitmap tmbm = new Bitmap(obm.Width, obm.Height);
            if (textBox11.Text != "" && textBox12.Text != "" && textBox5.Text != "" && textBox6.Text != "")
            {
                using (Graphics grd = Graphics.FromImage(tmbm))
                {
                    grd.DrawImage(obm, 0, 0);
                    grd.DrawImage(sticki, new Rectangle(Convert.ToInt32(textBox11.Text), Convert.ToInt32(textBox12.Text),Convert.ToInt32(textBox6.Text), Convert.ToInt32(textBox5.Text)));
                }
                pictureBox2.Image = tmbm;
                fai.Sandi = tmbm;
            }
            else
                MessageBox.Show("Campurile ce seteaza dimensiunile textului si pozitia sunt obligatorii!");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            if (undo.Count > 0)
            {
                pictureBox2.Image = undo.Pop();
                fai.Sandi = pictureBox2.Image;
            }
            else
            {
                MessageBox.Show("Ati ajuns la imaginea initiala!");
            }
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = init[c2];
            c2++;
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            imeg = pictureBox2.Image;
            SaveFileDialog sdf = new SaveFileDialog();
            sdf.Filter = "JPEG|*.JPG|PNG|*.PNG|GIF|*.GIF|BMP|*.BMP|All files (*.*)|*.*";
            if (DialogResult.OK == sdf.ShowDialog())
            {
                imeg.Save(sdf.FileName, ImageFormat.Bmp);
            }
            MessageBox.Show("Imaginea a fost salvata cu succes!");
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f = new Form1();
            f.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 f = new Form3();
            f.Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 f = new Form2();
            f.Show();
        }
        int c2 = 0;

        private void Form9_MouseDown(object sender, MouseEventArgs e)
        {
            
        }
        int x, y;
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            textBox3.Text = me.Location.X.ToString();
            textBox4.Text = me.Location.Y.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (panel1.AutoScroll == true)
            {
                panel1.AutoScroll = false;
                pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            }
            else
                if (panel1.AutoScroll == false)
                {
                    panel1.AutoScroll = true;
                    pictureBox2.SizeMode = PictureBoxSizeMode.AutoSize;
                }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
