using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Windows.Forms;
using Core.Models;
using Repositories;
using lab3.Repositories.Data;
using Repositories.Repository;

namespace UI
{
    public partial class Customer : Form
    {
        private readonly IGenericRepository<Core.Models.Application> _appRepository;
        private readonly IGenericRepository<Category> _categoryRepository;
        private decimal userBalance;

        public Customer()
        {
            _appRepository = new GenericRepository<Core.Models.Application>(new AppDbContext());
            _categoryRepository = new GenericRepository<Category>(new AppDbContext());

            InitializeForm();
        }

        private void InitializeForm()
        {
            // Ініціалізація компонентів форми
            LoadCategories();
            userBalance = 0.00m;
            lblBalance.Text = $"Баланс: {userBalance:C}";

            LoadApplications();
        }

        private void LoadCategories()
        {
            // Завантажуємо всі категорії з бази даних у ComboBox
            var categories = _categoryRepository.GetAll().ToList();
            cmbSearchCategory.DataSource = categories;
            cmbSearchCategory.DisplayMember = "CategoryName";
            cmbSearchCategory.ValueMember = "CategoryID";

            // Додаємо пункт для всіх категорій
            cmbSearchCategory.Items.Insert(0, new Category { CategoryID = 0, CategoryName = "Усі категорії" });
            cmbSearchCategory.SelectedIndex = 0;
        }

        private void LoadApplications(string searchName = "", int? categoryId = null)
        {
            // Завантажуємо програми на основі фільтрів
            var applicationsQuery = _appRepository.GetAll();

            // Фільтр по назві
            if (!string.IsNullOrEmpty(searchName))
            {
                applicationsQuery = applicationsQuery.Where(a => a.Name.Contains(searchName));
            }

            // Фільтр по категорії
            if (categoryId.HasValue && categoryId > 0)
            {
                applicationsQuery = applicationsQuery.Where(a => a.CategoryID == categoryId);
            }

            // Завантаження відфільтрованих даних
            var applications = applicationsQuery
                .Select(a => new
                {
                    a.ApplicationID,
                    a.Name,
                    CategoryName = a.Category.CategoryName,
                    ContentRatingName = a.ContentRating.RatingName,
                    a.LastUpdate,
                    a.CurrentVersion,
                    a.MinAndroidVersion,
                    Price = a.Pricing.Any() ? a.Pricing.First().Price : 0
                }).ToList();

            dgvApplications.DataSource = applications;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // Виконуємо пошук
            var searchName = txtSearchName.Text;
            var selectedCategoryId = (cmbSearchCategory.SelectedItem as Category)?.CategoryID;

            // Якщо обрана категорія "Усі категорії", встановлюємо categoryId як null
            if (selectedCategoryId == 0)
            {
                selectedCategoryId = null;
            }

            LoadApplications(searchName, selectedCategoryId);
        }

        private void btnSetBalance_Click(object sender, EventArgs e)
        {
            // Встановлюємо баланс користувача
            if (decimal.TryParse(txtBalance.Text, out decimal newBalance))
            {
                userBalance = newBalance;
                lblBalance.Text = $"Баланс: {userBalance:C}";
            }
            else
            {
                MessageBox.Show("Введіть правильний баланс.");
            }
        }

        private void btnPurchaseApp_Click(object sender, EventArgs e)
        {
            // Виконуємо покупку обраної програми
            if (dgvApplications.SelectedRows.Count == 0)
            {
                MessageBox.Show("Будь ласка, виберіть програму для покупки.");
                return;
            }

            var selectedAppId = (int)dgvApplications.SelectedRows[0].Cells["ApplicationID"].Value;
            var selectedApp = _appRepository.GetAll().FirstOrDefault(a => a.ApplicationID == selectedAppId);

            if (selectedApp != null && selectedApp.Pricing.Any())
            {
                var price = selectedApp.Pricing.First().Price;

                if (userBalance >= price)
                {
                    userBalance -= price;
                    lblBalance.Text = $"Баланс: {userBalance:C}";
                    MessageBox.Show("Програму успішно куплено!");
                }
                else
                {
                    MessageBox.Show("Недостатньо коштів для покупки цієї програми.");
                }
            }
            else
            {
                MessageBox.Show("Ця програма є безкоштовною або не знайдено даних про ціну.");
            }
        }
    }
}
