using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Stock.Parameter;
using Stock.Class;

namespace Stock.Interface.Master
{
    public partial class frmProductAdd : Form
    {
        string FUNCTION = "";
        public static string Dealer = "";
       public static string TypeProduct = "";
        public frmProductAdd()
        {
            InitializeComponent();
        }
        public frmProductAdd(string CASE)
        {
            InitializeComponent();
            FUNCTION = CASE;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var frm = new frmProduct();
            frm.ShowDialog();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DataTable dtType = clsSELECT.TypeProduct("", this.cbbTypeProduct.Text.Trim()).Tables[0];
            string Type_ID = dtType.Rows[0]["Type_ID"].ToString();

            DataTable dtDealer = clsSELECT.Dealer("", this.cbbDealer.Text.Trim()).Tables[0];
            string Dealer_ID = dtDealer.Rows[0]["Dealer_ID"].ToString();

           
             if (txtProductName .Text == "")
            {
                MessageBox.Show("กรุณาระบุชื่อตัวแทนจำหน่ายก่อน!", "การดำเนินการ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (txtCost .Text == "")
            {
                MessageBox.Show("กรุณาระบุราคาทุนก่อน!", "การดำเนินการ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (txtSele .Text == "")
            {
                MessageBox.Show("กรุณาระบุราคาขายก่อน!", "การดำเนินการ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (txtTotal.Text == "")
            {
                MessageBox.Show("กรุณาระบุจำนวนสินค้าในสต๊อกก่อน!", "การดำเนินการ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                try
                {
                    var product = new clsPRODUCT();
                    product.Product_ID = this.txtID.Text.Trim();
                    product.Dealer_ID = Dealer_ID;
                    product.Type_ID = Type_ID;
                    product.Product_Name = this.txtProductName.Text.Trim();
                    product.Pricebuy = this.txtCost.Text.Trim();
                    product.Pricesale = this.txtSele.Text.Trim();
                    product.Total = this.txtTotal.Text.Trim();


                    if (FUNCTION == "INSERT")
                    {
                        if (clsINSERT.PRODUCT(product) == true)
                        {
                            MessageBox.Show("บันทึกข้อมูลเรียบร้อย", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("ข้อมูลไม่ถูกต้อง", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        if (clsUPDATE.PRODUCT(product) == true)
                        {
                            MessageBox.Show("บันทึกข้อมูลเรียบร้อย", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("ข้อมูลไม่ถูกต้อง", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }

        private void frmProductAdd_Load(object sender, EventArgs e)
        {
            //this.cbbDealer.SelectedIndex = 0;
            if (FUNCTION == "EDIT")
            {
                this.txtID.ReadOnly = true;
                this.cbbDealer.Text = Dealer;
            }

            //this.cbbTypeProduct.SelectedIndex = 0;
            if (FUNCTION == "EDIT")
            {
                this.txtID.ReadOnly = true;
                this.cbbTypeProduct.Text = TypeProduct;
            }

            DataSet ds = new DataSet();
            string sql = "SELECT * FROM DEALER";
            ds = clsGlobal.SQLQUERY.MS_DataAdapter(sql);
            cbbDealer.DisplayMember = "Dealer_Name"; //เอาชื่อไปโชว์
            cbbDealer.ValueMember = "Dealer_ID"; //เอาค่าไปซ่อนไว้
            cbbDealer.DataSource = ds.Tables[0];
            cbbDealer.SelectedIndex = 0;

            string sql1 = "SELECT * FROM TYPE_PRODUCT";
            ds = clsGlobal.SQLQUERY.MS_DataAdapter(sql1);
            cbbTypeProduct.DisplayMember = "Type_Name"; //เอาชื่อไปโชว์
            cbbTypeProduct.ValueMember = "Type_ID"; //เอาค่าไปซ่อนไว้
            cbbTypeProduct.DataSource = ds.Tables[0];
            cbbTypeProduct.SelectedIndex = 0;
        }

    }
}
