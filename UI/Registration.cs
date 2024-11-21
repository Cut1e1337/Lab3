using Repositories.Repository;
using System;
using System.Linq;
using System.Windows.Forms;
using Repositories;
using Core.Models;
using Microsoft.EntityFrameworkCore;
using lab3.Repositories.Data;

namespace UI
{
    public partial class Registration : Form
    {
        private readonly IGenericRepository<User> _userRepository; // Репозиторій для користувачів
        private readonly IGenericRepository<UserRole> _userRoleRepository; // Репозиторій для ролей користувачів
        private readonly AppDbContext _dbContext; // Контекст бази даних для виклику SaveChanges

        public Registration(IGenericRepository<User> userRepository, IGenericRepository<UserRole> userRoleRepository, AppDbContext dbContext)
        {
            _userRepository = userRepository;
            _userRoleRepository = userRoleRepository;
            _dbContext = dbContext; // Ініціалізація контексту
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtNewUsername.Text;
            string password = txtNewPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;
            string email = txtEmail.Text;

            // Перевірка, чи всі поля заповнені
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword) || string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Будь ласка, заповніть всі поля.");
                return;
            }

            // Перевірка, чи паролі збігаються
            if (password != confirmPassword)
            {
                MessageBox.Show("Паролі не співпадають.");
                return;
            }

            // Перевірка формату електронної пошти
            if (!email.Contains("@") || !email.Contains("."))
            {
                MessageBox.Show("Будь ласка, введіть правильну електронну пошту.");
                return;
            }

            // Перевірка, чи існує користувач з таким логіном або email
            var existingUser = _userRepository.GetAll().FirstOrDefault(u => u.Username == username || u.Email == email);
            if (existingUser != null)
            {
                MessageBox.Show("Користувач з таким логіном або електронною поштою вже існує.");
                return;
            }

            // Отримуємо RoleID для ролі "User"
            var userRole = _userRoleRepository.GetAll().FirstOrDefault(r => r.RoleName == "User");
            if (userRole == null)
            {
                MessageBox.Show("Роль 'User' не знайдена в базі даних.");
                return;
            }

            // Створення нового користувача
            var newUser = new User
            {
                Username = username,
                PasswordHash = password, // Зберігаємо пароль у відкритому вигляді (для тестування)
                Email = email,
                RoleID = userRole.RoleID, // Встановлюємо RoleID для користувача
                IsAdmin = false // Вказуємо, що це не адмін
            };

            // Додавання нового користувача в репозиторій
            _userRepository.Add(newUser);
            _dbContext.SaveChanges(); // Збереження змін через контекст

            MessageBox.Show("Реєстрація успішна!");

            // Переходимо до форми логіну
            Login loginForm = new Login(_userRepository);
            loginForm.Show();
            this.Hide();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Повернення до форми логіну
            Login loginForm = new Login(_userRepository);
            loginForm.Show();
            this.Hide();
        }
    }
}
