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

namespace Stock.Interface
{
    public partial class frmStPrice : Form
    {
        
        private string action = "";
        public frmStPrice()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

            if (txtSale .Text == "")
            {
                MessageBox.Show("กรุณาระบุราคาขายสินค้าก่อน!", "การดำเนินการ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int a = Convert.ToInt32(txtSale.Text);
            int b = Convert.ToInt32(Math.Floor(Convert.ToDouble(txtPrice.Text)));
            if (a < b)
            {
                MessageBox.Show("ราคาทุนมากกกว่าราคาขาย!", "การดำเนินการ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else
            {
                try
                {
                    var Price = new clsPRODUCT();
                    Price.Product_ID = this.txtID.Text.Trim();
                    Price.Product_Name = this.txtProductName.Text.Trim();
                    Price.Pricesale = this.txtSale.Text.Trim();

                    
                    if (action == "")
                    {
                        if (clsUPDATE.PRICESALE(Price) == true)
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

        private void txtSale_KeyPress(object sender, KeyPressEventArgs e)
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
