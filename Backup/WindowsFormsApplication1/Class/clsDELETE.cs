using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stock.Parameter;

namespace Stock.Class
{
    class clsDELETE
    {
         public static Boolean MEMBER(clsMember  M)
            {
                try
                {
                    StringBuilder sb = new StringBuilder();

                    sb.Remove(0, sb.ToString().Length);
                    sb.Append(" DELETE ");
                    sb.Append(" FROM MEMBER ");
                    sb.Append(" WHERE Mem_ID = '" + M.Mem_ID + "'");

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
                 sb.Append(" DELETE ");
                 sb.Append(" FROM PRODUCT ");
                 sb.Append(" WHERE Product_ID = '" + M.Product_ID + "'");

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
                 sb.Append(" DELETE ");
                 sb.Append(" FROM DEALER ");
                 sb.Append(" WHERE Dealer_ID = '" + M.Dealer_ID + "'");

                 clsGlobal.SQLQUERY.MS_ExecuteNonQuery(sb.ToString());
                 return true;
             }
             catch (Exception ex) { return false; throw ex; }
         }
         public static Boolean Dealer1(clsDEALER  M)
         {
             try
             {
                 StringBuilder sb = new StringBuilder();

                 sb.Remove(0, sb.ToString().Length);
                 sb.Append(" DELETE ");
                 sb.Append(" FROM DETAIL_PRODUCT ");
                 sb.Append(" WHERE Product_ID = '" + M.Dealer_ID + "'");

                 clsGlobal.SQLQUERY.MS_ExecuteNonQuery(sb.ToString());
                 return true;
             }
             catch (Exception ex) { return false; throw ex; }
         }
    }
    }

