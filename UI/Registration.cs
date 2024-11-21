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
            _userRepository = new GenericRepository<User>(new AppDbContext());  // Ініціалізація репозиторію без параметрів
            _userRoleRepository = new GenericRepository<UserRole>(new AppDbContext());  // Ініціалізація репозиторію ролей
            _dbContext = new AppDbContext();  // Ініціалізація контексту
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtNewUsername.Text;
            string password = txtNewPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;
            string email = txtEmail.Text;

            // Перевірка на заповненість полів
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword) || string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Будь ласка, заповніть всі поля.");
                return;
            }

            // Перевірка паролів
            if (password != confirmPassword)
            {
                MessageBox.Show("Паролі не співпадають.");
                return;
            }

            // Перевірка електронної пошти
            if (!email.Contains("@") || !email.Contains("."))
            {
                MessageBox.Show("Будь ласка, введіть правильну електронну пошту.");
                return;
            }

            // Перевірка на існування користувача з таким логіном або email
            var existingUser = _userRepository.GetAll().FirstOrDefault(u => u.Username == username || u.Email == email);
            if (existingUser != null)
            {
                MessageBox.Show("Користувач з таким логіном або електронною поштою вже існує.");
                return;
            }

            // Отримуємо роль "User"
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

            // Додавання нового користувача
            _userRepository.Add(newUser);
            _dbContext.SaveChanges(); // Збереження змін через контекст

            MessageBox.Show("Реєстрація успішна!");

            // Перехід до форми логіну
            Login loginForm = new Login();
            loginForm.Show();
            this.Hide();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Повернення до форми логіну
            Login loginForm = new Login();
            loginForm.Show();
            this.Hide();
        }
    }
}
