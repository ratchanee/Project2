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
    public partial class frmViewOrder : Form
    {
        private string action1 = ""; 
        public frmViewOrder()
        {
            InitializeComponent();
            lblUser.Text = Class.clsGlobal.Mem_Name;

        }
        DataTable dtGridNull;
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            string sql = string.Format(@"SELECT O.Order_ID ,P.Product_ID, Product_Name,DP.Price,0 AS Total
                                                    FROM DETAIL_ORDER DO
                                                    INNER JOIN PRODUCT P ON DO.Product_ID = P.Product_ID
                                                    INNER JOIN O_ORDER O ON DO.Order_ID = O.Order_ID
                                                    INNER JOIN DETAIL_PRODUCT DP ON O.Dealer_ID = DP.Dealer_ID");  
////                                        WHERE DP.Dealer_ID = '{0}'",txtIDOrder .Text .Trim ());
            ds = clsGlobal.SQLQUERY.MS_DataAdapter(sql);

            dgvView.DataSource = ds.Tables[0];

            dtGridNull = new DataTable();
            dtGridNull = ds.Tables[0].Copy();
            dtGridNull.Clear();
            dgvView.DataSource = clsSELECT.ViewOrder(this.txtIDOrder.Text.Trim(), this.txtProduct.Text.Trim(), this.txtID.Text.Trim()).Tables[0];

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

        private void frmViewOrder_Load(object sender, EventArgs e)
        {
            btnSearch_Click(sender, e);
            dgvView.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Regular); //ปรับขนาดตัวหนังสือในตาราง
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("ต้องการบันทึกข้อมูลใช่หรือไม่", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
            var Order = new clsORDER();
            Order.Order_ID = dgvView.Rows[dgvView.CurrentRow.Index].Cells["Order_ID"].Value.ToString().Trim();
            Order.Product_ID = dgvView.Rows[dgvView.CurrentRow.Index].Cells["Product_ID"].Value.ToString().Trim();
            Order.Product_Name = dgvView.Rows[dgvView.CurrentRow.Index].Cells["Product_Name"].Value.ToString().Trim();
            Order.Price = dgvView.Rows[dgvView.CurrentRow.Index].Cells["Price"].Value.ToString().Trim();
            Order.Total = dgvView.Rows[dgvView.CurrentRow.Index].Cells["Total"].Value.ToString().Trim();
              if (action1 == "")
                  foreach (DataGridViewRow row in dgvView.Rows)
                  {
                      //if (Convert.ToInt32(row.Cells["Totaol"].Value.ToString()))
                      //{
  
                      //}else{
                      StringBuilder sbUPTOTAL = new StringBuilder();
                      sbUPTOTAL.Append("UPDATE DETAIL_ORDER ");
                      sbUPTOTAL.Append("SET Total = '" + row.Cells["Total"].Value.ToString() + "' ");
                      sbUPTOTAL.Append(" WHERE  Order_ID = '" + row.Cells["Order_ID"].Value.ToString() + "'");
                      sbUPTOTAL.Append(" AND Product_ID = '" + row.Cells["Product_ID"].Value.ToString() + "' ");
                      clsGlobal.SQLQUERY.MS_ExecuteNonQuery(sbUPTOTAL.ToString());
                      //}
                  }
                if (clsUPDATE.ORDEROK(Order) == true)
                { 
                 
                    MessageBox.Show("บันทึกข้อมูลเรียบร้อยแล้ว", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
               
               
                else
                {
                    MessageBox.Show("เกิดข้อผิดพลาด", "Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                }
            } btnSearch_Click(sender, e);
        }

        private void dgvView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
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

        private void dgvView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(tb_KeyPress);
            if (dgvView.CurrentCell.ColumnIndex == dgvView.Columns["Total"].Index) //Desired Column
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(tb_KeyPress);
                }
            }
        }
        void tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

    }
}
