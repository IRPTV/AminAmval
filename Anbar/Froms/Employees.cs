using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Anbar.Froms
{
    public partial class Employees : Form
    {
        public Employees()
        {
            InitializeComponent();

        }

        protected void LoadEmp()
        {
            DataTable DTable = new DataTable();

            DataColumn col1 = new DataColumn("ID");
            DataColumn col3 = new DataColumn("نام خانوادگی ");
            DataColumn col2 = new DataColumn("نام");
            DataColumn col5 = new DataColumn("شماره پرسنلی");
            DataColumn col6 = new DataColumn("واحد");
            DataColumn col7 = new DataColumn("تلفن");
            DataColumn col8 = new DataColumn("ش.ملی");


            DTable.Columns.Add(col1);         
            DTable.Columns.Add(col3);
            DTable.Columns.Add(col2);
            DTable.Columns.Add(col5);
            DTable.Columns.Add(col6);
            DTable.Columns.Add(col7);
            DTable.Columns.Add(col8);



            Anbar.BusinessLayer.DataLayer.EmployeesSql Emp_Sql = new BusinessLayer.DataLayer.EmployeesSql();
            List<Anbar.BusinessLayer.Employees> Emp_List = Emp_Sql.SelectAll();



            foreach (Anbar.BusinessLayer.Employees item in Emp_List)
            {
                DataRow row = DTable.NewRow();
                row[col1] = item.ID;
                row[col2] = item.NAME;
                row[col3] = item.FAMILY;
                row[col5] = item.PERSONALCODE;

                try
                {
                    BusinessLayer.DataLayer.DEPSSql DepSql = new BusinessLayer.DataLayer.DEPSSql();
                    BusinessLayer.DEPS Dep = DepSql.SelectByPrimaryKey(new BusinessLayer.DEPSKeys(int.Parse(item.DEP.ToString())));

                    //BusinessLayer.DataLayer.CHANNELSSql ChSql = new BusinessLayer.DataLayer.CHANNELSSql();
                    //BusinessLayer.CHANNELS Ch = ChSql.SelectByPrimaryKey(new BusinessLayer.CHANNELSKeys(int.Parse(Dep.CHANNELID.ToString())));
                    row[col6] = Dep.TITLE;

                }
                catch
                { }
              
                row[col7] = item.PHONE;
                row[col8] = item.ADDRESS;

                DTable.Rows.Add(row);
            }

            dataGridView1.DataSource = DTable;
            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[1].Width = 100;
            dataGridView1.Columns[2].Width = 120;
            dataGridView1.Columns[3].Width = 100;
            dataGridView1.Columns[4].Width = 100;
            dataGridView1.Columns[5].Width = 100;
            dataGridView1.Columns[6].Width = 100;
        }
        private void Employees_Load(object sender, EventArgs e)
        {

            BusinessLayer.DataLayer.CHANNELSSql ChSql = new BusinessLayer.DataLayer.CHANNELSSql();
            List<BusinessLayer.CHANNELS> ChLst = ChSql.SelectAll();
            comboBox2.Items.Clear();         
            foreach (Anbar.BusinessLayer.CHANNELS item in ChLst)
            {
                NewListItem Lst = new NewListItem();
                Lst.Text = item.TITLE;
                Lst.Value = item.ID;
                comboBox2.Items.Add(Lst);
            }
            if (comboBox2.Items.Count > 0)
            {
                comboBox2.SelectedIndex = 0;

            }
            comboBox2.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox2.AutoCompleteSource = AutoCompleteSource.ListItems;


            //LoadEmp();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string Condition = "";
            if (textBox8.Text.Trim().Length > 0)
            {
                Condition += " Name like N'%" + textBox8.Text.Trim() + "%' and ";
            }
            if (textBox7.Text.Trim().Length > 0)
            {
                Condition += "  FAMILY like N'%" + textBox7.Text.Trim() + "%' and ";
            }
            if (textBox6.Text.Trim().Length > 0)
            {
                Condition += "  PERSONALCODE=" + textBox6.Text.Trim() + " and ";
            }
            if (Condition.Length > 4)
            {
                Condition = Condition.Remove(Condition.Length - 4, 4);
            }
            else
            {
                Condition = " id > 0 ";
            }
            Anbar.BusinessLayer.DataLayer.EmployeesSql Emp_Sql = new BusinessLayer.DataLayer.EmployeesSql();
            List<Anbar.BusinessLayer.Employees> Emp_List = Emp_Sql.SelectByCondition(Condition);

            DataTable DTable = new DataTable();

            DataColumn col1 = new DataColumn("ID");
            DataColumn col3 = new DataColumn("نام خانوادگی ");
            DataColumn col2 = new DataColumn("نام");
            DataColumn col5 = new DataColumn("شماره پرسنلی");
            DataColumn col6 = new DataColumn("واحد");
            DataColumn col7 = new DataColumn("تلفن");
            DataColumn col8 = new DataColumn("ش.ملی");


            DTable.Columns.Add(col1);
            DTable.Columns.Add(col3);
            DTable.Columns.Add(col2);
            DTable.Columns.Add(col5);
            DTable.Columns.Add(col6);
            DTable.Columns.Add(col7);
            DTable.Columns.Add(col8);

            foreach (Anbar.BusinessLayer.Employees item in Emp_List)
            {
                DataRow row = DTable.NewRow();
                row[col1] = item.ID;
                row[col2] = item.NAME;
                row[col3] = item.FAMILY;
                row[col5] = item.PERSONALCODE;
                try
                {
                    BusinessLayer.DataLayer.DEPSSql DepSql = new BusinessLayer.DataLayer.DEPSSql();
                    BusinessLayer.DEPS Dep = DepSql.SelectByPrimaryKey(new BusinessLayer.DEPSKeys(int.Parse(item.DEP.ToString())));

                    BusinessLayer.DataLayer.CHANNELSSql ChSql = new BusinessLayer.DataLayer.CHANNELSSql();
                    BusinessLayer.CHANNELS Ch = ChSql.SelectByPrimaryKey(new BusinessLayer.CHANNELSKeys(int.Parse(Dep.CHANNELID.ToString())));
                    row[col6] = Ch.TITLE+ " - "+ Dep.TITLE;

                }
                catch
                { }
                row[col7] = item.PHONE;
                row[col8] = item.ADDRESS;

                DTable.Rows.Add(row);
            }

            dataGridView1.DataSource = DTable;
            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[1].Width = 100;
            dataGridView1.Columns[2].Width = 120;
            dataGridView1.Columns[3].Width = 100;
            dataGridView1.Columns[4].Width = 100;
            dataGridView1.Columns[5].Width = 100;
            dataGridView1.Columns[6].Width = 100;
            dataGridView1.ClearSelection();
            dataGridView1.Enabled = true;
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                groupBox3.Visible = true;
                groupBox3.Text = "ویرایش مشخصات کارمندان";
                BusinessLayer.DataLayer.EmployeesSql EmpSql = new BusinessLayer.DataLayer.EmployeesSql();
                BusinessLayer.Employees Emp =
                    EmpSql.SelectByPrimaryKey(new BusinessLayer.EmployeesKeys(int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString())));

                textBox1.Text = Emp.NAME.ToString();
                textBox2.Text = Emp.FAMILY.ToString();
                // textBox3.Text = Emp.FATHER.ToString();
                textBox4.Text = Emp.PHONE.ToString();
                textBox5.Text = Emp.ADDRESS.ToString();
                textBox9.Text = Emp.PERSONALCODE.ToString();
                dataGridView1.Enabled = false;
            }
            catch 
            {
             
            }
          


        }


        private void button3_Click(object sender, EventArgs e)
        {
            BusinessLayer.DataLayer.EmployeesSql EmpSql = new BusinessLayer.DataLayer.EmployeesSql();
            BusinessLayer.Employees Emp = new BusinessLayer.Employees();
            Emp.NAME = textBox1.Text.Trim();
            Emp.FAMILY = textBox2.Text.Trim();

            Emp.DEP = int.Parse(((NewListItem)comboBox1.SelectedItem).Value.ToString());

           // Emp.FATHER = textBox3.Text.Trim();
            Emp.PHONE = textBox4.Text.Trim();
            Emp.ADDRESS = textBox5.Text.Trim();
            Emp.PERSONALCODE = textBox9.Text.Trim();

            if (dataGridView1.SelectedRows.Count == 1)
            {
                Emp.ID = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                EmpSql.Update(Emp);
                MessageBox.Show("اطلاعات با موفقیت بروزشد");
                button2_Click(new object(), new EventArgs());
            }
            else
            {
                if (dataGridView1.SelectedRows.Count == 0)
                {
                    EmpSql.Insert(Emp);
                    MessageBox.Show("اطلاعات با موفقیت اضافه شد.");
                    LoadEmp();
                }
            }
            dataGridView1.ClearSelection();
            dataGridView1.Enabled = true;



        }

        private void button9_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            groupBox3.Visible = true;
            groupBox3.Text = "ثبت کارمند جدید";

        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                groupBox3.Visible = true;
                groupBox3.Text = "ویرایش مشخصات کارمندان";
                BusinessLayer.DataLayer.EmployeesSql EmpSql = new BusinessLayer.DataLayer.EmployeesSql();
                BusinessLayer.Employees Emp =
                    EmpSql.SelectByPrimaryKey(new BusinessLayer.EmployeesKeys(int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString())));

                BusinessLayer.DataLayer.DEPSSql DepSql = new BusinessLayer.DataLayer.DEPSSql();
                BusinessLayer.DEPS Dep = DepSql.SelectByPrimaryKey(new BusinessLayer.DEPSKeys(int.Parse(Emp.DEP.ToString())));



                textBox1.Text = Emp.NAME.ToString();
                textBox2.Text = Emp.FAMILY.ToString();

                for (int i = 0; i < comboBox2.Items.Count; i++)
                {
                    if (((NewListItem)(comboBox2.Items[i])).Value.ToString() == Dep.CHANNELID.ToString())
                    {
                        comboBox2.SelectedIndex = i;
                        comboBox2_SelectedIndexChanged(new object(), new EventArgs());
                    }
                }

                for (int i = 0; i < comboBox1.Items.Count; i++)
                {
                    if (((NewListItem)(comboBox1.Items[i])).Value.ToString() == Emp.DEP.ToString())
                    {
                        comboBox1.SelectedIndex = i;
                    }
                }





                textBox4.Text = Emp.PHONE.ToString();
                textBox5.Text = Emp.ADDRESS.ToString();
                textBox9.Text = Emp.PERSONALCODE.ToString();
                dataGridView1.Enabled = false;
            }
            catch { }
         
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
                DialogResult Rslt = MessageBox.Show("آیا کارمند مورد نظر حذف شود؟", "حذف کارمند", MessageBoxButtons.YesNo);
                if (Rslt == System.Windows.Forms.DialogResult.Yes)
                {
                    BusinessLayer.DataLayer.EmployeesSql EmpSql = new BusinessLayer.DataLayer.EmployeesSql();
                    EmpSql.Delete(new BusinessLayer.EmployeesKeys(int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString())));
                    button2_Click(new object(), new EventArgs());
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            groupBox3.Visible = false;
            dataGridView1.Enabled = true;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            BusinessLayer.DataLayer.DEPSSql DepSql = new BusinessLayer.DataLayer.DEPSSql();
               NewListItem Lst = new NewListItem();
            Lst=(NewListItem)comboBox2.SelectedItem;
            List<BusinessLayer.DEPS> DepLst = DepSql.SelectByField("CHANNELID",Lst.Value.ToString());
            comboBox1.Items.Clear();                   
            foreach (Anbar.BusinessLayer.DEPS item in DepLst)
            {
                NewListItem Lst3 = new NewListItem();
                Lst3.Text = item.TITLE;
                Lst3.Value = item.ID;
                comboBox1.Items.Add(Lst3);
            }
            if (comboBox1.Items.Count > 0)
            {
                comboBox1.SelectedIndex = 0;

            }
            comboBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox1.AutoCompleteSource = AutoCompleteSource.ListItems;

        }
    }
}