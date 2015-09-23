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
using System.Data.SqlClient;
using Stock.Interface;

namespace Stock
{
    public partial class frmExit : Form
    {
        private string action = "";
        private string action1 = ""; 
        public frmExit()
        {
            InitializeComponent();
            lblUser1.Text = Class.clsGlobal.Mem_Name;
            lblMID .Text = Class.clsGlobal.Mem_ID ;
        }
        DataTable dtGridNull;

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmExit_Load(object sender, EventArgs e)
        {
            btnSearch_Click(sender, e);
            this.lbID.Text = clsSELECT.strGenIDEXPIRED(); //เลขที่ตัดจ่าย
           
            try   //คิดเงินรวม
            {
                double total = 0;
                foreach (DataGridViewRow row in dgvView.Rows)
                {
                    total += Convert.ToDouble(row.Cells["Pricesale"].Value.ToString()) * Convert.ToDouble(row.Cells["Exp_Total"].Value.ToString());
                }
                txtSum.Text = total.ToString("##,###.00");
            }
            catch
            {

            }

        
}

        private void button5_Click(object sender, EventArgs e)
        {
            DataTable dt = clsSELECT.Cancel(this.lbID.Text.Trim(), this.txtPID.Text.Trim()).Tables[0];
            if (dt.Rows.Count < 0)
            {
                string ProductID = dt.Rows[0]["Product_ID"].ToString();
            }
          
             if (txtPID.Text.Trim() == "")
            {
                MessageBox.Show("กรุณระบุเบอร์ชื่อสินค้า!", "การดำเนินการ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
                 else if (txtTotal.Text.Trim() == "")
            {
                MessageBox.Show("กรุณระบุจำนวนสินค้า!", "การดำเนินการ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (txtNote.Text.Trim() == "")
            {
                MessageBox.Show("กรุณาระบุเหตุผลในการยกเลิกขาย!", "การดำเนินการ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
             else if (Convert.ToDecimal(txtTotal.Text) > Convert.ToDecimal(txtStock.Text))
             {
                 MessageBox.Show("จำนวนสินค้าที่ตัดจ่ายเกินจำนวนสินค้าที่มีในสต๊อก!", "การดำเนินการ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                 return;
             }
            else
            {

                try
                {
                    var Canael = new clsCancel ();
                    Canael.Exp_ID = this.lbID.Text.Trim();
                    Canael.Product_ID = this.txtPID.Text.Trim();
                    Canael.Exp_Total = this.txtTotal .Text.Trim();
                    Canael.Exp_Note = this.txtNote .Text.Trim();

                    if (dt.Rows.Count == 0)
                    {
                        if (clsINSERT.EXCANCEL(Canael) == true)
                        {
                            StringBuilder sbUPSTOCK = new StringBuilder();
                            sbUPSTOCK.Append("update dbo.PRODUCT set Total =  ");
                            sbUPSTOCK.Append("Total - '" + txtTotal.Text.Trim() + "'");
                            sbUPSTOCK.Append(" where  Product_ID = '" + txtPID.Text.Trim() + "'");
                            clsGlobal.SQLQUERY.MS_ExecuteNonQuery(sbUPSTOCK.ToString());
                        }
                        else
                        {
                            MessageBox.Show("ข้อมูลไม่ถูกต้อง", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }

                    else
                    {
                        StringBuilder sbUP = new StringBuilder();
                        sbUP.Append("update DETAIL_EXPIRED set Exp_Total =  ");
                        sbUP.Append("Exp_Total + " + txtTotal.Text.Trim());
                        sbUP.Append(" where  Exp_ID = '" + lbID.Text.Trim() + "'");
                        sbUP.Append(" and  Product_ID = '" + txtPID.Text.Trim() + "'");
                        clsGlobal.SQLQUERY.MS_ExecuteNonQuery(sbUP.ToString());

                        StringBuilder sbUPSTOCK = new StringBuilder();
                        sbUPSTOCK.Append("update dbo.PRODUCT set Total =  ");
                        sbUPSTOCK.Append("Total - '" + txtTotal.Text.Trim() + "'");
                        sbUPSTOCK.Append(" where  Product_ID = '" + txtPID.Text.Trim() + "'");
                        clsGlobal.SQLQUERY.MS_ExecuteNonQuery(sbUPSTOCK.ToString());

                    }
                 }
               catch (Exception) { MessageBox.Show("เกิดข้อผิดพลาดในการตัดจ่ายสินค้า!", "การดำเนินการ", MessageBoxButtons.OK, MessageBoxIcon.Warning); }

                }

            btnSearch_Click(sender, e);
            this.lbID.Text = clsSELECT.strGenIDEXPIRED(); //เลขที่ตัดจ่าย
            this.txtPName.Clear();
            this.txtPID.Clear();
            this.txtNote.Clear();
            this.txtTotal.Clear();
            }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                dgvView.Rows[dgvView.CurrentRow.Index].Cells["Exp_ID"].Value.ToString().Trim();

                if (MessageBox.Show("ต้องการบันทึกข้อมูลใช่หรือไม่", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    if (action1 == "")
                    {
                        foreach (DataGridViewRow row in dgvView.Rows)
                        {
                            StringBuilder sbDetail = new StringBuilder();
                            sbDetail.Append(" UPDATE DETAIL_EXPIRED SET Exp_Total = '" + row.Cells["Exp_Total"].Value.ToString() + "' ");
                            sbDetail.Append(" ,Exp_Note = '" + row.Cells["Exp_Note"].Value.ToString() + "' ");
                            sbDetail.Append("  WHERE Exp_ID = '" + lbID.Text.Trim() + "' ");
                            sbDetail.Append(" AND Product_ID = '" + row.Cells["Product_ID"].Value.ToString() + "' ");
                           clsGlobal.SQLQUERY.MS_ExecuteNonQuery(sbDetail.ToString());
                        } 
                        
                        //ตัดจ่าย
                        StringBuilder sb = new StringBuilder();
                        sb.Append("INSERT INTO EXPIRED(Exp_ID ,Exp_Date ,Mem_ID )");
                        sb.Append("VALUES (");
                        sb.Append(" '" + lbID.Text.Trim() + "' ");
                        sb.Append(" ,'" + dtpDate.Value.ToString("MM/dd/yyyy", cConfigAtt.formatEn) + "'");
                        sb.Append(" ,'" + lblMID.Text.Trim() + "' ) ");
                        clsGlobal.SQLQUERY.MS_ExecuteNonQuery(sb.ToString());
 MessageBox.Show("บันทึกเรียบร้อย", "การดำเนินการ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        
                    }
                    btnSearch_Click(sender, e);
                    this.lbID.Text = clsSELECT.strGenIDEXPIRED(); //เลขที่ตัดจ่าย
                    this.txtSum.Clear();
                }
                else
                { 
                    StringBuilder sb = new StringBuilder();
                    sb.Append(" DELETE DETAIL_EXPIRED WHERE Exp_ID = '" + lbID.Text.Trim() + "'   ");
                    clsGlobal.SQLQUERY.MS_ExecuteNonQuery(sb.ToString());
                    //อัพเดดสต๊อก
                        foreach (DataGridViewRow row in dgvView.Rows)
                        {
                            StringBuilder sbUPSTOCK = new StringBuilder();
                            sbUPSTOCK.Append("update dbo.PRODUCT set Total =  ");
                            sbUPSTOCK.Append("Total - " + row.Cells["Exp_Total"].Value.ToString());
                            sbUPSTOCK.Append(" where  Product_ID = '" + row.Cells["Product_ID"].Value.ToString() + "'");
                            clsGlobal.SQLQUERY.MS_ExecuteNonQuery(sbUPSTOCK.ToString());
   
                        }
                } 
                
            }
            catch (Exception)
            {
                MessageBox.Show("เกิดข้อผิดพลาด!", "การดำเนินการ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            btnSearch_Click(sender, e);
        }
        private void ResetForm()
        {
            dgvView.DataSource = dtGridNull;
        }
        private void btnResest_Click(object sender, EventArgs e)
        {
            ResetForm();
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
                txtSum .Text = total.ToString("##,###.00");
            }
            catch
            {
                dgvView.Rows[e.RowIndex].Cells["Exp_Total"].Value = 0;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                var Cancel = new clsCancel();
                Cancel.Exp_ID = dgvView.Rows[dgvView.CurrentRow.Index].Cells["Exp_ID"].Value.ToString().Trim();
                Cancel.Product_ID = dgvView.Rows[dgvView.CurrentRow.Index].Cells["Product_ID"].Value.ToString().Trim();
                Cancel.Pricesale = dgvView.Rows[dgvView.CurrentRow.Index].Cells["Pricesale"].Value.ToString().Trim();
                Cancel.Exp_Total = dgvView.Rows[dgvView.CurrentRow.Index].Cells["Exp_Total"].Value.ToString().Trim();


                if (MessageBox.Show("ต้องการลบข้อมูลใช่หรือไม่", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (clsDELETE.DECANCEL(Cancel) == true)
                    {
                            StringBuilder sbUPSTOCK = new StringBuilder();
                            sbUPSTOCK.Append("update dbo.PRODUCT set Total =  ");
                            sbUPSTOCK.Append("Total + '" + Cancel.Exp_Total + "'");
                            sbUPSTOCK.Append(" where  Product_ID = '" + Cancel.Product_ID + "'");
                            clsGlobal.SQLQUERY.MS_ExecuteNonQuery(sbUPSTOCK.ToString());
                        
                        MessageBox.Show("ลบข้อมูลสำเร็จ", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("ลบข้อมูลไม่สำเร็จ", "Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("เกิดข้อผิดพลาด!", "การดำเนินการ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            btnSearch_Click( sender,  e);
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            //DataSet ds = new DataSet();
            //string sql = string.Format(" SELECT Product_ID FROM PRODUCT ");
            //ds = clsGlobal.SQLQUERY.MS_DataAdapter(sql);

            //this.txtID.Text = string.Format(" SELECT Product_ID FROM PRODUCT "); 

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

            if (radioButton1.Checked == true)
            {
                DataSet ds = new DataSet();
                var customers = new AutoCompleteStringCollection();
                string sql = string.Format(" SELECT Product_Name FROM PRODUCT ");
                ds = clsGlobal.SQLQUERY.MS_DataAdapter(sql);
                foreach (DataRow str in ds.Tables[0].Rows)
                {
                    customers.Add(str["Product_Name"].ToString());
                }
                txtProductID.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                txtProductID.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtProductID.AutoCompleteCustomSource = customers;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                DataSet ds = new DataSet();
                var customers = new AutoCompleteStringCollection();
                string sql = string.Format(" SELECT Product_ID FROM PRODUCT ");
                ds = clsGlobal.SQLQUERY.MS_DataAdapter(sql);
                foreach (DataRow str in ds.Tables[0].Rows)
                {
                    customers.Add(str["Product_ID"].ToString());
                }
                txtProductID.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                txtProductID.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtProductID.AutoCompleteCustomSource = customers;
            }
        }
        private void SelectProduct(string strText, int intType)
        {
            try
            {
                DataTable dt = new DataTable();
                string Condition = " WHERE ";
                if (intType == 0)
                {
                    Condition += " Product_ID = '" + strText + "'";
                }
                else if (intType == 1)
                {
                    Condition += " Product_Name = '" + strText + "' ";
                }
                else if (intType == 2)
                {
                    Condition += " Total = '" + strText + "' ";
                }

                string sql = " SELECT Product_ID, Product_Name,Total FROM PRODUCT " + Condition;
                dt = clsGlobal.SQLQUERY.MS_DataAdapter(sql).Tables[0];

                txtPID.Text = dt.Rows[0]["Product_ID"].ToString();
                txtPName.Text = dt.Rows[0]["Product_Name"].ToString();
                txtStock .Text = dt.Rows[0]["Total"].ToString();

                txtTotal.Text = "1";
                txtTotal.Focus();
            }
            catch
            {

            }
        }

        private void txtProductID_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyData == Keys.Enter)
            {
                if (radioButton1.Checked == true)
                    SelectProduct(txtProductID.Text, 1);
                else if (radioButton2.Checked == true)
                    SelectProduct(txtProductID.Text, 0);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            string sql = string.Format("SELECT  DETAIL_EXPIRED.Exp_ID, DETAIL_EXPIRED.Product_ID, DETAIL_EXPIRED.Exp_Total,PRODUCT.Product_Name, CONVERT(VARCHAR,PRODUCT.Pricesale)Pricesale,DETAIL_EXPIRED.Exp_Note FROM  DETAIL_EXPIRED INNER JOIN PRODUCT ON DETAIL_EXPIRED.Product_ID = PRODUCT.Product_ID WHERE DETAIL_EXPIRED.Exp_ID = '" + lbID.Text + "' ");
            ds = clsGlobal.SQLQUERY.MS_DataAdapter(sql);
            dgvView.DataSource = ds.Tables[0];
            this.lbID.Text = clsSELECT.strGenIDEXPIRED(); //เลขที่ตัดจ่าย
            this.txtProductID.Clear();
            this.txtStock.Clear();
            this.txtPID.Clear();
            this.txtPName.Clear();
            this.txtTotal.Clear();
            this.txtNote.Clear();
            this.txtSum.Clear();

            try   //คิดเงินรวม
            {
                double total = 0;
                foreach (DataGridViewRow row in dgvView.Rows)
                {
                    total += Convert.ToDouble(row.Cells["Pricesale"].Value.ToString()) * Convert.ToDouble(row.Cells["Exp_Total"].Value.ToString());
                }
                txtSum.Text = total.ToString("##,###.00");
            }
            catch
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var frm = new frmViewExit();
            frm.ShowDialog();
        }

        private void txtTotal_KeyPress(object sender, KeyPressEventArgs e)
        {
            //พิมพ์ได้เฉพาะ 0-9
            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar)
                && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // only allow one decimal point

            if (e.KeyChar == '.'

                && (sender as TextBox).Text.IndexOf('.') > -1)
            {

                e.Handled = true;
            }
        }

        
    }
}
