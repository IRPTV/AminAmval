using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Anbar.MyDBTableAdapters;

namespace Anbar.Froms
{
    public partial class Report : Form
    {
        public Report()
        {
            InitializeComponent();
        }

        private void Report_Load(object sender, EventArgs e)
        {
            #region FetchDepartments
            ITTableAdapter It_Ta = new ITTableAdapter();
            MyDB.ITDataTable It_Dt = It_Ta.Dept_SelectByPid(37);
            TreeNode TrAnbar = new TreeNode();
            TrAnbar.Text = "-----";
            TrAnbar.Tag = "0";
            treeView1.Nodes.Add(TrAnbar);
            for (int i = 0; i < It_Dt.Rows.Count; i++)
            {
                TreeNode Tr = new TreeNode();
                Tr.Text = It_Dt[i]["Name"].ToString();
                Tr.Tag = It_Dt[i]["ID"].ToString();

                MyDB.ITDataTable It_DtChild = It_Ta.Dept_SelectByPid(decimal.Parse(It_Dt[i]["ID"].ToString()));
                for (int j = 0; j < It_DtChild.Rows.Count; j++)
                {
                    TreeNode TrChild = new TreeNode();
                    TrChild.Text = It_DtChild[j]["Name"].ToString();
                    TrChild.Tag = It_DtChild[j]["ID"].ToString();

                    MyDB.ITDataTable It_DtChild2 = It_Ta.Dept_SelectByPid(decimal.Parse(It_DtChild[j]["ID"].ToString()));
                    for (int p = 0; p < It_DtChild2.Rows.Count; p++)
                    {
                        TreeNode TrChild2 = new TreeNode();
                        TrChild2.Text = It_DtChild2[p]["Name"].ToString();
                        TrChild2.Tag = It_DtChild2[p]["ID"].ToString();
                        TrChild.Nodes.Add(TrChild2);
                    }
                    Tr.Nodes.Add(TrChild);
                }

                treeView1.Nodes.Add(Tr);
            }
            treeView1.ExpandAll();
            #endregion

            comboBox8.SelectedIndex = 0;
            LoadObjects(comboBox8.SelectedIndex);


            #region ResidKind
            NewListItem ResidKnd = new NewListItem();
            ResidKnd.Text = "رسید";
            ResidKnd.Value = 1;
            checkedListBox2.Items.Add(ResidKnd);

            NewListItem ResidKnd2 = new NewListItem();
            ResidKnd2.Text = "صورت جلسه";
            ResidKnd2.Value = 2;
            checkedListBox2.Items.Add(ResidKnd2);

            NewListItem ResidKnd3 = new NewListItem();
            ResidKnd3.Text = "موجودی انبار";
            ResidKnd3.Value = 3;
            checkedListBox2.Items.Add(ResidKnd3);

            #endregion

            #region DateTime
            int Today = int.Parse(DateConversion.GD2JD(DateTime.Now).Split('/')[2].ToString());
            for (int i = 1; i <= 31; i++)
            {
                NewListItem LstDay = new NewListItem();
                LstDay.Text = i.ToString();
                LstDay.Value = string.Format("{0:00}", i);
                comboBox2.Items.Add(LstDay);
                comboBox7.Items.Add(LstDay);
                if (i == Today)
                {
                    comboBox2.SelectedIndex = i - 1;
                    comboBox7.SelectedIndex = i - 1;
                }
            }



            int Month = int.Parse(DateConversion.GD2JD(DateTime.Now).Split('/')[1].ToString());
            for (int j = 1; j <= 12; j++)
            {
                NewListItem LstMonth = new NewListItem();
                LstMonth.Text = j.ToString();
                LstMonth.Value = string.Format("{0:00}", j);
                comboBox3.Items.Add(LstMonth);
                comboBox6.Items.Add(LstMonth);
                if (j == Month)
                {
                    comboBox3.SelectedIndex = j - 1;
                    comboBox6.SelectedIndex = j - 1;
                }
            }



            int Year = int.Parse(DateConversion.GD2JD(DateTime.Now).Split('/')[0].ToString());
            int IndxYear = 0;
            for (int p = 1380; p <= Year; p++)
            {
                NewListItem LstYear = new NewListItem();
                LstYear.Text = p.ToString();
                LstYear.Value = p;
                comboBox4.Items.Add(LstYear);
                comboBox5.Items.Add(LstYear);
                if (p == Year)
                {
                    comboBox4.SelectedIndex = IndxYear - 1;
                    comboBox5.SelectedIndex = IndxYear;
                }
                IndxYear++;
            }
            #endregion

            #region Employees
            ITTableAdapter Emp_Ta = new ITTableAdapter();
            MyDB.ITDataTable Emp_Dt = It_Ta.Select_All_Emp();
            for (int i = 0; i < Emp_Dt.Rows.Count; i++)
            {
                NewListItem Lst = new NewListItem();
                Lst.Text = Emp_Dt[i]["personnel_no"].ToString()+"_"+ Emp_Dt[i]["surname"].ToString() + "-" + Emp_Dt[i]["name"].ToString();
                Lst.Value = Emp_Dt[i]["personnel_no"].ToString();
                checkedListBox3.Items.Add(Lst);

            }

            comboBox1.SelectedIndex = 1;
            #endregion
        }

