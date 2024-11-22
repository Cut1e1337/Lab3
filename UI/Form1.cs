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
            // ����� ��� ���������� �����������
            MessageBox.Show("�� ������ �� ��������� ����������.");
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            Admin adminForm = new Admin();
            adminForm.ShowDialog();
        }
    }
}
