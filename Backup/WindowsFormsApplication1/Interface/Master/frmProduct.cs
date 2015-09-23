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

namespace Stock.Interface.Master
{
    public partial class frmProduct : Form
    {
        public frmProduct()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close ();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var frm = new frmProductAdd("INSERT");
            frm.ShowDialog();
            btnSearch_Click(sender, e);
        }

  
        private void btnSearch_Click(object sender, EventArgs e)
        {
            dgvView.DataSource = clsSELECT.PRODUCT (this.txtID .Text.Trim(), this.txtName .Text.Trim()).Tables[0];
        
        }

        private void frmProduct_Load(object sender, EventArgs e)
        {
            btnSearch_Click(sender, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var Product = new clsPRODUCT();
            Product.Product_ID = dgvView.Rows[dgvView.CurrentRow.Index].Cells["Product_ID"].Value.ToString().Trim();
            Product.Product_Name = dgvView.Rows[dgvView.CurrentRow.Index].Cells["Product_Name"].Value.ToString().Trim();
            Product.Pricebuy = dgvView.Rows[dgvView.CurrentRow.Index].Cells["Pricebuy"].Value.ToString().Trim();
            Product.Pricesale = dgvView.Rows[dgvView.CurrentRow.Index].Cells["Pricesale"].Value.ToString().Trim();
            Product.Total = dgvView.Rows[dgvView.CurrentRow.Index].Cells["Total"].Value.ToString().Trim();
            Product.Dealer_ID = dgvView.Rows[dgvView.CurrentRow.Index].Cells["Dealer_ID"].Value.ToString().Trim();
            Product.Type_ID = dgvView.Rows[dgvView.CurrentRow.Index].Cells["Type_ID"].Value.ToString().Trim();
            if (MessageBox.Show("ต้องการลบข้อมูลใช่หรือไม่", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                if (clsDELETE.PRODUCT (Product) == true)
                {
                    MessageBox.Show("DE OK", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("DE NOT OK", "Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                }
                btnSearch_Click(sender, e);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmProductAdd frm = new frmProductAdd("EDIT");
            
            frm.txtID.Visible = true;
            frm.txtID.Text = dgvView.Rows[dgvView.CurrentRow.Index].Cells["Product_ID"].Value.ToString().Trim();
            frm.txtProductName.Text = dgvView.Rows[dgvView.CurrentRow.Index].Cells["Product_Name"].Value.ToString().Trim();
            frm.txtCost.Text = dgvView.Rows[dgvView.CurrentRow.Index].Cells["Pricebuy"].Value.ToString().Trim();
            frm.txtSele.Text = dgvView.Rows[dgvView.CurrentRow.Index].Cells["Pricesale"].Value.ToString().Trim();
            frm.txtTotal.Text = dgvView.Rows[dgvView.CurrentRow.Index].Cells["Total"].Value.ToString().Trim();
            frm.cbbTypeProduct.Text = dgvView.Rows[dgvView.CurrentRow.Index].Cells["Type_ID"].Value.ToString().Trim();
            frm.cbbDealer.Text = dgvView.Rows[dgvView.CurrentRow.Index].Cells["Dealer_ID"].Value.ToString().Trim();
           
            frm.ShowDialog();
            btnSearch_Click(sender, e);

             
        }
    }
}
