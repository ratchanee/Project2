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
    public partial class frmStock : Form
    {
        public frmStock()
        {
            InitializeComponent();
            lblUser.Text = Class.clsGlobal.Mem_Name;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dgvView.DataSource = clsSELECT.PRODUCT(this.txtID.Text.Trim(), this.txtName.Text.Trim()).Tables[0];
            this.txtID.Clear();
            this.txtName.Clear();
        }

        private void frmStock_Load(object sender, EventArgs e)
        {
            button1_Click( sender, e);
            dgvView.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Regular); //ปรับขนาดตัวหนังสือในตาราง
        }

       
    }
}
 