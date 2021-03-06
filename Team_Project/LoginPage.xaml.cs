﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Job.Classes;

namespace Team_Project
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        private IRepository repository;
        private bool ifemployer;
        public LoginPage(IRepository r,bool i )
        {
            InitializeComponent();
            ifemployer = i;
            repository=r;
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            if (ifemployer == true)
                NavigationService.Navigate(new AddNewEmployer(repository));
            else
                NavigationService.Navigate(new AddNewEmployee(repository));
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxLogin.Text == null)
                MessageBox.Show("Please, enter your login");
            if (PasswordBox.Password == null)
                MessageBox.Show("Please, enter your password");
            if (ifemployer == true)
            {
                var t = Employer.Sign(textBoxLogin.Text, DataBaseRepository.GetHash(PasswordBox.Password));
                if (t != null)
                    NavigationService.Navigate(new EmployerAccountPage(repository, t));
                else
                    MessageBox.Show("Wrong login or password");
            }
            else
            {
                var t = Employee.Sign(textBoxLogin.Text, DataBaseRepository.GetHash(PasswordBox.Password));
                if (t != null)
                    NavigationService.Navigate(new EmployeeAccountPage(repository, t));
                else
                    MessageBox.Show("Wrong login or password");
            }
               
        }
    }
}
