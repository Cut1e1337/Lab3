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
        private readonly IGenericRepository<ContentRating> _contentRatingRepository;
        private readonly IGenericRepository<Genre> _genreRepository;
        private readonly IGenericRepository<AppType> _appTypeRepository;
        private decimal userBalance;

        public Customer()
        {
            _appRepository = new GenericRepository<Core.Models.Application>(new AppDbContext());
            _categoryRepository = new GenericRepository<Category>(new AppDbContext());
            _contentRatingRepository = new GenericRepository<ContentRating>(new AppDbContext());
            _genreRepository = new GenericRepository<Genre>(new AppDbContext());
            _appTypeRepository = new GenericRepository<AppType>(new AppDbContext());
            InitializeComponent();
            InitializeForm();
        }

        private void InitializeForm()
        {
            LoadCategories();
            LoadContentRatings();
            LoadGenres();
            LoadAppTypes();
            userBalance = 0.00m;
            lblBalance.Text = $"Баланс: {userBalance:C}";

            LoadApplications();
        }

        private void LoadCategories()
        {
            var categories = _categoryRepository.GetAll().ToList();
            categories.Insert(0, new Category { CategoryID = 0, CategoryName = "Усі категорії" });

            cmbCustomerCategory.DataSource = categories;
            cmbCustomerCategory.DisplayMember = "CategoryName";
            cmbCustomerCategory.ValueMember = "CategoryID";
            cmbCustomerCategory.SelectedIndex = 0;
        }

        private void LoadContentRatings()
        {
            var contentRatings = _contentRatingRepository.GetAll().ToList();
            contentRatings.Insert(0, new ContentRating { ContentRatingID = 0, RatingName = "Усі рейтинги" });

            cmbCustomerContentRating.DataSource = contentRatings;
            cmbCustomerContentRating.DisplayMember = "RatingName";
            cmbCustomerContentRating.ValueMember = "ContentRatingID";
            cmbCustomerContentRating.SelectedIndex = 0;
        }

        private void LoadGenres()
        {
            var genres = _genreRepository.GetAll().ToList();
            genres.Insert(0, new Genre { GenreID = 0, GenreName = "Усі жанри" });

            cmbCustomerGenre.DataSource = genres;
            cmbCustomerGenre.DisplayMember = "GenreName";
            cmbCustomerGenre.ValueMember = "GenreID";
            cmbCustomerGenre.SelectedIndex = 0;
        }

        private void LoadAppTypes()
        {
            var appTypes = _appTypeRepository.GetAll().ToList();
            appTypes.Insert(0, new AppType { TypeID = 0, TypeName = "Усі типи" });

            cmbCustomerAppType.DataSource = appTypes;
            cmbCustomerAppType.DisplayMember = "TypeName";
            cmbCustomerAppType.ValueMember = "TypeID";
            cmbCustomerAppType.SelectedIndex = 0;
        }

        private void LoadApplications(string searchName = "", int? categoryId = null, int? contentRatingId = null, int? genreId = null, int? appTypeId = null)
        {
            var applicationsQuery = _appRepository.GetAllWithIncludes("Pricings", "Category", "ContentRating", "Genres", "AppTypes");

            if (!string.IsNullOrEmpty(searchName))
            {
                applicationsQuery = applicationsQuery.Where(a => a.Name.Contains(searchName));
            }

            if (categoryId.HasValue && categoryId > 0)
            {
                applicationsQuery = applicationsQuery.Where(a => a.CategoryID == categoryId);
            }

            if (contentRatingId.HasValue && contentRatingId > 0)
            {
                applicationsQuery = applicationsQuery.Where(a => a.ContentRatingID == contentRatingId);
            }

            if (genreId.HasValue && genreId > 0)
            {
                applicationsQuery = applicationsQuery.Where(a => a.Genres.Any(g => g.GenreID == genreId));
            }

            if (appTypeId.HasValue && appTypeId > 0)
            {
                applicationsQuery = applicationsQuery.Where(a => a.AppTypes.Any(at => at.TypeID == appTypeId));
            }

            var applications = applicationsQuery
                .Select(a => new
                {
                    a.ApplicationID,
                    a.Name,
                    CategoryName = a.Category.CategoryName,
                    ContentRatingName = a.ContentRating.RatingName,
                    GenreNames = string.Join(", ", a.Genres.Select(g => g.GenreName)),
                    AppTypeNames = string.Join(", ", a.AppTypes.Select(at => at.TypeName)),
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
            var selectedCategoryId = (cmbCustomerCategory.SelectedItem as Category)?.CategoryID;
            var selectedContentRatingId = (cmbCustomerContentRating.SelectedItem as ContentRating)?.ContentRatingID;
            var selectedGenreId = (cmbCustomerGenre.SelectedItem as Genre)?.GenreID;
            var selectedAppTypeId = (cmbCustomerAppType.SelectedItem as AppType)?.TypeID;

            if (selectedCategoryId == 0) selectedCategoryId = null;
            if (selectedContentRatingId == 0) selectedContentRatingId = null;
            if (selectedGenreId == 0) selectedGenreId = null;
            if (selectedAppTypeId == 0) selectedAppTypeId = null;

            LoadApplications(searchName, selectedCategoryId, selectedContentRatingId, selectedGenreId, selectedAppTypeId);
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
                        // Віднімаємо суму покупки від балансу користувача
                        userBalance -= price;
                        lblBalance.Text = $"Баланс: {userBalance:C}";

                        // Збереження покупки в базі даних
                        string userLogin = txtUserLogin.Text; // Припускаємо, що є текстбокс для введення логіну користувача
                        using (var context = new AppDbContext())
                        {
                            // Знаходимо користувача по логіну
                            var user = context.Users.FirstOrDefault(u => u.Username == userLogin);
                            if (user != null)
                            {
                                // Створюємо запис у таблиці UserPurchases
                                var userPurchase = new UserPurchase
                                {
                                    UserID = user.UserID,
                                    ApplicationID = selectedApp.ApplicationID // Має бути ID програми
                                };

                                // Додаємо покупку і зберігаємо зміни
                                context.UserPurchases.Add(userPurchase);
                                context.SaveChanges();
                            }
                            else
                            {
                                MessageBox.Show("Користувача не знайдено.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }

                        // Повідомлення про успіх покупки
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
