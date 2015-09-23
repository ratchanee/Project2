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


            if (txtProductName.Text == "")
            {
                MessageBox.Show("กรุณาระบุชื่อสินค้าก่อน!", "การดำเนินการ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (txtID.Text == "")
            { 
            MessageBox .Show ("กรุณาระบุรหัสสินค้าก่อน!", "การดำเนินการ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
                else if (txtGoodmin .Text == "")
            {
                MessageBox.Show("กรุณาระบุจุดสั่งซื้อของสินค้า!", "การดำเนินการ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    var product = new clsPRODUCT();
                    product.Product_ID = this.txtID.Text.Trim();
                    product.Type_ID = Type_ID;
                    product.Product_Name = this.txtProductName.Text.Trim();
                    product.Good_Min = this.txtGoodmin.Text.Trim();

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

            } this.Close();

        }


        private void frmProductAdd_Load(object sender, EventArgs e)
        {
            if (FUNCTION == "EDIT")
            {
                this.txtID.ReadOnly = true;
            }

            if (FUNCTION == "EDIT")
            {
                this.txtID.ReadOnly = true;
                this.cbbTypeProduct.Text = TypeProduct;
            }

            DataSet ds = new DataSet();

            string sql1 = "SELECT * FROM TYPE_PRODUCT";
            ds = clsGlobal.SQLQUERY.MS_DataAdapter(sql1);
            cbbTypeProduct.DisplayMember = "Type_Name"; //เอาชื่อไปโชว์
            cbbTypeProduct.ValueMember = "Type_ID"; //เอาค่าไปซ่อนไว้
            cbbTypeProduct.DataSource = ds.Tables[0];
            cbbTypeProduct.SelectedIndex = 0;
        }

        private void txtID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtID.Text.Length >= 13)  //พิมพ์ได้ 13 ตัว
                e.Handled = true;

            //พิมพ์ได้เฉพาะ 0-9
            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar)
                && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // only allow one decimal point

            if (e.KeyChar == '.'

                && (sender as TextBox).Text.IndexOf('.') > -1)
            {

                e.Handled = true;
            }
        }

        private void txtGoodmin_KeyPress(object sender, KeyPressEventArgs e)
        {
            //พิมพ์ได้เฉพาะ 0-9
            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar)
                && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // only allow one decimal point

            if (e.KeyChar == '.'

                && (sender as TextBox).Text.IndexOf('.') > -1)
            {

                e.Handled = true;
            }
        }
    }
}
           
   

