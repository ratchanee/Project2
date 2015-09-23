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

namespace Stock.Interface
{
    public partial class frmDetailOrder : Form
    {
        private string action = "";
        public frmDetailOrder()
        {
            InitializeComponent();
            lblUser.Text = Class.clsGlobal.Mem_Name;
            lblMID .Text = Class.clsGlobal.Mem_ID ;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dgvView.DataSource = clsSELECT.DetailOrder(this.txtOrder.Text.Trim(),this.dtpDateSent.Value.ToString("yyyy-MM-dd", cConfigAtt.formatEn),this.txtRdb .Text.Trim()).Tables[0];
            //this.lbRecode.Text = dgvView.RowCount + "  รายการ".ToString();
        }

        private void frmDetailOrder_Load(object sender, EventArgs e)
        {
            btnSearch_Click(sender, e);
                this.txtRdb.Text = "W";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var frm = new frmDeler();
            frm.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
           
 if (MessageBox.Show("กรุณาระบุเหตุผลในการยกเลิกรายการ", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
            var Order = new clsORDER();
            Order.Order_ID = dgvView.Rows[dgvView.CurrentRow.Index].Cells["Order_ID"].Value.ToString().Trim();
            Order.DateSent = dgvView.Rows[dgvView.CurrentRow.Index].Cells["DateSent"].Value.ToString().Trim();
            Order.DateReceive = dgvView.Rows[dgvView.CurrentRow.Index].Cells["DateReceive"].Value.ToString().Trim();
            Order.Mem_ID = lblMID.Text.Trim();
            Order.note = dgvView.Rows[dgvView.CurrentRow.Index].Cells["note"].Value.ToString().Trim();
            Order.Status = dgvView.Rows[dgvView.CurrentRow.Index].Cells["Status"].Value.ToString().Trim();

                var frm = new frmNote();
                frm.txtNote.Text = dgvView.Rows[dgvView.CurrentRow.Index].Cells["note"].Value.ToString().Trim();
                frm.txtID.Text = dgvView.Rows[dgvView.CurrentRow.Index].Cells["Order_ID"].Value.ToString().Trim();
                frm.ShowDialog();

                if (clsUPDATE .ORDERCANCEL(Order) == true)
                {
                    MessageBox.Show("ยกเลิกรายการเรียบร้อยแล้ว", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("เกิดข้อผิดพลาด", "Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                }
            }
            btnSearch_Click( sender,  e);
        }

        private void btnView_Click(object sender, EventArgs e)
        {
             try
            {
                if (action == "")
                {
            var frm = new frmViewOrder();
                if (rdbW.Checked && true)
                frm.btnConfirm.Visible = true;
            frm.txtIDOrder.Text  = dgvView.Rows[dgvView.CurrentRow.Index].Cells["Order_ID"].Value.ToString().Trim();

            frm.ShowDialog();
                }

            }
             catch (Exception) { MessageBox.Show("ไม่พบข้อมูลการสั่งสินค้า!", "การดำเนินการ", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        
        }

        private void rdbW_CheckedChanged(object sender, EventArgs e)
        {
            this.txtRdb.Text = "W";
            btnSearch.PerformClick();
            this.btnDelete.Enabled = true ;
            //this.btnAdd.Enabled = true;
            
        }

        private void rdbA_CheckedChanged(object sender, EventArgs e)
        {
            this.txtRdb.Text = "B";
            btnSearch.PerformClick();
            this.btnDelete.Enabled = false;
            //this.btnAdd.Enabled = false;

        }

        private void rdbC_CheckedChanged(object sender, EventArgs e)
        {
            this.txtRdb.Text = "C";
            btnSearch.PerformClick();
            this.btnDelete.Enabled = false;
            //this.btnAdd.Enabled = false;
        }

        private void lblMID_Click(object sender, EventArgs e)
        {

        }

        private void lblUser_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void dgvView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txtRdb_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtOrder_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dtpDateSent_ValueChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

       
    }
}
