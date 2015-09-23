using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Stock.Class;
using Stock.Interface.Master;

namespace Stock.Interface
{
    public partial class frmSettingPrice : Form
    {
        public frmSettingPrice()
        {
            InitializeComponent();
            lblUser.Text = Class.clsGlobal.Mem_Name;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dgvView.DataSource = clsSELECT.PRODUCT1 (this.txtID.Text.Trim()).Tables[0];
            this.lbRecode.Text = dgvView.RowCount + "  รายการ".ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmStPrice  frm = new frmStPrice ();
            frm.txtID.Text = dgvView.Rows[dgvView.CurrentRow.Index].Cells["Product_ID"].Value.ToString().Trim();
            frm.txtProductName.Text = dgvView.Rows[dgvView.CurrentRow.Index].Cells["Product_Name1"].Value.ToString().Trim();
            frm.txtPrice.Text = dgvView1.Rows[dgvView.CurrentRow.Index].Cells["Price"].Value.ToString().Trim();
            frm.ShowDialog();
        }

        private void frmSettingPrice_Load(object sender, EventArgs e)
        {
            button1_Click( sender,e);
        }

        private void dgvView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string Product_ID = dgvView.Rows[dgvView.CurrentRow.Index].Cells["Product_ID"].Value.ToString().Trim();

            dgvView1.DataSource = clsSELECT.PRODUCTPrice(Product_ID).Tables[0];
            
        }

        private void dgvView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string Product_ID = dgvView.Rows[dgvView.CurrentRow.Index].Cells["Product_ID"].Value.ToString().Trim();

            dgvView2.DataSource = clsSELECT.PRODUCT1(Product_ID).Tables[0];
            btnAdd.Enabled = true;
        }
    }
}