        protected void LoadObjects(int Index)
        {
            #region FetchKinds
            checkedListBox1.Items.Clear();
            Anbar.BusinessLayer.DataLayer.OBJECTSSql ObjSql = new BusinessLayer.DataLayer.OBJECTSSql();
            string Kind = "";
            switch (Index)
            {
                case 1:
                    Kind = " groupid=0";
                    break;

                case 2:
                    Kind = " groupid=1";
                    break;

                case 0:
                    Kind = " id >0";
                    break;

                default:
                    Kind = " id >0";
                    break;
            }
            List<Anbar.BusinessLayer.OBJECTS> Obj_List = ObjSql.SelectbyKind(Kind);

            NewListItem Lst2 = new NewListItem();
            Lst2.Text = "----";
            Lst2.Value = 0;
            checkedListBox1.Items.Add(Lst2);

            foreach (Anbar.BusinessLayer.OBJECTS item in Obj_List)
            {
                NewListItem Lst = new NewListItem();
                Lst.Text = item.ID + " - " + item.TITLE;
                Lst.Value = item.ID;
                checkedListBox1.Items.Add(Lst);
            }
            #endregion
        }
        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < treeView1.Nodes.Count; i++)
            {
                treeView1.Nodes[i].Checked = true;
                for (int j = 0; j < treeView1.Nodes[i].Nodes.Count; j++)
                {
                    treeView1.Nodes[i].Nodes[j].Checked = true;
                    for (int p = 0; p < treeView1.Nodes[i].Nodes[j].Nodes.Count; p++)
                    {
                        treeView1.Nodes[i].Nodes[j].Nodes[p].Checked = true;
                    }
                   
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < treeView1.Nodes.Count; i++)
            {
                treeView1.Nodes[i].Checked = false;
                for (int j = 0; j < treeView1.Nodes[i].Nodes.Count; j++)
                {
                    treeView1.Nodes[i].Nodes[j].Checked = false;
                    for (int p = 0; p < treeView1.Nodes[i].Nodes[j].Nodes.Count; p++)
                    {
                        treeView1.Nodes[i].Nodes[j].Nodes[p].Checked = false;
                    }
                }
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 1)
            {
                SearchResid();
            }
            if (comboBox1.SelectedIndex == 0)
            {
                SearchIncoming();
            }
        }
        protected void SearchResid()
        {
            string FinalQuery = "";
            StringBuilder Cond = new StringBuilder();
            Cond.Append(" Where ");
            if (checkBox7.Checked)
            {
                if (checkedListBox2.CheckedItems.Count > 0)
                {
                    Cond.Append(" and ( ");
                }
                for (int i = 0; i < checkedListBox2.CheckedItems.Count; i++)
                {

                    NewListItem ChkKind = (NewListItem)checkedListBox2.CheckedItems[i];
                    Cond.Append(" kind=" + ChkKind.Value.ToString() + " or ");

                }
                if (checkedListBox2.CheckedItems.Count > 0)
                {
                    Cond = Cond.Remove(Cond.Length - 3, 3);
                    Cond.Append(" ) ");
                }
            }



            if (checkBox1.Checked)
            {
                Cond.Append(" and ( ");
                Cond.Append(" id=" + textBox1.Text.Trim() + " ");
                Cond.Append(" ) ");
            }


            if (checkBox8.Checked)
            {
                if (checkedListBox3.CheckedItems.Count > 0)
                {
                    Cond.Append(" and ( ");
                }
                for (int i = 0; i < checkedListBox3.CheckedItems.Count; i++)
                {

                    NewListItem ChkKind = (NewListItem)checkedListBox3.CheckedItems[i];
                    Cond.Append(" EMPLOYEEID=" + ChkKind.Value.ToString() + " or ");

                }
                if (checkedListBox3.CheckedItems.Count > 0)
                {
                    Cond = Cond.Remove(Cond.Length - 3, 3);
                    Cond.Append(" ) ");
                }

            }


            if (checkBox6.Checked)
            {

                string[] Rooms = textBox2.Text.Trim().Split('#');
                if (Rooms.Length > 0)
                {
                    Cond.Append(" and ( ");
                }
                for (int i = 0; i < Rooms.Length; i++)
                {
                    Cond.Append(" ROOMNUMBER=N'" + Rooms[i].Trim() + "' or ");

                }
                if (Rooms.Length > 0)
                {
                    Cond = Cond.Remove(Cond.Length - 3, 3);
                    Cond.Append(" ) ");
                }

            }




            if (checkBox4.Checked)
            {
                int NdCounts = 0;
                for (int i = 0; i < treeView1.Nodes.Count; i++)
                {
                    if (treeView1.Nodes[i].Checked)
                    {
                        NdCounts++;
                    }
                    for (int j = 0; j < treeView1.Nodes[i].Nodes.Count; j++)
                    {
                        if (treeView1.Nodes[i].Nodes[j].Checked)
                        {
                            NdCounts++;
                        }
                    }
                }
                if (NdCounts > 0)
                {
                    Cond.Append(" and ( ");
                }

                for (int i = 0; i < treeView1.Nodes.Count; i++)
                {
                    if (treeView1.Nodes[i].Checked)
                    {
                        Cond.Append(" DEP=" + treeView1.Nodes[i].Tag.ToString() + " or ");
                    }
                    for (int j = 0; j < treeView1.Nodes[i].Nodes.Count; j++)
                    {
                        if (treeView1.Nodes[i].Nodes[j].Checked)
                        {
                            Cond.Append(" DEP=" + treeView1.Nodes[i].Nodes[j].Tag.ToString() + " or ");
                        }
                        for (int p = 0; p < treeView1.Nodes[i].Nodes[j].Nodes.Count; p++)
                        {
                            if (treeView1.Nodes[i].Nodes[j].Nodes[p].Checked)
                            {
                                Cond.Append(" DEP=" + treeView1.Nodes[i].Nodes[j].Nodes[p].Tag.ToString() + " or ");
                            }
                        }
                    }

                }


                if (NdCounts > 0)
                {
                    Cond = Cond.Remove(Cond.Length - 3, 3);
                    Cond.Append(" ) ");
                }
            }






            //Check Date Range
            DateTime StartDate = DateConversion.JD2GD(((NewListItem)comboBox4.SelectedItem).Value.ToString() +
                    "/" + ((NewListItem)comboBox3.SelectedItem).Value.ToString() +
                    "/" + ((NewListItem)comboBox2.SelectedItem).Value.ToString());

            DateTime EndDate = DateConversion.JD2GD(((NewListItem)comboBox5.SelectedItem).Value.ToString() +
                    "/" + ((NewListItem)comboBox6.SelectedItem).Value.ToString() +
                    "/" + ((NewListItem)comboBox7.SelectedItem).Value.ToString());


            Cond.Append(" and ( ");

            Cond.Append(" datetime >= CONVERT(datetime, '" + StartDate + "',120)  and datetime <= CONVERT(datetime, '" + EndDate + "',120)");
            //   Cond.Append(" datetime between (" + StartDate +" and " +EndDate  + " ) or ");

            Cond.Append(" ) ");



            if (Cond.ToString().Length == 7)
            {
                FinalQuery = Cond.ToString().Remove(0, Cond.ToString().Length);
            }
            else
            {
                FinalQuery = Cond.ToString(); ;
                FinalQuery = FinalQuery.Remove(7, 5);
            }
            FinalQuery += " Order by ID desc";


            webBrowser1.Navigate("http://" + System.Configuration.ConfigurationSettings.AppSettings["PrintServerIp"].Trim() + "/pages/printResid.aspx?query=" + FinalQuery);
            // MessageBox.Show("http://192.168.100.151:801/pages/printResid.aspx?query="+FinalQuery);
            tabControl1.SelectedIndex = 1;

        }
        protected void SearchIncoming()
        {
            string FinalQuery = "";
            StringBuilder Cond = new StringBuilder();
            Cond.Append(" Where ");

            if (textBox8.Text.Trim().Length > 0)
            {
                Cond.Append(" and ( ");
                Cond.Append(" AMVALCODE  like N'" + textBox8.Text.Trim() + "%' ");
                Cond.Append(" ) ");
            }

            if (textBox3.Text.Trim().Length > 0)
            {
                Cond.Append(" and ( ");
                Cond.Append(" serial  like N'" + textBox3.Text.Trim() + "%' ");
                Cond.Append(" ) ");
            }

            if (textBox4.Text.Trim().Length > 0)
            {
                Cond.Append(" and ( ");
                Cond.Append(" brand  like N'" + textBox4.Text.Trim() + "%' ");
                Cond.Append(" ) ");
            }

            if (textBox5.Text.Trim().Length > 0)
            {
                Cond.Append(" and ( ");
                Cond.Append(" model  like N'" + textBox5.Text.Trim() + "%' ");
                Cond.Append(" ) ");
            }

            if (checkBox3.Checked)
            {
                if (checkedListBox1.CheckedItems.Count > 0)
                {
                    Cond.Append(" and ( ");
                }
                for (int i = 0; i < checkedListBox1.CheckedItems.Count; i++)
                {

                    NewListItem ChkKind = (NewListItem)checkedListBox1.CheckedItems[i];
                    Cond.Append(" objectid=" + ChkKind.Value.ToString() + " or ");

                }
                if (checkedListBox1.CheckedItems.Count > 0)
                {
                    Cond = Cond.Remove(Cond.Length - 3, 3);
                    Cond.Append(" ) ");
                }
            }

            //Check Date Range
            DateTime StartDate = DateConversion.JD2GD(((NewListItem)comboBox4.SelectedItem).Value.ToString() +
                    "/" + ((NewListItem)comboBox3.SelectedItem).Value.ToString() +
                    "/" + ((NewListItem)comboBox2.SelectedItem).Value.ToString());

            DateTime EndDate = DateConversion.JD2GD(((NewListItem)comboBox5.SelectedItem).Value.ToString() +
                    "/" + ((NewListItem)comboBox6.SelectedItem).Value.ToString() +
                    "/" + ((NewListItem)comboBox7.SelectedItem).Value.ToString());


            Cond.Append(" and ( ");

            Cond.Append(" datetime >= CONVERT(datetime, '" + StartDate + "',120)  and datetime <= CONVERT(datetime, '" + EndDate + "',120)");
            //   Cond.Append(" datetime between (" + StartDate +" and " +EndDate  + " ) or ");

            Cond.Append(" ) ");



            if (Cond.ToString().Length == 7)
            {
                FinalQuery = Cond.ToString().Remove(0, Cond.ToString().Length);
            }
            else
            {
                FinalQuery = Cond.ToString(); ;
                FinalQuery = FinalQuery.Remove(7, 5);
            }
            FinalQuery += " Order by ID desc";
            webBrowser1.Navigate("http://" + System.Configuration.ConfigurationSettings.AppSettings["PrintServerIp"].Trim() + "/pages/printincoming.aspx?query=" + FinalQuery);
            tabControl1.SelectedIndex = 1;

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResetAllControlsBackColor(this);
            if (comboBox1.SelectedIndex == 0)
            {
                //Pink
                textBox3.BackColor = Color.LightPink;
                textBox4.BackColor = Color.LightPink;
                textBox5.BackColor = Color.LightPink;
                textBox8.BackColor = Color.LightPink;
            
                comboBox7.BackColor = Color.LightPink;
                comboBox6.BackColor = Color.LightPink;
                comboBox5.BackColor = Color.LightPink;
                comboBox4.BackColor = Color.LightPink;
                comboBox3.BackColor = Color.LightPink;
                comboBox2.BackColor = Color.LightPink;
                checkedListBox1.BackColor = Color.LightPink;

            }

            if (comboBox1.SelectedIndex == 1)
            {    textBox1.BackColor = Color.LightPink;
                textBox2.BackColor = Color.LightPink;
                comboBox7.BackColor = Color.LightPink;
                comboBox6.BackColor = Color.LightPink;
                comboBox5.BackColor = Color.LightPink;
                comboBox4.BackColor = Color.LightPink;
                comboBox3.BackColor = Color.LightPink;
                comboBox2.BackColor = Color.LightPink;
                checkedListBox2.BackColor = Color.LightPink;
                checkedListBox3.BackColor = Color.LightPink;
                treeView1.BackColor = Color.LightPink;

            }
        }

