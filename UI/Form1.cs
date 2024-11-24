using System;
using System.Windows.Forms;
using Core.Models;

namespace UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // ������������� �������� ���������� ��� �������� ��� �����������
            if (Login.LoggedInUser != null && Login.LoggedInUser.IsAdmin)
            {
                btnAdmin.Visible = true;
            }
            else
            {
                btnAdmin.Visible = false;
            }
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                Customer customer = new Customer();
                customer.ShowDialog();
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show($"�������: {ex.Message}\n\n{ex.StackTrace}", "������� �����������", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnAdmin_Click(object sender, EventArgs e)
        {
            Admin adminForm = new Admin();
            adminForm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Report report = new Report();
            report.ShowDialog();
        }
    }
}
