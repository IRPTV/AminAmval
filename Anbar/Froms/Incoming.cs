using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Anbar.Froms
{
    public partial class Incoming : Form
    {
        List<Anbar.BusinessLayer.INCOMING> _IncList = new List<BusinessLayer.INCOMING>();
        int _index = 0;
        public Incoming()
        {
            InitializeComponent();
        }

        private void Incoming_Load(object sender, EventArgs e)
        {
           // button1_Click_1(new object(), new EventArgs());

            Anbar.BusinessLayer.DataLayer.OBJECTSSql ObjSql = new BusinessLayer.DataLayer.OBJECTSSql();
            List<Anbar.BusinessLayer.OBJECTS> Obj_List = ObjSql.SelectAll();

            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            NewListItem Lst2 = new NewListItem();
            Lst2.Text = "----";
            Lst2.Value = 0;
            comboBox1.Items.Add(Lst2);
            comboBox2.Items.Add(Lst2);
            foreach (Anbar.BusinessLayer.OBJECTS item in Obj_List)
            {
                NewListItem Lst = new NewListItem();
                Lst.Text = item.TITLE;
                Lst.Value = item.ID;
                comboBox1.Items.Add(Lst);
                comboBox2.Items.Add(Lst);
            }
            if (comboBox1.Items.Count > 0)
            {
                comboBox1.SelectedIndex = 0;
            }
            comboBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox1.AutoCompleteSource = AutoCompleteSource.ListItems;
            if (comboBox2.Items.Count > 0)
            {
                comboBox2.SelectedIndex = 0;
            }
            comboBox2.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox2.AutoCompleteSource = AutoCompleteSource.ListItems;

            textBox1.Text = DateConversion.GD2JD(GetDate.GetDateTime());

        }

        private void textBox2_Leave(object sender, EventArgs e)
        {



        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            Anbar.BusinessLayer.DataLayer.OBJECTSSql ObjSql = new BusinessLayer.DataLayer.OBJECTSSql();
            List<Anbar.BusinessLayer.OBJECTS> Obj_List = ObjSql.SelectByField("ID", textBox2.Text.Trim());


            if (Obj_List.Count == 1)
            {
                for (int i = 0; i < comboBox1.Items.Count; i++)
                {
                    if (((NewListItem)comboBox1.Items[i]).Value.ToString() == Obj_List[0].ID.ToString())
                    {
                        comboBox1.SelectedIndex = i;
                    }
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Enabled == true)
            {
                Anbar.BusinessLayer.DataLayer.INCOMINGSql IncSql = new BusinessLayer.DataLayer.INCOMINGSql();

                List<Anbar.BusinessLayer.INCOMING> IncLst = IncSql.SelectByField("AMVALCODE",textBox8.Text.Trim());
                if (IncLst.Count > 0)
                {
                    MessageBox.Show("این شماره اموال تکراری است");
                }
                else
                {
                    Anbar.BusinessLayer.INCOMING Inc = new BusinessLayer.INCOMING();
                    Inc.AMVALCODE = textBox8.Text.Trim();
                    Inc.BRAND = textBox4.Text.Trim();
                    Inc.DATETIME = DateConversion.JD2GD(textBox1.Text.Trim());
                    Inc.MODEL = textBox5.Text.Trim();
                    Inc.OBJECTID = int.Parse(((NewListItem)comboBox1.SelectedItem).Value.ToString());
                    Inc.OWNER = 0;
                    Inc.SERIAL = textBox3.Text.Trim();

                    IncSql.Insert(Inc);
                  //  ClearForm();
                    button1_Click_1(new object(), new EventArgs());
                   // groupBox1.Visible = false;
                }
                button7_Click(new object(), new EventArgs());
            }
            else
            {
                 Anbar.BusinessLayer.DataLayer.INCOMINGSql IncSql2 = new BusinessLayer.DataLayer.INCOMINGSql();

                //List<Anbar.BusinessLayer.INCOMING> IncLst = IncSql2.SelectByField("AMVALCODE",textBox8.Text.Trim());
                //if (IncLst.Count > 0)
                //{
                //    MessageBox.Show("این شماره اموال تکراری است");
                //}
                //else
                //{
                    if (dataGridView1.SelectedRows.Count == 1 && dataGridView1.Enabled == false)
                    {
                        Anbar.BusinessLayer.DataLayer.INCOMINGSql IncSql = new BusinessLayer.DataLayer.INCOMINGSql();
                        Anbar.BusinessLayer.INCOMING Inc = IncSql.SelectByPrimaryKey(
                            new BusinessLayer.INCOMINGKeys(int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString())));
                        Inc.AMVALCODE = textBox8.Text.Trim();
                        Inc.BRAND = textBox4.Text.Trim();
                        Inc.DATETIME = DateConversion.JD2GD(textBox1.Text.Trim());
                        Inc.MODEL = textBox5.Text.Trim();
                        Inc.OBJECTID = int.Parse(((NewListItem)comboBox1.SelectedItem).Value.ToString());
                        Inc.OWNER = 0;
                        Inc.SERIAL = textBox3.Text.Trim();

                        IncSql.Update(Inc);
                     //   ClearForm();
                        //LoadIncoming();
                        button1_Click_1(new object(), new EventArgs());
                        dataGridView1.Enabled = true;
                        dataGridView1.ClearSelection();
                        groupBox1.Visible = false;

                    }
                //}
              
            }
          

        }
        protected void LoadIncoming()
        {
            Anbar.BusinessLayer.DataLayer.INCOMINGSql IncSql = new BusinessLayer.DataLayer.INCOMINGSql();
            List<Anbar.BusinessLayer.INCOMING> IncList = IncSql.SelectAll();
            _index = 0;

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


            //foreach (Anbar.BusinessLayer.INCOMING item in IncList)
            //{
            //    try
            //    {
            //        DataRow row = DTable.NewRow();
            //        row[col1] = item.ID;

            //        Anbar.BusinessLayer.DataLayer.OBJECTSSql ObjSql = new BusinessLayer.DataLayer.OBJECTSSql();
            //        Anbar.BusinessLayer.OBJECTS Obj =
            //            ObjSql.SelectByPrimaryKey(new BusinessLayer.OBJECTSKeys((int)item.OBJECTID));

            //        row[col2] = Obj.TITLE;
            //        row[col4] = item.AMVALCODE;
            //        row[col5] = item.SERIAL;

            //        row[col7] = item.MODEL;
            //        row[col8] = item.BRAND;
            //        row[col9] = DateConversion.GD2JD((DateTime)item.DATETIME);
            //        DTable.Rows.Add(row);
            //    }
            //    catch
            //    {
            //    }
               
            //}

            dataGridView1.DataSource = DTable;
            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[1].Width = 150;
            dataGridView1.Columns[2].Width = 120;
            dataGridView1.Columns[3].Width = 100;
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                Anbar.BusinessLayer.DataLayer.INCOMINGSql IncSql = new BusinessLayer.DataLayer.INCOMINGSql();
                Anbar.BusinessLayer.INCOMING Inc = IncSql.SelectByPrimaryKey(
                    new BusinessLayer.INCOMINGKeys(int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString())));
                textBox8.Text = Inc.AMVALCODE;
                textBox4.Text = Inc.BRAND;
                textBox1.Text = DateConversion.GD2JD(((DateTime)Inc.DATETIME));
                textBox5.Text = Inc.MODEL;

                for (int i = 0; i < comboBox1.Items.Count; i++)
                {
                    if (((NewListItem)comboBox1.Items[i]).Value.ToString() == Inc.OBJECTID.ToString())
                    {
                        comboBox1.SelectedIndex = i;

                        Anbar.BusinessLayer.DataLayer.OBJECTSSql ObjSql = new BusinessLayer.DataLayer.OBJECTSSql();
                        Anbar.BusinessLayer.OBJECTS Obj =
                            ObjSql.SelectByPrimaryKey(new BusinessLayer.OBJECTSKeys((int)Inc.OBJECTID));
                        textBox2.Text = Obj.CODE;
                    }
                }

                Inc.OBJECTID = int.Parse(((NewListItem)comboBox1.SelectedItem).Value.ToString());
                textBox3.Text = Inc.SERIAL;

                dataGridView1.Enabled = false;
            }
        }
        protected void ClearForm()
        {
            textBox1.Text = DateConversion.GD2JD(GetDate.GetDateTime());
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox8.Text = "";

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != 0)
            {
                Anbar.BusinessLayer.DataLayer.OBJECTSSql ObjSql = new BusinessLayer.DataLayer.OBJECTSSql();
                Anbar.BusinessLayer.OBJECTS Obj =
                    ObjSql.SelectByPrimaryKey(new BusinessLayer.OBJECTSKeys(int.Parse(((NewListItem)comboBox1.SelectedItem).Value.ToString())));
                textBox2.Text = Obj.ID.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClearForm();
            dataGridView1.Enabled = true;
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

            string Condition = " where ";

            if (textBox12.Text.Trim().Length > 0)
            {
                Condition += " AMVALCODE  like N'%" + textBox12.Text.Trim() + "%' and ";
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
            if (comboBox2.SelectedIndex > 0)
            {
                NewListItem LstSlct = (NewListItem)comboBox2.SelectedItem;
                Condition += " OBJECTID='" + LstSlct.Value.ToString() +"' and ";
            }


            if (Condition.Length > 7)
            {

                Condition = Condition.Remove(Condition.Length - 4, 4);
                Condition += "  order by id desc ";
            }
            else
            {
                Condition = "  order by id desc";
            }




            Anbar.BusinessLayer.DataLayer.INCOMINGSql IncSql = new BusinessLayer.DataLayer.INCOMINGSql();
            _IncList = IncSql.SelectByCondition(Condition);
            _index = 0;

            try
            {
                label11.Text = _IncList.Count.ToString();
                int PagesCount = (_IncList.Count / 20);
                numericUpDown1.Maximum = PagesCount;
                numericUpDown1.Value = 1;
                numericUpDown1.Minimum = 1;
            }
            catch
            {
                
               
            }
            


        }

        private void button9_Click(object sender, EventArgs e)
        {           
            groupBox3.Visible = true;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            Anbar.BusinessLayer.DataLayer.INCOMINGSql IncSql = new BusinessLayer.DataLayer.INCOMINGSql();
             _IncList = IncSql.SelectAll();
            _index = 0;
          
            label11.Text = _IncList.Count.ToString();
            int PagesCount = (_IncList.Count / 20);
            numericUpDown1.Maximum = PagesCount;
            numericUpDown1.Value = 1;
            numericUpDown1.Minimum = 1;
            numericUpDown1_ValueChanged(new object(), new EventArgs());
        
           
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
                DialogResult Rslt = MessageBox.Show("آیا ردیف مورد نظر حذف شود؟", "حذف ", MessageBoxButtons.YesNo);
                if (Rslt == System.Windows.Forms.DialogResult.Yes)
                {
                    Anbar.BusinessLayer.DataLayer.INCOMINGSql ObjSql = new BusinessLayer.DataLayer.INCOMINGSql();
                    ObjSql.Delete(new BusinessLayer.INCOMINGKeys(int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString())));
                    button2_Click(new object(), new EventArgs());
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
           
            groupBox1.Visible = true;
            groupBox1.Text = "ثبت  جدید";
            textBox8.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox5.Text = "";
            textBox4.Text = "";
            textBox1.Text = DateConversion.GD2JD(DateTime.Now);
        }

        private void button5_Click(object sender, EventArgs e)
        {
           
            groupBox1.Visible = true;
            groupBox1.Text = "ویرایش";
            dataGridView1.Enabled = false;

            Anbar.BusinessLayer.DataLayer.INCOMINGSql ObjSql = new BusinessLayer.DataLayer.INCOMINGSql();
            Anbar.BusinessLayer.INCOMING Obj =
                ObjSql.SelectByPrimaryKey(new BusinessLayer.INCOMINGKeys(int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString())));
            
            textBox8.Text = Obj.AMVALCODE;
            textBox2.Text = Obj.OBJECTID.ToString();
            textBox3.Text = Obj.SERIAL;
            textBox5.Text = Obj.MODEL;
            textBox4.Text = Obj.BRAND;
            textBox1.Text = DateConversion.GD2JD((DateTime)Obj.DATETIME);

        }

        private void button10_Click(object sender, EventArgs e)
        {
            groupBox3.Visible = false;
            dataGridView1.Enabled = true;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            dataGridView1.Enabled = true;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
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

          
            int End = 0;
            if ((int)numericUpDown1.Value == _IncList.Count / 20)
            {
                End = _IncList.Count;
                _index = _IncList.Count - 20;
            }
            else
            {
                _index = (int)(numericUpDown1.Value * 20) - 20;
                End=(int)numericUpDown1.Value*20;
            }


          //  _index = (int)(numericUpDown1.Value * 20 )- 20;
            for (int i =_index; i < End  ; i++)
            {
                if (_index <= _IncList.Count)
                {
                    try
                    {
                        Anbar.BusinessLayer.INCOMING item = (Anbar.BusinessLayer.INCOMING)_IncList[_index];
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
                        _index++;
                    }
                    catch
                    {
                        _index++;
                    }
                   
               }
            }         
            dataGridView1.DataSource = DTable;
            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[1].Width = 150;
            dataGridView1.Columns[2].Width = 120;
            dataGridView1.Columns[3].Width = 100;
        }


    }
}
