using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stock.Parameter;

namespace Stock.Class
{
    class clsUPDATE
    {
        public static Boolean MEMBER(clsMember  M)
        {
            try
            {
                StringBuilder sb = new StringBuilder();

                sb.Remove(0, sb.ToString().Length);
                sb.Append(" UPDATE MEMBER ");
                sb.Append(" SET Mem_Name =  '" + M.Mem_Name + "' ");
                sb.Append(" ,Share_Member  =  '" + M.Share_Member + "' ");
                sb.Append(" ,Phone  =  '" + M.Phone + "'");
                sb.Append(" ,Status  =  '" + M.Status + "'");
                sb.Append(" ,Address  =  '" +  M.Address+ "' ");
                sb.Append(" WHERE  Mem_ID =  '" + M.Mem_ID + "' ");
              

                clsGlobal.SQLQUERY.MS_ExecuteNonQuery(sb.ToString());
                return true;
            }
            catch (Exception ex) { return false; throw ex; }
        }
        public static Boolean PRODUCT(clsPRODUCT M)
        {
            try
            {
                StringBuilder sb = new StringBuilder();

                sb.Remove(0, sb.ToString().Length);
                sb.Append(" UPDATE PRODUCT ");
                sb.Append(" SET Product_Name =  '" + M.Product_Name + "' ");
                sb.Append(" ,Pricebuy =  '" + M.Pricebuy + "' ");
                sb.Append(" ,Pricesale =  '" + M.Pricesale + "'");
                sb.Append(" ,Total =  '" + M.Total + "'");
                sb.Append(" ,Type_ID =  '" + M.Type_ID + "' ");
                sb.Append(" ,Dealer_ID =  '" + M.Dealer_ID + "' ");
                sb.Append(" WHERE Product_ID =  '" + M.Product_ID + "' ");


                clsGlobal.SQLQUERY.MS_ExecuteNonQuery(sb.ToString());
                return true;
            }
            catch (Exception ex) { return false; throw ex; }
        }
        public static Boolean DEALER(clsDEALER  M)
        {
            try
            {
                StringBuilder sb = new StringBuilder();

                sb.Remove(0, sb.ToString().Length);
                sb.Append(" UPDATE DEALER ");
                sb.Append(" SET Dealer_Name  =  '" + M.Dealer_Name + "' ");
                sb.Append(" ,Dealer_Tel  =  '" + M.Dealer_Tel + "'");
                sb.Append(" ,Dealer_Address  =  '" + M.Dealer_Address + "'");
                sb.Append(" WHERE  Dealer_ID =  '" + M.Dealer_ID + "' ");

                clsGlobal.SQLQUERY.MS_ExecuteNonQuery(sb.ToString());
                return true;
            }
            catch (Exception ex) { return false; throw ex; }
        }
    }
}
 