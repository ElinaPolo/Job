using Job.Classes;
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

namespace Team_Project
{
    /// <summary>
    /// Логика взаимодействия для InviteEmployee.xaml
    /// </summary>
    public partial class InviteEmployee : Page
    {
        private IRepository repository;
        private Employer employer;
        private Employee employee;
        public InviteEmployee(IRepository r, Employee e, Employer er)
        {
            InitializeComponent();
            repository = r;
            employee = e;
            employer = er;
            repository.ReadVacancies();
            var s = Helper.EmployerVacancies(employer, repository.vacancies);
            Vacancies.ItemsSource = s;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EmployerAccountPage(repository, employer));
        }

        private void Send_Click(object sender, RoutedEventArgs e)
        {
            if(Vacancies.SelectedItem!=null)
            {
                repository.SendInvitation(employee, Vacancies.SelectedItem as Vacancy, textBoxComment.Text);
            }
            else
            {
                MessageBox.Show("Choose a vacancy!");
            }
        }
    }
}
