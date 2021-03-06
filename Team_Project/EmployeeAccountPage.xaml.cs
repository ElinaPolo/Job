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
    /// Логика взаимодействия для EmployeeAccountPage.xaml
    /// </summary>
    public partial class EmployeeAccountPage : Page
    {
        
        private IRepository repository;
        private Employee employee;
        public EmployeeAccountPage(IRepository r, Employee e)
        {
            InitializeComponent();
            repository = r;
            employee = e;
            repository.ReadVacancies();            
            DataGridResult.ItemsSource = null;
            DataGridResult.ItemsSource = repository.vacancies;

        }

        private void DefSpecialization_Click(object sender, RoutedEventArgs e)
        {
            DataGridResult.ItemsSource = null;
            List<Employee> d = repository.GetEmployees();
            Employee employee_ = d.FirstOrDefault(x => x.Login == employee.Login);
            DataGridResult.ItemsSource =Helper.Vacancies(employee_.Specializations) ;
        }

        private void AddResume_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridResult.SelectedItem != null)
            {
                var v = DataGridResult.SelectedItem as Vacancy;
                var employer = v.Employer;
                NavigationService.Navigate(new AddNewResumePage(repository, employee, employer, v));
            }
            else { MessageBox.Show("Choose a vacancy!"); }
        }

        private void Invitations_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EmployeeInvitations(repository,employee));
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            DataGridResult.ItemsSource = null;
            DataGridResult.ItemsSource = repository.vacancies;
        }
    }
    
}
