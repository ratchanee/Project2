using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Stock.Class;
using Stock.Interface;

namespace Stock
{
    public partial class frmDelivery : Form
    {
        private string action = "";
        public frmDelivery()
        {
            InitializeComponent();
            lblUser.Text = Class.clsGlobal.Mem_Name;
        }

        private void Delivery_Load(object sender, EventArgs e)
        {
            btnSearch_Click(sender,  e);
            dgvView.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Regular); //ปรับขนาดตัวหนังสือในตาราง
            this.lbRecode.Text = dgvView.RowCount + "  รายการ".ToString(); //นับบรรทัดตาราง
            this.txtStatus.Text = "B";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dgvView.DataSource = clsSELECT.OrderDetail(this.txtOrderID.Text.Trim(), this.dtpDate.Value.ToString("yyyy-MM-dd", cConfigAtt.formatEn), this.txtStatus.Text.Trim()).Tables[0];

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            try
            {
                if (action == "")
                {
                    var frm = new frmViewDelivery();
                    frm.txtIDOrder.Text = dgvView.Rows[dgvView.CurrentRow.Index].Cells["Order_ID"].Value.ToString().Trim();
                    frm.txtDeler.Text = dgvView.Rows[dgvView.CurrentRow.Index].Cells["Dealer_ID"].Value.ToString().Trim();
                   
                    frm.ShowDialog();
                }

            }
            catch (Exception) { MessageBox.Show("ไม่พบข้อมูลการสั่งสินค้า!", "การดำเนินการ", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }
    }

}