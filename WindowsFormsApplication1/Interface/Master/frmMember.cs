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
using Excel = Microsoft.Office.Interop.Excel;
using System.Threading;
using System.Globalization;


namespace Stock.Interface.Master
{
    public partial class frmMember : Form
    {
        Excel.Application xlApp; 
        public frmMember()
        {
            InitializeComponent();
            lblUser.Text = Class.clsGlobal.Mem_Name;
        }


        private void btnSearch_Click(object sender, EventArgs e)
        {
            dgvView.DataSource = clsSELECT.MEMBER(this.txtMemberID.Text.Trim(), this.txtMemberName.Text.Trim()).Tables[0];
            this .txtMemberID.Clear();
            this.txtMemberName.Clear();
            this.lbRecode.Text = dgvView.RowCount + "  รายการ".ToString ();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var frm = new frmMemberAdd("INSERT");
            frm.ShowDialog();
            btnSearch_Click(sender, e);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            frmMemberAdd frm = new frmMemberAdd("EDIT");
            frm.txtID.Visible = true;
            frm.txtID.Text = dgvView.Rows[dgvView.CurrentRow.Index].Cells["Mem_ID"].Value.ToString().Trim();
            frm.txtName.Text = dgvView.Rows[dgvView.CurrentRow.Index].Cells["Mem_Name"].Value.ToString().Trim();
            frmMemberAdd.Shere = dgvView.Rows[dgvView.CurrentRow.Index].Cells["Share_Member"].Value.ToString().Trim();
            frm.txtTel.Text = dgvView.Rows[dgvView.CurrentRow.Index].Cells["Phone"].Value.ToString().Trim();
            frmMemberAdd.Status = dgvView.Rows[dgvView.CurrentRow.Index].Cells["Status"].Value.ToString().Trim();
            frm.txtAddress.Text = dgvView.Rows[dgvView.CurrentRow.Index].Cells["Address"].Value.ToString().Trim();
            frm.txtUser .Text = dgvView.Rows[dgvView.CurrentRow.Index].Cells["M_User"].Value.ToString().Trim();
            frm.txtPass .Text = dgvView.Rows[dgvView.CurrentRow.Index].Cells["M_Pass"].Value.ToString().Trim();
            frm.ShowDialog();
            btnSearch_Click(sender, e);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var Member = new clsMember ();
            Member.Mem_ID = dgvView.Rows[dgvView.CurrentRow.Index].Cells["Mem_ID"].Value.ToString().Trim();
            Member.Mem_Name = dgvView.Rows[dgvView.CurrentRow.Index].Cells["Mem_Name"].Value.ToString().Trim();
            Member.Share_Member = dgvView.Rows[dgvView.CurrentRow.Index].Cells["Share_Member"].Value.ToString().Trim();
            Member.Phone = dgvView.Rows[dgvView.CurrentRow.Index].Cells["Phone"].Value.ToString().Trim();
            Member.Status = dgvView.Rows[dgvView.CurrentRow.Index].Cells["Status"].Value.ToString().Trim();
            Member.Address = dgvView.Rows[dgvView.CurrentRow.Index].Cells["Address"].Value.ToString().Trim();
            Member.M_User = dgvView.Rows[dgvView.CurrentRow.Index].Cells["M_User"].Value.ToString().Trim();
            Member.M_Pass = dgvView.Rows[dgvView.CurrentRow.Index].Cells["M_Pass"].Value.ToString().Trim();

            //if (lblUser.Text == Cells["M_User"].Value.ToString())
            //{
            //    MessageBox.Show("กำลังใช้งาน ไม่สามารถลบได้", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
                 if (MessageBox.Show("ต้องการลบข้อมูลใช่หรือไม่", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (clsDELETE.MEMBER(Member) == true)
                {
                    MessageBox.Show("ลบข้อมูลสำเร็จ", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("ลบข้อมูลไม่สำเร็จ", "Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                }
            }
         
            btnSearch_Click(sender, e);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                xlApp = new Excel.ApplicationClass();
                Excel.Workbook myExcelWorkbook;
                Excel.Workbooks myExcelWorkbooks;
                object misValue = System.Reflection.Missing.Value;
                //**---**
                Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");

                xlApp.Visible = false;
                myExcelWorkbooks = xlApp.Workbooks;
                string strPathExcelFile = Application.StartupPath + "\\MEMBER.xlsx";
                myExcelWorkbook = myExcelWorkbooks.Open(strPathExcelFile, misValue, misValue, misValue, misValue, misValue, misValue, misValue,
                                                        misValue, misValue, misValue, misValue, misValue, misValue, misValue);
                Excel.Worksheet myExcelWorksheet = (Excel.Worksheet)myExcelWorkbook.ActiveSheet;

                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "Excel file |*.xls";

                if (save.ShowDialog() == DialogResult.OK)
                {
                    int i = 0, j = 0;
                    string data = " ";

                    DataSet ds = new DataSet();

                    ds = MEMBER();

                    for (i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                    {
                        for (j = 0; j <= ds.Tables[0].Columns.Count - 1; j++)
                        {
                            data = ds.Tables[0].Rows[i].ItemArray[j].ToString();
                            myExcelWorksheet.Cells[i + 4, j + 1] = data;
                        }
                    }

                    myExcelWorkbook.SaveAs(save.FileName, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                    myExcelWorkbook.Close(true, misValue, misValue);
                    xlApp.Quit();

                    releaseObject(myExcelWorksheet);
                    releaseObject(myExcelWorkbook);
                    releaseObject(xlApp);

                    MessageBox.Show("บันทึกข้อมูลเรียบร้อยแล้ว");
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }


        public static DataSet MEMBER()
        {
            DataSet ds = new DataSet();
            StringBuilder sb = new StringBuilder();
            sb.Remove(0, sb.ToString().Length);
            sb.Append(" SELECT * ");
            sb.Append(" FROM MEMBER ");
            return ds = clsGlobal.SQLQUERY.MS_DataAdapter(sb.ToString());

        }

        private void frmMember_Load(object sender, EventArgs e)
        {
            btnSearch_Click(sender, e);

            dgvView.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Regular); //ปรับตัวหนังสือในตาราง
        }

    }
}
