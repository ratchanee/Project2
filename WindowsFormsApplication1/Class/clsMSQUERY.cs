using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Stock.Class
{
    class clsMSQUERY
    {
        SqlConnection scon = new SqlConnection(clsGlobal.strConnection);
        SqlCommand scom = new SqlCommand();
        SqlTransaction st;
        //public SqlDataReader reader;

        public void MS_Connection()
        {
            if (scon.State == ConnectionState.Closed)
            {
                scon.Open();
            }
        }

        public void MS_Disconnection()
        {
            if (scon.State == ConnectionState.Open)
            {
                scon.Close();
            }
        }

        //read
        public DataSet MS_DataAdapter(string sqlcmd)
        {
            try
            {
                DataSet ds = new DataSet();
                MS_Connection();
                SqlDataAdapter sda = new SqlDataAdapter(sqlcmd, scon);
                sda.Fill(ds, "table");

                return ds;
            }
            catch (Exception ex) { throw ex; }
        }

        //query
        public void MS_ExecuteNonQuery(string sqlcmd)
        {
            try
            {
                MS_Connection();
                st = scon.BeginTransaction();
                new SqlCommand(sqlcmd, scon, st).ExecuteNonQuery();
                st.Commit();
            }
            catch (SqlException sqlError)
            {
                st.Rollback();
                throw sqlError;
            }
        }
    }
}
