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
    public partial class frmViewDelivery : Form
    {
        private string action1 = ""; 
        private string action = "";
        DataTable dtGridNull;
        public frmViewDelivery()
        {
            InitializeComponent();
            lblUser.Text = Class.clsGlobal.Mem_Name;
            lblMID.Text = Class.clsGlobal.Mem_ID ;

        }

        private void frmViewDelivery_Load(object sender, EventArgs e)
        {
            this.lbID.Text = clsSELECT.strGenIDDelivery();//เลขที่รับสินค้า
            btnSearch_Click(sender, e);
            dgvView.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Regular); //ปรับขนาดตัวหนังสือในตาราง

           
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            string sql = string.Format(@"SELECT O.Order_ID ,P.Product_ID, Product_Name,0 AS Total
                                                                FROM DETAIL_ORDER DO
                                                                INNER JOIN PRODUCT P ON DO.Product_ID = P.Product_ID
                                                                INNER JOIN O_ORDER O ON DO.Order_ID = O.Order_ID");
            ////                                        WHERE DP.Dealer_ID = '{0}'",txtIDOrder .Text .Trim ());
            ds = clsGlobal.SQLQUERY.MS_DataAdapter(sql);

            dgvView.DataSource = ds.Tables[0];

            dtGridNull = new DataTable();
            dtGridNull = ds.Tables[0].Copy();
            dtGridNull.Clear();
            dgvView.DataSource = clsSELECT.ViewOrderConfirm(this.txtIDOrder.Text.Trim(), this.txtProduct.Text.Trim(), this.txt.Text.Trim()).Tables[0];

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

        private void dgvView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try   //คิดเงินรวม
            {
                int n;
                if (!int.TryParse(dgvView.Rows[e.RowIndex].Cells["TotalDerivery"].Value.ToString(), out n))
                    return;

                double total = 0;
                foreach (DataGridViewRow row in dgvView.Rows)
                {
                    total += Convert.ToDouble(row.Cells["Price"].Value.ToString()) * Convert.ToDouble(row.Cells["TotalDerivery"].Value.ToString());
                }
                txtTotal.Text = total.ToString("##,###.00");
            }
            catch
            {
                dgvView.Rows[e.RowIndex].Cells["TotalDerivery"].Value = 0;
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {

                var Order = new clsORDER();
                Order.Order_ID = dgvView.Rows[dgvView.CurrentRow.Index].Cells["Order_ID"].Value.ToString().Trim();
                Order.Product_ID = dgvView.Rows[dgvView.CurrentRow.Index].Cells["Product_ID"].Value.ToString().Trim();
                Order.Product_Name = dgvView.Rows[dgvView.CurrentRow.Index].Cells["Product_Name"].Value.ToString().Trim();
                Order.Price = dgvView.Rows[dgvView.CurrentRow.Index].Cells["Price"].Value.ToString().Trim();
                Order.Total = dgvView.Rows[dgvView.CurrentRow.Index].Cells["Total"].Value.ToString().Trim();

                var Stock = new clsPRODUCT();
                Stock.Product_ID = dgvView.Rows[dgvView.CurrentRow.Index].Cells["Product_ID"].Value.ToString().Trim();
                Stock.Product_Name = dgvView.Rows[dgvView.CurrentRow.Index].Cells["Product_Name"].Value.ToString().Trim();
                Stock.Total = dgvView.Rows[dgvView.CurrentRow.Index].Cells["Total"].Value.ToString().Trim();

                if (MessageBox.Show("ต้องการบันทึกข้อมูลใช่หรือไม่", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                if (action == "")
                {  //รับสินค้า
                    StringBuilder sb = new StringBuilder();
                    sb.Append("INSERT INTO DELIVERY(DELIVERY_ID ,Dealer_ID ,DELIVERY_Date ,Mem_ID)");
                    sb.Append("VALUES (");
                    sb.Append(" '" + lbID.Text.Trim() + "' ");
                    sb.Append(" ,'" + txtDeler .Text.Trim() + "' ");
                    sb.Append(" ,'" + dtpDateReceive.Value.ToString("MM/dd/yyyy", cConfigAtt.formatEn) + "'");
                    sb.Append(" ,'" + lblMID.Text.Trim() + "' ) ");
                    clsGlobal.SQLQUERY.MS_ExecuteNonQuery(sb.ToString());

                    StringBuilder sbDetail = new StringBuilder();
                    
                    foreach (DataGridViewRow row in dgvView.Rows)
                    {  //รายละเอียดการรับ
                        sbDetail.Append(" INSERT INTO DETAIL_DELIVERY(DELIVERY_ID ,Product_ID,Price ,Total )");
                        sbDetail.Append(" VALUES( ");
                        sbDetail.Append(" '" + lbID.Text.Trim() + "' ");
                        sbDetail.Append(", '" + row.Cells["Product_ID"].Value.ToString() + "' ");
                        sbDetail.Append(", '" + row.Cells["Price"].Value.ToString() + "' ");
                        sbDetail.Append(", '" + row.Cells["TotalDerivery"].Value.ToString() + "' ");
                        sbDetail.Append(" ); ");

                        if (action1 == "") // เพิ่มสินค้าเข้าสต๊อก
                        {
                            StringBuilder sbUPSTOCK = new StringBuilder();
                            sbUPSTOCK.Append("update dbo.PRODUCT set Total =  ");
                            sbUPSTOCK.Append("Total + " + row.Cells["TotalDerivery"].Value.ToString());
                            sbUPSTOCK.Append(" where  Product_ID = '" + row.Cells["Product_ID"].Value.ToString() + "'" );
                            clsGlobal.SQLQUERY.MS_ExecuteNonQuery(sbUPSTOCK.ToString());
                        }
                        

                    }
                    clsGlobal.SQLQUERY.MS_ExecuteNonQuery(sbDetail.ToString());
                   
  
                }

                if (clsUPDATE.DERIVERYOK(Order) == true) // อัพเดดสถานะ
                {
                   
                        MessageBox.Show("บันทึกข้อมูลเรียบร้อยแล้ว", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                 }
               
                else
                {
                    MessageBox.Show("เกิดข้อผิดพลาด", "Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                }
            } 
            }
            catch (Exception) { MessageBox.Show("เกิดข้อผิดพลาดในการรับสินค้า!", "การดำเนินการ", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        
        }

        private void dgvView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            //พิมพ์เฉพาะตัวเลขในตาราง
             e.Control.KeyPress -= new KeyPressEventHandler(tb_KeyPress);
            if (dgvView.CurrentCell.ColumnIndex == dgvView.Columns["TotalDerivery"].Index) //Desired Column
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

      

        }
    }

