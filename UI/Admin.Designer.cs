namespace UI
{
    partial class Admin
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
            txtAppName = new TextBox();
            txtCurrentVersion = new TextBox();
            txtMinAndroidVersion = new TextBox();
            cmbCategory = new ComboBox();
            txtPrice = new TextBox();
            cmbAppType = new ComboBox();
            cmbGenre = new ComboBox();
            cmbContentRating = new ComboBox();
            dtpLastUpdate = new DateTimePicker();
            dgvApplications = new DataGridView();
            btnAddApp = new Button();
            btnUpdateApp = new Button();
            btnDeleteApp = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvApplications).BeginInit();
            SuspendLayout();
            // 
            // txtAppName
            // 
            txtAppName.Location = new Point(209, 249);
            txtAppName.Name = "txtAppName";
            txtAppName.Size = new Size(125, 27);
            txtAppName.TabIndex = 0;
            // 
            // txtCurrentVersion
            // 
            txtCurrentVersion.Location = new Point(209, 363);
            txtCurrentVersion.Name = "txtCurrentVersion";
            txtCurrentVersion.Size = new Size(125, 27);
            txtCurrentVersion.TabIndex = 1;
            // 
            // txtMinAndroidVersion
            // 
            txtMinAndroidVersion.Location = new Point(209, 325);
            txtMinAndroidVersion.Name = "txtMinAndroidVersion";
            txtMinAndroidVersion.Size = new Size(125, 27);
            txtMinAndroidVersion.TabIndex = 2;
            // 
            // cmbCategory
            // 
            cmbCategory.FormattingEnabled = true;
            cmbCategory.Location = new Point(613, 311);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(151, 28);
            cmbCategory.TabIndex = 3;
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(209, 291);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(125, 27);
            txtPrice.TabIndex = 4;
            // 
            // cmbAppType
            // 
            cmbAppType.FormattingEnabled = true;
            cmbAppType.Location = new Point(419, 311);
            cmbAppType.Name = "cmbAppType";
            cmbAppType.Size = new Size(151, 28);
            cmbAppType.TabIndex = 5;
            // 
            // cmbGenre
            // 
            cmbGenre.FormattingEnabled = true;
            cmbGenre.Location = new Point(419, 248);
            cmbGenre.Name = "cmbGenre";
            cmbGenre.Size = new Size(151, 28);
            cmbGenre.TabIndex = 6;
            // 
            // cmbContentRating
            // 
            cmbContentRating.FormattingEnabled = true;
            cmbContentRating.Location = new Point(613, 249);
            cmbContentRating.Name = "cmbContentRating";
            cmbContentRating.Size = new Size(151, 28);
            cmbContentRating.TabIndex = 7;
            // 
            // dtpLastUpdate
            // 
            dtpLastUpdate.Location = new Point(514, 411);
            dtpLastUpdate.Name = "dtpLastUpdate";
            dtpLastUpdate.Size = new Size(250, 27);
            dtpLastUpdate.TabIndex = 8;
            // 
            // dgvApplications
            // 
            dgvApplications.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvApplications.Location = new Point(2, 3);
            dgvApplications.Name = "dgvApplications";
            dgvApplications.RowHeadersWidth = 51;
            dgvApplications.Size = new Size(775, 233);
            dgvApplications.TabIndex = 9;
            // 
            // btnAddApp
            // 
            btnAddApp.Location = new Point(262, 409);
            btnAddApp.Name = "btnAddApp";
            btnAddApp.Size = new Size(94, 29);
            btnAddApp.TabIndex = 10;
            btnAddApp.Text = "Add";
            btnAddApp.UseVisualStyleBackColor = true;
            btnAddApp.Click += btnAddApp_Click;
            // 
            // btnUpdateApp
            // 
            btnUpdateApp.Location = new Point(130, 409);
            btnUpdateApp.Name = "btnUpdateApp";
            btnUpdateApp.Size = new Size(94, 29);
            btnUpdateApp.TabIndex = 11;
            btnUpdateApp.Text = "Update";
            btnUpdateApp.UseVisualStyleBackColor = true;
            btnUpdateApp.Click += btnUpdateApp_Click;
            // 
            // btnDeleteApp
            // 
            btnDeleteApp.Location = new Point(12, 409);
            btnDeleteApp.Name = "btnDeleteApp";
            btnDeleteApp.Size = new Size(94, 29);
            btnDeleteApp.TabIndex = 12;
            btnDeleteApp.Text = "Delete";
            btnDeleteApp.UseVisualStyleBackColor = true;
            btnDeleteApp.Click += btnDeleteApp_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(19, 332);
            label1.Name = "label1";
            label1.Size = new Size(144, 20);
            label1.TabIndex = 13;
            label1.Text = "Min android version:";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(19, 370);
            label2.Name = "label2";
            label2.Size = new Size(90, 20);
            label2.TabIndex = 14;
            label2.Text = "Curr version:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(19, 298);
            label3.Name = "label3";
            label3.Size = new Size(44, 20);
            label3.TabIndex = 15;
            label3.Text = "Price:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(19, 256);
            label4.Name = "label4";
            label4.Size = new Size(52, 20);
            label4.TabIndex = 16;
            label4.Text = "Name:";
            // 
            // Admin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnDeleteApp);
            Controls.Add(btnUpdateApp);
            Controls.Add(btnAddApp);
            Controls.Add(dgvApplications);
            Controls.Add(dtpLastUpdate);
            Controls.Add(cmbContentRating);
            Controls.Add(cmbGenre);
            Controls.Add(cmbAppType);
            Controls.Add(txtPrice);
            Controls.Add(cmbCategory);
            Controls.Add(txtMinAndroidVersion);
            Controls.Add(txtCurrentVersion);
            Controls.Add(txtAppName);
            Name = "Admin";
            Text = "Admin";
            ((System.ComponentModel.ISupportInitialize)dgvApplications).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtAppName;
        private TextBox txtCurrentVersion;
        private TextBox txtMinAndroidVersion;
        private ComboBox cmbCategory;
        private TextBox txtPrice;
        private ComboBox cmbAppType;
        private ComboBox cmbGenre;
        private ComboBox cmbContentRating;
        private DateTimePicker dtpLastUpdate;
        private DataGridView dgvApplications;
        private Button btnAddApp;
        private Button btnUpdateApp;
        private Button btnDeleteApp;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
    }
}