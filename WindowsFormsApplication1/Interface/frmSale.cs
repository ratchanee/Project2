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
    public partial class frmSale : Form
    {
        string FUNCTION = "";
        private string action1 = "";
        public frmSale()
        {
            InitializeComponent();
            lblUser.Text = Class.clsGlobal.Mem_Name;
            lblMemID.Text = Class.clsGlobal.Mem_ID;
        }
        public frmSale(string CASE)
        {
            InitializeComponent();
            FUNCTION = CASE;
        }
        DataTable dtGridNull;

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.F2))
            {
                this.btnAdd.PerformClick(); //เพิ่มรายการ
            }
            if (keyData == (Keys.F3))
            {
                this.button4.PerformClick();//ลบรายการ
            }
            if (keyData == (Keys.F8))
            {
                this.btnSum.PerformClick();//ชำระเงิน
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void frmSale_Load(object sender, EventArgs e)
        {
            btnSearch_Click( sender,  e);
            this.lbID.Text = clsSELECT.strGenIDSale(); //เลขที่การขาย
           

            this.lbRecode.Text = dgvView.RowCount + "  รายการ".ToString(); //นับบรรทัดตาราง

            try   //คิดเงินรวม
            {

                double total = 0;
                foreach (DataGridViewRow row in dgvView.Rows)
                {
                    total += Convert.ToDouble(row.Cells["Pricesale"].Value.ToString()) * Convert.ToDouble(row.Cells["Total"].Value.ToString());
                }
                txtSum.Text = total.ToString("##,###.00");
            }
            catch
            {

            }
            //SetAutoComplete();

            //SetAutoComplete1();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DataTable dt = clsSELECT.sale(this.lbID.Text.Trim(), this.txtPID.Text.Trim()).Tables[0];
            if (dt.Rows.Count < 0)
            {
                string ProductID = dt.Rows[0]["Product_ID"].ToString();
            }

            if (txtPID.Text.Trim() == "")
            {
                MessageBox.Show("กรุณาระบุรหัสสินค้า!", "การดำเนินการ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (txtTotal.Text.Trim() == "")
            {
                MessageBox.Show("กรุณาระบุจำนวนสินค้า!", "การดำเนินการ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (Convert.ToDecimal(txtTotal.Text) > Convert.ToDecimal(txtStock.Text))
            {
                MessageBox.Show("จำนวนสินค้าในสต๊อกมีไม่เพียงพอ!", "การดำเนินการ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            else
            {
                try
                {
                    var Sale = new clsSale();
                    Sale.Sale_ID = this.lbID.Text.Trim();
                    Sale.Product_ID = this.txtPID.Text.Trim();
                    Sale.Total = this.txtTotal.Text.Trim();

                    if (dt.Rows.Count == 0)
                    {
                        if (clsINSERT.SALE(Sale) == true)
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
                        sbUP.Append("update DETAIL_SALE set Total =  ");
                        sbUP.Append("Total + " + txtTotal.Text.Trim());
                        sbUP.Append(" where  Sale_ID = '" + lbID.Text.Trim() + "'");
                        sbUP.Append(" and  Product_ID = '" + txtPID.Text.Trim() + "'");
                        clsGlobal.SQLQUERY.MS_ExecuteNonQuery(sbUP.ToString());
//อัพเดดสต๊อก
                        StringBuilder sbUPSTOCK = new StringBuilder();
                        sbUPSTOCK.Append("update dbo.PRODUCT set Total =  ");
                        sbUPSTOCK.Append("Total - '" + txtTotal.Text.Trim() + "'");
                        sbUPSTOCK.Append(" where  Product_ID = '" + txtPID.Text.Trim() + "'");
                        clsGlobal.SQLQUERY.MS_ExecuteNonQuery(sbUPSTOCK.ToString());
                            
                    }
                }
                catch (Exception) { MessageBox.Show("เกิดข้อผิดพลาด!", "การดำเนินการ", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            }

            try   //คิดเงินรวม
            {

                double total = 0;
                foreach (DataGridViewRow row in dgvView.Rows)
                {
                    total += Convert.ToDouble(row.Cells["Pricesale"].Value.ToString()) * Convert.ToDouble(row.Cells["Total"].Value.ToString());
                }
                txtSum.Text = total.ToString("##,###.00");
            }
            catch
            {

            }
           
            btnSearch_Click( sender,  e);

        }

        private void SetAutoComplete1()
        {
            DataSet ds = new DataSet();

            var customers = new AutoCompleteStringCollection();
            string sql = string.Format(" SELECT Mem_ID FROM MEMBER ");
            ds = clsGlobal.SQLQUERY.MS_DataAdapter(sql);
            foreach (DataRow str in ds.Tables[0].Rows)
            {
                customers.Add(str["Mem_ID"].ToString());
            }
            txtMem_ID.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtMem_ID.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtMem_ID.AutoCompleteCustomSource = customers;

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
                if (!int.TryParse(dgvView.Rows[e.RowIndex].Cells["Total"].Value.ToString(), out n))
                    return;

                double total = 0;
                foreach (DataGridViewRow row in dgvView.Rows)
                {
                    total += Convert.ToDouble(row.Cells["Pricesale"].Value.ToString()) * Convert.ToDouble(row.Cells["Total"].Value.ToString());
                }
                txtSum.Text = total.ToString("##,###.00");
            }
            catch
            {
                dgvView.Rows[e.RowIndex].Cells["Total"].Value = 0;
            }
        }

        private void btnSum_Click(object sender, EventArgs e)
        {
        //     if (txtMem_ID .Text.Trim() == "")
        //    {
        //        MessageBox.Show("กรุณาระบุรหัสหรือชื่อสมาชิก!", "การดำเนินการ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        return;
        //    }
              if (txtReceive .Text.Trim() == "")
             {
                 MessageBox.Show("กรุณาระบุจำนวนเงินที่รับ!", "การดำเนินการ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                 return;
             }
              else if (Convert.ToDecimal(txtSum.Text) > Convert.ToDecimal(txtReceive.Text))
              {
                  MessageBox.Show("จำนวนเงินที่รับมาน้อยกว่าราคาสินค้า!", "การดำเนินการ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                  return;
              }

             else
             {
                 try
                 {
                     if (MessageBox.Show("ต้องการขายสินค้าใช่หรือไม่", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                     {

                         if (action1 == "")
                         {
                             //รายการขาย
                             StringBuilder sb = new StringBuilder();
                             sb.Append("INSERT INTO SALE(Sale_ID ,Sale_Date ,Time,Price,Mem_ID )");
                             sb.Append(" VALUES (");
                             sb.Append(" '" + lbID.Text.Trim() + "' ");
                             sb.Append(" ,'" + dtpDate.Value.ToString("MM/dd/yyyy", cConfigAtt.formatEn) + "'");
                             sb.Append(" ,'" + dtpTime.Value.ToString("HH:mm", cConfigAtt.formatEn) + "'");
                             sb.Append(" ,'" + txtSum.Text.Trim() + "'");
                             sb.Append(" ,'" + lblMemID.Text.Trim() + "' ) ");

                             clsGlobal.SQLQUERY.MS_ExecuteNonQuery(sb.ToString());
                            
                             //StringBuilder sbUPMember = new StringBuilder();
                             //sbUPMember.Append("update MEMBER set M_Buy =");
                             //sbUPMember.Append(" M_Buy + " + txtSum.Text.Trim());
                             //sbUPMember.Append(" where  Mem_ID = " + txtMem_ID.Text.Trim());
                             //clsGlobal.SQLQUERY.MS_ExecuteNonQuery(sbUPMember.ToString());
                        }
                         MessageBox.Show("ดำเนินการขายเรียบร้อยแล้ว", "การดำเนินการ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        
                     }
                     else
                     {
                         StringBuilder sb = new StringBuilder();
                         sb.Append(" DELETE DETAIL_SALE WHERE Sale_ID = '" + lbID.Text.Trim() + "'   ");
                         clsGlobal.SQLQUERY.MS_ExecuteNonQuery(sb.ToString());

                         //อัพเดดสต๊อก
                         foreach (DataGridViewRow row in dgvView.Rows)
                         {
                             StringBuilder sbUPSTOCK = new StringBuilder();
                             sbUPSTOCK.Append("update dbo.PRODUCT set Total =  ");
                             sbUPSTOCK.Append("Total + " + row.Cells["Total"].Value.ToString());
                             sbUPSTOCK.Append(" where  Product_ID = '" + row.Cells["Product_ID"].Value.ToString() + "'");
                             clsGlobal.SQLQUERY.MS_ExecuteNonQuery(sbUPSTOCK.ToString());
                         }
                     }
                 }
                 catch (Exception)
                 {
                     MessageBox.Show("เกิดข้อผิดพลาด!", "การดำเนินการ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                 }
                 
             }
            this.lbID.Text = clsSELECT.strGenIDSale(); //เลขที่การขาย  
              DataSet ds = new DataSet();
              string sql = string.Format("SELECT DETAIL_SALE.Sale_ID, DETAIL_SALE.Product_ID,DETAIL_SALE.Total,PRODUCT.Product_Name, CONVERT(VARCHAR,PRODUCT.Pricesale )Pricesale FROM DETAIL_SALE INNER JOIN PRODUCT ON DETAIL_SALE.Product_ID = PRODUCT.Product_ID WHERE DETAIL_SALE.Sale_ID = '" + lbID.Text + "'  ");
              ds = clsGlobal.SQLQUERY.MS_DataAdapter(sql);
              dgvView.DataSource = ds.Tables[0];
              this.txtSum.Text = ".00"  ;
              this.txtReceive.Text = "";
              this.txtResult .Text = "0";
              
            
           
        }

        private void txtReceive_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtResult.Text = (Convert.ToDecimal(txtReceive.Text) - Convert.ToDecimal(txtSum.Text)).ToString();
            }
            catch (Exception) { MessageBox.Show("เกิดข้อผิดพลาด!", "การดำเนินการ", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
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
                txtStock.Text = dt.Rows[0]["Total"].ToString();

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

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked == true)
            {
                DataSet ds = new DataSet();
                var customers = new AutoCompleteStringCollection();
                string sql = string.Format(" SELECT Mem_Name FROM MEMBER ");
                ds = clsGlobal.SQLQUERY.MS_DataAdapter(sql);
                foreach (DataRow str in ds.Tables[0].Rows)
                {
                    customers.Add(str["Mem_Name"].ToString());
                }
                txtMem_ID.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                txtMem_ID.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtMem_ID.AutoCompleteCustomSource = customers;
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked == true)
            {
                DataSet ds = new DataSet();
                var customers = new AutoCompleteStringCollection();
                string sql = string.Format(" SELECT Mem_ID FROM MEMBER ");
                ds = clsGlobal.SQLQUERY.MS_DataAdapter(sql);
                foreach (DataRow str in ds.Tables[0].Rows)
                {
                    customers.Add(str["Mem_ID"].ToString());
                }
                txtMem_ID.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                txtMem_ID.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtMem_ID.AutoCompleteCustomSource = customers;
            }
        }
        private void SelectMEMBER(string strText1, int intType1)
        {
            try
            {
                DataTable dt = new DataTable();
                string Condition1 = " WHERE ";
                if (intType1 == 0)
                {
                    Condition1 += " Mem_ID = '" + strText1 + "'";
                }
                else if (intType1 == 1)
                {
                    Condition1 += " Mem_Name = '" + strText1 + "' ";
                }

                string sql = " SELECT Mem_ID, Mem_Name FROM PRODUCT " + Condition1;
                dt = clsGlobal.SQLQUERY.MS_DataAdapter(sql).Tables[0];

                lblMID.Text = dt.Rows[0]["Mem_ID"].ToString();
                lblMName.Text = dt.Rows[0]["Mem_Name"].ToString();

            }
            catch
            {

            }

        }

        private void txtMem_ID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                if (radioButton4.Checked == true)
                    SelectMEMBER(txtMem_ID.Text, 1);
                else if (radioButton3.Checked == true)
                    SelectMEMBER(txtMem_ID.Text, 0);
            }
        }

        private void txtMem_ID_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            var Sale = new clsSale ();
            Sale.Sale_ID = dgvView.Rows[dgvView.CurrentRow.Index].Cells["Sale_ID"].Value.ToString().Trim();
            Sale.Product_ID = dgvView.Rows[dgvView.CurrentRow.Index].Cells["Product_ID"].Value.ToString().Trim();
            Sale.Pricesale = dgvView.Rows[dgvView.CurrentRow.Index].Cells["Pricesale"].Value.ToString().Trim();
            Sale.Total = dgvView.Rows[dgvView.CurrentRow.Index].Cells["Total"].Value.ToString().Trim();

            if (MessageBox.Show("ต้องการลบข้อมูลใช่หรือไม่", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (clsDELETE.SALE(Sale) == true)
                {
                        StringBuilder sbUPSTOCK = new StringBuilder();
                        sbUPSTOCK.Append("update dbo.PRODUCT set Total =  ");
                        sbUPSTOCK.Append("Total + '" + Sale.Total+"'");
                        sbUPSTOCK.Append(" where  Product_ID = '" + Sale.Product_ID + "'");
                        clsGlobal.SQLQUERY.MS_ExecuteNonQuery(sbUPSTOCK.ToString());
                   
                    MessageBox.Show("ลบข้อมูลสำเร็จ", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("ลบข้อมูลไม่สำเร็จ", "Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                }
            }
            btnSearch_Click( sender,  e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            btnCancel .Enabled = true ;
            btnSum.Enabled = false ;
            btnAdd.Enabled = false;
            button4.Enabled = false;
            this.txtStatus.Text = "S";
            try
            {
                DataSet ds = new DataSet();
                string sql = string.Format("SELECT S.Sale_ID, S.Sale_Date, DS.Product_ID, P.Product_Name, P.Pricesale,DS.Total, dbo.FUNC_CONVERT_TYPE( S.Status) AS 'Status' FROM SALE S INNER JOIN DETAIL_SALE DS ON S.Sale_ID = DS.Sale_ID INNER JOIN PRODUCT P ON DS.Product_ID = P.Product_ID where S.Sale_ID = '" + txtCancel.Text + "' and S.Status like '" + txtStatus.Text + "' and S.Sale_Date = '" + dtpDate.Value.ToString("MM/dd/yyyy", cConfigAtt.formatEn) + "'");
                ds = clsGlobal.SQLQUERY.MS_DataAdapter(sql);
                dgvView.DataSource = ds.Tables[0];
                

                try   //คิดเงินรวม
                {

                    double total = 0;
                    foreach (DataGridViewRow row in dgvView.Rows)
                    {
                        total += Convert.ToDouble(row.Cells["Pricesale"].Value.ToString()) * Convert.ToDouble(row.Cells["Total"].Value.ToString());
                    }
                    txtSum.Text = total.ToString("##,###.00");
                }
                catch
                {

                }
            }
            catch (Exception)
            {
                MessageBox.Show("ไม่พบข้อมูลการขายสินค้า!", "การดำเนินการ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
           
            try
            {
                if (MessageBox.Show("ต้องการยกเลิกรายการขายสินค้าใช่หรือไม่", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    if (action1 == "")
                    {
                    //อัพเดดสเตตัส
                        StringBuilder sbUP = new StringBuilder();
                        sbUP.Append("update SALE set Status = 'E' ");
                        sbUP.Append(" where  Sale_ID = '" + txtCancel.Text.Trim()+"' ");
                        clsGlobal.SQLQUERY.MS_ExecuteNonQuery(sbUP.ToString());


                        //อัพเดดสต๊อก
                        foreach (DataGridViewRow row in dgvView.Rows)
                        {
                            StringBuilder sbUPSTOCK = new StringBuilder();
                            sbUPSTOCK.Append("update dbo.PRODUCT set Total =  ");
                            sbUPSTOCK.Append("Total + " + row.Cells["Total"].Value.ToString());
                            sbUPSTOCK.Append(" where  Product_ID = '" + row.Cells["Product_ID"].Value.ToString() + "'");
                            clsGlobal.SQLQUERY.MS_ExecuteNonQuery(sbUPSTOCK.ToString());
                        }
                        ////ลบยอดซื้อของสมาชิก
                        //StringBuilder sbUPMember = new StringBuilder();
                        //sbUPMember.Append("update MEMBER set M_Buy = ");
                        //sbUPMember.Append(" M_Buy - " + txtSum.Text.Trim()+"'");
                        //sbUPMember.Append(" where  Sale_ID = " + txtCancel.Text.Trim()+"'");
                        //sbUPMember.Append(" AND  Mem_ID = '" + txtMem_ID.Text.Trim()+"'");
                        //clsGlobal.SQLQUERY.MS_ExecuteNonQuery(sbUPMember.ToString());
                    }
                    MessageBox.Show("ยกเลิกรายการขายเรียบร้อย", "การดำเนินการ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
btnSearch_Click( sender,  e);
                }
                else
                {
                    btnSum.Enabled = true;
                    btnAdd.Enabled = true;
                    button4.Enabled = true;

                }
            }
            catch (Exception)
            {
                MessageBox.Show("เกิดข้อผิดพลาดในการรับสินค้า!", "การดำเนินการ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            string sql = string.Format("SELECT DETAIL_SALE.Sale_ID, DETAIL_SALE.Product_ID,DETAIL_SALE.Total,PRODUCT.Product_Name, CONVERT(VARCHAR,PRODUCT.Pricesale )Pricesale FROM DETAIL_SALE INNER JOIN PRODUCT ON DETAIL_SALE.Product_ID = PRODUCT.Product_ID WHERE DETAIL_SALE.Sale_ID = '" + lbID.Text + "'  ");
            ds = clsGlobal.SQLQUERY.MS_DataAdapter(sql);
            dgvView.DataSource = ds.Tables[0];
            try   //คิดเงินรวม
            {

                double total = 0;
                foreach (DataGridViewRow row in dgvView.Rows)
                {
                    total += Convert.ToDouble(row.Cells["Pricesale"].Value.ToString()) * Convert.ToDouble(row.Cells["Total"].Value.ToString());
                }
                txtSum.Text = total.ToString("##,###.00");
            }
            catch
            {

            }
            this.txtProductID.Clear();
            this.txtPID.Clear();
            this.txtPName.Clear();
            this.txtTotal.Clear();
            btnSum.Enabled = true;
            btnAdd.Enabled = true;
            button4.Enabled = true;
            this.txtMem_ID.Clear();
            this.txtCancel.Clear();
            this.txtStock .Clear();
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

        private void txtReceive_KeyPress(object sender, KeyPressEventArgs e)
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
