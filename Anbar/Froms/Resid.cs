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
    /// <summary>
    /// Check level 2 for select tree view node**************************************************
    /// </summary>
    public partial class Resid : Form
    {

        MyDB.AmvalDataTable _Dt;
        int _index = 0;
        public Resid()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            groupBox3.Location = new Point(137, 142);
            groupBox3.Visible = true;
            groupBox3.Text = "ثبت رسید جدید";
            textBox7.Text = "";
        }

        private void button15_Click(object sender, EventArgs e)
        {
            groupBox3.Visible = false;
            dataGridView1.Enabled = true;
        }

        private void Resid_Load(object sender, EventArgs e)
        {
            #region ResidKind
            NewListItem ResidKnd = new NewListItem();
            ResidKnd.Text = "رسید";
            ResidKnd.Value = 1;
            CmbResidKind.Items.Add(ResidKnd);
            CmbResidKind.SelectedIndex = 0;

            NewListItem ResidKnd2 = new NewListItem();
            ResidKnd2.Text = "صورت جلسه";
            ResidKnd2.Value = 2;
            CmbResidKind.Items.Add(ResidKnd2);

            NewListItem ResidKnd3 = new NewListItem();
            ResidKnd3.Text = "موجودی انبار";
            ResidKnd3.Value = 3;
            CmbResidKind.Items.Add(ResidKnd3);

            #endregion

            #region Channel
            BusinessLayer.DataLayer.CHANNELSSql ChSql = new BusinessLayer.DataLayer.CHANNELSSql();
            List<BusinessLayer.CHANNELS> ChLst = ChSql.SelectAll();
            //CmbChannel.Items.Clear();
            //foreach (Anbar.BusinessLayer.CHANNELS item in ChLst)
            //{
            //    NewListItem Lst = new NewListItem();
            //    Lst.Text = item.TITLE;
            //    Lst.Value = item.ID;
            //    CmbChannel.Items.Add(Lst);
            //}
            //if (CmbChannel.Items.Count > 0)
            //{
            //    CmbChannel.SelectedIndex = 0;

            //}
            //CmbChannel.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //CmbChannel.AutoCompleteSource = AutoCompleteSource.ListItems; 
            #endregion





            //Load DEps
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












            #region DateTime
            comboBox1.Items.Clear();
            comboBox6.Items.Clear();
            int Today = int.Parse(DateConversion.GD2JD(DateTime.Now).Split('/')[2].ToString());
            for (int i = 1; i <= 31; i++)
            {
                NewListItem LstDay = new NewListItem();
                LstDay.Text = i.ToString();
                LstDay.Value = string.Format("{0:00}", i);
                comboBox1.Items.Add(LstDay);
                comboBox6.Items.Add(LstDay);
                if (i == Today)
                {
                    comboBox1.SelectedIndex = i - 1;
                    comboBox6.SelectedIndex = i - 1;
                }
            }


            comboBox3.Items.Clear();
            comboBox5.Items.Clear();
            int Month = int.Parse(DateConversion.GD2JD(DateTime.Now).Split('/')[1].ToString());
            for (int j = 1; j <= 12; j++)
            {
                NewListItem LstMonth = new NewListItem();
                LstMonth.Text = j.ToString();
                LstMonth.Value = string.Format("{0:00}", j);
                comboBox3.Items.Add(LstMonth);
                comboBox5.Items.Add(LstMonth);
                if (j == Month)
                {
                    comboBox3.SelectedIndex = j - 1;
                    comboBox5.SelectedIndex = j - 1;
                }
            }



            comboBox4.Items.Clear();
            comboBox2.Items.Clear();
            int Year = int.Parse(DateConversion.GD2JD(DateTime.Now).Split('/')[0].ToString());
            int IndxYear = 0;
            for (int p = 1380; p <= Year; p++)
            {
                NewListItem LstYear = new NewListItem();
                LstYear.Text = p.ToString();
                LstYear.Value = p;
                comboBox4.Items.Add(LstYear);
                comboBox2.Items.Add(LstYear);
                if (p == Year)
                {
                    comboBox4.SelectedIndex = IndxYear;
                    comboBox2.SelectedIndex = IndxYear;
                }
                IndxYear++;
            }
            #endregion
        }

        private void button16_Click(object sender, EventArgs e)
        {
            bool IsInsert = false;
            bool AlowTask = true;
            if (dataGridView1.Enabled)
            {
                IsInsert = true;
            }

            if (textBox7.Text.Trim() != "0")
            {
                ITTableAdapter It_Ta = new ITTableAdapter();
                MyDB.ITDataTable It_Dt = It_Ta.Get_Personel_ByCode(int.Parse(textBox7.Text.Trim()));
                if (It_Dt.Rows.Count != 1)
                {
                    //Check for Exist:
                    MyDB.ITDataTable It_Dt2 = It_Ta.Emp_ByEmpCode_NoJoin(int.Parse(textBox7.Text.Trim()));
                    if (It_Dt2.Rows.Count == 0)
                    {
                        MessageBox.Show("کارمندی با این شماره وجود ندارد");
                        AlowTask = false;
                    }
                }
            }

            if (!(treeView1.SelectedNode.Index >= 0))
            {
                MessageBox.Show("لطفا یک واحد را انتخاب نمایید");
                AlowTask = false;
            }

            if (AlowTask)
            {
                BusinessLayer.DataLayer.RESIDSql RsdSql = new BusinessLayer.DataLayer.RESIDSql();
                BusinessLayer.RESID Rsd = new BusinessLayer.RESID();
                Rsd.BOSSID = 0;
                Rsd.DATETIME = DateConversion.JD2GD(((NewListItem)comboBox4.SelectedItem).Value.ToString() +
                    "/" + ((NewListItem)comboBox3.SelectedItem).Value.ToString() +
                    "/" + ((NewListItem)comboBox1.SelectedItem).Value.ToString());
                Rsd.EMPLOYEEID = int.Parse(textBox7.Text.Trim());
                Rsd.KIND = byte.Parse(((NewListItem)CmbResidKind.SelectedItem).Value.ToString());
                Rsd.REQDATE = "";
                Rsd.REQNUMBER = "";
                Rsd.RESIDCODE = "0";
                Rsd.ROOMNUMBER = TxtRoom.Text.Trim();
                Rsd.DEP = int.Parse(treeView1.SelectedNode.Tag.ToString());
                if (IsInsert)
                {
                    RsdSql.Insert(Rsd);
                    dataGridView1.Enabled = true;
                    LoadResids();
                    groupBox3.Visible = false;
                }
                else
                {
                    Rsd.ID = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                    RsdSql.Update(Rsd);
                    dataGridView1.Enabled = true;
                    LoadResids();
                    groupBox3.Visible = false;
                }
            }




        }
        protected void LoadResids()
        {
            dataGridView1.Rows.Clear();
            MyDBTableAdapters.AmvalTableAdapter Ta = new MyDBTableAdapters.AmvalTableAdapter();
            ITTableAdapter It_Ta = new ITTableAdapter();
            _Dt = Ta.Resid_Select_All();
            _index = 0;




            label11.Text = _Dt.Count.ToString();
            int PagesCount = (_Dt.Count / 20);
            numericUpDown1.Maximum = PagesCount;
            numericUpDown1.Value = 1;
            numericUpDown1.Minimum = 1;
           // numericUpDown1_ValueChanged(new object(), new EventArgs());






        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadResids();
        }

        private void CmbChannel_SelectedIndexChanged(object sender, EventArgs e)
        {
            //BusinessLayer.DataLayer.DEPSSql DepSql = new BusinessLayer.DataLayer.DEPSSql();
            //NewListItem Lst = new NewListItem();
            //Lst = (NewListItem)CmbChannel.SelectedItem;
            //List<BusinessLayer.DEPS> DepLst = DepSql.SelectByField("CHANNELID", Lst.Value.ToString());
            //CmbDep.Items.Clear();
            //foreach (Anbar.BusinessLayer.DEPS item in DepLst)
            //{
            //    NewListItem Lst3 = new NewListItem();
            //    Lst3.Text = item.TITLE;
            //    Lst3.Value = item.ID;
            //    CmbDep.Items.Add(Lst3);
            //}
            //if (CmbDep.Items.Count > 0)
            //{
            //    CmbDep.SelectedIndex = 0;

            //}
            //CmbDep.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //CmbDep.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                MyDBTableAdapters.AmvalTableAdapter Ta = new MyDBTableAdapters.AmvalTableAdapter();
                MyDB.AmvalDataTable Dt = Ta.Resid_Select_By_Id(int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString()));
                if (Dt.Rows.Count > 0)
                {
                    dataGridView1.Enabled = false;
                    groupBox3.Location = new Point(137, 142);
                    groupBox3.Visible = true;
                    groupBox3.Text = "ویرایش";
                    textBox7.Text = Dt[0]["EMPLOYEEID"].ToString().Trim();
                    TxtRoom.Text = Dt[0]["ROOMNUMBER"].ToString().Trim();

                    for (int i = 0; i < CmbResidKind.Items.Count; i++)
                    {
                        if (((NewListItem)(CmbResidKind.Items[i])).Value.ToString() == Dt[0]["KIND"].ToString().Trim())
                        {
                            CmbResidKind.SelectedIndex = i;
                        }
                    }



                    int Today = int.Parse(DateConversion.GD2JD(DateTime.Now).Split('/')[2].ToString());
                    int ThisToday = int.Parse(DateConversion.GD2JD(DateTime.Parse(Dt[0]["DATEtime"].ToString().Trim())).Split('/')[2].ToString());
                    for (int i = 1; i <= 31; i++)
                    {
                        NewListItem LstDay = new NewListItem();
                        LstDay.Text = i.ToString();
                        LstDay.Value = string.Format("{0:00}", i);
                        comboBox1.Items.Add(LstDay);
                        if (i == ThisToday)
                        {
                            comboBox1.SelectedIndex = i - 1;
                        }
                    }


                    comboBox3.Items.Clear();
                    int Month = int.Parse(DateConversion.GD2JD(DateTime.Now).Split('/')[1].ToString());
                    int ThisMonth = int.Parse(DateConversion.GD2JD(DateTime.Parse(Dt[0]["DATEtime"].ToString().Trim())).Split('/')[1].ToString());
                    for (int j = 1; j <= 12; j++)
                    {
                        NewListItem LstMonth = new NewListItem();
                        LstMonth.Text = j.ToString();
                        LstMonth.Value = string.Format("{0:00}", j);
                        comboBox3.Items.Add(LstMonth);
                        if (j == ThisMonth)
                        {
                            comboBox3.SelectedIndex = j - 1;
                        }
                    }



                    comboBox4.Items.Clear();
                    int Year = int.Parse(DateConversion.GD2JD(DateTime.Now).Split('/')[0].ToString());
                    int ThisYear = int.Parse(DateConversion.GD2JD(DateTime.Parse(Dt[0]["DATEtime"].ToString().Trim())).Split('/')[0].ToString());
                    int IndxYear = 0;
                    for (int p = 1380; p <= Year; p++)
                    {
                        NewListItem LstYear = new NewListItem();
                        LstYear.Text = p.ToString();
                        LstYear.Value = p;
                        comboBox4.Items.Add(LstYear);
                        if (p == ThisYear)
                        {
                            comboBox4.SelectedIndex = IndxYear;
                        }
                        IndxYear++;
                    }


                    for (int i = 0; i < treeView1.Nodes.Count; i++)
                    {
                        PrintRecursive(treeView1.Nodes[i], Dt[0]["DEP"].ToString().Trim());
                    }


                    //for (int i = 0; i < treeView1.Nodes.Count; i++)
                    //{

                    //    if (treeView1.Nodes[i].Tag.ToString() == Dt[0]["DEP"].ToString().Trim())
                    //    {
                    //        treeView1.SelectedNode = treeView1.Nodes[i];
                    //        treeView1.Focus();
                    //    }
                    //    else
                    //    {
                    //        for (int j = 0; j < treeView1.Nodes[i].Nodes.Count; j++)
                    //        {
                    //            if (treeView1.Nodes[i].Nodes[j].Tag.ToString() == Dt[0]["DEP"].ToString().Trim())
                    //            {
                    //                treeView1.SelectedNode = treeView1.Nodes[i].Nodes[j];
                    //                treeView1.Focus();
                    //            }
                    //            else
                    //            {
                    //                for (int p = 0; p < treeView1.Nodes[j].Nodes.Count; p++)
                    //                {
                    //                    if (treeView1.Nodes[i].Nodes[j].Nodes[p].Tag.ToString() == Dt[0]["DEP"].ToString().Trim())
                    //                    {
                    //                        treeView1.SelectedNode = treeView1.Nodes[i].Nodes[j].Nodes[p];
                    //                        treeView1.Focus();
                    //                    }
                    //                }
                    //            }
                    //        }
                    //    }
                    //}

                }
            }
        }


        private void PrintRecursive(TreeNode treeNode,string InValue)
        {
            foreach (TreeNode tn in treeNode.Nodes)
            {
                if (tn.Tag.ToString() == InValue)
                {
                    treeView1.SelectedNode = tn;
                    treeView1.Focus();

                }
                PrintRecursive(tn, InValue);
            }
        }

      
        private void button7_Click(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Rows[0].Selected = true;
                dataGridView1.FirstDisplayedScrollingRowIndex = 0;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Selected = true;
                dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.RowCount - 1;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                DialogResult EmpResult = MessageBox.Show("آیا رسید  شماره : " + dataGridView1.SelectedRows[0].Cells[1].Value.ToString() + " حذف گردد؟", "تایید حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (EmpResult == System.Windows.Forms.DialogResult.Yes)
                {
                    BusinessLayer.DataLayer.RESIDSql RsdSql = new BusinessLayer.DataLayer.RESIDSql();
                    RsdSql.Delete(new BusinessLayer.RESIDKeys(int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString().Trim())));
                    LoadResids();
                }
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            groupBox4.Visible = true;
            groupBox4.Location = new Point(137, 142);
            groupBox3.Text = "ثبت کالای جدید";
        }

        private void button17_Click(object sender, EventArgs e)
        {
            groupBox4.Visible = false;
            dataGridView2.Enabled = true;
            dataGridView1.Enabled = true;
        }

        private void button18_Click(object sender, EventArgs e)
        {
            MyDBTableAdapters.AmvalTableAdapter Ta = new MyDBTableAdapters.AmvalTableAdapter();
            MyDB.AmvalDataTable Dt = Ta.Incoming_SelectBy_AmvaCode(textBox2.Text.Trim());
            bool InsertActive = false;
            //Check Object is registered?
            if (Dt.Rows.Count == 1)
            {
                string IncomeDesc = "";
                IncomeDesc = "نوع کالا" + ":" + Dt[0]["title"].ToString() + "\n" +
                     "مارک" + ":" + Dt[0]["brand"].ToString() + "\n" +
                      "مدل" + ":" + Dt[0]["model"].ToString() + "\n" +
                       "سریال" + ":" + Dt[0]["Serial"].ToString() + "\n";
                ;
                //Check Is object thats you want?
                DialogResult IsIncome = MessageBox.Show(IncomeDesc, "کالای زیر مورد نظر میباشد؟", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (IsIncome == System.Windows.Forms.DialogResult.Yes)
                {
                    MyDB.AmvalDataTable DtFr = Ta.Find_ObjectIsfree(int.Parse(Dt[0]["ID"].ToString().Trim()));
                    if (DtFr.Rows.Count > 0)
                    {
                        string FreeDesc = "";
                        FreeDesc = "شماره رسید" + ":" + DtFr[0]["ID"].ToString() + "\n" +
                             "فامیلی" + ":" + DtFr[0]["FAMILY"].ToString() + "\n" +
                              "نام" + ":" + DtFr[0]["NAME"].ToString() + "\n" +
                               "شماره کارمندی" + ":" + DtFr[0]["EMPLOYEEID"].ToString() + "\n";
                        ;
                        //Object is in another resid free???????
                        if (DtFr[0]["RESIDID"].ToString() != dataGridView1.SelectedRows[0].Cells[0].Value.ToString().Trim())
                        {
                            if (checkBox1.Checked)
                            {
                                DialogResult FreeIncome = MessageBox.Show(FreeDesc, "کالا در حساب زیر است آیا خارج گردد؟", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (FreeIncome == System.Windows.Forms.DialogResult.Yes)
                                {
                                    //Remove object from Resid
                                    Ta.Resid_Details_UpdateActive(false, int.Parse(DtFr[0]["RESIDDETAILSID"].ToString()));
                                    MessageBox.Show("با موفقیت از حساب خارج شد", "خروج کالا از حساب کاربر", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    InsertActive = true;
                                }
                                else
                                {
                                    InsertActive = false;
                                }
                            }
                        }
                    }
                    else
                    {
                        InsertActive = true;
                    }
                    if (dataGridView2.Enabled)
                    {
                        //insert
                        DateTime RsdDetDateTime = DateConversion.JD2GD(((NewListItem)comboBox2.SelectedItem).Value.ToString() +
                       "/" + ((NewListItem)comboBox5.SelectedItem).Value.ToString() +
                       "/" + ((NewListItem)comboBox6.SelectedItem).Value.ToString());
                        Ta.Resid_Details_Insert(richTextBox1.Text.Trim(), int.Parse(Dt[0]["ID"].ToString().Trim()), int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString()), RsdDetDateTime, InsertActive);
                        MessageBox.Show("کالا با موفقیت در رسید اضافه شد", "ثبت کالا در حساب", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {

                        //update
                        DateTime RsdDetDateTime = DateConversion.JD2GD(((NewListItem)comboBox2.SelectedItem).Value.ToString() +
                 "/" + ((NewListItem)comboBox5.SelectedItem).Value.ToString() +
                 "/" + ((NewListItem)comboBox6.SelectedItem).Value.ToString());
                        Ta.Resid_Details_Update(RsdDetDateTime, richTextBox1.Text.Trim(), checkBox1.Checked, int.Parse(Dt[0]["ID"].ToString().Trim()), int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString()), int.Parse(dataGridView2.SelectedRows[0].Cells[0].Value.ToString()));
                        MessageBox.Show("کالا با موفقیت ویرایش شد", "ویرایش کالا در حساب", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    LoadResidDetails();
                    button17_Click(new object(), new EventArgs());

                }

            }
            else
            {
                MessageBox.Show("کالایی با این شماره اموال تاکنون در سیستم ثبت نشده است", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }


        protected void LoadResidDetails()
        {
            dataGridView2.Rows.Clear();
            MyDBTableAdapters.AmvalTableAdapter Ta = new MyDBTableAdapters.AmvalTableAdapter();
            //textBox12.Tex

            MyDB.AmvalDataTable Dt = Ta.Resid_Details_SelectByResidId(int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString()));
            for (int i = 0; i < Dt.Rows.Count; i++)
            {
                dataGridView2.Rows.Add(
                    Dt[i]["Id"].ToString(),
                     Dt[i]["TITLE"].ToString(),
                      Dt[i]["AMVALCODE"].ToString(),
                        DateConversion.GD2JD(DateTime.Parse(Dt[i]["DATETIME"].ToString())),
                        Dt[i]["ACTIVE"].ToString(),
                         Dt[i]["text"].ToString()
                    );
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            { LoadResidDetails(); }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            dataGridView2.ClearSelection();
            if (dataGridView2.Rows.Count > 0)
            {
                dataGridView2.Rows[0].Selected = true;
                dataGridView2.FirstDisplayedScrollingRowIndex = 0;
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            dataGridView2.ClearSelection();
            if (dataGridView2.Rows.Count > 0)
            {
                dataGridView2.Rows[dataGridView2.Rows.Count - 1].Selected = true;
                dataGridView2.FirstDisplayedScrollingRowIndex = dataGridView2.RowCount - 1;
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count == 1)
            {
                DialogResult EmpResult = MessageBox.Show("آیا شماره اموال  : " + dataGridView2.SelectedRows[0].Cells[2].Value.ToString() + " حذف گردد؟", "تایید حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (EmpResult == System.Windows.Forms.DialogResult.Yes)
                {
                    MyDBTableAdapters.AmvalTableAdapter Ta = new MyDBTableAdapters.AmvalTableAdapter();
                    Ta.Resid_Details_DeleteById(int.Parse(dataGridView2.SelectedRows[0].Cells[0].Value.ToString()));
                    LoadResidDetails();
                }
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count == 1)
            {
                dataGridView2.Enabled = false;
                MyDBTableAdapters.AmvalTableAdapter Ta = new MyDBTableAdapters.AmvalTableAdapter();
                MyDB.AmvalDataTable Dt = Ta.Resid_Details_SelectById(int.Parse(dataGridView2.SelectedRows[0].Cells[0].Value.ToString()));
                if (Dt.Rows.Count > 0)
                {
                    dataGridView2.Enabled = false;
                    dataGridView1.Enabled = false;
                    groupBox4.Location = new Point(137, 142);
                    groupBox4.Visible = true;
                    groupBox4.Text = "ویرایش";

                    textBox2.Text = Dt[0]["AMVALCODE"].ToString().Trim();
                    richTextBox1.Text = Dt[0]["TEXT"].ToString().Trim();
                    checkBox1.Checked = bool.Parse(Dt[0]["ACTIVE"].ToString().Trim());



                    comboBox6.Items.Clear();
                    int Today = int.Parse(DateConversion.GD2JD(DateTime.Now).Split('/')[2].ToString());
                    int ThisToday = int.Parse(DateConversion.GD2JD(DateTime.Parse(Dt[0]["DATEtime"].ToString().Trim())).Split('/')[2].ToString());
                    for (int i = 1; i <= 31; i++)
                    {
                        NewListItem LstDay = new NewListItem();
                        LstDay.Text = i.ToString();
                        LstDay.Value = string.Format("{0:00}", i);
                        comboBox6.Items.Add(LstDay);
                        if (i == ThisToday)
                        {
                            comboBox6.SelectedIndex = i - 1;
                        }
                    }


                    comboBox5.Items.Clear();
                    int Month = int.Parse(DateConversion.GD2JD(DateTime.Now).Split('/')[1].ToString());
                    int ThisMonth = int.Parse(DateConversion.GD2JD(DateTime.Parse(Dt[0]["DATEtime"].ToString().Trim())).Split('/')[1].ToString());
                    for (int j = 1; j <= 12; j++)
                    {
                        NewListItem LstMonth = new NewListItem();
                        LstMonth.Text = j.ToString();
                        LstMonth.Value = string.Format("{0:00}", j);
                        comboBox5.Items.Add(LstMonth);
                        if (j == ThisMonth)
                        {
                            comboBox5.SelectedIndex = j - 1;
                        }
                    }



                    comboBox2.Items.Clear();
                    int Year = int.Parse(DateConversion.GD2JD(DateTime.Now).Split('/')[0].ToString());
                    int ThisYear = int.Parse(DateConversion.GD2JD(DateTime.Parse(Dt[0]["DATEtime"].ToString().Trim())).Split('/')[0].ToString());
                    int IndxYear = 0;
                    for (int p = 1380; p <= Year; p++)
                    {
                        NewListItem LstYear = new NewListItem();
                        LstYear.Text = p.ToString();
                        LstYear.Value = p;
                        comboBox2.Items.Add(LstYear);
                        if (p == ThisYear)
                        {
                            comboBox2.SelectedIndex = IndxYear;
                        }
                        IndxYear++;
                    }
                }
            }
        }

        private void Resid_Shown(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ITTableAdapter It_Ta = new ITTableAdapter();
            MyDB.ITDataTable It_Dt = It_Ta.Get_Personel_ByCode(int.Parse(textBox7.Text.Trim()));
            if (It_Dt.Rows.Count == 1)
            {
                label8.Text = It_Dt[0]["Surname"].ToString() + "-" + It_Dt[0]["firstname"].ToString();
                label9.Text = It_Dt[0]["BLNAME"].ToString();

                for (int i = 0; i < treeView1.Nodes.Count; i++)
                {
                    if (treeView1.Nodes[i].Tag.ToString() == It_Dt[0]["supervision"].ToString())
                    {
                        treeView1.SelectedNode = treeView1.Nodes[i];
                        treeView1.Focus();
                    }
                }
            }
            else
            {
                MyDB.ITDataTable It_Dt2 = It_Ta.Emp_ByEmpCode_NoJoin(int.Parse(textBox7.Text.Trim()));
                if (It_Dt2.Rows.Count > 0)
                {
                    label8.Text = It_Dt2[0]["Surname"].ToString() + "-" + It_Dt2[0]["firstname"].ToString();
                    MessageBox.Show("واحدی برای این کارمند وجود ندارد");
                }

            }

        }

        private void button9_Click(object sender, EventArgs e)
        {
            groupBox5.Location = new Point(137, 142);
            groupBox5.Visible = true;
        }

        private void button19_Click(object sender, EventArgs e)
        {
            groupBox5.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim().Length > 0)
            {
                dataGridView1.Rows.Clear();
                MyDBTableAdapters.AmvalTableAdapter Ta = new MyDBTableAdapters.AmvalTableAdapter();
                ITTableAdapter It_Ta = new ITTableAdapter();
                MyDB.AmvalDataTable Dt = Ta.Resid_Select_By_Id(int.Parse(textBox1.Text.Trim()));
                if (Dt.Rows.Count == 1)
                {
                    string EmpName = "---";
                    string Dept = "---";
                    for (int i = 0; i < Dt.Rows.Count; i++)
                    {
                        MyDB.ITDataTable It_Dt = It_Ta.Get_Personel_ByCode(int.Parse(Dt[i]["Employeeid"].ToString()));
                        if (It_Dt.Rows.Count == 1)
                        {
                            EmpName = It_Dt[0]["Surname"].ToString() + "-" + It_Dt[0]["firstname"].ToString();

                            //Check anbar?
                        }
                        else
                        {
                            EmpName = "---";
                        }



                        MyDB.ITDataTable Dep_Dt = It_Ta.Dep_Select_ById(decimal.Parse(Dt[i]["DEP"].ToString()));
                        if (Dep_Dt.Rows.Count == 1)
                        {
                            Dept = Dep_Dt[0]["name"].ToString();
                        }
                        else
                        {
                            Dept = "---";
                        }

                        string Kind = "----";
                        switch (Dt[i]["KIND"].ToString())
                        {
                            case "1":
                                Kind = "رسید";
                                break;

                            case "2":
                                Kind = "صورت جلسه";
                                break;

                            case "3":
                                Kind = "موجودی انبار";
                                break;
                            default:
                                Kind = "----";
                                break;
                        }



                        dataGridView1.Rows.Add(
                            Dt[i]["Id"].ToString(),
                              EmpName,
                               Dt[i]["EMPLOYEEID"].ToString(),
                              Dept,
                                 DateConversion.GD2JD(DateTime.Parse(Dt[i]["DATETIME"].ToString())),
                                  Dt[i]["ROOMNUMBER"].ToString(), Kind
                            );
                    }
                    groupBox5.Visible = false;
                }
                else
                {
                    MessageBox.Show("رسیدی با این شماره یافت نشد");
                }
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            try
            {


                MyDBTableAdapters.AmvalTableAdapter Ta = new MyDBTableAdapters.AmvalTableAdapter();
                ITTableAdapter It_Ta = new ITTableAdapter();
                dataGridView1.Rows.Clear();
                string EmpName = "---";
                string Dept = "---";
                int End = 0;
                if ((int)numericUpDown1.Value == _Dt.Count / 20)
                {
                    End = _Dt.Count;
                    _index = _Dt.Count - 20;
                }
                else
                {
                    _index = (int)(numericUpDown1.Value * 20) - 20;
                    End = (int)numericUpDown1.Value * 20;
                }


                //  _index = (int)(numericUpDown1.Value * 20 )- 20;
                for (int i = _index; i < End; i++)
                {
                    if (_index <= _Dt.Count)
                    {

                        MyDB.ITDataTable It_Dt = It_Ta.Get_Personel_ByCode(int.Parse(_Dt[i]["Employeeid"].ToString()));
                        if (It_Dt.Rows.Count == 1)
                        {
                            EmpName = It_Dt[0]["Surname"].ToString() + "-" + It_Dt[0]["firstname"].ToString();

                            //Check anbar?
                        }
                        else
                        {
                            MyDB.ITDataTable It_Dt2 = It_Ta.Emp_ByEmpCode_NoJoin(int.Parse(_Dt[i]["Employeeid"].ToString()));
                            if (It_Dt2.Rows.Count > 0)
                            {
                                EmpName = It_Dt2[0]["Surname"].ToString() + "-" + It_Dt2[0]["firstname"].ToString();
                            }
                            else
                            {

                                EmpName = "---";
                            }
                        }



                        MyDB.ITDataTable Dep_Dt = It_Ta.Dep_Select_ById(decimal.Parse(_Dt[i]["DEP"].ToString()));
                        if (Dep_Dt.Rows.Count == 1)
                        {
                            Dept = Dep_Dt[0]["name"].ToString();
                        }
                        else
                        {
                            Dept = "---";
                        }

                        string Kind = "----";
                        switch (_Dt[i]["KIND"].ToString())
                        {
                            case "1":
                                Kind = "رسید";
                                break;

                            case "2":
                                Kind = "صورت جلسه";
                                break;

                            case "3":
                                Kind = "موجودی انبار";
                                break;
                            default:
                                Kind = "----";
                                break;
                        }



                        dataGridView1.Rows.Add(
                            _Dt[i]["Id"].ToString(),
                              EmpName,
                               _Dt[i]["EMPLOYEEID"].ToString(),
                              Dept,
                                 DateConversion.GD2JD(DateTime.Parse(_Dt[i]["DATETIME"].ToString())),
                                  _Dt[i]["ROOMNUMBER"].ToString(), Kind
                            );
                    }

                }


            }
            catch
            {
            }
        }

    }
}
