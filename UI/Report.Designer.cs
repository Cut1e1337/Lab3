namespace UI
{
    partial class Report
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
            txtUserLogin = new TextBox();
            btnGenerateReport = new Button();
            SuspendLayout();
            // 
            // txtUserLogin
            // 
            txtUserLogin.Location = new Point(278, 182);
            txtUserLogin.Name = "txtUserLogin";
            txtUserLogin.Size = new Size(125, 27);
            txtUserLogin.TabIndex = 0;
            // 
            // btnGenerateReport
            // 
            btnGenerateReport.Location = new Point(259, 232);
            btnGenerateReport.Name = "btnGenerateReport";
            btnGenerateReport.Size = new Size(160, 41);
            btnGenerateReport.TabIndex = 1;
            btnGenerateReport.Text = "Generate";
            btnGenerateReport.UseVisualStyleBackColor = true;
            btnGenerateReport.Click += btnGenerateReport_Click;
            // 
            // Report
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnGenerateReport);
            Controls.Add(txtUserLogin);
            Name = "Report";
            Text = "Report";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtUserLogin;
        private Button btnGenerateReport;
    }
}