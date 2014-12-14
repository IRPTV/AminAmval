using System;
using System.Collections.Generic;
using System.Data.SqlClient;

using System.Text;


    class GetDate
    {
        public static DateTime GetDateTime()
        {
            SqlConnection SqlCon = new SqlConnection("Data Source=192.168.100.73;Initial Catalog=AminAmval;User Id=AminAmval;Password=AminAmval;");
            SqlCon.Open();

            string Cmd = "select GETDATE()";
            SqlCommand SelectCmd = new SqlCommand(Cmd, SqlCon);

            DateTime Dt = DateTime.Parse(SelectCmd.ExecuteScalar().ToString());

            SqlCon.Close();
            return Dt;           
        }
    }
