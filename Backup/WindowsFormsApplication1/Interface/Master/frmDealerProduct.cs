using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Stock.Class;
using Stock.Parameter;
using Stock.Interface.Master;

namespace Stock
{
    public partial class frmDealerProduct : Form
    {
        string FUNCTION = "";
        public frmDealerProduct()
        {
            InitializeComponent();
        }

        public frmDealerProduct(string FormType)
        {
            InitializeComponent();
            FUNCTION = FormType;
        }

        private void frmDealerProduct_Load(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            string sql = "SELECT * FROM TYPE_PRODUCT";
            ds = clsGlobal.SQLQUERY.MS_DataAdapter(sql);
            cbbTypeProduct.DisplayMember = "Type_Name"; //เอาชื่อไปโชว์
            cbbTypeProduct.ValueMember = "Type_ID"; //เอาค่าไปซ่อนไว้
            cbbTypeProduct.DataSource = ds.Tables[0];
            cbbTypeProduct.SelectedIndex = 0;

            DataSet ds1 = new DataSet();
            string sql1 = "SELECT * FROM PRODUCT";
            ds1 = clsGlobal.SQLQUERY.MS_DataAdapter(sql1);
            cbbProduct .DisplayMember = "Product_Name"; //เอาชื่อไปโชว์
            cbbProduct .ValueMember = "Product_ID"; //เอาค่าไปซ่อนไว้
            cbbProduct.DataSource = ds1.Tables[0];
            cbbProduct.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dtProduct = clsSELECT.PRODUCT("", this.cbbProduct.Text.Trim()).Tables[0];
            string Product_ID = dtProduct.Rows[0]["Product_ID"].ToString();

            DataTable dtType = clsSELECT.TypeProduct("", this.cbbTypeProduct.Text.Trim()).Tables[0];
            string Type_ID = dtType.Rows[0]["Type_ID"].ToString();

            DataTable dtDealer = clsSELECT.Dealer("", this.cbbDealer.Text.Trim()).Tables[0];
            string Dealer_ID = dtDealer.Rows[0]["Dealer_ID"].ToString();

            if (txtPrice.Text == "")
            {
                MessageBox.Show("กรุณาระบุราคาสินค้าก่อน!", "การดำเนินการ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                try
                {
                    var Dealer1 = new clsDEALER();
                    Dealer1.Dealer_ID = Dealer_ID;
                    Dealer1.Product_ID = Product_ID;
                    Dealer1.Type_ID = Type_ID;
                    Dealer1.Price = this.txtPrice.Text.Trim();

                    if (FUNCTION == "INSERT")
                    {
                        if (clsINSERT.DEALERPRODUCT(Dealer1) == true)
                        {
                            MessageBox.Show("บันทึกข้อมูลเรียบร้อย", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("ข้อมูลไม่ถูกต้อง", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var frm = new frmDealer ();
            this.Close(); 
            frm.ShowDialog();
        }
    }
}

