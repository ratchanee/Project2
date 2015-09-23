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
            lblUser.Text = Class.clsGlobal.Mem_Name;
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
            this.lbRecode.Text = dgvView.RowCount + "  รายการ".ToString();
        
        }

        private void frmProduct_Load(object sender, EventArgs e)
        {
            btnSearch_Click(sender, e);
            dgvView.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Regular); //ปรับขนาดตัวหนังสือในตาราง
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            var Product = new clsPRODUCT();
            Product.Product_ID = dgvView.Rows[dgvView.CurrentRow.Index].Cells["Product_ID"].Value.ToString().Trim();
            Product.Product_Name = dgvView.Rows[dgvView.CurrentRow.Index].Cells["Product_Name"].Value.ToString().Trim();
            Product.Type_ID = dgvView.Rows[dgvView.CurrentRow.Index].Cells["Type_ID"].Value.ToString().Trim();
            Product.Good_Min = dgvView.Rows[dgvView.CurrentRow.Index].Cells["Good_min"].Value.ToString().Trim();

            //dgvView.Columns ("Pricebuy").DefaultCellStyle.Format = "#,##0.00";
            if (MessageBox.Show("ต้องการลบข้อมูลใช่หรือไม่", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                if (clsDELETE.PRODUCT (Product) == true)
                {
                    MessageBox.Show("ลบข้อมูลเรียบร้อย", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("เกิดข้อผิดพลาดในการลบข้อมูล", "Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                }
                btnSearch_Click(sender, e);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmProductAdd frm = new frmProductAdd("EDIT");
            
            //frm.txtID.Enabled  = true;
            frm.txtID.Text = dgvView.Rows[dgvView.CurrentRow.Index].Cells["Product_ID"].Value.ToString().Trim();
            frm.txtProductName.Text = dgvView.Rows[dgvView.CurrentRow.Index].Cells["Product_Name"].Value.ToString().Trim();
            frm.cbbTypeProduct.Text = dgvView.Rows[dgvView.CurrentRow.Index].Cells["Type_ID"].Value.ToString().Trim();
            frm.txtGoodmin.Text = dgvView.Rows[dgvView.CurrentRow.Index].Cells["Good_min"].Value.ToString().Trim();

            frm.ShowDialog();
            btnSearch_Click(sender, e);

        }
    }
}
