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
    /// Логика взаимодействия для AddNewVacancy.xaml
    /// </summary>
    public partial class AddNewVacancy : Page
    {
        private IRepository repository;
        private Employer employer;
        public AddNewVacancy(IRepository r, Employer e)
        {
            InitializeComponent();
            repository = r;
            employer = e;         
            comboBoxSpecialization.ItemsSource = repository.specializations;
        }


        private void Add_Click(object sender, RoutedEventArgs e)
        {
            repository.AddVacancy(employer, textBoxVacancyName.Text, textBoxSalary.Text, textBoxAddress.Text, textBoxContact.Text, textBoxContactPerson.Text, comboBoxSpecialization.SelectedItem as Specialization);
            NavigationService.Navigate(new EmployerAccountPage(repository, employer));
        }

        private void Cancel_Cick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EmployerAccountPage(repository,employer));
        }
    }
}
