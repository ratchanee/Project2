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
    public partial class frmDeler : Form
    {
        private string action = "";
        public frmDeler()
        {
            InitializeComponent();
            lblUser.Text = Class.clsGlobal.Mem_Name;
            lblMID .Text = Class.clsGlobal.Mem_ID ;
        }

        DataTable dtGridNull;

        private void frmOrder_Load(object sender, EventArgs e)
        {
            
            DataSet ds = new DataSet();
            string sql = "SELECT * FROM DEALER";
            ds = clsGlobal.SQLQUERY.MS_DataAdapter(sql);
            cbbDealer.DisplayMember = "Dealer_Name"; //เอาชื่อไปโชว์
            cbbDealer.ValueMember = "Dealer_ID"; //เอาค่าไปซ่อนไว้
            cbbDealer.DataSource = ds.Tables[0];
            cbbDealer.SelectedIndex = 0;


            button1_Click( sender, e);
            dgvView.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Regular); //ปรับขนาดตัวหนังสือในตาราง
            this.lbRecode.Text = dgvView.RowCount + "  รายการ".ToString(); //นับบรรทัดตาราง
            this.lbID.Text = clsSELECT.strGenID(); //เลขที่สั่งสินค้า
        }
       
        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            string sql = string.Format(@"SELECT T.Type_Name ,P.Product_ID, Product_Name,CONVERT(VARCHAR,DP.Price)Price,0 AS Total
                                        FROM DETAIL_PRODUCT DP
                                        INNER JOIN PRODUCT P ON DP.Product_ID = P.Product_ID
                                        INNER JOIN TYPE_PRODUCT T ON DP.Type_ID = T.Type_ID   
                                        WHERE DP.Dealer_ID = '{0}'", cbbDealer.SelectedValue.ToString());
            ds = clsGlobal.SQLQUERY.MS_DataAdapter(sql);

            dgvView.DataSource = ds.Tables[0];

            dtGridNull = new DataTable();
            dtGridNull = ds.Tables[0].Copy();
            dtGridNull.Clear();

            this.lbRecode.Text = dgvView.RowCount + "  รายการ".ToString(); //นับบรรทัดตาราง
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (action == "")
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("INSERT INTO O_ORDER(Order_ID ,DateSent ,DateReceive ,Dealer_ID, Mem_ID )");
                    sb.Append("VALUES (");
                    sb.Append(" '" + lbID.Text.Trim() + "' ");
                    sb.Append(" ,'" + dtpDateSent.Value.ToString("MM/dd/yyyy", cConfigAtt.formatEn) + "' ");
                    sb.Append(" ,'" + dtpDateReceive.Value.ToString("MM/dd/yyyy", cConfigAtt.formatEn) + "'");
                    sb.Append(" ,'" + cbbDealer.SelectedValue.ToString() + "'  ");
                    sb.Append(" ,'" + lblMID.Text.Trim() + "' ) ");
                    clsGlobal.SQLQUERY.MS_ExecuteNonQuery(sb.ToString());

                    StringBuilder sbDetail = new StringBuilder();
                    foreach (DataGridViewRow row in dgvView.Rows)
                    {
                        sbDetail.Append(" INSERT INTO DETAIL_ORDER(Order_ID ,Dealer_ID,Product_ID ,Total )");
                        sbDetail.Append(" VALUES( ");
                        sbDetail.Append(" '" + lbID.Text.Trim() + "' ");
                        sbDetail.Append(", '" + cbbDealer .SelectedValue .ToString () + "' ");
                        sbDetail.Append(", '" + row.Cells["Product_ID"].Value.ToString() + "' ");
                        sbDetail.Append(", '" + row.Cells["Total"].Value.ToString() + "' ");
                        sbDetail.Append(" ); ");
                    }

                    clsGlobal.SQLQUERY.MS_ExecuteNonQuery(sbDetail.ToString());
                    MessageBox.Show("บันทึกข้อมูลเรียบร้อย", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnResest_Click(sender, e);
                    this.lbID.Text = clsSELECT.strGenID(); //เลขที่สั่งสินค้า
                }
                
            }
            catch (Exception ) { MessageBox.Show("เกิดข้อผิดพลาดในการสั่งสินค้า!", "การดำเนินการ", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
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
            catch {
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


        private void ResetForm()
        {
            dgvView.DataSource = dtGridNull;
            txtTotal.Text = "";
            cbbDealer.SelectedIndex = 0;
        }

        private void btnResest_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            var frm = new frmDetailOrder();
            frm.ShowDialog();
        }

    }
}
