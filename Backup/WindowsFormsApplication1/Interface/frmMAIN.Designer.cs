namespace Stock.Interface
{
    partial class frmMAIN
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnDealer = new System.Windows.Forms.Button();
            this.btnReportSale = new System.Windows.Forms.Button();
            this.btnPermission = new System.Windows.Forms.Button();
            this.btnSale = new System.Windows.Forms.Button();
            this.btnDalivery = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnReport = new System.Windows.Forms.Button();
            this.btnProduct = new System.Windows.Forms.Button();
            this.btnShere = new System.Windows.Forms.Button();
            this.btnReportMember = new System.Windows.Forms.Button();
            this.btnMember = new System.Windows.Forms.Button();
            this.btnOrder = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDealer
            // 
            this.btnDealer.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDealer.Font = new System.Drawing.Font("Maiandra GD", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDealer.Location = new System.Drawing.Point(661, 157);
            this.btnDealer.Name = "btnDealer";
            this.btnDealer.Size = new System.Drawing.Size(157, 99);
            this.btnDealer.TabIndex = 12;
            this.btnDealer.Text = "ตัวแทน\r\nจำหน่าย";
            this.btnDealer.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnDealer.UseVisualStyleBackColor = true;
            this.btnDealer.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnReportSale
            // 
            this.btnReportSale.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnReportSale.Font = new System.Drawing.Font("Maiandra GD", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReportSale.Location = new System.Drawing.Point(246, 406);
            this.btnReportSale.Name = "btnReportSale";
            this.btnReportSale.Size = new System.Drawing.Size(157, 99);
            this.btnReportSale.TabIndex = 9;
            this.btnReportSale.Text = "สรุปยอด\r\nขายสินค้า";
            this.btnReportSale.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnReportSale.UseVisualStyleBackColor = true;
            // 
            // btnPermission
            // 
            this.btnPermission.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnPermission.Font = new System.Drawing.Font("Maiandra GD", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPermission.Location = new System.Drawing.Point(43, 282);
            this.btnPermission.Name = "btnPermission";
            this.btnPermission.Size = new System.Drawing.Size(157, 99);
            this.btnPermission.TabIndex = 2;
            this.btnPermission.Text = "สิทธิ์\r\nการใช้งาน";
            this.btnPermission.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnPermission.UseVisualStyleBackColor = true;
            // 
            // btnSale
            // 
            this.btnSale.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSale.Font = new System.Drawing.Font("Maiandra GD", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSale.Location = new System.Drawing.Point(43, 157);
            this.btnSale.Name = "btnSale";
            this.btnSale.Size = new System.Drawing.Size(157, 99);
            this.btnSale.TabIndex = 6;
            this.btnSale.Text = "ขายสินค้า";
            this.btnSale.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnSale.UseVisualStyleBackColor = true;
            // 
            // btnDalivery
            // 
            this.btnDalivery.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDalivery.Font = new System.Drawing.Font("Maiandra GD", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDalivery.Location = new System.Drawing.Point(453, 282);
            this.btnDalivery.Name = "btnDalivery";
            this.btnDalivery.Size = new System.Drawing.Size(157, 99);
            this.btnDalivery.TabIndex = 4;
            this.btnDalivery.Text = "รับสินค้า";
            this.btnDalivery.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnDalivery.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(-288, -138);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1460, 838);
            this.panel1.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.btnDealer);
            this.panel2.Controls.Add(this.btnExit);
            this.panel2.Controls.Add(this.btnReport);
            this.panel2.Controls.Add(this.btnProduct);
            this.panel2.Controls.Add(this.btnReportSale);
            this.panel2.Controls.Add(this.btnShere);
            this.panel2.Controls.Add(this.btnPermission);
            this.panel2.Controls.Add(this.btnReportMember);
            this.panel2.Controls.Add(this.btnMember);
            this.panel2.Controls.Add(this.btnOrder);
            this.panel2.Controls.Add(this.btnSale);
            this.panel2.Controls.Add(this.btnDalivery);
            this.panel2.Location = new System.Drawing.Point(297, 150);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(863, 538);
            this.panel2.TabIndex = 11;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::Stock.Properties.Resources.login01;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(769, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(94, 79);
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // btnExit
            // 
            this.btnExit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnExit.Font = new System.Drawing.Font("Maiandra GD", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(661, 282);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(157, 99);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "สินค้า\r\nยกเลิกขาย";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnExit.UseVisualStyleBackColor = true;
            // 
            // btnReport
            // 
            this.btnReport.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnReport.Font = new System.Drawing.Font("Maiandra GD", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReport.Location = new System.Drawing.Point(661, 406);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(157, 99);
            this.btnReport.TabIndex = 10;
            this.btnReport.Text = "รายงาน\r\nสรุปผล";
            this.btnReport.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnReport.UseVisualStyleBackColor = true;
            // 
            // btnProduct
            // 
            this.btnProduct.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnProduct.Font = new System.Drawing.Font("Maiandra GD", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProduct.Location = new System.Drawing.Point(453, 157);
            this.btnProduct.Name = "btnProduct";
            this.btnProduct.Size = new System.Drawing.Size(157, 99);
            this.btnProduct.TabIndex = 1;
            this.btnProduct.Text = "ข้อมูล\r\nสินค้า";
            this.btnProduct.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnProduct.UseVisualStyleBackColor = true;
            this.btnProduct.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnShere
            // 
            this.btnShere.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnShere.Font = new System.Drawing.Font("Maiandra GD", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShere.Location = new System.Drawing.Point(453, 406);
            this.btnShere.Name = "btnShere";
            this.btnShere.Size = new System.Drawing.Size(157, 99);
            this.btnShere.TabIndex = 7;
            this.btnShere.Text = "เงินปันผล";
            this.btnShere.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnShere.UseVisualStyleBackColor = true;
            // 
            // btnReportMember
            // 
            this.btnReportMember.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnReportMember.Font = new System.Drawing.Font("Maiandra GD", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReportMember.Location = new System.Drawing.Point(43, 406);
            this.btnReportMember.Name = "btnReportMember";
            this.btnReportMember.Size = new System.Drawing.Size(157, 99);
            this.btnReportMember.TabIndex = 8;
            this.btnReportMember.Text = "สรุปยอด\r\nซื้อสมาชิก";
            this.btnReportMember.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnReportMember.UseVisualStyleBackColor = true;
            // 
            // btnMember
            // 
            this.btnMember.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnMember.Font = new System.Drawing.Font("Maiandra GD", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMember.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnMember.Location = new System.Drawing.Point(246, 157);
            this.btnMember.Name = "btnMember";
            this.btnMember.Size = new System.Drawing.Size(157, 99);
            this.btnMember.TabIndex = 0;
            this.btnMember.Text = "ข้อมูล\r\nสมาชิก";
            this.btnMember.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnMember.UseVisualStyleBackColor = true;
            this.btnMember.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnOrder
            // 
            this.btnOrder.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnOrder.Font = new System.Drawing.Font("Maiandra GD", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOrder.Location = new System.Drawing.Point(246, 282);
            this.btnOrder.Name = "btnOrder";
            this.btnOrder.Size = new System.Drawing.Size(157, 99);
            this.btnOrder.TabIndex = 5;
            this.btnOrder.Text = "สั่งสินค้า";
            this.btnOrder.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnOrder.UseVisualStyleBackColor = true;
            // 
            // frmMAIN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 562);
            this.Controls.Add(this.panel1);
            this.Name = "frmMAIN";
            this.Text = "frmMAIN";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.Button btnDealer;
        public System.Windows.Forms.Button btnReportSale;
        public System.Windows.Forms.Button btnPermission;
        public System.Windows.Forms.Button btnMember;
        public System.Windows.Forms.Button btnSale;
        public System.Windows.Forms.Button btnDalivery;
        public System.Windows.Forms.Button btnExit;
        public System.Windows.Forms.Button btnReport;
        public System.Windows.Forms.Button btnProduct;
        public System.Windows.Forms.Button btnShere;
        public System.Windows.Forms.Button btnReportMember;
        public System.Windows.Forms.Button btnOrder;
    }
}