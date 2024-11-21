using Repositories.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Repositories;
using Core;

namespace UI
{
    public partial class Login : Form
    {
        private readonly IGenericRepository<User> _userRepository;

        public Login(IGenericRepository<User> userRepository)
        {
            _userRepository = userRepository;
            InitializeComponent();
        }

        private void linkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Registration registration = new Registration();
            registration.ShowDialog();
        }
    }
}
