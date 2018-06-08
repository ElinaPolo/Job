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
    /// Логика взаимодействия для AddNewEmployee.xaml
    /// </summary>
    public partial class AddNewEmployee : Page
    {
        private IRepository repository;
        public AddNewEmployee(IRepository r)
        {
            InitializeComponent();
            repository = r;
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
           // repository.SaveEmployee(textBoxFullname.Text, textBoxLogin.Text, textBoxEducation.Text, comboBoxSpecialization.SelectedItem as Specialization, comboBoxGrade.SelectedItem as Grades);
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
           NavigationService.Navigate(new LoginPage(repository,false));
        }
    }
}
