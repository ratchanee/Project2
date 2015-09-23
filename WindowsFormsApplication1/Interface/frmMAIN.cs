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
    public partial class frmMAIN : Form
    {
        public frmMAIN()
        {
            InitializeComponent();
            lblUser.Text = Class.clsGlobal.Mem_Name;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var frm = new Stock.Interface.Master.frmMember ();
            frm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var frm = new Stock.Interface.Master.frmProduct ();
            frm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var frm = new Stock.Interface.Master.frmDealer ();
            frm.ShowDialog();
        }
        private void btnOrder_Click(object sender, EventArgs e)
        {
            var frm = new frmMenuOrder ();
            frm.ShowDialog ();
        }

        private void btnDalivery_Click(object sender, EventArgs e)
        {
            var frm = new frmMenuDerivery  ();
            frm.ShowDialog();
        }

        private void btnPermission_Click(object sender, EventArgs e)
        {
            var frm = new frmStock();
            frm.ShowDialog(); 
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            var frm = new frmSettingPrice ();
            frm.ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            var frm = new frmMenuExit ();
            frm.ShowDialog();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        private void frmMAIN_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("ยืนยันการออกโปรแกรม!", "ต้องการออกจากโปรแกรมหรือไม่?", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                e.Cancel = false;
                this.Dispose();
                Application.Exit();
            }
            else
                e.Cancel = true;
        }

        private void btnSale_Click(object sender, EventArgs e)
        {
               var frm = new frmSale();
               frm.ShowDialog(); 
           
        }

        private void frmMAIN_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            var frm = new frmViewSale  ();
            frm.ShowDialog(); 
           
        }

    }
}
