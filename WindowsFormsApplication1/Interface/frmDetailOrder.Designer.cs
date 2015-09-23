namespace Stock.Interface
{
    partial class frmDetailOrder
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblMID = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvView = new System.Windows.Forms.DataGridView();
            this.Order_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateSent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateReceive = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dealer_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mem_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mem_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dealer_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.note = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdbW = new System.Windows.Forms.RadioButton();
            this.rdbC = new System.Windows.Forms.RadioButton();
            this.rdbA = new System.Windows.Forms.RadioButton();
            this.txtRdb = new System.Windows.Forms.TextBox();
            this.txtOrder = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnView = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpDateSent = new System.Windows.Forms.DateTimePicker();
            this.btnSearch = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.lblMID);
            this.panel1.Controls.Add(this.lblUser);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.txtRdb);
            this.panel1.Controls.Add(this.txtOrder);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.btnView);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dtpDateSent);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Location = new System.Drawing.Point(13, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(859, 536);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // lblMID
            // 
            this.lblMID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMID.AutoSize = true;
            this.lblMID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblMID.Location = new System.Drawing.Point(567, -4);
            this.lblMID.Name = "lblMID";
            this.lblMID.Size = new System.Drawing.Size(51, 20);
            this.lblMID.TabIndex = 20;
            this.lblMID.Text = "label3";
            this.lblMID.Visible = false;
            this.lblMID.Click += new System.EventHandler(this.lblMID_Click);
            // 
            // lblUser
            // 
            this.lblUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUser.AutoSize = true;
            this.lblUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblUser.Location = new System.Drawing.Point(698, -2);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(51, 20);
            this.lblUser.TabIndex = 19;
            this.lblUser.Text = "label3";
            this.lblUser.Visible = false;
            this.lblUser.Click += new System.EventHandler(this.lblUser_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.dgvView);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.groupBox2.Location = new System.Drawing.Point(3, 87);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(853, 396);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "ข้อมูลการสั่ง";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // dgvView
            // 
            this.dgvView.AllowUserToAddRows = false;
            this.dgvView.AllowUserToDeleteRows = false;
            this.dgvView.AllowUserToResizeRows = false;
            this.dgvView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Order_ID,
            this.DateSent,
            this.DateReceive,
            this.Status,
            this.Dealer_Name,
            this.Mem_ID,
            this.Mem_Name,
            this.Dealer_ID,
            this.note});
            this.dgvView.Location = new System.Drawing.Point(6, 25);
            this.dgvView.Name = "dgvView";
            this.dgvView.RowHeadersVisible = false;
            this.dgvView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvView.Size = new System.Drawing.Size(841, 365);
            this.dgvView.TabIndex = 0;
            this.dgvView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvView_CellContentClick);
            // 
            // Order_ID
            // 
            this.Order_ID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Order_ID.DataPropertyName = "Order_ID";
            this.Order_ID.HeaderText = "รหัสการสั่ง";
            this.Order_ID.Name = "Order_ID";
            // 
            // DateSent
            // 
            this.DateSent.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DateSent.DataPropertyName = "DateSent";
            this.DateSent.HeaderText = "วันที่สั่ง";
            this.DateSent.Name = "DateSent";
            // 
            // DateReceive
            // 
            this.DateReceive.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DateReceive.DataPropertyName = "DateReceive";
            this.DateReceive.HeaderText = "วันที่รับ";
            this.DateReceive.Name = "DateReceive";
            // 
            // Status
            // 
            this.Status.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Status.DataPropertyName = "Status";
            this.Status.HeaderText = "สถานะ";
            this.Status.Name = "Status";
            // 
            // Dealer_Name
            // 
            this.Dealer_Name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Dealer_Name.DataPropertyName = "Dealer_Name";
            this.Dealer_Name.HeaderText = "ตัวแทนจำหน่าย";
            this.Dealer_Name.Name = "Dealer_Name";
            // 
            // Mem_ID
            // 
            this.Mem_ID.DataPropertyName = "Mem_ID";
            this.Mem_ID.HeaderText = "Mem_ID";
            this.Mem_ID.Name = "Mem_ID";
            this.Mem_ID.Visible = false;
            // 
            // Mem_Name
            // 
            this.Mem_Name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Mem_Name.DataPropertyName = "Mem_Name";
            this.Mem_Name.HeaderText = "ชื่อกรรมการ";
            this.Mem_Name.Name = "Mem_Name";
            // 
            // Dealer_ID
            // 
            this.Dealer_ID.DataPropertyName = "Dealer_ID";
            this.Dealer_ID.HeaderText = "Dealer_ID";
            this.Dealer_ID.Name = "Dealer_ID";
            this.Dealer_ID.Visible = false;
            // 
            // note
            // 
            this.note.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.note.DataPropertyName = "note";
            this.note.HeaderText = "หมายเหตุ";
            this.note.Name = "note";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.rdbW);
            this.groupBox1.Controls.Add(this.rdbC);
            this.groupBox1.Controls.Add(this.rdbA);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.groupBox1.Location = new System.Drawing.Point(335, 52);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(404, 38);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "สถานะ";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // rdbW
            // 
            this.rdbW.AutoSize = true;
            this.rdbW.Checked = true;
            this.rdbW.Location = new System.Drawing.Point(55, 11);
            this.rdbW.Name = "rdbW";
            this.rdbW.Size = new System.Drawing.Size(76, 24);
            this.rdbW.TabIndex = 12;
            this.rdbW.TabStop = true;
            this.rdbW.Text = "รอยืนยัน";
            this.rdbW.UseVisualStyleBackColor = true;
            this.rdbW.CheckedChanged += new System.EventHandler(this.rdbW_CheckedChanged);
            // 
            // rdbC
            // 
            this.rdbC.AutoSize = true;
            this.rdbC.Location = new System.Drawing.Point(295, 11);
            this.rdbC.Name = "rdbC";
            this.rdbC.Size = new System.Drawing.Size(105, 24);
            this.rdbC.TabIndex = 15;
            this.rdbC.TabStop = true;
            this.rdbC.Text = "ยกเลิกการสั่ง";
            this.rdbC.UseVisualStyleBackColor = true;
            this.rdbC.CheckedChanged += new System.EventHandler(this.rdbC_CheckedChanged);
            // 
            // rdbA
            // 
            this.rdbA.AutoSize = true;
            this.rdbA.Location = new System.Drawing.Point(166, 10);
            this.rdbA.Name = "rdbA";
            this.rdbA.Size = new System.Drawing.Size(99, 24);
            this.rdbA.TabIndex = 13;
            this.rdbA.TabStop = true;
            this.rdbA.Text = "ยืนยันการสั่ง";
            this.rdbA.UseVisualStyleBackColor = true;
            this.rdbA.CheckedChanged += new System.EventHandler(this.rdbA_CheckedChanged);
            // 
            // txtRdb
            // 
            this.txtRdb.Location = new System.Drawing.Point(9, 3);
            this.txtRdb.Name = "txtRdb";
            this.txtRdb.Size = new System.Drawing.Size(100, 20);
            this.txtRdb.TabIndex = 17;
            this.txtRdb.Visible = false;
            this.txtRdb.TextChanged += new System.EventHandler(this.txtRdb_TextChanged);
            // 
            // txtOrder
            // 
            this.txtOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtOrder.Location = new System.Drawing.Point(584, 24);
            this.txtOrder.Name = "txtOrder";
            this.txtOrder.Size = new System.Drawing.Size(185, 26);
            this.txtOrder.TabIndex = 10;
            this.txtOrder.TextChanged += new System.EventHandler(this.txtOrder_TextChanged);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnClose.Location = new System.Drawing.Point(761, 489);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 44);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "ปิด";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnDelete.Location = new System.Drawing.Point(680, 489);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 44);
            this.btnDelete.TabIndex = 7;
            this.btnDelete.Text = "ยกเลิก";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnView
            // 
            this.btnView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnView.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnView.Location = new System.Drawing.Point(599, 489);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(75, 44);
            this.btnView.TabIndex = 6;
            this.btnView.Text = "ดูข้อมูล";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label2.Location = new System.Drawing.Point(491, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "เลขที่เอกสาร";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(294, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "วันที่";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // dtpDateSent
            // 
            this.dtpDateSent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpDateSent.CustomFormat = "dd/MM/yyyy";
            this.dtpDateSent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.dtpDateSent.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateSent.Location = new System.Drawing.Point(335, 24);
            this.dtpDateSent.Name = "dtpDateSent";
            this.dtpDateSent.Size = new System.Drawing.Size(154, 26);
            this.dtpDateSent.TabIndex = 2;
            this.dtpDateSent.ValueChanged += new System.EventHandler(this.dtpDateSent_ValueChanged);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnSearch.Location = new System.Drawing.Point(775, 14);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 42);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "ค้นหา";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // frmDetailOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Stock.Properties.Resources.Untitled_2x4;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.panel1);
            this.Name = "frmDetailOrder";
            this.Text = "ข้อมูลการสั่ง";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmDetailOrder_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpDateSent;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtOrder;
        private System.Windows.Forms.RadioButton rdbC;
        private System.Windows.Forms.RadioButton rdbA;
        private System.Windows.Forms.RadioButton rdbW;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtRdb;
        public System.Windows.Forms.DataGridView dgvView;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label lblMID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Order_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateSent;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateReceive;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dealer_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mem_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mem_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dealer_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn note;
    }
}