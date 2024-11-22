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
        public static User LoggedInUser { get; private set; } // Статична властивість для зберігання авторизованого користувача

        public Login()
        {
            _userRepository = new GenericRepository<User>(new AppDbContext());
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
                LoggedInUser = user; // Зберігаємо авторизованого користувача в статичну властивість
                MessageBox.Show("Вхід успішний!");
                Form1 mainForm = new Form1();
                mainForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Неправильний логін або пароль!");
            }
        }
    }
}
