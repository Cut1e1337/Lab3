using System;
using System.Linq;
using System.Windows.Forms;
using Repositories;
using Core.Models;
using lab3.Repositories.Data;
using Repositories.Repository;

namespace UI
{
    public partial class Login : Form
    {
        private readonly IGenericRepository<User> _userRepository;

        public Login()
        {
            _userRepository = new GenericRepository<User>(new AppDbContext());  // Ініціалізація репозиторію без параметрів
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

            // Перевірка логіна і пароля
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
