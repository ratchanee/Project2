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
    public partial class frmDealerAdd : Form
    {
        string FUNCTION = "";
        public frmDealerAdd()
        {
            InitializeComponent();
        }
        public frmDealerAdd(string Event)
        {
            InitializeComponent();
            FUNCTION = Event;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {

          if (txtName.Text == "")
            {
                MessageBox.Show("กรุณาระบุชื่อตัวแทนจำหน่ายก่อน!", "การดำเนินการ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (txtTel.Text == "")
            {
                MessageBox.Show("กรุณาระบุหมายเลขโทรศัพท์ก่อน!", "การดำเนินการ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (txtAddress.Text == "")
            {
                MessageBox.Show("กรุณาระบุที่อยู่ก่อน!", "การดำเนินการ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                try
                {
                    var Dealer = new clsDEALER();
                    Dealer.Dealer_ID = this.txtID.Text.Trim();
                    Dealer.Dealer_Name = this.txtName.Text.Trim();
                    Dealer.Dealer_Tel = this.txtTel.Text.Trim();
                    Dealer.Dealer_Address = this.txtAddress.Text.Trim();

                    if (FUNCTION == "INSERT")
                    {
                        if (clsINSERT.DEALER(Dealer) == true)
                        {
                            MessageBox.Show("บันทึกข้อมูลเรียบร้อย", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("ข้อมูลไม่ถูกต้อง", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        if (clsUPDATE.DEALER(Dealer) == true)
                        {
                            MessageBox.Show("บันทึกข้อมูลเรียบร้อย", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("ข้อมูลไม่ถูกต้อง", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }
        private void btnView_Click(object sender, EventArgs e)
        {
            var frm = new frmDealer();
            frm.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
