namespace UI
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnAdmin = new Button();
            btnCustomer = new Button();
            SuspendLayout();
            // 
            // btnAdmin
            // 
            btnAdmin.Location = new Point(694, 409);
            btnAdmin.Name = "btnAdmin";
            btnAdmin.Size = new Size(94, 29);
            btnAdmin.TabIndex = 0;
            btnAdmin.Text = "button1";
            btnAdmin.UseVisualStyleBackColor = true;
            btnAdmin.Click += btnAdmin_Click;
            // 
            // btnCustomer
            // 
            btnCustomer.Location = new Point(319, 166);
            btnCustomer.Name = "btnCustomer";
            btnCustomer.Size = new Size(142, 77);
            btnCustomer.TabIndex = 2;
            btnCustomer.Text = "button3";
            btnCustomer.UseVisualStyleBackColor = true;
            btnCustomer.Click += btnCustomer_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnCustomer);
            Controls.Add(btnAdmin);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Button btnAdmin;
        private Button btnCustomer;
    }
}
