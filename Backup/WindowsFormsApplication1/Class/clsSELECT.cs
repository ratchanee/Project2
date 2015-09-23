using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Stock.Class
{
    class clsSELECT
    {
        public static DataSet Dealer(string DaelerID, string DealerName)
        { 
            DataSet ds = new DataSet();
            StringBuilder sb = new StringBuilder();
            sb.Remove(0, sb.ToString().Length);
            sb.Append(" SELECT * ");
            sb.Append(" ,Dealer_Name ");
            sb.Append(" FROM DEALER ");
            sb.Append(" WHERE Dealer_ID LIKE '" + DaelerID + "%' ");
            sb.Append(" and Dealer_Name LIKE '" + DealerName + "%' ");
            return ds = clsGlobal.SQLQUERY.MS_DataAdapter(sb.ToString()); 
        }
        public static DataSet TypeProduct(string ID, string strName)
        {
            DataSet ds = new DataSet();
            StringBuilder sb = new StringBuilder();
            sb.Remove(0,sb.ToString().Length);
            sb.Append(" SELECT Type_ID ");
            sb.Append(" ,Type_Name ");
            sb.Append(" FROM TYPE_PRODUCT ");
            sb.Append(" WHERE Type_ID LIKE '" + ID + "%' ");
            sb.Append(" AND Type_Name LIKE '" + strName + "%' ");
            return ds = clsGlobal.SQLQUERY.MS_DataAdapter(sb.ToString());
        }
        public static DataSet MEMBER(string MemBerID, string MemberName)
        {
            DataSet ds = new DataSet();
            StringBuilder sb = new StringBuilder();
            sb.Remove(0, sb.ToString().Length);
            sb.Append(" SELECT * ");
            sb.Append(" FROM MEMBER ");
            sb.Append(" WHERE Mem_ID LIKE '%" + MemBerID + "%' ");
            sb.Append(" AND Mem_Name LIKE '%" + MemberName + "%' ");
            return ds = clsGlobal.SQLQUERY.MS_DataAdapter(sb.ToString());
        }
        public static DataSet PRODUCT(string Product_ID, string Product_Name)
        {
            DataSet ds = new DataSet();

            StringBuilder sb = new StringBuilder();
            sb.Remove(0, sb.ToString().Length);
            sb.Append("SELECT P.Product_ID"); 
	        sb.Append(",P.Product_Name");
	        sb.Append(",T.Type_Name");
	        sb.Append(",D.Dealer_Name"); 
	        sb.Append(",P.Pricebuy");
	        sb.Append(",P.Pricesale");
	        sb.Append(",P.Total");
            sb.Append(",D.Dealer_ID");
            sb.Append(",T.Type_ID");
            sb.Append(" FROM PRODUCT P");
            sb.Append(" INNER JOIN TYPE_PRODUCT T ON P.Type_ID = T.Type_ID");
            sb.Append(" INNER JOIN DEALER D ON P.Dealer_ID = D.Dealer_ID");
            sb.Append(" WHERE Product_ID LIKE '%" + Product_ID + "%' ");
            sb.Append(" AND Product_Name LIKE '%" + Product_Name + "%' ");
            return ds = clsGlobal.SQLQUERY.MS_DataAdapter(sb.ToString());
        }
        public static DataSet ORDER()
        { 
            DataSet ds = new DataSet();
            StringBuilder sb = new StringBuilder();
            sb.Remove(0, sb.ToString().Length);
            sb.Append(" SELECT P.Product_ID ,P.Product_Name , D.Total");
            sb.Append(" FROM DETAIL_ORDER D ");
            sb.Append(" INNER JOIN PRODUCT P ON D.Product_ID =P.Product_ID ");
            //sb.Append(" INNER JOIN MEMBER M ON O.Mem_ID = M.Mem_ID ");
            //sb.Append(" WHERE D.Dealer_Name LIKE '" + Dealer_Name + "%' ");
           
            return ds = clsGlobal.SQLQUERY.MS_DataAdapter(sb.ToString());
        }
        public static DataSet DETAIL_PRODUCT()
        {
            DataSet ds = new DataSet();
            StringBuilder sb = new StringBuilder();
            sb.Remove(0, sb.ToString().Length);
            sb.Append(" SELECT DETAIL_PRODUCT.* ");
            sb.Append(" ,DEALER.Dealer_Name ");
            sb.Append(" ,TYPE_PRODUCT.Type_Name ");
            sb.Append(" ,PRODUCT.Product_Name ");
            sb.Append(" FROM DETAIL_PRODUCT ");
            sb.Append(" INNER JOIN DEALER ON DEALER.Dealer_ID = DETAIL_PRODUCT.Dealer_ID ");
            sb.Append(" INNER JOIN TYPE_PRODUCT ON TYPE_PRODUCT.Type_ID = DETAIL_PRODUCT.Type_ID ");
            sb.Append(" INNER JOIN PRODUCT ON PRODUCT.Product_ID = DETAIL_PRODUCT.Product_ID ");
                    

            return ds = clsGlobal.SQLQUERY.MS_DataAdapter(sb.ToString());
        }
        public static DataSet Dealer1(string Dealer_ID)
        {
            DataSet ds = new DataSet();
            StringBuilder sb = new StringBuilder();
            sb.Remove(0, sb.ToString().Length);
            sb.Append(" SELECT DETAIL_PRODUCT.* ");
            sb.Append(" ,DEALER.Dealer_Name ");
            sb.Append(" ,TYPE_PRODUCT.Type_Name ");
            sb.Append(" ,PRODUCT.Product_Name ");
            sb.Append(" FROM DETAIL_PRODUCT ");
            sb.Append(" INNER JOIN DEALER ON DEALER.Dealer_ID = DETAIL_PRODUCT.Dealer_ID ");
            sb.Append(" INNER JOIN TYPE_PRODUCT ON TYPE_PRODUCT.Type_ID = DETAIL_PRODUCT.Type_ID ");
            sb.Append(" INNER JOIN PRODUCT ON PRODUCT.Product_ID = DETAIL_PRODUCT.Product_ID ");
            sb.Append(" WHERE DEALER.Dealer_ID  LIKE '%" + Dealer_ID + "%'  ");
            return ds = clsGlobal.SQLQUERY.MS_DataAdapter(sb.ToString());
        }
        public static DataSet DETAILORDER(string Dealer_ID)
        {
            DataSet ds = new DataSet();
            StringBuilder sb = new StringBuilder();
            sb.Remove(0, sb.ToString().Length);
            sb.Append(" SELECT O.Order_ID, DE.Dealer_Name  ,T.Type_Name ,P.Product_Name ,d.Total ");
            sb.Append(" FROM DETAIL_ORDER D ");
            sb.Append(" INNER JOIN O_ORDER O ON D.Order_ID  = O.Order_ID   ");
            sb.Append(" INNER JOIN DEALER DE ON D.Dealer_ID = DE.Dealer_ID  ");
            sb.Append(" INNER JOIN TYPE_PRODUCT T ON D.Type_ID  = T.Type_ID   ");
            sb.Append(" INNER JOIN PRODUCT P ON D.Product_ID   = P.Product_ID  ");
            sb.Append(" WHERE D.Dealer_ID  LIKE '%" + Dealer_ID + "%' ");

            return ds = clsGlobal.SQLQUERY.MS_DataAdapter(sb.ToString());
        }
    }
}
               



 

 