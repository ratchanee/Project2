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
    public partial class frmViewExit : Form
    {
        private string action = "";
        public frmViewExit()
        {
            InitializeComponent();
            lblUser.Text = Class.clsGlobal.Mem_Name;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            string sql = string.Format("SELECT E.Exp_ID, E.Exp_Date, E.Mem_ID , M.Mem_Name FROM EXPIRED E INNER JOIN MEMBER M ON M.Mem_ID = E.Mem_ID WHERE E.Exp_Date LIKE '%" + dtpDate.Value.ToString("yyyy-MM-dd", cConfigAtt.formatEn) + "%'  AND E.Exp_ID LIKE '%" + txtExitID.Text + "%' ");
            ds = clsGlobal.SQLQUERY.MS_DataAdapter(sql);
            dgvView.DataSource = ds.Tables[0];

            dgvView.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Regular); //ปรับขนาดตัวหนังสือในตาราง
            this.lbRecode.Text = dgvView.RowCount + "  รายการ".ToString(); //นับบรรทัดตาราง

        }

        private void btnSelect_Click(object sender, EventArgs e)
        {

            try
            {
                if (action == "")
                {
                    var frm = new frmDetailExit ();
                    frm.txtIDExit.Text = dgvView.Rows[dgvView.CurrentRow.Index].Cells["Exp_ID"].Value.ToString().Trim();

                    frm.ShowDialog();
                }

            }
            catch (Exception) { MessageBox.Show("ไม่พบข้อมูล!", "การดำเนินการ", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        private void frmViewExit_Load(object sender, EventArgs e)
        {
            btnSearch_Click( sender,  e);
            dgvView.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Regular); //ปรับขนาดตัวหนังสือในตาราง
        }
    }
}
