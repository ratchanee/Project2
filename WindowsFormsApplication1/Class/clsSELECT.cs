using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Stock.Class
{
    class clsSELECT
    {

        public static DataTable AuthenUser(string Username, string Password)
        {
            string strQuery = string.Format(" Select * From MEMBER WHERE M_User = '{0}' AND M_Pass = '{1}' ", Username, Password);
            return clsGlobal.SQLQUERY.MS_DataAdapter(strQuery).Tables[0];
        }

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
            sb.Append(" SELECT M.Mem_ID ,M.Mem_Name ,CONVERT(VARCHAR,M.Share_Member )Share_Member,M.Status,M.Phone,M.Address,M.M_User,M.M_Pass");
            sb.Append(" FROM MEMBER M ");
            sb.Append(" WHERE M.Mem_ID LIKE '%" + MemBerID + "%' ");
            sb.Append(" AND M.Mem_Name LIKE '%" + MemberName + "%' ");
            return ds = clsGlobal.SQLQUERY.MS_DataAdapter(sb.ToString());
        }

        public static DataSet MEMBERSetting(string MemBerID, string MemberName, string Status) 
        {
            DataSet ds = new DataSet();
            StringBuilder sb = new StringBuilder();
            sb.Remove(0, sb.ToString().Length);
            sb.Append(" SELECT M.Mem_ID ,M.Mem_Name ,M.Status");
            sb.Append(" FROM MEMBER M ");
            sb.Append(" WHERE M.Mem_ID LIKE '%" + MemBerID + "%' ");
            sb.Append(" AND M.Mem_Name LIKE '%" + MemberName + "%' ");
            sb.Append(" AND M.Status LIKE '%" + Status + "%' ");
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
            sb.Append(",T.Type_ID");
            sb.Append(",P.Good_Min");
            sb.Append(",P.Total");
            sb.Append(" FROM PRODUCT P");
            sb.Append(" INNER JOIN TYPE_PRODUCT T ON P.Type_ID = T.Type_ID");
            sb.Append(" WHERE Product_ID LIKE '%" + Product_ID + "%' ");
            sb.Append(" AND Product_Name LIKE '%" + Product_Name + "%' ");
            return ds = clsGlobal.SQLQUERY.MS_DataAdapter(sb.ToString());
        }
        public static DataSet PRODUCTSt(string Product_ID, string Total)
        {
            DataSet ds = new DataSet();

            StringBuilder sb = new StringBuilder();
            sb.Remove(0, sb.ToString().Length);
            sb.Append("SELECT P.Product_ID");
            sb.Append(",P.Total");
            sb.Append(" FROM PRODUCT P");
            sb.Append(" WHERE Product_ID LIKE '%" + Product_ID + "%' ");
            sb.Append(" AND Total LIKE '%" + Total + "%' ");
            return ds = clsGlobal.SQLQUERY.MS_DataAdapter(sb.ToString());
        }
        public static DataSet PRODUCT1(string Product_ID)
        {
            DataSet ds = new DataSet();

            StringBuilder sb = new StringBuilder();
            sb.Remove(0, sb.ToString().Length);
            sb.Append("SELECT P.Product_ID");
            sb.Append(",P.Product_Name");
            sb.Append(" ,CONVERT(VARCHAR,P.Pricesale )Pricesale");
            sb.Append(" FROM PRODUCT P");
            sb.Append(" WHERE Product_ID LIKE '%" + Product_ID + "%' ");
            return ds = clsGlobal.SQLQUERY.MS_DataAdapter(sb.ToString());
        }

        public static DataSet sale(string Sale_ID, string Product_ID)  
        {
            DataSet ds = new DataSet();

            StringBuilder sb = new StringBuilder();
            sb.Remove(0, sb.ToString().Length);
            sb.Append(" SELECT dbo.DETAIL_SALE.Sale_ID, dbo.DETAIL_SALE.Product_ID, dbo.DETAIL_SALE.Total");
            sb.Append(" FROM dbo.DETAIL_SALE ");
            sb.Append(" INNER JOIN dbo.PRODUCT ON dbo.DETAIL_SALE.Product_ID = dbo.PRODUCT.Product_ID ");
            sb.Append(" WHERE dbo.DETAIL_SALE.Sale_ID LIKE  '%"+ Sale_ID +"%' ");
            sb.Append(" AND dbo.DETAIL_SALE.Product_ID LIKE '%" + Product_ID + "%' ");
            return ds = clsGlobal.SQLQUERY.MS_DataAdapter(sb.ToString());
        }

        public static DataSet Cancel(string Exp_ID, string Product_ID)
        {
            DataSet ds = new DataSet();

            StringBuilder sb = new StringBuilder();
            sb.Remove(0, sb.ToString().Length);
            sb.Append("  SELECT dbo.DETAIL_EXPIRED.Exp_ID, dbo.DETAIL_EXPIRED.Product_ID, dbo.DETAIL_EXPIRED.Exp_Total, dbo.DETAIL_EXPIRED.Exp_Note, dbo.PRODUCT.Product_Name, CONVERT(VARCHAR,dbo.PRODUCT.Pricesale )Pricesale");
            sb.Append(" FROM dbo.DETAIL_EXPIRED ");
            sb.Append(" INNER JOIN dbo.PRODUCT ON dbo.DETAIL_EXPIRED.Product_ID = dbo.PRODUCT.Product_ID ");
            sb.Append(" WHERE dbo.DETAIL_EXPIRED.Exp_ID  LIKE  '%" + Exp_ID + "%' ");
            sb.Append(" AND dbo.DETAIL_EXPIRED.Product_ID LIKE '%" + Product_ID + "%' ");
            return ds = clsGlobal.SQLQUERY.MS_DataAdapter(sb.ToString());
        }

        public static DataSet PRODUCT2(string Product_Name)
        {
            DataSet ds = new DataSet();

            StringBuilder sb = new StringBuilder();
            sb.Remove(0, sb.ToString().Length);
            sb.Append("SELECT P.Product_ID");
            sb.Append(",P.Product_Name");
            sb.Append(" ,CONVERT(VARCHAR,P.Pricesale )Pricesale");
            sb.Append(" FROM PRODUCT P");
            sb.Append(" WHERE Product_Name LIKE '%" + Product_Name + "%' ");
            return ds = clsGlobal.SQLQUERY.MS_DataAdapter(sb.ToString());
        }
        public static DataSet PRODUCTPrice(string Product_ID)
        {
            DataSet ds = new DataSet();

            StringBuilder sb = new StringBuilder();
            sb.Remove(0, sb.ToString().Length);
            sb.Append(" SELECT dbo.DELIVERY.DELIVERY_Date,dbo.DETAIL_DELIVERY.Product_ID,CONVERT(VARCHAR,dbo.DETAIL_DELIVERY.Price)Price  ");
            sb.Append(" FROM dbo.DELIVERY ");
            sb.Append(" INNER JOIN dbo.DETAIL_DELIVERY ON dbo.DELIVERY.DELIVERY_ID = dbo.DETAIL_DELIVERY.DELIVERY_ID ");
            sb.Append(" WHERE (dbo.DELIVERY.DELIVERY_Date BETWEEN { fn NOW() } - 3 AND { fn NOW() }) ");
            sb.Append(" AND Product_ID LIKE '%" + Product_ID + "%' ");
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
            sb.Append("  SELECT  D.Dealer_Name ,T.Type_Name ,P.Product_ID,P.Product_Name,CONVERT(VARCHAR,DP.Price)Price");
            sb.Append("  FROM DETAIL_PRODUCT DP ");
            sb.Append(" INNER JOIN DEALER D ON D.Dealer_ID = DP.Dealer_ID  ");
            sb.Append(" INNER JOIN TYPE_PRODUCT T ON T.Type_ID = DP.Type_ID  ");
            sb.Append(" INNER JOIN PRODUCT P ON P.Product_ID = DP.Product_ID ");
            sb.Append(" WHERE D.Dealer_ID  LIKE '%" + Dealer_ID + "%'  ");
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
        public static string strGenID() // รหัสอัตโนมัติสั่งสินค้า
        {
            DataSet ds = new DataSet();
            StringBuilder sb = new StringBuilder();
            sb.Append(" SELECT 'HW' + RIGHT(DATEPART(yy, GETDATE()), 4) +  ");
            sb.Append(" (SELECT RIGHT('0000' + CONVERT(NVARCHAR ");
            sb.Append(" , ISNULL( MAX( SUBSTRING(Order_ID, 7, 4) + 1 ) , 1 ) ), 4)  ");
            sb.Append(" FROM O_ORDER ");
            sb.Append(" WHERE SUBSTRING(Order_ID, 0, 7) = 'HW' +  ");
            sb.Append(" RIGHT(DATEPART(yy, GETDATE()), 4)  ");
            sb.Append(" ) AS ID  ");
            return (String) clsGlobal.SQLQUERY.MS_DataAdapter(sb.ToString()).Tables[0].Rows[0][0];
        }
        public static string strGenIDSale() // รหัสอัตโนมัติรายการขาย
        { 
            DataSet ds = new DataSet();
            StringBuilder sb = new StringBuilder();
            sb.Append(" SELECT 'HW' + RIGHT(DATEPART(yy, GETDATE()), 4) +  ");
            sb.Append(" (SELECT RIGHT('0000' + CONVERT(NVARCHAR ");
            sb.Append(" , ISNULL( MAX( SUBSTRING(Sale_ID, 7, 4) + 1 ) , 1 ) ), 4)  ");
            sb.Append(" FROM SALE ");
            sb.Append(" WHERE SUBSTRING(Sale_ID, 0, 7) = 'HW' +  ");
            sb.Append(" RIGHT(DATEPART(yy, GETDATE()), 4)  ");
            sb.Append(" ) AS ID  ");
            return (String)clsGlobal.SQLQUERY.MS_DataAdapter(sb.ToString()).Tables[0].Rows[0][0];
        }
        public static string strGenIDEXPIRED() // รหัสอัตโนมัติตัดจ่าย 
        {
            DataSet ds = new DataSet();
            StringBuilder sb = new StringBuilder();
            sb.Append(" SELECT 'HW' + RIGHT(DATEPART(yy, GETDATE()), 4) +  ");
            sb.Append(" (SELECT RIGHT('0000' + CONVERT(NVARCHAR ");
            sb.Append(" , ISNULL( MAX( SUBSTRING(Exp_ID, 7, 4) + 1 ) , 1 ) ), 4)  ");
            sb.Append(" FROM EXPIRED ");
            sb.Append(" WHERE SUBSTRING(Exp_ID, 0, 7) = 'HW' +  ");
            sb.Append(" RIGHT(DATEPART(yy, GETDATE()), 4)  ");
            sb.Append(" ) AS ID  ");
            return (String)clsGlobal.SQLQUERY.MS_DataAdapter(sb.ToString()).Tables[0].Rows[0][0];
        }
        public static DataSet DetailOrder(string Order_ID, string DateSent, string Status)    
        {
            DataSet ds = new DataSet();
            StringBuilder sb = new StringBuilder();
            sb.Remove(0, sb.ToString().Length);
            sb.Append(" SELECT O.Order_ID ");
            sb.Append(" , O.DateSent ");
            sb.Append(" ,O.DateReceive ");
            sb.Append(" ,O.Dealer_ID");
            sb.Append(" ,O.note ");
            sb.Append(" ,D.Dealer_Name ");
            sb.Append(" ,M.Mem_Name");
            sb.Append(" , dbo.FUNC_CONVERT_TYPE( O.Status) AS 'Status'");
            sb.Append(" FROM  O_ORDER O ");
            sb.Append(" INNER JOIN MEMBER M ON O.Mem_ID = M.Mem_ID  ");
            sb.Append(" INNER JOIN DEALER D ON O.Dealer_ID = D.Dealer_ID  ");
            sb.Append(" WHERE O.Order_ID LIKE '%" + Order_ID + "%' ");
            sb.Append(" and O.DateSent = '" + DateSent + "' ");
            sb.Append(" and O.Status = '" + Status + "' ");
            return ds = clsGlobal.SQLQUERY.MS_DataAdapter(sb.ToString());
        }
        public static DataSet ViewOrder(string Order_ID, string Product_Name, string ID)
        {
            DataSet ds = new DataSet();
            StringBuilder sb = new StringBuilder();
            sb.Remove(0, sb.ToString().Length);
            sb.Append(" SELECT DO.Order_ID,P.Product_ID,P.Product_Name ,CONVERT(VARCHAR,DP.Price)Price,DO.Total ");
            sb.Append(" FROM DETAIL_ORDER DO ");
            sb.Append(" INNER JOIN PRODUCT  P ON P.Product_ID = DO.Product_ID ");
            sb.Append(" INNER JOIN DETAIL_PRODUCT DP ON DO.Product_ID = DP.Product_ID AND DO.Dealer_ID = DP.Dealer_ID");
            sb.Append(" WHERE DO.Order_ID LIKE '%" + Order_ID + "%' ");
            sb.Append(" AND P.Product_Name LIKE '%" + Product_Name + "%' ");
            sb.Append(" AND DO.ID LIKE '%" + ID + "%' ");
            return ds = clsGlobal.SQLQUERY.MS_DataAdapter(sb.ToString());
        }
        public static DataSet OrderDetail(string Order_ID, string DateSent, string Status)
        {
            DataSet ds = new DataSet();
            StringBuilder sb = new StringBuilder();
            sb.Remove(0, sb.ToString().Length); 
            sb.Append(" SELECT O.Order_ID ");
            sb.Append(" ,O.DateSent ");
            sb.Append(" ,O.DateReceive ");
            sb.Append(" ,O.Mem_ID ");
            sb.Append(" ,M.Mem_Name");
            sb.Append(" ,O.Dealer_ID");
            sb.Append(" ,DE.Dealer_Name ");
            sb.Append(" ,O.note ");
            sb.Append(" , dbo.FUNC_CONVERT_TYPE(O.Status) AS 'Status'");
            sb.Append(" FROM O_ORDER O ");
            sb.Append(" INNER JOIN DEALER DE ON O.Dealer_ID = DE.Dealer_ID  ");
            sb.Append(" INNER JOIN MEMBER M ON O.Mem_ID = M.Mem_ID  ");
            sb.Append(" WHERE O.Order_ID LIKE '%" + Order_ID + "%' ");
            sb.Append(" and O.DateSent = '" + DateSent + "' ");
            sb.Append(" and O.Status  LIKE '%" + Status + "%' ");
            return ds = clsGlobal.SQLQUERY.MS_DataAdapter(sb.ToString());
        }
        public static string strGenIDDelivery() // รหัสอัตโนมัติรับ 
        {
            DataSet ds = new DataSet(); 
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT 'HW' + RIGHT(DATEPART(yy, GETDATE()), 4) +   ");
            sb.Append(" (SELECT  ");
            sb.Append(" RIGHT('0000' + CONVERT(NVARCHAR , ISNULL( MAX( SUBSTRING ");
            sb.Append("(DELIVERY_ID, 7, 4) + 1 ) , 1 ) ), 4)   FROM DELIVERY WHERE SUBSTRING(DELIVERY_ID , 0, 7) = 'HW' +  ");
            sb.Append(" RIGHT(DATEPART(yy, GETDATE()), 4) ");
            sb.Append(") AS ID  ");
            return (String)clsGlobal.SQLQUERY.MS_DataAdapter(sb.ToString()).Tables[0].Rows[0][0];
        }
        public static DataSet SETTINGPRICE(string Product_ID) 
        { 
            DataSet ds = new DataSet();
            StringBuilder sb = new StringBuilder();
            sb.Remove(0, sb.ToString().Length);
            sb.Append(" select  DD.Product_ID, MAX(CONVERT(VARCHAR,DD.Price)) AS MAXPRICE ");
            sb.Append(" from DETAIL_DELIVERY DD ");
            sb.Append(" inner join DELIVERY D on DD.DELIVERY_ID = D.DELIVERY_ID");
            sb.Append(" WHERE DD.Product_ID LIKE '%" + Product_ID + "%' ");
            sb.Append(" GROUP BY D.Dealer_ID, DD.Product_ID ");
            return ds = clsGlobal.SQLQUERY.MS_DataAdapter(sb.ToString());
        }
        public static DataSet ViewOrderConfirm(string Order_ID, string Product_Name, string ID) 
        {
            DataSet ds = new DataSet();
            StringBuilder sb = new StringBuilder();
            sb.Remove(0, sb.ToString().Length);
            sb.Append(" SELECT DO.Order_ID,P.Product_ID,P.Product_Name ,CONVERT(VARCHAR,DP.Price)Price,DO.Total,DO.TotalDerivery  ");
            sb.Append(" FROM DETAIL_ORDER DO ");
            sb.Append(" INNER JOIN PRODUCT  P ON P.Product_ID = DO.Product_ID ");
            sb.Append(" INNER JOIN DETAIL_PRODUCT DP ON DO.Product_ID = DP.Product_ID AND DO.Dealer_ID = DP.Dealer_ID");
            sb.Append(" WHERE DO.Order_ID LIKE '%" + Order_ID + "%' ");
            sb.Append(" AND P.Product_Name LIKE '%" + Product_Name + "%' ");
            sb.Append(" AND DO.Total > 0 ");
            sb.Append(" AND DO.ID LIKE '%" + ID + "%' ");
            return ds = clsGlobal.SQLQUERY.MS_DataAdapter(sb.ToString());
        }
        public static DataSet Derivery(string DELIVERY_ID, string DELIVERY_Date) 
        {
            DataSet ds = new DataSet();
            StringBuilder sb = new StringBuilder();
            sb.Remove(0, sb.ToString().Length);
            sb.Append("SELECT D.DELIVERY_ID , D. Dealer_ID,DE.Dealer_Name ,D.DELIVERY_Date,D.Mem_ID,M.Mem_Name");
            sb.Append(" FROM DELIVERY D");
            sb.Append(" INNER JOIN DEALER DE ON DE.Dealer_ID = D.Dealer_ID");
            sb.Append(" INNER JOIN MEMBER M ON M.Mem_ID = D.Mem_ID");
            sb.Append(" WHERE DELIVERY_ID LIKE '" + DELIVERY_ID + "%' ");
            sb.Append(" and DELIVERY_Date = '" + DELIVERY_Date + "' ");
           
            return ds = clsGlobal.SQLQUERY.MS_DataAdapter(sb.ToString());
        }
        public static DataSet DEDerivery(string DELIVERY_ID, string Product_Name) 
        {
            DataSet ds = new DataSet();
            StringBuilder sb = new StringBuilder();
            sb.Remove(0, sb.ToString().Length);
            sb.Append(" SELECT DD.DELIVERY_ID , DD. Product_ID,P.Product_Name,CONVERT(VARCHAR,DD.Price)Price ,DD.Total ");
            sb.Append(" FROM DETAIL_DELIVERY DD  ");
            sb.Append(" INNER JOIN PRODUCT P ON P.Product_ID = DD.Product_ID");
            sb.Append(" WHERE DELIVERY_ID LIKE '" + DELIVERY_ID + "%' ");
            sb.Append(" AND Product_Name LIKE'%" + Product_Name + "%' ");
            sb.Append(" AND DD.Total > 0  ");

            return ds = clsGlobal.SQLQUERY.MS_DataAdapter(sb.ToString());
        }
        public static DataSet DetailSale(string Sale_ID, string Sale_Date, string Status)  
        {

            DataSet ds = new DataSet();
            StringBuilder sb = new StringBuilder();
            sb.Remove(0, sb.ToString().Length);
            sb.Append(" SELECT dbo.SALE.Sale_ID ");
            sb.Append(", dbo.SALE.Sale_Date ");
            sb.Append(" , dbo.SALE.Time ");
            sb.Append("  , CONVERT(VARCHAR,dbo.SALE.Price)Price");
            sb.Append(" , dbo.FUNC_CONVERT_TYPE( dbo.SALE.Status) AS 'Status' ");
            sb.Append(" , dbo.SALE.Mem_ID ");
            sb.Append(" , dbo.MEMBER.Mem_Name");
            sb.Append(" FROM dbo.SALE ");
            sb.Append(" INNER JOIN dbo.MEMBER ON dbo.SALE.Mem_ID = dbo.MEMBER.Mem_ID ");
            sb.Append(" WHERE dbo.SALE.Sale_ID LIKE '%" + Sale_ID + "%' ");
            sb.Append(" and dbo.SALE.Sale_Date = '" + Sale_Date + "' ");
            sb.Append(" and dbo.SALE.Status LIKE '%" + Status + "%' ");
            return ds = clsGlobal.SQLQUERY.MS_DataAdapter(sb.ToString());
        }
        public static DataSet ViewSale(string Sale_ID, string Product_Name)  
        {
            DataSet ds = new DataSet();
            StringBuilder sb = new StringBuilder();
            sb.Remove(0, sb.ToString().Length);
            sb.Append(" SELECT DS.Sale_ID, DS.Product_ID, P.Product_Name, CONVERT(VARCHAR,P.Pricesale)Pricesale, DS.Total ");
            sb.Append(" FROM  DETAIL_SALE DS ");
            sb.Append(" INNER JOIN SALE  S ON DS.Sale_ID = S.Sale_ID ");
            sb.Append(" INNER JOIN PRODUCT  P ON DS.Product_ID = P.Product_ID ");
            sb.Append(" WHERE DS.Sale_ID LIKE '%" + Sale_ID + "%' ");
            sb.Append(" AND P.Product_Name LIKE '%" + Product_Name + "%' ");
            return ds = clsGlobal.SQLQUERY.MS_DataAdapter(sb.ToString());
        }
    }
}
 
