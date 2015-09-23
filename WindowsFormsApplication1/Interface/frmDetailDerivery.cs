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
    public partial class frmDetailDerivery : Form
    {
        public frmDetailDerivery()
        {
            InitializeComponent();
            lblUser.Text = Class.clsGlobal.Mem_Name;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dgvView.DataSource = clsSELECT.DEDerivery(this.txtIDDerivery.Text.Trim(), this.txtProduct.Text.Trim()).Tables[0];

            try   //คิดเงินรวม
            {

                double total = 0;
                foreach (DataGridViewRow row in dgvView.Rows)
                {
                    total += Convert.ToDouble(row.Cells["Price"].Value.ToString()) * Convert.ToDouble(row.Cells["Total"].Value.ToString());
                }
                txtTotal.Text = total.ToString("##,###.00");
            }
            catch
            {

            }
        }

        private void frmDetailDerivery_Load(object sender, EventArgs e)
        {
            btnSearch_Click(sender,  e);
        }

        private void dgvView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            try   //คิดเงินรวม
            {
                int n;
                if (!int.TryParse(dgvView.Rows[e.RowIndex].Cells["Total"].Value.ToString(), out n))
                    return;

                double total = 0;
                foreach (DataGridViewRow row in dgvView.Rows)
                {
                    total += Convert.ToDouble(row.Cells["Price"].Value.ToString()) * Convert.ToDouble(row.Cells["Total"].Value.ToString());
                }
                txtTotal.Text = total.ToString("##,###.00");
            }
            catch
            {
                dgvView.Rows[e.RowIndex].Cells["Total"].Value = 0;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
