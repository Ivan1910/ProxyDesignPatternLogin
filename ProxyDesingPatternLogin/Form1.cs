using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProxyDesingPatternLogin
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            InitializeComponent();
        }

        private void button_WOC1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text) || string.IsNullOrWhiteSpace(textBox3.Text))
            {
                System.Windows.Forms.MessageBox.Show("Please make sure to fill all parameters !");
            }
            else
            {
                User user = new User(textBox1.Text, textBox2.Text);
                ProxyImage pImg = new ProxyImage(user.HasAccess);
                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox2.Image = pImg.LoadImage(textBox3.Text);
                if (user.HasAccess == true)
                {
                    textBox1.Hide();
                    textBox2.Hide();
                    label1.Hide();
                    label2.Hide();
                    button_WOC1.Hide();
                    label4.Text = "Welcome, " + user.Username + '!';
                    label4.Left = (this.Size.Width / 2) - (label4.Width / 2);
                    label4.Visible = true;
                    button_WOC3.Visible = true;
                }
                else
                {
                    textBox1.Hide();
                    textBox2.Hide();
                    label1.Hide();
                    label2.Hide();
                    button_WOC1.Hide();
                    label4.Text = "User " + user.Username + " is not registered!";
                    label4.Left = (this.Size.Width / 2) - (label4.Width / 2);
                    label4.Visible = true;
                }
            }

        }

        private void button_WOC2_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "Image Files (*.bmp;*.jpg;*.jpeg,*.png)|*.BMP;*.JPG;*.JPEG;*.PNG";
            if (of.ShowDialog() == DialogResult.OK)
            {
                textBox3.Text = of.FileName;
            }
        }

        private void pictureBox2_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, pictureBox2.ClientRectangle, Color.Red, 5,ButtonBorderStyle.Dotted, Color.Red,5, ButtonBorderStyle.Dotted, Color.Red, 5, ButtonBorderStyle.Dotted, Color.Red, 5, ButtonBorderStyle.Dotted);

        }

        private void button_WOC3_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = null;
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox1.Show();
            textBox2.Show();
            label1.Show();
            label2.Show();
            button_WOC1.Show();
            label4.Visible = false;
            button_WOC3.Visible = false;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (button_WOC3.Visible == true)
            {
                if (!string.IsNullOrWhiteSpace(textBox1.Text))
                {
                    pictureBox2.Image = Image.FromFile(textBox3.Text);
                }
            }
        }
    }
}
