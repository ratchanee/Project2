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

namespace Stock.Interface.Master
{
    public partial class frmDealer : Form
    {
        public frmDealer()
        {
            InitializeComponent();
            lblUser.Text = Class.clsGlobal.Mem_Name;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dgvView.DataSource = clsSELECT.Dealer(this.txtDealerID.Text.Trim(), this.txtDealerName.Text.Trim()).Tables[0];
            
        }

        private void frmDealer_Load(object sender, EventArgs e)
        {
            //DataSet ds = new DataSet();
            //string sql = "SELECT * FROM DEALER";
            //ds = clsGlobal.SQLQUERY.MS_DataAdapter(sql);
            //cbbType.DisplayMember = "Dealer_Name"; //เอาชื่อไปโชว์
            //cbbType.ValueMember = "Dealer_ID"; //เอาค่าไปซ่อนไว้
            //cbbType.DataSource = ds.Tables[0];
            //cbbType.SelectedIndex = 0;

            btnSearch_Click(sender, e);
            dgvView.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Regular); //ปรับขนาดตัวหนังสือในตาราง
            dgvView1.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Regular); //ปรับขนาดตัวหนังสือในตาราง
            //dgvView1.DataSource = clsSELECT.Dealer1(dgvView.Rows[dgvView.CurrentRow.Index].Cells["Dealer_ID"].Value.ToString().Trim()).Tables[0];
            
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            var Dealer = new clsDEALER ();
            Dealer.Dealer_ID = dgvView.Rows[dgvView.CurrentRow.Index].Cells["Dealer_ID"].Value.ToString().Trim();
            Dealer.Dealer_Name = dgvView.Rows[dgvView.CurrentRow.Index].Cells["Dealer_Name"].Value.ToString().Trim();
            Dealer.Dealer_Tel = dgvView.Rows[dgvView.CurrentRow.Index].Cells["Dealer_Tel"].Value.ToString().Trim();
            Dealer.Dealer_Address = dgvView.Rows[dgvView.CurrentRow.Index].Cells["Dealer_Address"].Value.ToString().Trim();
            
            if (MessageBox.Show("ต้องการลบข้อมูลใช่หรือไม่", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (clsDELETE.DEALER(Dealer) == true)
                {
                    MessageBox.Show("ลบข้อมูลเรียบร้อยแล้ว", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("เกิดข้อผิดพลาด", "Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                }
            }
            btnSearch_Click(sender, e);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var frm = new frmDealerAdd ("INSERT");
            frm.ShowDialog ();
            btnSearch_Click(sender, e);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            frmDealerAdd  frm = new frmDealerAdd ("EDIT");
            //frm.lbID.Visible = true;
            frm.txtID.Visible = true;
            frm.txtID.Text = dgvView.Rows[dgvView.CurrentRow.Index].Cells["Dealer_ID"].Value.ToString().Trim();
            frm.txtName.Text = dgvView.Rows[dgvView.CurrentRow.Index].Cells["Dealer_Name"].Value.ToString().Trim();
            frm.txtTel.Text = dgvView.Rows[dgvView.CurrentRow.Index].Cells["Dealer_Tel"].Value.ToString().Trim();
            frm.txtAddress.Text = dgvView.Rows[dgvView.CurrentRow.Index].Cells["Dealer_Address"].Value.ToString().Trim();
            
            frm.ShowDialog();
            btnSearch_Click(sender, e);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var frm = new frmDealerProduct("INSERT") ;
            frm.cbbDealer.Text = dgvView.Rows[dgvView.CurrentRow.Index].Cells["Dealer_Name"].Value.ToString().Trim();
            frm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dgvView1.DataSource = clsSELECT.DETAIL_PRODUCT ().Tables[0];
        }

        private void dgvView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string Dealer_ID = dgvView.Rows[dgvView.CurrentRow.Index].Cells["Dealer_ID"].Value.ToString().Trim();
            button1.Enabled = true;
            btnDProduct.Enabled = true;
            dgvView1.DataSource = clsSELECT.Dealer1(Dealer_ID).Tables[0];
        }

        private void btnDProduct_Click(object sender, EventArgs e)
        {


            var Dealer1 = new clsDEALER ();
            Dealer1.Dealer_ID = dgvView1.Rows[dgvView1.CurrentRow.Index].Cells["Dealer_ID1"].Value.ToString().Trim();
            Dealer1.Type_ID = dgvView1.Rows[dgvView1.CurrentRow.Index].Cells["Type_ID"].Value.ToString().Trim();
            Dealer1.Product_ID = dgvView1.Rows[dgvView1.CurrentRow.Index].Cells["Product_ID"].Value.ToString().Trim();
            Dealer1.Price = dgvView1.Rows[dgvView1.CurrentRow.Index].Cells["Price"].Value.ToString().Trim();
            
            if (MessageBox.Show("ต้องการลบข้อมูลใช่หรือไม่", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (clsDELETE.Dealer1(Dealer1) == true)
                {
                    MessageBox.Show("ลบข้อมูลเรียบร้อยแล้ว", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("เกิดข้อผิดพลาด", "Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                }
            }
            //btnSearch_Click(sender, e);

        }

       
    }
}