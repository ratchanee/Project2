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
    public partial class frmDetailSale : Form
    {
        public frmDetailSale()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dgvView.DataSource = clsSELECT.ViewSale(this.txtIDSale.Text.Trim(), this.txtProduct.Text.Trim()).Tables[0];
            try   //คิดเงินรวม
            {

                double total = 0;
                foreach (DataGridViewRow row in dgvView.Rows)
                {
                    total += Convert.ToDouble(row.Cells["Pricesale"].Value.ToString()) * Convert.ToDouble(row.Cells["Total"].Value.ToString());
                }
                txtTotal.Text = total.ToString("##,###.00");
            }
            catch
            {

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmDetailSale_Load(object sender, EventArgs e)
        {
            btnSearch_Click( sender,  e);
        }
    }
}
