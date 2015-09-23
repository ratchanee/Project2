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
            //ตรวจสอบค่าว่าง
            //if (txtID.Text.Trim() == "")
            //{
            //    MessageBox.Show("กรุณาเลือกข้อมูลลูกค้าก่อน!", "การดำเนินการ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}
            //else if (txtID.Text.Trim() == "")
            //{
            //    MessageBox.Show("กรุณาระบุรหัสสมาชิก!", "การดำเนินการ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}
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

    }
}
