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
            dateTimePicker1 = new DateTimePicker();
            dataGridView1 = new DataGridView();
            btnAddApp = new Button();
            btnUpdateApp = new Button();
            btnDeleteApp = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // txtAppName
            // 
            txtAppName.Location = new Point(663, 292);
            txtAppName.Name = "txtAppName";
            txtAppName.Size = new Size(125, 27);
            txtAppName.TabIndex = 0;
            // 
            // txtCurrentVersion
            // 
            txtCurrentVersion.Location = new Point(346, 292);
            txtCurrentVersion.Name = "txtCurrentVersion";
            txtCurrentVersion.Size = new Size(125, 27);
            txtCurrentVersion.TabIndex = 1;
            // 
            // txtMinAndroidVersion
            // 
            txtMinAndroidVersion.Location = new Point(206, 292);
            txtMinAndroidVersion.Name = "txtMinAndroidVersion";
            txtMinAndroidVersion.Size = new Size(125, 27);
            txtMinAndroidVersion.TabIndex = 2;
            // 
            // cmbCategory
            // 
            cmbCategory.FormattingEnabled = true;
            cmbCategory.Location = new Point(637, 242);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(151, 28);
            cmbCategory.TabIndex = 3;
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(505, 292);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(125, 27);
            txtPrice.TabIndex = 4;
            // 
            // cmbAppType
            // 
            cmbAppType.FormattingEnabled = true;
            cmbAppType.Location = new Point(151, 242);
            cmbAppType.Name = "cmbAppType";
            cmbAppType.Size = new Size(151, 28);
            cmbAppType.TabIndex = 5;
            // 
            // cmbGenre
            // 
            cmbGenre.FormattingEnabled = true;
            cmbGenre.Location = new Point(320, 242);
            cmbGenre.Name = "cmbGenre";
            cmbGenre.Size = new Size(151, 28);
            cmbGenre.TabIndex = 6;
            // 
            // cmbContentRating
            // 
            cmbContentRating.FormattingEnabled = true;
            cmbContentRating.Location = new Point(479, 245);
            cmbContentRating.Name = "cmbContentRating";
            cmbContentRating.Size = new Size(151, 28);
            cmbContentRating.TabIndex = 7;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(538, 334);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(250, 27);
            dateTimePicker1.TabIndex = 8;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(2, 3);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(775, 233);
            dataGridView1.TabIndex = 9;
            // 
            // btnAddApp
            // 
            btnAddApp.Location = new Point(404, 371);
            btnAddApp.Name = "btnAddApp";
            btnAddApp.Size = new Size(94, 29);
            btnAddApp.TabIndex = 10;
            btnAddApp.Text = "Add";
            btnAddApp.UseVisualStyleBackColor = true;
            btnAddApp.Click += btnAddApp_Click;
            // 
            // btnUpdateApp
            // 
            btnUpdateApp.Location = new Point(308, 371);
            btnUpdateApp.Name = "btnUpdateApp";
            btnUpdateApp.Size = new Size(94, 29);
            btnUpdateApp.TabIndex = 11;
            btnUpdateApp.Text = "Update";
            btnUpdateApp.UseVisualStyleBackColor = true;
            btnUpdateApp.Click += btnUpdateApp_Click;
            // 
            // btnDeleteApp
            // 
            btnDeleteApp.Location = new Point(208, 371);
            btnDeleteApp.Name = "btnDeleteApp";
            btnDeleteApp.Size = new Size(94, 29);
            btnDeleteApp.TabIndex = 12;
            btnDeleteApp.Text = "Delete";
            btnDeleteApp.UseVisualStyleBackColor = true;
            btnDeleteApp.Click += btnDeleteApp_Click;
            // 
            // Admin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnDeleteApp);
            Controls.Add(btnUpdateApp);
            Controls.Add(btnAddApp);
            Controls.Add(dataGridView1);
            Controls.Add(dateTimePicker1);
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
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
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
        private DateTimePicker dateTimePicker1;
        private DataGridView dataGridView1;
        private Button btnAddApp;
        private Button btnUpdateApp;
        private Button btnDeleteApp;
    }
}