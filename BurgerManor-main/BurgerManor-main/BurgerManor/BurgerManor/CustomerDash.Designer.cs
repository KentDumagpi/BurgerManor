namespace BurgerManor
{
    partial class CustomerDash
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomerDash));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnFries = new System.Windows.Forms.Label();
            this.btnBurger = new System.Windows.Forms.Label();
            this.btnHome = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelHomeMain = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.fLPanelHome = new System.Windows.Forms.FlowLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.receipt = new System.Windows.Forms.DataGridView();
            this.OrderNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remove = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Add = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel10 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.btnEditOrder = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnPlaceOrder = new System.Windows.Forms.Button();
            this.panelBurgerMain = new System.Windows.Forms.Label();
            this.fLPanelBurger = new System.Windows.Forms.FlowLayoutPanel();
            this.panelburger = new System.Windows.Forms.Panel();
            this.panelFries = new System.Windows.Forms.Panel();
            this.flPanelFries = new System.Windows.Forms.FlowLayoutPanel();
            this.panelFriesMain = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelHomeMain.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.receipt)).BeginInit();
            this.panel10.SuspendLayout();
            this.panelburger.SuspendLayout();
            this.panelFries.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(152)))), ((int)(((byte)(59)))));
            this.panel1.Controls.Add(this.btnFries);
            this.panel1.Controls.Add(this.btnBurger);
            this.panel1.Controls.Add(this.btnHome);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1102, 114);
            this.panel1.TabIndex = 0;
            // 
            // btnFries
            // 
            this.btnFries.AutoSize = true;
            this.btnFries.Font = new System.Drawing.Font("Rockwell", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFries.ForeColor = System.Drawing.Color.White;
            this.btnFries.Location = new System.Drawing.Point(450, 49);
            this.btnFries.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.btnFries.Name = "btnFries";
            this.btnFries.Size = new System.Drawing.Size(74, 29);
            this.btnFries.TabIndex = 2;
            this.btnFries.Text = "Fries";
            this.btnFries.Click += new System.EventHandler(this.btnFries_Click);
            // 
            // btnBurger
            // 
            this.btnBurger.AutoSize = true;
            this.btnBurger.Font = new System.Drawing.Font("Rockwell", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBurger.ForeColor = System.Drawing.Color.White;
            this.btnBurger.Location = new System.Drawing.Point(306, 49);
            this.btnBurger.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.btnBurger.Name = "btnBurger";
            this.btnBurger.Size = new System.Drawing.Size(108, 29);
            this.btnBurger.TabIndex = 2;
            this.btnBurger.Text = "Burgers";
            this.btnBurger.Click += new System.EventHandler(this.label2_Click);
            // 
            // btnHome
            // 
            this.btnHome.AutoSize = true;
            this.btnHome.Font = new System.Drawing.Font("Rockwell", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHome.ForeColor = System.Drawing.Color.White;
            this.btnHome.Location = new System.Drawing.Point(195, 49);
            this.btnHome.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(83, 29);
            this.btnHome.TabIndex = 1;
            this.btnHome.Text = "Home";
            this.btnHome.Click += new System.EventHandler(this.label1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(148, 113);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // panelHomeMain
            // 
            this.panelHomeMain.Controls.Add(this.fLPanelHome);
            this.panelHomeMain.Controls.Add(this.label4);
            this.panelHomeMain.Location = new System.Drawing.Point(6, 121);
            this.panelHomeMain.Name = "panelHomeMain";
            this.panelHomeMain.Size = new System.Drawing.Size(676, 632);
            this.panelHomeMain.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Rockwell", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 23);
            this.label4.TabIndex = 0;
            this.label4.Text = "Home";
            // 
            // fLPanelHome
            // 
            this.fLPanelHome.Location = new System.Drawing.Point(4, 42);
            this.fLPanelHome.Name = "fLPanelHome";
            this.fLPanelHome.Size = new System.Drawing.Size(669, 582);
            this.fLPanelHome.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Location = new System.Drawing.Point(688, 172);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(408, 44);
            this.panel3.TabIndex = 57;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Sans Serif Collection", 5.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(265, 11);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 17);
            this.label9.TabIndex = 4;
            this.label9.Text = "PRICE";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Sans Serif Collection", 5.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(180, 11);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(78, 17);
            this.label8.TabIndex = 3;
            this.label8.Text = "QUANTITY";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Sans Serif Collection", 5.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(59, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 17);
            this.label5.TabIndex = 1;
            this.label5.Text = "NAME";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Sans Serif Collection", 5.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(7, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(16, 17);
            this.label6.TabIndex = 0;
            this.label6.Text = "#";
            // 
            // receipt
            // 
            this.receipt.AllowUserToAddRows = false;
            this.receipt.AllowUserToDeleteRows = false;
            this.receipt.AllowUserToResizeColumns = false;
            this.receipt.AllowUserToResizeRows = false;
            this.receipt.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.receipt.BackgroundColor = System.Drawing.Color.White;
            this.receipt.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.receipt.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.receipt.ColumnHeadersHeight = 37;
            this.receipt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.receipt.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.OrderNo,
            this.OID,
            this.OrderName,
            this.OrderQuantity,
            this.UnitPrice,
            this.OrderPrice,
            this.Remove,
            this.Add});
            this.receipt.Location = new System.Drawing.Point(688, 216);
            this.receipt.Name = "receipt";
            this.receipt.ReadOnly = true;
            this.receipt.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.receipt.RowHeadersVisible = false;
            this.receipt.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.receipt.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.receipt.ShowRowErrors = false;
            this.receipt.Size = new System.Drawing.Size(408, 420);
            this.receipt.TabIndex = 56;
            // 
            // OrderNo
            // 
            this.OrderNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.OrderNo.HeaderText = "#";
            this.OrderNo.Name = "OrderNo";
            this.OrderNo.ReadOnly = true;
            this.OrderNo.Width = 51;
            // 
            // OID
            // 
            this.OID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.OID.DataPropertyName = "PID";
            this.OID.HeaderText = "ID";
            this.OID.Name = "OID";
            this.OID.ReadOnly = true;
            this.OID.Visible = false;
            this.OID.Width = 43;
            // 
            // OrderName
            // 
            this.OrderName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.OrderName.DataPropertyName = "P_NAME";
            this.OrderName.FillWeight = 150F;
            this.OrderName.HeaderText = "Name";
            this.OrderName.Name = "OrderName";
            this.OrderName.ReadOnly = true;
            this.OrderName.Width = 125;
            // 
            // OrderQuantity
            // 
            this.OrderQuantity.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.OrderQuantity.DataPropertyName = "P_QUANTITY";
            this.OrderQuantity.HeaderText = "Quantity";
            this.OrderQuantity.Name = "OrderQuantity";
            this.OrderQuantity.ReadOnly = true;
            this.OrderQuantity.Width = 86;
            // 
            // UnitPrice
            // 
            this.UnitPrice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.UnitPrice.DataPropertyName = "P_PRICE";
            this.UnitPrice.HeaderText = "Unit Price";
            this.UnitPrice.Name = "UnitPrice";
            this.UnitPrice.ReadOnly = true;
            this.UnitPrice.Visible = false;
            this.UnitPrice.Width = 60;
            // 
            // OrderPrice
            // 
            this.OrderPrice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.OrderPrice.DataPropertyName = "P_PRICE";
            this.OrderPrice.HeaderText = "Price";
            this.OrderPrice.Name = "OrderPrice";
            this.OrderPrice.ReadOnly = true;
            this.OrderPrice.Width = 75;
            // 
            // Remove
            // 
            this.Remove.HeaderText = "-";
            this.Remove.Name = "Remove";
            this.Remove.ReadOnly = true;
            // 
            // Add
            // 
            this.Add.HeaderText = "+";
            this.Add.Name = "Add";
            this.Add.ReadOnly = true;
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(152)))), ((int)(((byte)(59)))));
            this.panel10.Controls.Add(this.label7);
            this.panel10.Location = new System.Drawing.Point(688, 120);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(408, 52);
            this.panel10.TabIndex = 55;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Rockwell", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(161, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 23);
            this.label7.TabIndex = 54;
            this.label7.Text = "RECEIPT";
            // 
            // btnEditOrder
            // 
            this.btnEditOrder.BackColor = System.Drawing.Color.White;
            this.btnEditOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditOrder.Font = new System.Drawing.Font("Sans Serif Collection", 5.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditOrder.Location = new System.Drawing.Point(688, 681);
            this.btnEditOrder.Name = "btnEditOrder";
            this.btnEditOrder.Size = new System.Drawing.Size(408, 33);
            this.btnEditOrder.TabIndex = 63;
            this.btnEditOrder.Text = "Edit";
            this.btnEditOrder.UseVisualStyleBackColor = false;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.White;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Sans Serif Collection", 5.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(688, 720);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(408, 33);
            this.btnDelete.TabIndex = 62;
            this.btnDelete.Text = "Remove";
            this.btnDelete.UseVisualStyleBackColor = false;
            // 
            // btnPlaceOrder
            // 
            this.btnPlaceOrder.BackColor = System.Drawing.Color.White;
            this.btnPlaceOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlaceOrder.Font = new System.Drawing.Font("Sans Serif Collection", 5.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlaceOrder.Location = new System.Drawing.Point(688, 642);
            this.btnPlaceOrder.Name = "btnPlaceOrder";
            this.btnPlaceOrder.Size = new System.Drawing.Size(408, 33);
            this.btnPlaceOrder.TabIndex = 61;
            this.btnPlaceOrder.Text = "Purchase";
            this.btnPlaceOrder.UseVisualStyleBackColor = false;
            // 
            // panelBurgerMain
            // 
            this.panelBurgerMain.AutoSize = true;
            this.panelBurgerMain.Font = new System.Drawing.Font("Rockwell", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelBurgerMain.Location = new System.Drawing.Point(12, 16);
            this.panelBurgerMain.Name = "panelBurgerMain";
            this.panelBurgerMain.Size = new System.Drawing.Size(86, 23);
            this.panelBurgerMain.TabIndex = 0;
            this.panelBurgerMain.Text = "Burgers";
            // 
            // fLPanelBurger
            // 
            this.fLPanelBurger.Location = new System.Drawing.Point(4, 42);
            this.fLPanelBurger.Name = "fLPanelBurger";
            this.fLPanelBurger.Size = new System.Drawing.Size(669, 582);
            this.fLPanelBurger.TabIndex = 1;
            // 
            // panelburger
            // 
            this.panelburger.Controls.Add(this.panelBurgerMain);
            this.panelburger.Controls.Add(this.fLPanelBurger);
            this.panelburger.Location = new System.Drawing.Point(6, 123);
            this.panelburger.Name = "panelburger";
            this.panelburger.Size = new System.Drawing.Size(676, 632);
            this.panelburger.TabIndex = 2;
            // 
            // panelFries
            // 
            this.panelFries.Controls.Add(this.flPanelFries);
            this.panelFries.Controls.Add(this.panelFriesMain);
            this.panelFries.Location = new System.Drawing.Point(3, 121);
            this.panelFries.Name = "panelFries";
            this.panelFries.Size = new System.Drawing.Size(676, 632);
            this.panelFries.TabIndex = 2;
            // 
            // flPanelFries
            // 
            this.flPanelFries.Location = new System.Drawing.Point(4, 42);
            this.flPanelFries.Name = "flPanelFries";
            this.flPanelFries.Size = new System.Drawing.Size(669, 582);
            this.flPanelFries.TabIndex = 1;
            // 
            // panelFriesMain
            // 
            this.panelFriesMain.AutoSize = true;
            this.panelFriesMain.Font = new System.Drawing.Font("Rockwell", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelFriesMain.Location = new System.Drawing.Point(12, 16);
            this.panelFriesMain.Name = "panelFriesMain";
            this.panelFriesMain.Size = new System.Drawing.Size(59, 23);
            this.panelFriesMain.TabIndex = 0;
            this.panelFriesMain.Text = "Fries";
            // 
            // CustomerDash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1102, 756);
            this.Controls.Add(this.btnEditOrder);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnPlaceOrder);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.receipt);
            this.Controls.Add(this.panel10);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelHomeMain);
            this.Controls.Add(this.panelburger);
            this.Controls.Add(this.panelFries);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "CustomerDash";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.Load += new System.EventHandler(this.CustomerDash_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelHomeMain.ResumeLayout(false);
            this.panelHomeMain.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.receipt)).EndInit();
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.panelburger.ResumeLayout(false);
            this.panelburger.PerformLayout();
            this.panelFries.ResumeLayout(false);
            this.panelFries.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label btnHome;
        private System.Windows.Forms.Label btnFries;
        private System.Windows.Forms.Label btnBurger;
        private System.Windows.Forms.Panel panelHomeMain;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.FlowLayoutPanel fLPanelHome;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView receipt;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn OID;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderName;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderPrice;
        private System.Windows.Forms.DataGridViewButtonColumn Remove;
        private System.Windows.Forms.DataGridViewButtonColumn Add;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnEditOrder;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnPlaceOrder;
        private System.Windows.Forms.Panel panelFries;
        private System.Windows.Forms.FlowLayoutPanel flPanelFries;
        private System.Windows.Forms.Label panelFriesMain;
        private System.Windows.Forms.Label panelBurgerMain;
        private System.Windows.Forms.FlowLayoutPanel fLPanelBurger;
        private System.Windows.Forms.Panel panelburger;
    }
}