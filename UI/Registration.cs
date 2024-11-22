using System;
using System.Linq;
using System.Windows.Forms;
using Repositories;
using Core.Models;
using lab3.Repositories.Data;
using Repositories.Repository;

namespace UI
{
    public partial class Registration : Form
    {
        private readonly IGenericRepository<User> _userRepository;
        private readonly IGenericRepository<UserRole> _userRoleRepository;
        private readonly AppDbContext _dbContext;

        public Registration()
        {
            _userRepository = new GenericRepository<User>(new AppDbContext());
            _userRoleRepository = new GenericRepository<UserRole>(new AppDbContext());
            _dbContext = new AppDbContext();
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtNewUsername.Text;
            string password = txtNewPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;
            string email = txtEmail.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword) || string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Будь ласка, заповніть всі поля.");
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Паролі не співпадають.");
                return;
            }

            if (!email.Contains("@") || !email.Contains("."))
            {
                MessageBox.Show("Будь ласка, введіть правильну електронну пошту.");
                return;
            }

            var existingUser = _userRepository.GetAll().FirstOrDefault(u => u.Username == username || u.Email == email);
            if (existingUser != null)
            {
                MessageBox.Show("Користувач з таким логіном або електронною поштою вже існує.");
                return;
            }

            var userRole = _userRoleRepository.GetAll().FirstOrDefault(r => r.RoleName == "User");
            if (userRole == null)
            {
                MessageBox.Show("Роль 'User' не знайдена в базі даних.");
                return;
            }

            var newUser = new User
            {
                Username = username,
                PasswordHash = password,
                Email = email,
                RoleID = userRole.RoleID,
                IsAdmin = false
            };

            _userRepository.Add(newUser);
            _dbContext.SaveChanges();

            MessageBox.Show("Реєстрація успішна!");

            Login loginForm = new Login();
            loginForm.Show();
            this.Hide();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Login loginForm = new Login();
            loginForm.Show();
            this.Hide();
        }
    }
}
