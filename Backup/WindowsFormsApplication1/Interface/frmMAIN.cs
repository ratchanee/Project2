using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Stock.Interface
{
    public partial class frmMAIN : Form
    {
        public frmMAIN()
        {
            InitializeComponent();
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

    }
}
