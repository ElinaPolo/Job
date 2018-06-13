using System;
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
    /// Логика взаимодействия для EmployerAccountPage.xaml
    /// </summary>
    public partial class EmployerAccountPage : Page
    {
        private IRepository repository;
        private Employer employer;
        public EmployerAccountPage(IRepository r, Employer e)
        {
            InitializeComponent();
            repository = r;
            employer = e;
            repository.ReadData();
            repository.GetEmployees();
            ComboBoxGrades.ItemsSource = repository.grades;
            ComboBoxSpecializations.ItemsSource = repository.specializations;
            DataGridResult.ItemsSource = null;
            var gr = ComboBoxGrades.SelectedItem as Grades;
            var sp = ComboBoxSpecializations.SelectedItem as Specialization;
            DataGridResult.ItemsSource = repository.employee;
                
        }

        private void ComboBoxSpecializations_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var gr = ComboBoxGrades.SelectedItem as Grades;
            var sp = ComboBoxSpecializations.SelectedItem as Specialization;
            DataGridResult.ItemsSource = Helper.Employees(gr, sp);
        }

        private void ComboBoxGrades_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var gr = ComboBoxGrades.SelectedItem as Grades;
            var sp = ComboBoxSpecializations.SelectedItem as Specialization;
            DataGridResult.ItemsSource = Helper.Employees(gr, sp);
        }

        private void AddVacancy_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddNewVacancy(repository, employer));
        }

        private void SeeResumes_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Resumes(repository, employer));
        }
    }
}
