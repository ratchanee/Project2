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
    public partial class frmMenuDerivery : Form
    {
        public frmMenuDerivery()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var frm = new frmDelivery();
            frm.ShowDialog();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var frm = new frmDeriveryV ();
            frm.ShowDialog();
        }

        private void frmMenuDerivery_Load(object sender, EventArgs e)
        {

        }
    }
}
