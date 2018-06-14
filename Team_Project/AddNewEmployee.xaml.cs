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
    /// Логика взаимодействия для AddNewEmployee.xaml
    /// </summary>
    public partial class AddNewEmployee : Page
    {
        private IRepository repository;
        public AddNewEmployee(IRepository r)
        {
            InitializeComponent();
            repository = r;
            repository.ReadData();
            comboBoxGrade.ItemsSource = repository.grades;
            comboBoxSpecialization.ItemsSource = repository.specializations;
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxYear.Text != "" && textBoxMonth.Text != "" && textBoxDay.Text != "")
            {
                var y = int.Parse(textBoxYear.Text);
                var m = int.Parse(textBoxMonth.Text);
                var d = int.Parse(textBoxDay.Text);
                if (m > 0 && m <= 12 && d > 0 && d <= 31)
                {
                    var date = new DateTime(y, m, d);
                    if (textBoxFullname.Text != "" && textBoxLogin.Text != "" && PasswordBox.Password != null && textBoxEducation.Text != "" && comboBoxGrade.SelectedItem != null && comboBoxSpecialization.SelectedItem != null)
                    {
                        bool clush = false;
                        repository.ReadEmployees();
                        foreach(var r in repository.employee)
                        {
                            if(textBoxLogin.Text==r.Login)
                            {
                                MessageBox.Show("Create another login!");
                                clush = true;
                            }
                        }
                        if (clush == false)
                        {
                            repository.SaveEmployee(textBoxFullname.Text, textBoxLogin.Text, PasswordBox.Password, textBoxEducation.Text, comboBoxSpecialization.SelectedItem as Specialization, comboBoxGrade.SelectedItem as Grades, date);
                            NavigationService.Navigate(new LoginPage(repository, false));
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please, fill all information!");
                    }
                }
                else
                { MessageBox.Show("Check your birtdate!"); }
            }
            else
            { MessageBox.Show("Check your birtdate!"); }

        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
           NavigationService.Navigate(new LoginPage(repository,false));
        }
    }
}
