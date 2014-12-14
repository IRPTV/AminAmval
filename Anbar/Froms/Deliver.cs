using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Anbar.Froms
{
    public partial class Deliver : Form
    {
        int _ResidId = 0;
        public Deliver()
        {
            InitializeComponent();
        }

        private void Deliver_Load(object sender, EventArgs e)
        {
            textBox2.Text = DateConversion.GD2JD(GetDate.GetDateTime());
            textBox4.Text = DateConversion.GD2JD(GetDate.GetDateTime());

            Employees_Load();
            LoadChannels();
        }
        protected void LoadObjectsKinds()
        {
            //Anbar.BusinessLayer.DataLayer.OBJECTSSql ObjSql = new BusinessLayer.DataLayer.OBJECTSSql();
            //List<Anbar.BusinessLayer.OBJECTS> Obj_List = ObjSql.SelectAll();

            //comboBox7.Items.Clear();
            //NewListItem Lst2 = new NewListItem();
            //Lst2.Text = "------";
            //Lst2.Value = 0;
            //comboBox7.Items.Add(Lst2);


            //foreach (Anbar.BusinessLayer.OBJECTS item in Obj_List)
            //{
            //    NewListItem Lst = new NewListItem();
            //    Lst.Text = item.TITLE;
            //    Lst.Value = item.ID;
            //    comboBox7.Items.Add(Lst);
            //}
            //if (comboBox7.Items.Count > 0)
            //{
            //    comboBox7.SelectedIndex = 0;
            //}

        }
        protected void Employees_Load()
        {
            _ResidId = 0;
            groupBox3.Enabled = false;
            groupBox4.Enabled = false;

            Anbar.BusinessLayer.DataLayer.EmployeesSql Emp_Sql = new BusinessLayer.DataLayer.EmployeesSql();
            List<Anbar.BusinessLayer.Employees> Emp_List = Emp_Sql.SelectAll();

            comboBox1.Items.Clear();
            comboBox4.Items.Clear();

            comboBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox1.AutoCompleteSource = AutoCompleteSource.ListItems;

            comboBox4.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox4.AutoCompleteSource = AutoCompleteSource.ListItems;

            for (int i = 0; i < Emp_List.Count; i++)
            {
                NewListItem Lst = new NewListItem();
                Lst.Text = Emp_List[i].FAMILY + " " + Emp_List[i].NAME;
                Lst.Value = Emp_List[i].ID;

                comboBox1.Items.Add(Lst);
                comboBox4.Items.Add(Lst);

            }


            NewListItem Lst2 = new NewListItem();
            Lst2.Text = "رسید اموال";
            Lst2.Value = 1;
            comboBox5.Items.Add(Lst2);

            NewListItem Lst3 = new NewListItem();
            Lst3.Text = "صورت جلسه";
            Lst3.Value = 2;
            comboBox5.Items.Add(Lst3);
            comboBox5.SelectedIndex = 0;




        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            Anbar.BusinessLayer.DataLayer.EmployeesSql Emp_Sql = new BusinessLayer.DataLayer.EmployeesSql();
            List<Anbar.BusinessLayer.Employees> Emp_List = Emp_Sql.SelectByField("PERSONALCODE", textBox3.Text.Trim());
            if (Emp_List.Count == 1)
            {
                for (int i = 0; i < comboBox1.Items.Count; i++)
                {
                    if (((NewListItem)comboBox1.Items[i]).Value.ToString() == Emp_List[0].ID.ToString())
                    {
                        comboBox1.SelectedIndex = i;
                    }
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Anbar.BusinessLayer.DataLayer.EmployeesSql Emp_Sql = new BusinessLayer.DataLayer.EmployeesSql();
            List<Anbar.BusinessLayer.Employees> Emp_List = Emp_Sql.SelectByField("PERSONALCODE", textBox1.Text.Trim());
            if (Emp_List.Count == 1)
            {
                for (int i = 0; i < comboBox4.Items.Count; i++)
                {
                    if (((NewListItem)comboBox4.Items[i]).Value.ToString() == Emp_List[0].ID.ToString())
                    {
                        comboBox4.SelectedIndex = i;
                    }
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Anbar.BusinessLayer.DataLayer.EmployeesSql Emp_Sql = new BusinessLayer.DataLayer.EmployeesSql();
            Anbar.BusinessLayer.Employees Emp = Emp_Sql.SelectByPrimaryKey(
                new BusinessLayer.EmployeesKeys(int.Parse(((NewListItem)comboBox1.SelectedItem).Value.ToString())));
            textBox3.Text = Emp.PERSONALCODE;
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            Anbar.BusinessLayer.DataLayer.EmployeesSql Emp_Sql = new BusinessLayer.DataLayer.EmployeesSql();
            Anbar.BusinessLayer.Employees Emp = Emp_Sql.SelectByPrimaryKey(
                new BusinessLayer.EmployeesKeys(int.Parse(((NewListItem)comboBox4.SelectedItem).Value.ToString())));
            textBox1.Text = Emp.PERSONALCODE;
        }
        protected void LoadChannels()
        {
            Anbar.BusinessLayer.DataLayer.CHANNELSSql ChSql = new BusinessLayer.DataLayer.CHANNELSSql();
            List<Anbar.BusinessLayer.CHANNELS> ChLst = ChSql.SelectAll();

            comboBox2.Items.Clear();
            for (int i = 0; i < ChLst.Count; i++)
            {
                NewListItem Lst = new NewListItem();
                Lst.Text = ChLst[i].TITLE;
                Lst.Value = ChLst[i].ID;

                comboBox2.Items.Add(Lst);
            }
            comboBox2.SelectedIndex = 0;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Anbar.BusinessLayer.DataLayer.DEPSSql ChSql = new BusinessLayer.DataLayer.DEPSSql();
            List<Anbar.BusinessLayer.DEPS> ChLst =
                ChSql.SelectByField("CHANNELID", ((NewListItem)comboBox2.SelectedItem).Value);


            comboBox3.Items.Clear();
            for (int i = 0; i < ChLst.Count; i++)
            {
                NewListItem Lst = new NewListItem();
                Lst.Text = ChLst[i].TITLE;
                Lst.Value = ChLst[i].ID;

                comboBox3.Items.Add(Lst);
            }
            comboBox3.SelectedIndex = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Anbar.BusinessLayer.DataLayer.RESIDSql ResidSql = new BusinessLayer.DataLayer.RESIDSql();
            Anbar.BusinessLayer.RESID Resid = new BusinessLayer.RESID();
            if (_ResidId == 0)
            {
                Resid.BOSSID = int.Parse(((NewListItem)comboBox4.SelectedItem).Value.ToString());
                Resid.CHANNEL = int.Parse(((NewListItem)comboBox2.SelectedItem).Value.ToString());
                Resid.DATETIME = GetDate.GetDateTime();
                Resid.DEP = int.Parse(((NewListItem)comboBox3.SelectedItem).Value.ToString());
                Resid.EMPLOYEEID = int.Parse(((NewListItem)comboBox1.SelectedItem).Value.ToString());
                Resid.KIND = byte.Parse(((NewListItem)comboBox5.SelectedItem).Value.ToString());
                Resid.REQNUMBER = textBox5.Text.Trim();
                Resid.RESIDCODE = textBox8.Text.Trim();
                Resid.REQDATE = textBox2.Text.Trim();

                _ResidId = ResidSql.Insert(Resid);
                LoadResidDetails();
                if (_ResidId != 0)
                {
                    MessageBox.Show("رسید با موفقیت ذخیره شد می توانید از پایین اقلام را جستجو و به رسید اضافه کنید");
                    groupBox3.Enabled = true;
                    groupBox4.Enabled = true;
                }
                else
                {
                    MessageBox.Show("ثبت نا موفق اطلاعات دوباره تلاش کنید");
                }
            }
            else
            {
                Resid = ResidSql.SelectByPrimaryKey(new BusinessLayer.RESIDKeys(_ResidId));
                Resid.BOSSID = int.Parse(((NewListItem)comboBox4.SelectedItem).Value.ToString());
                Resid.CHANNEL = int.Parse(((NewListItem)comboBox2.SelectedItem).Value.ToString());
                Resid.DATETIME = GetDate.GetDateTime();
                Resid.DEP = int.Parse(((NewListItem)comboBox3.SelectedItem).Value.ToString());
                Resid.EMPLOYEEID = int.Parse(((NewListItem)comboBox1.SelectedItem).Value.ToString());
                Resid.KIND = byte.Parse(((NewListItem)comboBox5.SelectedItem).Value.ToString());
                Resid.REQNUMBER = textBox5.Text.Trim();
                Resid.RESIDCODE = textBox8.Text.Trim();
                Resid.REQDATE = textBox2.Text.Trim();
                ResidSql.Update(Resid);
                MessageBox.Show("اطلاعات با موفقیت بروز شد");


            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            //Anbar.BusinessLayer.DataLayer.OBJECTSSql ObjSql = new BusinessLayer.DataLayer.OBJECTSSql();
            //List<Anbar.BusinessLayer.OBJECTS> Obj_List = ObjSql.SelectByField("CODE", textBox6.Text.Trim());


            //if (Obj_List.Count == 1)
            //{
            //    for (int i = 0; i < comboBox7.Items.Count; i++)
            //    {
            //        if (((NewListItem)comboBox7.Items[i]).Value.ToString() == Obj_List[0].ID.ToString())
            //        {
            //            comboBox7.SelectedIndex = i;
            //        }
            //    }

            //}
        }

        private void button4_Click(object sender, EventArgs e)
        {

            string Condition = " where ";

            if (textBox12.Text.Trim().Length > 0)
            {
                Condition += " AMVALCODE='" + textBox12.Text.Trim() + "' and ";
            }
            if (textBox10.Text.Trim().Length > 0)
            {
                Condition += " BRAND like N'%" + textBox10.Text.Trim() + "%' and ";
            }
            if (textBox7.Text.Trim().Length > 0)
            {
                Condition += " SERIAL='" + textBox7.Text.Trim() + "' and ";
            }
            if (textBox9.Text.Trim().Length > 0)
            {
                Condition += " MODEL like N'%" + textBox9.Text.Trim() + "%' and ";
            }

            if (Condition.Length > 7)
            {

                Condition = Condition.Remove(Condition.Length - 4, 4);
                Condition += " order by datetime ";
            }
            else
            {
                Condition = "  order by datetime";
            }

            Anbar.BusinessLayer.DataLayer.INCOMINGSql IncSql = new BusinessLayer.DataLayer.INCOMINGSql();
            List<Anbar.BusinessLayer.INCOMING> IncList = IncSql.SelectByCondition(Condition);



            DataTable DTable = new DataTable();
            DataColumn col1 = new DataColumn("ID");
            DataColumn col2 = new DataColumn("نوع کالا");
            DataColumn col4 = new DataColumn("شماره اموال ");
            DataColumn col5 = new DataColumn("شماره سریال");
            DataColumn col7 = new DataColumn("مدل");
            DataColumn col8 = new DataColumn("مارک");
            DataColumn col9 = new DataColumn("تاریخ ورود");

            DTable.Columns.Add(col1);
            DTable.Columns.Add(col2);
            DTable.Columns.Add(col4);
            DTable.Columns.Add(col5);
            DTable.Columns.Add(col8);
            DTable.Columns.Add(col7);
            DTable.Columns.Add(col9);


            foreach (Anbar.BusinessLayer.INCOMING item in IncList)
            {
                DataRow row = DTable.NewRow();
                row[col1] = item.ID;

                Anbar.BusinessLayer.DataLayer.OBJECTSSql ObjSql = new BusinessLayer.DataLayer.OBJECTSSql();
                Anbar.BusinessLayer.OBJECTS Obj =
                    ObjSql.SelectByPrimaryKey(new BusinessLayer.OBJECTSKeys((int)item.OBJECTID));

                row[col2] = Obj.TITLE;
                row[col4] = item.AMVALCODE;
                row[col5] = item.SERIAL;

                row[col7] = item.MODEL;
                row[col8] = item.BRAND;
                row[col9] = DateConversion.GD2JD((DateTime)item.DATETIME);
                DTable.Rows.Add(row);
            }

            dataGridView1.DataSource = DTable;
            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[1].Width = 110;
            dataGridView1.Columns[2].Width = 100;
            dataGridView1.Columns[3].Width = 100;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Anbar.BusinessLayer.DataLayer.RESID_DETAILSSql IncSql = new BusinessLayer.DataLayer.RESID_DETAILSSql();
            Anbar.BusinessLayer.RESID_DETAILS ResidDet = new BusinessLayer.RESID_DETAILS();
            ResidDet.INCOMINGID = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            ResidDet.RESIDID = _ResidId;
            ResidDet.ACTIVE = true;
            IncSql.Insert(ResidDet);
            MessageBox.Show("مورد انتخاب شده با موفقیت اضافه شد");
            LoadResidDetails();
        }
        protected void LoadResidDetails()
        {
            Anbar.BusinessLayer.DataLayer.RESID_DETAILSSql IncSql = new BusinessLayer.DataLayer.RESID_DETAILSSql();
            List<Anbar.BusinessLayer.RESID_DETAILS> IncList = IncSql.SelectCondition(" where RESIDID=" + _ResidId + " ");



            DataTable DTable = new DataTable();
            DataColumn col1 = new DataColumn("ID");
            DataColumn col2 = new DataColumn("نوع کالا");
            DataColumn col4 = new DataColumn("اموال");
            DataColumn col5 = new DataColumn("سریال");
            DataColumn col7 = new DataColumn("مدل");
            DataColumn col8 = new DataColumn("مارک");
            DataColumn col9 = new DataColumn("تاریخ");
            DataColumn col10 = new DataColumn("وضعیت");

            DTable.Columns.Add(col1);
            DTable.Columns.Add(col2);
            DTable.Columns.Add(col4);
            DTable.Columns.Add(col5);
            DTable.Columns.Add(col8);
            DTable.Columns.Add(col7);
            DTable.Columns.Add(col9);
            DTable.Columns.Add(col10);


            foreach (Anbar.BusinessLayer.RESID_DETAILS item in IncList)
            {
                DataRow row = DTable.NewRow();

                Anbar.BusinessLayer.DataLayer.INCOMINGSql IncSql2 = new BusinessLayer.DataLayer.INCOMINGSql();
                Anbar.BusinessLayer.INCOMING Inc = IncSql2.SelectByPrimaryKey(new BusinessLayer.INCOMINGKeys((int)item.INCOMINGID));


                row[col1] = item.ID;

                Anbar.BusinessLayer.DataLayer.OBJECTSSql ObjSql = new BusinessLayer.DataLayer.OBJECTSSql();
                Anbar.BusinessLayer.OBJECTS Obj =
                    ObjSql.SelectByPrimaryKey(new BusinessLayer.OBJECTSKeys((int)Inc.OBJECTID));

                row[col2] = Obj.TITLE;
                row[col4] = Inc.AMVALCODE;
                row[col5] = Inc.SERIAL;

                row[col7] = Inc.MODEL;
                row[col8] = Inc.BRAND;
                row[col9] = DateConversion.GD2JD((DateTime)Inc.DATETIME);

                if ((bool)item.ACTIVE)
                {
                    row[col10] = "فعال";
                }
                else
                {
                    row[col10] = "غیرفعال";
                }
                DTable.Rows.Add(row);
            }

            dataGridView2.DataSource = DTable;
            dataGridView2.Columns[0].Width = 50;
            dataGridView2.Columns[1].Width = 100;
            dataGridView2.Columns[2].Width = 90;
            dataGridView2.Columns[3].Width = 90;
            dataGridView2.Columns[7].Width = 60;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string Condition = " where ";
            if (textBox21.Text.Trim().Length > 0)
            {
                Anbar.BusinessLayer.DataLayer.EmployeesSql EmpSQl2 = new BusinessLayer.DataLayer.EmployeesSql();
                List<Anbar.BusinessLayer.Employees> Emp2 = EmpSQl2.SelectByField("PERSONALCODE", textBox21.Text.Trim());
                if (Emp2.Count > 0)
                {

                    foreach (Anbar.BusinessLayer.Employees item in Emp2)
                    {
                        Condition += " EMPLOYEEID=" + item.ID + " or BOSSID=" + item.ID + " or ";
                    }
                }
            }
            if (textBox22.Text.Trim().Length > 0)
            {
                Condition += " RESIDCODE=" +textBox22.Text.Trim()+" or ";
            }
            if (Condition.Length > 7)
            {
                Condition = Condition.Remove(Condition.Length - 3, 3);
            }
            else
            {
                Condition = " ";
            }

            Condition += " order by datetime desc ";

            Anbar.BusinessLayer.DataLayer.RESIDSql ResidSql = new BusinessLayer.DataLayer.RESIDSql();
            List<Anbar.BusinessLayer.RESID> ResidList = ResidSql.SelectByCondition(Condition);


            DataTable DTable = new DataTable();
            DataColumn col1 = new DataColumn("ID");
            DataColumn col2 = new DataColumn("شماره رسید");
            DataColumn col3 = new DataColumn("شبکه");
            DataColumn col4 = new DataColumn("واحد ");
            DataColumn col5 = new DataColumn("شخص");
            DataColumn col6 = new DataColumn("مدیر");
            DataColumn col7 = new DataColumn("تاریخ");


            DTable.Columns.Add(col1);
            DTable.Columns.Add(col2);
            DTable.Columns.Add(col3);
            DTable.Columns.Add(col4);
            DTable.Columns.Add(col5);
            DTable.Columns.Add(col6);
            DTable.Columns.Add(col7);


            foreach (Anbar.BusinessLayer.RESID item in ResidList)
            {
                Anbar.BusinessLayer.DataLayer.EmployeesSql EmpSQl = new BusinessLayer.DataLayer.EmployeesSql();
                DataRow row = DTable.NewRow();
                row[col1] = item.ID;
                row[col2] = item.RESIDCODE;


                Anbar.BusinessLayer.DataLayer.CHANNELSSql ChSql = new Anbar.BusinessLayer.DataLayer.CHANNELSSql();
                row[col3] = ChSql.SelectByPrimaryKey(new BusinessLayer.CHANNELSKeys((int)item.CHANNEL)).TITLE;




                Anbar.BusinessLayer.DataLayer.DEPSSql DepSql = new Anbar.BusinessLayer.DataLayer.DEPSSql();
                row[col4] = DepSql.SelectByPrimaryKey(new BusinessLayer.DEPSKeys((int)item.DEP)).TITLE;


                Anbar.BusinessLayer.Employees Emp = EmpSQl.SelectByPrimaryKey(new BusinessLayer.EmployeesKeys((int)item.EMPLOYEEID));

                row[col5] = Emp.FAMILY + "-" + Emp.NAME;
                Emp = EmpSQl.SelectByPrimaryKey(new BusinessLayer.EmployeesKeys((int)item.BOSSID));
                row[col6] = Emp.FAMILY + "-" + Emp.NAME;

                row[col7] = DateConversion.GD2JD((DateTime)item.DATETIME);

                DTable.Rows.Add(row);
            }

            dataGridView3.DataSource = DTable;
            dataGridView3.Columns[0].Width = 50;
            dataGridView3.Columns[1].Width = 100;
            dataGridView3.Columns[2].Width = 100;
            dataGridView3.Columns[3].Width = 120;
            dataGridView3.Columns[4].Width = 120;
            dataGridView3.Columns[5].Width = 120;
            dataGridView3.Columns[6].Width = 100;

        }

        private void dataGridView3_DoubleClick(object sender, EventArgs e)
        {
            _ResidId = int.Parse(dataGridView3.SelectedRows[0].Cells[0].Value.ToString());
            tabControl1.SelectedIndex = 1;
            LoadResidDetails();
            LoadResid();
        }
        protected void LoadResid()
        {
            Anbar.BusinessLayer.DataLayer.RESIDSql ResidSql = new BusinessLayer.DataLayer.RESIDSql();
            Anbar.BusinessLayer.RESID Resid =
                ResidSql.SelectByPrimaryKey(new BusinessLayer.RESIDKeys(int.Parse(dataGridView3.SelectedRows[0].Cells[0].Value.ToString())));

            Anbar.BusinessLayer.DataLayer.EmployeesSql EmpSQl = new BusinessLayer.DataLayer.EmployeesSql();
            textBox1.Text = EmpSQl.SelectByPrimaryKey(new BusinessLayer.EmployeesKeys((int)Resid.BOSSID)).PERSONALCODE;
            textBox1_TextChanged(new object(), new EventArgs());

            textBox3.Text = EmpSQl.SelectByPrimaryKey(new BusinessLayer.EmployeesKeys((int)Resid.EMPLOYEEID)).PERSONALCODE;
            textBox3_TextChanged(new object(), new EventArgs());

            textBox5.Text = Resid.REQNUMBER;
            textBox8.Text = Resid.RESIDCODE;
            textBox4.Text = DateConversion.GD2JD((DateTime)Resid.DATETIME);
            textBox2.Text = Resid.REQDATE;


            for (int i = 0; i < comboBox2.Items.Count; i++)
            {
                NewListItem Lst = (NewListItem )comboBox2.Items[i];
                if (Lst.Value.ToString() == Resid.CHANNEL.ToString())
                {
                    comboBox2.SelectedIndex = i;
                }
                
            }
            for (int i = 0; i < comboBox3.Items.Count; i++)
            {
                NewListItem Lst = (NewListItem)comboBox3.Items[i];
                if (Lst.Value.ToString() == Resid.DEP.ToString())
                {
                    comboBox3.SelectedIndex = i;
                }

            }

            for (int i = 0; i < comboBox5.Items.Count; i++)
            {
                NewListItem Lst = (NewListItem)comboBox5.Items[i];
                if (Lst.Value.ToString() == Resid.KIND.ToString())
                {
                    comboBox5.SelectedIndex = i;
                }

            }



            groupBox3.Enabled = true;
            groupBox4.Enabled = true;


        }

        private void button5_Click(object sender, EventArgs e)
        {
           
           
        }

        private void dataGridView2_DoubleClick(object sender, EventArgs e)
        {

        }
    }
}
