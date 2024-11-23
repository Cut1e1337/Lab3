using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Windows.Forms;
using Core.Models;
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
            LoadCategories();
            userBalance = 0.00m;
            lblBalance.Text = $"Баланс: {userBalance:C}";

            LoadApplications();
        }

        private void LoadCategories()
        {
            var categories = _categoryRepository.GetAll().ToList();
            cmbSearchCategory.DataSource = categories;
            cmbSearchCategory.DisplayMember = "CategoryName";
            cmbSearchCategory.ValueMember = "CategoryID";

            cmbSearchCategory.Items.Insert(0, new Category { CategoryID = 0, CategoryName = "Усі категорії" });
            cmbSearchCategory.SelectedIndex = 0;
        }

        private void LoadApplications(string searchName = "", int? categoryId = null)
        {
            var dbContext = new AppDbContext();

            var applicationsQuery = dbContext.Applications
                .Include(a => a.Pricings)
                .Include(a => a.Category)
                .Include(a => a.ContentRating)
                .AsQueryable();

            if (!string.IsNullOrEmpty(searchName))
            {
                applicationsQuery = applicationsQuery.Where(a => a.Name.Contains(searchName));
            }

            if (categoryId.HasValue && categoryId > 0)
            {
                applicationsQuery = applicationsQuery.Where(a => a.CategoryID == categoryId);
            }

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
                    Price = a.Pricings.FirstOrDefault() == null ? 0 : a.Pricings.FirstOrDefault().Price
                }).ToList();

            dgvApplications.DataSource = applications;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var searchName = txtSearchName.Text;
            var selectedCategoryId = (cmbSearchCategory.SelectedItem as Category)?.CategoryID;

            if (selectedCategoryId == 0)
            {
                selectedCategoryId = null;
            }

            LoadApplications(searchName, selectedCategoryId);
        }

        private void btnSetBalance_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtBalance.Text, out decimal newBalance))
            {
                userBalance = newBalance;
                lblBalance.Text = $"Баланс: {userBalance:C}";
            }
            else
            {
                MessageBox.Show("Введіть правильну суму!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPurchaseApp_Click(object sender, EventArgs e)
        {
            if (dgvApplications.SelectedRows.Count > 0)
            {
                var selectedApp = dgvApplications.SelectedRows[0].DataBoundItem as dynamic;

                if (selectedApp != null)
                {
                    var price = selectedApp.Price;
                    if (userBalance >= price)
                    {
                        userBalance -= price;
                        lblBalance.Text = $"Баланс: {userBalance:C}";
                        MessageBox.Show($"Ви успішно придбали програму {selectedApp.Name}!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Недостатньо коштів для покупки цієї програми.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