        private void ResetAllControlsBackColor(Control control)
        {
            control.BackColor = SystemColors.Control;
            if (control.HasChildren)
            {
                foreach (Control childControl in control.Controls)
                {
                    ResetAllControlsBackColor(childControl);
                }
            }
        }

        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadObjects(comboBox8.SelectedIndex);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, true);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox2.Items.Count; i++)
            {
                checkedListBox2.SetItemChecked(i, true);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox3.Items.Count; i++)
            {
                checkedListBox3.SetItemChecked(i, true);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox3.Items.Count; i++)
            {
                checkedListBox3.SetItemChecked(i, false);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox2.Items.Count; i++)
            {
                checkedListBox2.SetItemChecked(i, false);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, false);
            }
        }


        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            webBrowser1.ShowPrintPreviewDialog();
        }

        private void toolStripBtnPrint_Click(object sender, EventArgs e)
        {
            webBrowser1.ShowPrintDialog();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            checkedListBox3.ClearSelected();
            for (int i = 0; i < checkedListBox3.Items.Count; i++)
            {

                NewListItem ChkKind = (NewListItem)checkedListBox3.Items[i];
                if(ChkKind.Text.ToLower().Trim().Contains(textBox6.Text.ToLower().Trim()))
                {
                    checkedListBox3.SetItemChecked(i, true);
                    checkedListBox3.SelectedIndex = i;
                    checkedListBox3.Focus();
                }

            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            checkedListBox1.ClearSelected();

            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {

                NewListItem ChkKind = (NewListItem)checkedListBox1.Items[i];
                if (ChkKind.Text.ToLower().Trim().Contains(textBox7.Text.ToLower().Trim()))
                {
                    checkedListBox1.SetItemChecked(i, true);
                    checkedListBox1.SelectedIndex = i;
                    checkedListBox1.Focus();
                }

            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            try
            {
                MyDBTableAdapters.AmvalTableAdapter Ta = new AmvalTableAdapter();
                MyDB.AmvalDataTable Dt = Ta.Incoming_SelectBy_AmvaCode(textBox9.Text.Trim());
                if (Dt.Rows.Count == 1)
                {
                    MyDB.AmvalDataTable Dt2 = Ta.Resid_Details_Search("where  active=1 and  INCOMINGID=" + int.Parse(Dt[0]["id"].ToString()));
                    if (Dt2.Rows.Count == 1)
                    {
                        MessageBox.Show(Dt2[0]["RESIDID"].ToString(), "شماره رسید", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch
            {
               
            }
         
        }
    }
}
