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
    public partial class frmViewSale : Form
    {
        private string action = "";
        public frmViewSale()
        {
            InitializeComponent();
            lblUser.Text = Class.clsGlobal.Mem_Name;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            
            dgvView.DataSource = clsSELECT.DetailSale(this.txtIDSale.Text.Trim(), this.dtpDateSent.Value.ToString("yyyy-MM-dd", cConfigAtt.formatEn), this.txtRdb.Text.Trim()).Tables[0];
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                if (action == "")
                {
                    var frm = new frmDetailSale ();
                        frm.txtIDSale.Text = dgvView.Rows[dgvView.CurrentRow.Index].Cells["Sale_ID"].Value.ToString().Trim();

                    frm.ShowDialog();
                }

            }
            catch (Exception) { MessageBox.Show("ไม่พบข้อมูล!", "การดำเนินการ", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        private void rdbW_CheckedChanged(object sender, EventArgs e)
        {
            this.txtRdb.Text = "S";
            btnSearch.PerformClick();
        }

        private void rdbA_CheckedChanged(object sender, EventArgs e)
        {
            this.txtRdb.Text = "E";
            btnSearch.PerformClick();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmViewSale_Load(object sender, EventArgs e)
        {
            
            this.txtRdb.Text = "S";
            btnSearch_Click( sender,  e);
        }
    }
}
