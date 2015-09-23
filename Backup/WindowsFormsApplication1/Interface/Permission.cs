using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Stock.Parameter;

namespace Stock
{
    public partial class Permission : Form
    {
        string strGroupCode;
        string strGroupName;
        string strFunction;
        public Permission()
        {
            InitializeComponent();
        }
        public Permission(string GroupCode,string GroupName, string Function)
        {
            InitializeComponent();
            strGroupCode = GroupCode;
            strGroupName = GroupName;
            strFunction = Function;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void checkBox14_CheckedChanged(object sender, EventArgs e)
        {
            if (cbbStore.Checked && true)
            {
                cbbSale.Checked = true;
                cbbSale.ForeColor = System.Drawing.Color.YellowGreen;
            }
            else
            {
                cbbSale.Checked = false ;
                cbbSale.ForeColor = System.Drawing.Color.Black ;
            }
        }

        private void cbbSale_CheckedChanged(object sender, EventArgs e)
        {
            if (cbbSale.Checked && true)
            {
                cbbStore.Checked = true;
            }
            else
            {
                cbbStore.Checked = false;
            }
        }

        private void cbbBackOffice_CheckedChanged(object sender, EventArgs e)
        {
            if (cbbBackOffice.Checked && true)
            {
                cbbMember.Checked = true;
                cbbMember.ForeColor = System.Drawing.Color.YellowGreen;
                cbbProduct.Checked = true;
                cbbProduct.ForeColor = System.Drawing.Color.YellowGreen;
                cbbDealer.Checked = true;
                cbbDealer.ForeColor = System.Drawing.Color.YellowGreen;
                cbbOrder.Checked = true;
                cbbOrder.ForeColor = System.Drawing.Color.YellowGreen;
                cbbDeliver.Checked = true;
                cbbDeliver.ForeColor = System.Drawing.Color.YellowGreen;
                cbbPermission.Checked = true;
                cbbPermission.ForeColor = System.Drawing.Color.YellowGreen;
                cbbExp.Checked = true;
                cbbExp.ForeColor = System.Drawing.Color.YellowGreen;
                cbbShere.Checked = true;
                cbbShere.ForeColor = System.Drawing.Color.YellowGreen;
                cbbReport.Checked = true;
                cbbReport.ForeColor = System.Drawing.Color.YellowGreen;
                cbbReportProduct.Checked = true;
                cbbReportProduct.ForeColor = System.Drawing.Color.YellowGreen;
                cbbReportSale.Checked = true;
                cbbReportSale.ForeColor = System.Drawing.Color.YellowGreen;
                CbbReportSaleProduct.Checked = true;
                CbbReportSaleProduct.ForeColor = System.Drawing.Color.YellowGreen;
            }
            else
            {
                cbbMember.Checked = false;
                cbbMember.ForeColor = System.Drawing.Color.Black;
                cbbProduct.Checked = false;
                cbbProduct.ForeColor = System.Drawing.Color.Black;
                cbbDealer.Checked = false;
                cbbDealer.ForeColor = System.Drawing.Color.Black;
                cbbOrder.Checked = false;
                cbbOrder.ForeColor = System.Drawing.Color.Black;
                cbbDeliver.Checked = false;
                cbbDeliver.ForeColor = System.Drawing.Color.Black;
                cbbPermission.Checked = false;
                cbbPermission.ForeColor = System.Drawing.Color.Black;
                cbbExp.Checked = false;
                cbbExp.ForeColor = System.Drawing.Color.Black;
                cbbReport.Checked = false;
                cbbReport.ForeColor = System.Drawing.Color.Black;
                cbbReportProduct.Checked = false;
                cbbReportProduct.ForeColor = System.Drawing.Color.Black;
                cbbReportSale.Checked = false;
                cbbReportSale.ForeColor = System.Drawing.Color.Black;
                cbbShere.Checked = false;
                cbbShere.ForeColor = System.Drawing.Color.Black;
                CbbReportSaleProduct.Checked = false;
                CbbReportSaleProduct.ForeColor = System.Drawing.Color.Black;
            }
            

        }

        private void cbbMember_CheckedChanged(object sender, EventArgs e)
        {
            if (cbbMember.Checked && true)
            {
                cbbBackOffice.Checked = true;
                cbbProduct.Checked = true;
                cbbDealer.Checked = true;
                cbbOrder.Checked = true;
                cbbDeliver.Checked = true;
                cbbPermission.Checked = true;
                cbbExp.Checked = true;
                cbbShere.Checked = true;
                cbbReport.Checked = true;
                cbbReportProduct.Checked = true;
                cbbReportSale.Checked = true;
                CbbReportSaleProduct.Checked = true;
            }
            else
            {
                cbbBackOffice.Checked = false;
                cbbProduct.Checked = false;
                cbbDealer.Checked = false;
                cbbOrder.Checked = false;
                cbbDeliver.Checked = false;
                cbbPermission.Checked = false;
                cbbExp.Checked = false;
                cbbReport.Checked = false;
                cbbReportProduct.Checked = false;
                cbbReportSale.Checked = false;
                cbbShere.Checked = false;
                CbbReportSaleProduct.Checked = false;
            }
            
        }

        private void cbbProduct_CheckedChanged(object sender, EventArgs e)
        {
            if (cbbProduct.Checked && true)
            {
                cbbBackOffice.Checked = true;
                cbbMember.Checked = true;
                cbbDealer.Checked = true;
                cbbOrder.Checked = true;
                cbbDeliver.Checked = true;
                cbbPermission.Checked = true;
                cbbExp.Checked = true;
                cbbShere.Checked = true;
                cbbReport.Checked = true;
                cbbReportProduct.Checked = true;
                cbbReportSale.Checked = true;
                CbbReportSaleProduct.Checked = true;
            }
            else
            {
                cbbBackOffice.Checked = false;
                cbbMember.Checked = false;
                cbbDealer.Checked = false;
                cbbOrder.Checked = false;
                cbbDeliver.Checked = false;
                cbbPermission.Checked = false;
                cbbExp.Checked = false;
                cbbReport.Checked = false;
                cbbReportProduct.Checked = false;
                cbbReportSale.Checked = false;
                cbbShere.Checked = false;
                CbbReportSaleProduct.Checked = false;
            }
            
        }

        private void cbbDealer_CheckedChanged(object sender, EventArgs e)
        {
            if (cbbDealer.Checked && true)
            {
                cbbBackOffice.Checked = true;
                cbbMember.Checked = true;
                cbbProduct.Checked = true;
                cbbOrder.Checked = true;
                cbbDeliver.Checked = true;
                cbbPermission.Checked = true;
                cbbExp.Checked = true;
                cbbShere.Checked = true;
                cbbReport.Checked = true;
                cbbReportProduct.Checked = true;
                cbbReportSale.Checked = true;
                CbbReportSaleProduct.Checked = true;
            }
            else
            {
                cbbBackOffice.Checked = false;
                cbbMember.Checked = false;
                cbbProduct.Checked = false;
                cbbOrder.Checked = false;
                cbbDeliver.Checked = false;
                cbbPermission.Checked = false;
                cbbExp.Checked = false;
                cbbReport.Checked = false;
                cbbReportProduct.Checked = false;
                cbbReportSale.Checked = false;
                cbbShere.Checked = false;
                CbbReportSaleProduct.Checked = false;
            }
        }

        private void cbbOrder_CheckedChanged(object sender, EventArgs e)
        {
            if (cbbOrder.Checked && true)
            {
                cbbBackOffice.Checked = true;
                cbbMember.Checked = true;
                cbbProduct.Checked = true;
                cbbDealer.Checked = true;
                cbbDeliver.Checked = true;
                cbbPermission.Checked = true;
                cbbExp.Checked = true;
                cbbShere.Checked = true;
                cbbReport.Checked = true;
                cbbReportProduct.Checked = true;
                cbbReportSale.Checked = true;
                CbbReportSaleProduct.Checked = true;
            }
            else
            {
                cbbBackOffice.Checked = false;
                cbbMember.Checked = false;
                cbbProduct.Checked = false;
                cbbDealer.Checked = false;
                cbbDeliver.Checked = false;
                cbbPermission.Checked = false;
                cbbExp.Checked = false;
                cbbReport.Checked = false;
                cbbReportProduct.Checked = false;
                cbbReportSale.Checked = false;
                cbbShere.Checked = false;
                CbbReportSaleProduct.Checked = false;
            }
        }

        private void cbbDeliver_CheckedChanged(object sender, EventArgs e)
        {
            if (cbbDeliver.Checked && true)
            {
                cbbBackOffice.Checked = true;
                cbbMember.Checked = true;
                cbbProduct.Checked = true;
                cbbDealer.Checked = true;
                cbbOrder.Checked = true;
                cbbPermission.Checked = true;
                cbbExp.Checked = true;
                cbbShere.Checked = true;
                cbbReport.Checked = true;
                cbbReportProduct.Checked = true;
                cbbReportSale.Checked = true;
                CbbReportSaleProduct.Checked = true;
            }
            else
            {
                cbbBackOffice.Checked = false;
                cbbMember.Checked = false;
                cbbProduct.Checked = false;
                cbbDealer.Checked = false;
                cbbOrder.Checked = false;
                cbbPermission.Checked = false;
                cbbExp.Checked = false;
                cbbReport.Checked = false;
                cbbReportProduct.Checked = false;
                cbbReportSale.Checked = false;
                cbbShere.Checked = false;
                CbbReportSaleProduct.Checked = false;
            }
        }

        private void cbbAuthority_CheckedChanged(object sender, EventArgs e)
        {
            if (cbbPermission.Checked && true)
            {
                cbbBackOffice.Checked = true;
                cbbMember.Checked = true;
                cbbProduct.Checked = true;
                cbbDealer.Checked = true;
                cbbOrder.Checked = true;
                cbbDeliver.Checked = true;
                cbbExp.Checked = true;
                cbbShere.Checked = true;
                cbbReport.Checked = true;
                cbbReportProduct.Checked = true;
                cbbReportSale.Checked = true;
                CbbReportSaleProduct.Checked = true;
            }
            else
            {
                cbbBackOffice.Checked = false;
                cbbMember.Checked = false;
                cbbProduct.Checked = false;
                cbbDealer.Checked = false;
                cbbOrder.Checked = false;
                cbbDeliver.Checked = false;
                cbbExp.Checked = false;
                cbbReport.Checked = false;
                cbbReportProduct.Checked = false;
                cbbReportSale.Checked = false;
                cbbShere.Checked = false;
                CbbReportSaleProduct.Checked = false;
            }
        }

        private void cbbExp_CheckedChanged(object sender, EventArgs e)
        {
            if (cbbExp.Checked && true)
            {
                cbbBackOffice.Checked = true;
                cbbMember.Checked = true;
                cbbProduct.Checked = true;
                cbbDealer.Checked = true;
                cbbOrder.Checked = true;
                cbbDeliver.Checked = true;
                cbbPermission.Checked = true;
                cbbShere.Checked = true;
                cbbReport.Checked = true;
                cbbReportProduct.Checked = true;
                cbbReportSale.Checked = true;
                CbbReportSaleProduct.Checked = true;
            }
            else
            {
                cbbBackOffice.Checked = false;
                cbbMember.Checked = false;
                cbbProduct.Checked = false;
                cbbDealer.Checked = false;
                cbbOrder.Checked = false;
                cbbDeliver.Checked = false;
                cbbPermission.Checked = false;
                cbbReport.Checked = false;
                cbbReportProduct.Checked = false;
                cbbReportSale.Checked = false;
                cbbShere.Checked = false;
                CbbReportSaleProduct.Checked = false;
            }
        }

        private void cbbReportSale_CheckedChanged(object sender, EventArgs e)
        {
            if (cbbReportSale.Checked && true)
            {
                cbbBackOffice.Checked = true;
                cbbMember.Checked = true;
                cbbProduct.Checked = true;
                cbbDealer.Checked = true;
                cbbOrder.Checked = true;
                cbbDeliver.Checked = true;
                cbbPermission.Checked = true;
                cbbShere.Checked = true;
                cbbReport.Checked = true;
                cbbReportProduct.Checked = true;
                cbbExp.Checked = true;
                CbbReportSaleProduct.Checked = true;
            }
            else
            {
                cbbBackOffice.Checked = false;
                cbbMember.Checked = false;
                cbbProduct.Checked = false;
                cbbDealer.Checked = false;
                cbbOrder.Checked = false;
                cbbDeliver.Checked = false;
                cbbPermission.Checked = false;
                cbbReport.Checked = false;
                cbbReportProduct.Checked = false;
                cbbExp.Checked = false;
                cbbShere.Checked = false;
                CbbReportSaleProduct.Checked = false;
            }
        }

        private void cbbReportProduct_CheckedChanged(object sender, EventArgs e)
        {
            if (cbbReportProduct.Checked && true)
            {
                cbbBackOffice.Checked = true;
                cbbMember.Checked = true;
                cbbProduct.Checked = true;
                cbbDealer.Checked = true;
                cbbOrder.Checked = true;
                cbbDeliver.Checked = true;
                cbbPermission.Checked = true;
                cbbShere.Checked = true;
                cbbReport.Checked = true;
                cbbReportSale.Checked = true;
                cbbExp.Checked = true;
                CbbReportSaleProduct.Checked = true;
            }
            else
            {
                cbbBackOffice.Checked = false;
                cbbMember.Checked = false;
                cbbProduct.Checked = false;
                cbbDealer.Checked = false;
                cbbOrder.Checked = false;
                cbbDeliver.Checked = false;
                cbbPermission.Checked = false;
                cbbReport.Checked = false;
                cbbReportSale.Checked = false;
                cbbExp.Checked = false;
                cbbShere.Checked = false;
                CbbReportSaleProduct.Checked = false;
            }
        }

        private void cbbShere_CheckedChanged(object sender, EventArgs e)
        {
            if (cbbShere.Checked && true)
            {
                cbbBackOffice.Checked = true;
                cbbMember.Checked = true;
                cbbProduct.Checked = true;
                cbbDealer.Checked = true;
                cbbOrder.Checked = true;
                cbbDeliver.Checked = true;
                cbbPermission.Checked = true;
                cbbReportProduct.Checked = true;
                cbbReport.Checked = true;
                cbbReportSale.Checked = true;
                cbbExp.Checked = true;
                CbbReportSaleProduct.Checked = true;
            }
            else
            {
                cbbBackOffice.Checked = false;
                cbbMember.Checked = false;
                cbbProduct.Checked = false;
                cbbDealer.Checked = false;
                cbbOrder.Checked = false;
                cbbDeliver.Checked = false;
                cbbPermission.Checked = false;
                cbbReport.Checked = false;
                cbbReportSale.Checked = false;
                cbbExp.Checked = false;
                cbbReportProduct.Checked = false;
                CbbReportSaleProduct.Checked = false;
            }
        }

        private void CbbReportSaleProduct_CheckedChanged(object sender, EventArgs e)
        {
            if (CbbReportSaleProduct.Checked && true)
            {
                cbbBackOffice.Checked = true;
                cbbMember.Checked = true;
                cbbProduct.Checked = true;
                cbbDealer.Checked = true;
                cbbOrder.Checked = true;
                cbbDeliver.Checked = true;
                cbbPermission.Checked = true;
                cbbReportProduct.Checked = true;
                cbbReport.Checked = true;
                cbbReportSale.Checked = true;
                cbbExp.Checked = true;
                cbbShere.Checked = true;
            }
            else
            {
                cbbBackOffice.Checked = false;
                cbbMember.Checked = false;
                cbbProduct.Checked = false;
                cbbDealer.Checked = false;
                cbbOrder.Checked = false;
                cbbDeliver.Checked = false;
                cbbPermission.Checked = false;
                cbbReport.Checked = false;
                cbbReportSale.Checked = false;
                cbbExp.Checked = false;
                cbbReportProduct.Checked = false;
                cbbShere.Checked = false;
            }
        }

        private void cbbReport_CheckedChanged(object sender, EventArgs e)
        {
            if (cbbReport.Checked && true)
            {
                cbbBackOffice.Checked = true;
                cbbMember.Checked = true;
                cbbProduct.Checked = true;
                cbbDealer.Checked = true;
                cbbOrder.Checked = true;
                cbbDeliver.Checked = true;
                cbbPermission.Checked = true;
                cbbReportProduct.Checked = true;
                CbbReportSaleProduct.Checked = true;
                cbbReportSale.Checked = true;
                cbbExp.Checked = true;
                cbbShere.Checked = true;
            }
            else
            {
                cbbBackOffice.Checked = false;
                cbbMember.Checked = false;
                cbbProduct.Checked = false;
                cbbDealer.Checked = false;
                cbbOrder.Checked = false;
                cbbDeliver.Checked = false;
                cbbPermission.Checked = false;
                CbbReportSaleProduct.Checked = false;
                cbbReportSale.Checked = false;
                cbbExp.Checked = false;
                cbbReportProduct.Checked = false;
                cbbShere.Checked = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        
    }
}
