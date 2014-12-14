using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Anbar
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
          
        private void کالاهاToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Anbar.Froms.Objects Emp = new Froms.Objects();
            Emp.MdiParent = this;
            Emp.Show();
        }

        private void کارمندانToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Anbar.Froms.Employees Emp = new Froms.Employees();
            Emp.MdiParent = this;
            Emp.Show();
        }

        private void ثبتواردهToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Anbar.Froms.Incoming Emp = new Froms.Incoming();
            Emp.MdiParent = this;
            Emp.Show();
        }

        private void تحویلToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Anbar.Froms.Resid Emp = new Froms.Resid();
            Emp.MdiParent = this;
            Emp.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < InputLanguage.InstalledInputLanguages.Count; i++)
            {
                if (InputLanguage.InstalledInputLanguages[i].LayoutName.ToLower() == "farsi"
                    || InputLanguage.InstalledInputLanguages[i].LayoutName.ToLower() == "persian")
                {
                    InputLanguage.CurrentInputLanguage = InputLanguage.InstalledInputLanguages[i];
                }
            }    
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult Rs = MessageBox.Show("آیا از برنامه خارج می شوید", "خروج از برنامه",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Rs == System.Windows.Forms.DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Anbar.Froms.Report Emp = new Froms.Report();
            Emp.MdiParent = this;
            Emp.Show();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            Anbar.Froms.Resid Emp = new Froms.Resid();
            Emp.MdiParent = this;
            Emp.Show();
        }
    }
}
