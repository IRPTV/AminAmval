using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Anbar
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.ToLower().Trim() == "yazdani" && textBox2.Text.ToLower().Trim() == "yazdan")
            {
                Form1 Frm1 = new Form1();
                Frm1.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show(" نام کاربری و گذرواژه را چک فرمایید");
                textBox1.Text = "";
                textBox2.Text = "";
            }
        }
    }
}
