namespace UI
{
    partial class Customer
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
            txtSearchName = new TextBox();
            txtBalance = new TextBox();
            lblBalance = new Label();
            btnSearch = new Button();
            btnSetBalance = new Button();
            dgvApplications = new DataGridView();
            btnPurchaseApp = new Button();
            cmbCustomerContentRating = new ComboBox();
            cmbCustomerAppType = new ComboBox();
            cmbCustomerGenre = new ComboBox();
            cmbCustomerCategory = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dgvApplications).BeginInit();
            SuspendLayout();
            // 
            // txtSearchName
            // 
            txtSearchName.Location = new Point(12, 244);
            txtSearchName.Name = "txtSearchName";
            txtSearchName.Size = new Size(125, 27);
            txtSearchName.TabIndex = 0;
            // 
            // txtBalance
            // 
            txtBalance.Location = new Point(496, 281);
            txtBalance.Name = "txtBalance";
            txtBalance.Size = new Size(125, 27);
            txtBalance.TabIndex = 2;
            // 
            // lblBalance
            // 
            lblBalance.AutoSize = true;
            lblBalance.Location = new Point(12, 290);
            lblBalance.Name = "lblBalance";
            lblBalance.Size = new Size(64, 20);
            lblBalance.TabIndex = 3;
            lblBalance.Text = "Balance:";
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(343, 243);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(94, 29);
            btnSearch.TabIndex = 4;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // btnSetBalance
            // 
            btnSetBalance.Location = new Point(624, 281);
            btnSetBalance.Name = "btnSetBalance";
            btnSetBalance.Size = new Size(94, 29);
            btnSetBalance.TabIndex = 5;
            btnSetBalance.Text = "Set";
            btnSetBalance.UseVisualStyleBackColor = true;
            btnSetBalance.Click += btnSetBalance_Click;
            // 
            // dgvApplications
            // 
            dgvApplications.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvApplications.Location = new Point(-1, 3);
            dgvApplications.Name = "dgvApplications";
            dgvApplications.RowHeadersWidth = 51;
            dgvApplications.Size = new Size(789, 216);
            dgvApplications.TabIndex = 6;
            // 
            // btnPurchaseApp
            // 
            btnPurchaseApp.Location = new Point(496, 409);
            btnPurchaseApp.Name = "btnPurchaseApp";
            btnPurchaseApp.Size = new Size(94, 29);
            btnPurchaseApp.TabIndex = 7;
            btnPurchaseApp.Text = "Buy";
            btnPurchaseApp.UseVisualStyleBackColor = true;
            btnPurchaseApp.Click += btnPurchaseApp_Click;
            // 
            // cmbCustomerContentRating
            // 
            cmbCustomerContentRating.FormattingEnabled = true;
            cmbCustomerContentRating.Location = new Point(317, 309);
            cmbCustomerContentRating.Name = "cmbCustomerContentRating";
            cmbCustomerContentRating.Size = new Size(151, 28);
            cmbCustomerContentRating.TabIndex = 8;
            // 
            // cmbCustomerAppType
            // 
            cmbCustomerAppType.FormattingEnabled = true;
            cmbCustomerAppType.Location = new Point(317, 365);
            cmbCustomerAppType.Name = "cmbCustomerAppType";
            cmbCustomerAppType.Size = new Size(151, 28);
            cmbCustomerAppType.TabIndex = 9;
            // 
            // cmbCustomerGenre
            // 
            cmbCustomerGenre.FormattingEnabled = true;
            cmbCustomerGenre.Location = new Point(129, 365);
            cmbCustomerGenre.Name = "cmbCustomerGenre";
            cmbCustomerGenre.Size = new Size(151, 28);
            cmbCustomerGenre.TabIndex = 10;
            // 
            // cmbCustomerCategory
            // 
            cmbCustomerCategory.FormattingEnabled = true;
            cmbCustomerCategory.Location = new Point(129, 309);
            cmbCustomerCategory.Name = "cmbCustomerCategory";
            cmbCustomerCategory.Size = new Size(151, 28);
            cmbCustomerCategory.TabIndex = 11;
            // 
            // Customer
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(cmbCustomerCategory);
            Controls.Add(cmbCustomerGenre);
            Controls.Add(cmbCustomerAppType);
            Controls.Add(cmbCustomerContentRating);
            Controls.Add(btnPurchaseApp);
            Controls.Add(dgvApplications);
            Controls.Add(btnSetBalance);
            Controls.Add(btnSearch);
            Controls.Add(lblBalance);
            Controls.Add(txtBalance);
            Controls.Add(txtSearchName);
            Name = "Customer";
            Text = "Customer";
            ((System.ComponentModel.ISupportInitialize)dgvApplications).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtSearchName;
        private TextBox txtBalance;
        private Label lblBalance;
        private Button btnSearch;
        private Button btnSetBalance;
        private DataGridView dgvApplications;
        private Button btnPurchaseApp;
        private ComboBox cmbCustomerContentRating;
        private ComboBox cmbCustomerAppType;
        private ComboBox cmbCustomerGenre;
        private ComboBox cmbCustomerCategory;
    }
}