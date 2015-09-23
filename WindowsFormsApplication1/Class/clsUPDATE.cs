using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stock.Parameter;

namespace Stock.Class
{
    class clsUPDATE
    {
        public static Boolean MEMBER(clsMember M)
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
                sb.Append(" ,Address  =  '" + M.Address + "' ");
                sb.Append(" ,M_User  =  '" + M.M_User + "' ");
                sb.Append(" ,M_Pass  =  '" + M.M_Pass + "' ");
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
                sb.Append(" ,Good_Min =  '" + M.Good_Min + "' ");
                sb.Append(" ,Type_ID =  '" + M.Type_ID + "' ");
                sb.Append(" WHERE Product_ID =  '" + M.Product_ID + "' ");


                clsGlobal.SQLQUERY.MS_ExecuteNonQuery(sb.ToString());
                return true;
            }
            catch (Exception ex) { return false; throw ex; }
        }
        public static Boolean SALE(clsSale  S)
        {
            try
            {
                StringBuilder sb = new StringBuilder();

                sb.Remove(0, sb.ToString().Length);
                sb.Append(" UPDATE DETAIL_SALE ");
                sb.Append(" SET Total =  ");
                sb.Append(" , Total +  '" + S.Total + "' ");
                sb.Append(" WHERE Sale_ID =  '" + S.Sale_ID + "' ");
                sb.Append(" AND Product_ID =  '" + S.Product_ID + "' ");


                clsGlobal.SQLQUERY.MS_ExecuteNonQuery(sb.ToString());
                return true;
            }
            catch (Exception ex) { return false; throw ex; }
        }
        public static Boolean DEALER(clsDEALER M)
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
        public static Boolean ORDERCANCEL(clsORDER O)
        {
            try
            {
                StringBuilder sb = new StringBuilder();

                sb.Remove(0, sb.ToString().Length);
                sb.Append(" UPDATE O_ORDER ");
                sb.Append(" SET Status =  'C' ");
                sb.Append(" , Mem_ID =  '"+O .Mem_ID +"' ");
                sb.Append(" WHERE  Order_ID =  '" + O.Order_ID + "'  ");
                clsGlobal.SQLQUERY.MS_ExecuteNonQuery(sb.ToString());
                return true;
            }
            catch (Exception ex) { return false; throw ex; }
        }
        public static Boolean ORDEROK(clsORDER O)
        {
            try
            {
                StringBuilder sb = new StringBuilder();

                sb.Remove(0, sb.ToString().Length);
                sb.Append(" UPDATE O_ORDER ");
                sb.Append(" SET Status =  'B' ");
                sb.Append(" WHERE  Order_ID =  '" + O.Order_ID + "'  ");
                clsGlobal.SQLQUERY.MS_ExecuteNonQuery(sb.ToString());
                return true;

            }
            catch (Exception ex) { return false; throw ex; }
        }
        public static Boolean DERIVERYOK(clsORDER O) 
        {
            try
            {
                StringBuilder sb = new StringBuilder();

                sb.Remove(0, sb.ToString().Length);
                sb.Append(" UPDATE O_ORDER ");
                sb.Append(" SET Status =  'P' ");
                sb.Append(" WHERE  Order_ID =  '" + O.Order_ID + "'  ");
                clsGlobal.SQLQUERY.MS_ExecuteNonQuery(sb.ToString());
                return true;

            }
            catch (Exception ex) { return false; throw ex; }
        }
        public static Boolean ORDEROK1(clsORDER O) 
        {
            try
            {
                StringBuilder sb = new StringBuilder();

                sb.Remove(0, sb.ToString().Length);
                sb.Append(" UPDATE DETAIL_ORDER ");
                sb.Append(" SET Total =  '" + O.Total + "'  ");
                sb.Append(" WHERE  Order_ID =  '" + O.Order_ID + "'  ");
                sb.Append(" AND Product_ID = '"+O.Product_ID+"' ");
                clsGlobal.SQLQUERY.MS_ExecuteNonQuery(sb.ToString());
                return true;

            }
            catch (Exception ex) { return false; throw ex; }
        }
        public static Boolean UPNOTE(clsORDER O) 
        {
            try
            {
                StringBuilder sb = new StringBuilder();

                sb.Remove(0, sb.ToString().Length);
                sb.Append(" UPDATE O_ORDER ");
                sb.Append(" SET note =  '" + O.note + "' ");
                sb.Append(" WHERE  Order_ID =  '" + O.Order_ID + "'  ");
                clsGlobal.SQLQUERY.MS_ExecuteNonQuery(sb.ToString());
                return true;

            }
            catch (Exception ex) { return false; throw ex; }
        }
        public static Boolean STOCK(clsPRODUCT S)
        {
            try
            {
                StringBuilder sb = new StringBuilder();

                sb.Remove(0, sb.ToString().Length);
                sb.Append(" UPDATE PRODUCT ");
                sb.Append(" SET Total =  '" + S.Total  + "' ");
                sb.Append(" WHERE  Product_ID =  '" + S.Product_ID + "'  ");
                clsGlobal.SQLQUERY.MS_ExecuteNonQuery(sb.ToString());
                return true;

            }
            catch (Exception ex) { return false; throw ex; }
        }
        public static Boolean PRICESALE(clsPRODUCT P) 
        {
            try
            {
                StringBuilder sb = new StringBuilder();

                sb.Remove(0, sb.ToString().Length);
                sb.Append(" UPDATE PRODUCT ");
                sb.Append(" SET Pricesale =  '" + P.Pricesale + "' ");
                sb.Append(" WHERE  Product_ID =  '" + P.Product_ID + "'  ");
                clsGlobal.SQLQUERY.MS_ExecuteNonQuery(sb.ToString());
                return true;

            }
            catch (Exception ex) { return false; throw ex; }
        }
    }
}
 