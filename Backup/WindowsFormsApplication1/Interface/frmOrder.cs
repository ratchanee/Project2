using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Stock.Class;

namespace Stock.Interface
{
    public partial class frmOrder : Form
    {
        public frmOrder()
        {
            InitializeComponent();
        }

        private void frmOrder_Load(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            string sql = "SELECT * FROM DEALER";
            ds = clsGlobal.SQLQUERY.MS_DataAdapter(sql);
            cbbDealer.DisplayMember = "Dealer_Name"; //เอาชื่อไปโชว์
            cbbDealer.ValueMember = "Dealer_ID"; //เอาค่าไปซ่อนไว้
            cbbDealer.DataSource = ds.Tables[0];
            cbbDealer.SelectedIndex = 0;
            //dgvView.DataSource = clsSELECT.ORDER().Tables[0];
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            string sql = string.Format(@"SELECT T.Type_Name ,P.Product_ID, Product_Name,DP.Price,0 AS Total
                                        FROM DETAIL_PRODUCT DP
                                        INNER JOIN PRODUCT P ON DP.Product_ID = P.Product_ID
                                        INNER JOIN TYPE_PRODUCT T ON DP.Type_ID = T.Type_ID   
                                        WHERE DP.Dealer_ID = '{0}'", cbbDealer.SelectedValue.ToString());
            ds = clsGlobal.SQLQUERY.MS_DataAdapter(sql);

            dgvView.DataSource = ds.Tables[0];
        }
    }
}
