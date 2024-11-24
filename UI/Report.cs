using System;
using System.Linq;
using System.Windows.Forms;
using Core.Models;
using lab3.Repositories.Data;
using Repositories.Repository;

namespace UI
{
    public partial class Report : Form
    {
        private readonly IGenericRepository<Core.Models.Application> _appRepository;
        private readonly IGenericRepository<UserPurchase> _userPurchaseRepository;

        public Report()
        {
            _appRepository = new GenericRepository<Core.Models.Application>(new AppDbContext());
            _userPurchaseRepository = new GenericRepository<UserPurchase>(new AppDbContext());
            InitializeComponent();
        }

        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            string userLogin = txtUserLogin.Text.Trim();

            if (string.IsNullOrEmpty(userLogin))
            {
                MessageBox.Show("Будь ласка, введіть логін користувача.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Отримання списку куплених програм користувача
            var purchasedApps = _userPurchaseRepository
                .GetAllWithIncludes("Application")
                .Where(up => up.UserLogin == userLogin)
                .Select(up => up.Application)
                .ToList();

            if (purchasedApps.Any())
            {
                string report = "Користувач купив наступні програми:\n";
                foreach (var app in purchasedApps)
                {
                    report += $"- {app.Name} (Версія: {app.CurrentVersion})\n";
                }
                MessageBox.Show(report, "Звіт про покупки", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Цей користувач не купував програм.", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
