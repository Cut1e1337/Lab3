using Repositories.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Repositories;
using Core.Models;

namespace UI
{
    public partial class Login : Form
    {
        private readonly IGenericRepository<User> _userRepository;

        public Login(IGenericRepository<User> userRepository)
        {
            _userRepository = userRepository;
            InitializeComponent();
        }

        private void linkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Registration registration = new Registration();
            registration.ShowDialog();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            var user = _userRepository.GetAll().FirstOrDefault(u => u.Username == username && u.PasswordHash == password);

            if (user != null)
            {
                MessageBox.Show("Вхід успішний!");
                Form1 form1 = new Form1();
                form1.ShowDialog();
            }
            else
            {
                MessageBox.Show("Неправильний логін або пароль!");
            }
        }
    }
}
