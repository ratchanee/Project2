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
    public partial class frmDeriveryV : Form
    {
        private string action = "";
        public frmDeriveryV()
        {
            InitializeComponent();
            lblUser.Text = Class.clsGlobal.Mem_Name;
        }

        private void frmDeriveryV_Load(object sender, EventArgs e)
        {
            btnSearch_Click(sender, e);
            dgvView.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Regular); //ปรับขนาดตัวหนังสือในตาราง
            this.lbRecode.Text = dgvView.RowCount + "  รายการ".ToString(); //นับบรรทัดตาราง
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dgvView.DataSource = clsSELECT.Derivery(this.txtDeriveryID.Text.Trim(), this.dtpDate.Value.ToString("yyyy-MM-dd", cConfigAtt.formatEn)).Tables[0];
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSelect_Click(object sender, EventArgs e)
        {

            try
            {
                if (action == "")
                {
                    var frm = new frmDetailDerivery ();
                    frm.txtIDDerivery.Text = dgvView.Rows[dgvView.CurrentRow.Index].Cells["DELIVERY_ID"].Value.ToString().Trim();

                    frm.ShowDialog();
                }

            }
            catch (Exception) { MessageBox.Show("ไม่พบข้อมูลการสั่งสินค้า!", "การดำเนินการ", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        
        }

        private void txtDeriveryID_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblUser_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void lbRecode_Click(object sender, EventArgs e)
        {

        }

        private void dgvView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
