using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Stock.Class;
using System.Data.SqlClient;
using Stock.Interface;

namespace Stock
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtUN.Text == "" || txtPW.Text == "")
            {
                MessageBox.Show("กรุณาใสข้อมูลให้ครบ ");
            }
            else
            {
                DataTable dtUser = Class.clsSELECT.AuthenUser(txtUN.Text.Trim(), txtPW.Text.Trim());
                if (dtUser.Rows.Count > 0)
                {
                    //clsGlobal.Mem_ID = Convert.ToInt32(dtUser.Rows[0]["Mem_ID"].ToString());
                    clsGlobal.Mem_ID = dtUser.Rows[0]["Mem_ID"].ToString();
                    clsGlobal.Mem_Name = dtUser.Rows[0]["Mem_Name"].ToString();
                    clsGlobal.Mem_Status = dtUser.Rows[0]["Status"].ToString();


                    if (clsGlobal.Mem_Status == "กรรมการ")
                    {
                        this.Hide();
                        var frm = new frmMAIN();
                        frm.Show();
                    }
                    else if (clsGlobal.Mem_Status == "พนักงานขาย")
                    {
                        this.Hide();
                        var frm = new frmSale();
                        frm.Show();
                    }
                    else
                    {
                        MessageBox.Show("คุณไม่มีสิทธิ์เข้าใช้งานระบบ", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("ข้อมูลไม่ถูกต้อง ");
                }
            }

        }
    }
}
