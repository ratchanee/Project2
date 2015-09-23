using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stock.Class
{
    class clsGlobal
    {
        public static string strConnection = @"Data Source=MIW-PC\MSSQLSV2008R2;Initial Catalog=STORE;Persist Security Info=True;User ID=sa;Password=pass";
        public static clsMSQUERY SQLQUERY = new clsMSQUERY();

        private static string mem_ID;

        public static string Mem_ID
        {
            get { return mem_ID; }
            set { mem_ID = value; }
        }

        private static string mem_Name;

        public static string Mem_Name
        {
            get { return mem_Name; }
            set { mem_Name = value; }
        }

        private static string mem_Status;

        public static string Mem_Status
        {
            get { return mem_Status; }
            set { mem_Status = value; }
        }


    }
}
