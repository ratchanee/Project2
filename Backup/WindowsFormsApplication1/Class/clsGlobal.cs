using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stock.Class
{
    class clsGlobal
    {
        public static string strConnection = "Data Source=DEV_JCHAIWAT\\MSSQL2008R2;Initial Catalog=STORE;Persist Security Info=True;User ID=sa;Password=P@ssw0rd2o08r2";
        public static clsMSQUERY SQLQUERY = new clsMSQUERY();
    }
}
