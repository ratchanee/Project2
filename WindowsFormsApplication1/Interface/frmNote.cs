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

namespace Stock.Interface
{
   
    public partial class frmNote : Form
    {
        public frmNote()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (txtNote.Text == "")
            {
                MessageBox.Show("กรุณาระบุเหตุผลในการยกเลิกรายการ!", "การดำเนินการ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                try
                {
                    var Note = new clsORDER();
                    Note.Order_ID = this.txtID .Text.Trim();
                    Note.note = this.txtNote.Text.Trim();
                        if (clsUPDATE.UPNOTE(Note) == true)
                        {
                            this.Close();
                        }
                    }
                
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}