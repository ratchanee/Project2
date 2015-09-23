using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Stock.Parameter;

namespace Stock.Class
{
    class clsINSERT
    {
        public static Boolean MEMBER(clsMember  M)
        {
            try
            {
                StringBuilder sb = new StringBuilder();

                sb.Remove(0, sb.ToString().Length);
                sb.Append(" INSERT INTO MEMBER ");
                //sb.Append(" ( Mem_ID ");
                sb.Append(" ( Mem_Name ");
                sb.Append(" ,Share_Member ");
                sb.Append(" ,Phone ");
                sb.Append(" ,Status ");
                sb.Append(" ,Address )");
                sb.Append(" VALUES ");
                //sb.Append(" ('" + M.Mem_ID + "' ");
                sb.Append(" ('" + M.Mem_Name + "' ");
                sb.Append(" ,'" + M.Share_Member + "' ");
                sb.Append(" ,'" + M.Phone + "' ");
                sb.Append(" ,'" + M.Status + "' ");
                sb.Append(" ,'" + M.Address + "') ");


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
                sb.Append(" INSERT INTO PRODUCT ");
                sb.Append(" (Dealer_ID ");
                sb.Append(" ,Type_ID ");
                sb.Append(" ,Product_Name ");
                sb.Append(" ,Pricebuy ");
                sb.Append(" ,Pricesale ");
                sb.Append(" ,Total )");
                sb.Append(" VALUES ");
                sb.Append(" ('" + M.Dealer_ID  + "' ");
                sb.Append(" ,'" + M.Type_ID + "' ");
                sb.Append(" ,'" + M.Product_Name + "' ");
                sb.Append(" ,'" + M.Pricebuy + "' ");
                sb.Append(" ,'" + M.Pricesale + "' ");
                sb.Append(" ,'" + M.Total+ "') ");

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
                sb.Append(" INSERT INTO DEALER ");
                //sb.Append(" ( Dealer_ID ");
                sb.Append(" (Dealer_Name ");
                sb.Append(" ,Dealer_Tel ");
                sb.Append(" ,Dealer_Address )");
                sb.Append(" VALUES ");
                //sb.Append(" ('" + M.Dealer_ID + "' ");
                sb.Append(" ('" + M.Dealer_Name + "' ");
                sb.Append(" ,'" + M.Dealer_Tel + "' ");
                sb.Append(" ,'" + M.Dealer_Address + "') ");

                clsGlobal.SQLQUERY.MS_ExecuteNonQuery(sb.ToString());
                return true;
            }
            catch (Exception ex) { return false; throw ex; }
        }
        public static Boolean DEALERPRODUCT(clsDEALER  M)
        {
            try
            {
                StringBuilder sb = new StringBuilder();

                sb.Remove(0, sb.ToString().Length);
                sb.Append(" INSERT INTO DETAIL_PRODUCT ");
                sb.Append(" (Dealer_ID ");
                sb.Append(" ,Type_ID ");
                sb.Append(" ,Product_ID ");
                sb.Append(" ,Price) ");
                sb.Append(" VALUES ");
                sb.Append(" ('" + M.Dealer_ID + "' ");
                //sb.Append(" ,'" + M.Dealer_Name + "' ");
                sb.Append(" ,'" + M.Type_ID + "' ");
                //sb.Append(" ,'" + M.Type_Name + "' ");
                sb.Append(" ,'" + M.Product_ID + "' ");
                sb.Append(" ,'" + M.Price + "') ");

                clsGlobal.SQLQUERY.MS_ExecuteNonQuery(sb.ToString());
                return true;
            }
            catch (Exception ex) { return false; throw ex; }
        }
    }
}
