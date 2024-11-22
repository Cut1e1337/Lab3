using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Core.Models;
using Repositories;
using lab3.Repositories.Data;
using Repositories.Repository;


namespace UI
{
    public partial class Admin : Form
    {
        private readonly IGenericRepository<Core.Models.Application> _appRepository;
        private readonly IGenericRepository<Category> _categoryRepository;
        private readonly IGenericRepository<ContentRating> _contentRatingRepository;
        private readonly IGenericRepository<Genre> _genreRepository;
        private readonly IGenericRepository<AppType> _appTypeRepository;
        private readonly IGenericRepository<Pricing> _pricingRepository;
        private readonly AppDbContext _dbContext;

        public Admin()
        {
            _dbContext = new AppDbContext();  // Ініціалізація контексту бази даних
            _appRepository = new GenericRepository<Core.Models.Application>(_dbContext);
            _categoryRepository = new GenericRepository<Category>(_dbContext);
            _contentRatingRepository = new GenericRepository<ContentRating>(_dbContext);
            _genreRepository = new GenericRepository<Genre>(_dbContext);
            _appTypeRepository = new GenericRepository<AppType>(_dbContext);
            _pricingRepository = new GenericRepository<Pricing>(_dbContext);

            InitializeComponent();
            LoadForm();
        }

        private void LoadForm()
        {
            cmbCategory.DataSource = _categoryRepository.GetAll().ToList();
            cmbCategory.DisplayMember = "CategoryName";
            cmbCategory.ValueMember = "CategoryID";

            cmbContentRating.DataSource = _contentRatingRepository.GetAll().ToList();
            cmbContentRating.DisplayMember = "RatingName";
            cmbContentRating.ValueMember = "ContentRatingID";

            cmbGenre.DataSource = _genreRepository.GetAll().ToList();
            cmbGenre.DisplayMember = "GenreName";
            cmbGenre.ValueMember = "GenreID";

            cmbAppType.DataSource = _appTypeRepository.GetAll().ToList();
            cmbAppType.DisplayMember = "TypeName";
            cmbAppType.ValueMember = "TypeID";

            LoadApplications();
        }

        private void LoadApplications()
        {
            var applications = _appRepository.GetAll().Select(a => new
            {
                a.ApplicationID,
                a.Name,
                CategoryName = a.Category.CategoryName,
                ContentRatingName = a.ContentRating.RatingName,
                a.LastUpdate,
                a.CurrentVersion,
                a.MinAndroidVersion
            }).ToList();

            dgvApplications.DataSource = applications;
        }

        private void btnAddApp_Click(object sender, EventArgs e)
        {
            // Перевірка введених даних
            if (string.IsNullOrWhiteSpace(txtAppName.Text) ||
                string.IsNullOrWhiteSpace(txtCurrentVersion.Text) ||
                string.IsNullOrWhiteSpace(txtMinAndroidVersion.Text))
            {
                MessageBox.Show("Будь ласка, заповніть всі поля.");
                return;
            }

            if (!decimal.TryParse(txtPrice.Text, out decimal price))
            {
                MessageBox.Show("Введіть правильну ціну.");
                return;
            }

            var newApp = new Core.Models.Application
            {
                Name = txtAppName.Text,
                CategoryID = (int)cmbCategory.SelectedValue,
                ContentRatingID = (int)cmbContentRating.SelectedValue,
                LastUpdate = dtpLastUpdate.Value,
                CurrentVersion = txtCurrentVersion.Text,
                MinAndroidVersion = txtMinAndroidVersion.Text
            };

            _dbContext.Add(newApp);
            _dbContext.SaveChanges(); // Зберігаємо додану програму

            // Додаємо жанр
            var appGenre = new AppGenre
            {
                ApplicationID = newApp.ApplicationID,
                GenreID = (int)cmbGenre.SelectedValue
            };
            _dbContext.AppGenres.Add(appGenre);

            // Додаємо ціну
            var pricing = new Pricing
            {
                ApplicationID = newApp.ApplicationID,
                TypeID = (int)cmbAppType.SelectedValue,
                Price = price
            };
            _dbContext.Pricings.Add(pricing);
            _dbContext.SaveChanges(); // Зберігаємо зміни

            LoadApplications();
            MessageBox.Show("Програма успішно додана!");
        }

        private void btnUpdateApp_Click(object sender, EventArgs e)
        {
            if (dgvApplications.SelectedRows.Count == 0)
            {
                MessageBox.Show("Будь ласка, виберіть програму для оновлення.");
                return;
            }

            var appId = (int)dgvApplications.SelectedRows[0].Cells["ApplicationID"].Value;
            var appToUpdate = _appRepository.GetAll().FirstOrDefault(a => a.ApplicationID == appId);

            if (appToUpdate != null)
            {
                appToUpdate.Name = txtAppName.Text;
                appToUpdate.CategoryID = (int)cmbCategory.SelectedValue;
                appToUpdate.ContentRatingID = (int)cmbContentRating.SelectedValue;
                appToUpdate.LastUpdate = dtpLastUpdate.Value;
                appToUpdate.CurrentVersion = txtCurrentVersion.Text;
                appToUpdate.MinAndroidVersion = txtMinAndroidVersion.Text;

                var appGenreToUpdate = _dbContext.AppGenres.FirstOrDefault(ag => ag.ApplicationID == appToUpdate.ApplicationID);
                if (appGenreToUpdate != null)
                {
                    appGenreToUpdate.GenreID = (int)cmbGenre.SelectedValue;
                }

                var pricingToUpdate = _pricingRepository.GetAll().FirstOrDefault(p => p.ApplicationID == appToUpdate.ApplicationID);
                if (pricingToUpdate != null)
                {
                    pricingToUpdate.TypeID = (int)cmbAppType.SelectedValue;
                    pricingToUpdate.Price = decimal.Parse(txtPrice.Text);
                }

                _dbContext.SaveChanges();
                LoadApplications();
                MessageBox.Show("Програма успішно оновлена!");
            }
        }

        private void btnDeleteApp_Click(object sender, EventArgs e)
        {
            if (dgvApplications.SelectedRows.Count == 0)
            {
                MessageBox.Show("Будь ласка, виберіть програму для видалення.");
                return;
            }

            var appId = (int)dgvApplications.SelectedRows[0].Cells["ApplicationID"].Value;
            var appToDelete = _appRepository.GetAll().FirstOrDefault(a => a.ApplicationID == appId);

            if (appToDelete != null)
            {
                // Видаляємо пов'язані записи з таблиць AppGenres та Pricings
                var genresToRemove = _dbContext.AppGenres.Where(ag => ag.ApplicationID == appId).ToList();
                var pricingToRemove = _dbContext.Pricings.Where(p => p.ApplicationID == appId).ToList();

                if (genresToRemove.Any())
                    _dbContext.AppGenres.RemoveRange(genresToRemove);

                if (pricingToRemove.Any())
                    _dbContext.Pricings.RemoveRange(pricingToRemove);

                _dbContext.Applications.Remove(appToDelete);
                _dbContext.SaveChanges();

                LoadApplications();
                MessageBox.Show("Програму успішно видалено!");
            }
        }
    }
}
