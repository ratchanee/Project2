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
    public partial class frmDetailExit : Form
    {
        public frmDetailExit()
        {
            InitializeComponent();
            lblUser.Text = Class.clsGlobal.Mem_Name;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmDetailExit_Load(object sender, EventArgs e)
        {
            btnSearch_Click( sender,  e);
        } 

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            string sql = string.Format("SELECT  DETAIL_EXPIRED.Exp_ID, DETAIL_EXPIRED.Product_ID, DETAIL_EXPIRED.Exp_Total,PRODUCT.Product_Name,CONVERT(VARCHAR, PRODUCT.Pricesale)Pricesale,DETAIL_EXPIRED.Exp_Note FROM  DETAIL_EXPIRED INNER JOIN PRODUCT ON DETAIL_EXPIRED.Product_ID = PRODUCT.Product_ID WHERE DETAIL_EXPIRED.Exp_ID = '" + txtIDExit.Text + "' AND PRODUCT.Product_Name LIKE '%" + txtProduct.Text + "%' ");
            ds = clsGlobal.SQLQUERY.MS_DataAdapter(sql);
            dgvView.DataSource = ds.Tables[0];

            try   //คิดเงินรวม
            {

                double total = 0;
                foreach (DataGridViewRow row in dgvView.Rows)
                {
                    total += Convert.ToDouble(row.Cells["Pricesale"].Value.ToString()) * Convert.ToDouble(row.Cells["Exp_Total"].Value.ToString());
                }
                txtTotal.Text = total.ToString("##,###.00");
            }
            catch
            {

            }
        }

        private void dgvView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try   //คิดเงินรวม
            {
                int n;
                if (!int.TryParse(dgvView.Rows[e.RowIndex].Cells["Exp_Total"].Value.ToString(), out n))
                    return;

                double total = 0;
                foreach (DataGridViewRow row in dgvView.Rows)
                {
                    total += Convert.ToDouble(row.Cells["Pricesale"].Value.ToString()) * Convert.ToDouble(row.Cells["Exp_Total"].Value.ToString());
                }
                txtTotal.Text = total.ToString("##,###.00");
            }
            catch
            {
                dgvView.Rows[e.RowIndex].Cells["Exp_Total"].Value = 0;
            }
        }
    }
}
