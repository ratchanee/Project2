using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Stock.Parameter;
using Stock.Class;

namespace Stock.Interface.Master
{
    public partial class frmMemberAdd : Form
    {
        string FUNCTION = "";
        public static string Status = "";
        public static string Shere = "";
        public frmMemberAdd()
        {
            InitializeComponent();
        }

        public frmMemberAdd(string CASE)
        {
            InitializeComponent();
            FUNCTION = CASE;
        }

        private void frmMemberAdd_Load(object sender, EventArgs e)
        {
            this.cbbShere.SelectedIndex = 0;
            this.cboStatus.SelectedIndex = 0;
            if (FUNCTION == "EDIT")
            {
                this.txtID.ReadOnly = true;
                this.cboStatus.Text = Status;
                this.cbbShere.Text = Shere;
                //ค่าที่รับมาจาก DGV ส่งไป Cbb กรณีแก้ไข Int32 ใช้แปลง ค่า string ที่แทนตัวเลข(เป็นการ alias name)
                Int32 intChar = Shere.IndexOf(".");
                Int32 intShere = (Convert.ToInt32(Shere.Substring(0, intChar))-1);
                this.cbbShere.SelectedIndex = Convert.ToByte(intShere);

                
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
         
           if (txtName .Text.Trim() == "")
            {
                MessageBox.Show("กรุณาระบุชื่อ!", "การดำเนินการ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
          
            else if (txtTel .Text.Trim() == "")
            {
                MessageBox.Show("กรุณระบุเบอร์โทรศัพท์!", "การดำเนินการ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (txtAddress .Text.Trim() == "")
            {
                MessageBox.Show("กรุณาระบุที่อยู่!", "การดำเนินการ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
           {
                try
                {
                    //ค่าที่รับมา
                    var Member = new clsMember();
                    Member.Mem_ID = this.txtID.Text.Trim();
                    Member.Mem_Name = this.txtName.Text.Trim();
                    Member.Share_Member = this.cbbShere.Text.Trim();
                    Member.Phone = this.txtTel.Text.Trim();
                    Member.Status = this.cboStatus.Text.Trim();
                    Member.Address = this.txtAddress.Text.Trim();
                    Member.M_User = this.txtUser.Text.Trim();
                    Member.M_Pass = this.txtPass.Text.Trim();

                    if (FUNCTION == "INSERT")
                    {
                        if (clsINSERT.MEMBER(Member) == true)
                        {
                            MessageBox.Show("บันทึกข้อมูลเรียบร้อย", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("เกิดข้อผิดพลาด", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        if (clsUPDATE.MEMBER(Member) == true)
                        {
                            MessageBox.Show("บันทึกข้อมูลเรียบร้อย", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("เกิดข้อผิดพลาด", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
           this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            var frm = new frmMember();
            frm.ShowDialog();
        }

        private void txtTel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtTel.Text.Length >= 10)  //พิมพ์ได้ 10 ตัว
                e.Handled = true;
            //MessageBox.Show("พิมพ์เฉพาะ 0-9 ได้ 10 หลัก");
         
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

        private void cboStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboStatus.Text == "กรรมการ")
            {
                txtUser.Enabled = true;
                txtPass.Enabled = true;
            }
            else if (cboStatus.Text == "พนักงานขาย")
            {
                txtUser.Enabled = true;
                txtPass.Enabled = true;
            }
            else
            {
                txtUser.Enabled = false ;
                txtPass.Enabled = false ;
            }
        }
    }
}
