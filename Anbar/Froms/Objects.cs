using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Anbar.Froms
{
    public partial class Objects : Form
    {
        public Objects()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Objects_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();

            NewListItem Lst1 = new NewListItem();
            Lst1.Text = "اموال فنی";
            Lst1.Value = 0;


            NewListItem Lst2 = new NewListItem();
            Lst2.Text = "اموال اداری";
            Lst2.Value = 1;

            comboBox1.Items.Add(Lst1);
            comboBox1.Items.Add(Lst2);
            comboBox1.SelectedIndex = 0;
            LoadObjects();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Anbar.BusinessLayer.OBJECTS Obj = new BusinessLayer.OBJECTS();

            Obj.CODE = "0";
            Obj.GROUPID = int.Parse(((NewListItem)comboBox1.SelectedItem).Value.ToString());
            Obj.TITLE = textBox8.Text.Trim();



            Anbar.BusinessLayer.DataLayer.OBJECTSSql ObjSql = new BusinessLayer.DataLayer.OBJECTSSql();
            ObjSql.Insert(Obj);
            LoadObjects();
        }
        protected void LoadObjects()
        {
            DataTable DTable = new DataTable();

            DataColumn col1 = new DataColumn("کد");
            DataColumn col2 = new DataColumn("عنوان");
            DataColumn col3 = new DataColumn("گروه ");
           // DataColumn col5 = new DataColumn("کد");           
            DTable.Columns.Add(col1);
            DTable.Columns.Add(col2);
            DTable.Columns.Add(col3);
          //  DTable.Columns.Add(col5);

            Anbar.BusinessLayer.DataLayer.OBJECTSSql ObjSql = new BusinessLayer.DataLayer.OBJECTSSql();
            List<Anbar.BusinessLayer.OBJECTS> Obj_List = ObjSql.SelectAll();

            foreach (Anbar.BusinessLayer.OBJECTS item in Obj_List)
            {
                DataRow row = DTable.NewRow();
                row[col1] = item.ID;
                row[col2] = item.TITLE;

                switch (item.GROUPID)
                {
                    case 1:
                         row[col3] ="اداری";
                        break;
                    case 0:
                        row[col3] = "فنی";
                        break;

                    default:
                         row[col3] = "---";
                        break;

                }
               
          //      row[col5] = item.CODE;
              
                DTable.Rows.Add(row);
            }

            dataGridView1.DataSource = DTable;
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Selected = true;
                dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.RowCount - 1;
            }
            dataGridView1.Columns[0].Width = 50;            
            dataGridView1.Columns[1].Width = 230;
            dataGridView1.Columns[2].Width = 135;                         
        }

        private void button3_Click(object sender, EventArgs e)
        {         
            groupBox1.Visible = true;
            button1.Visible = false;
            button2.Visible = true;
            groupBox1.Text = "ثبت مورد جدید";
            textBox8.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            dataGridView1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Anbar.BusinessLayer.DataLayer.OBJECTSSql ObjSql = new BusinessLayer.DataLayer.OBJECTSSql();
            BusinessLayer.OBJECTS Obj=new BusinessLayer.OBJECTS ();
           Obj=ObjSql.SelectByPrimaryKey(new BusinessLayer.OBJECTSKeys(int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString())));
           Obj.CODE = "0";
            Obj.GROUPID = int.Parse(((NewListItem)comboBox1.SelectedItem).Value.ToString());
            Obj.TITLE = textBox8.Text.Trim();
            ObjSql.Update(Obj);
            LoadObjects();
            groupBox1.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {           
            groupBox1.Visible = true;
            button1.Visible = true;
            button2.Visible = false;
            groupBox1.Text = "ویرایش";
            textBox8.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();

            Anbar.BusinessLayer.DataLayer.OBJECTSSql ObjSql = new BusinessLayer.DataLayer.OBJECTSSql();
            BusinessLayer.OBJECTS Obj = new BusinessLayer.OBJECTS();
            Obj = ObjSql.SelectByPrimaryKey(new BusinessLayer.OBJECTSKeys(int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString())));
            for (int i = 0; i < comboBox1.Items.Count; i++)
            {
                if (((NewListItem)(comboBox1.Items[i])).Value.ToString() == Obj.GROUPID.ToString())
                {
                    comboBox1.SelectedIndex = i;
                }
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
                dataGridView1.Rows[dataGridView1.Rows.Count-1].Selected = true;
                dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.RowCount - 1;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                DialogResult Rslt = MessageBox.Show("آیا ردیف انتخاب شده حذف شود؟", "حذف", MessageBoxButtons.YesNo);
                if (Rslt == System.Windows.Forms.DialogResult.Yes)
                {

                    Anbar.BusinessLayer.DataLayer.OBJECTSSql ObjSql = new BusinessLayer.DataLayer.OBJECTSSql();
                    ObjSql.Delete(new BusinessLayer.OBJECTSKeys(int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString())));
                    LoadObjects();
                }
            }
        }
    }
}
