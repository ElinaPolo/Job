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
    /// Логика взаимодействия для AddNewResumePage.xaml
    /// </summary>
    public partial class AddNewResumePage : Page
    {
        private IRepository repository;
        private Employer employer;
        private Employee employee;
        private Vacancy vacancy;
        public AddNewResumePage(IRepository r,Employee e, Employer er, Vacancy vac)
        {
            InitializeComponent();
            repository = r;
            employee = e;
            employer = er;
            vacancy = vac;
        }

        private void Send_Click(object sender, RoutedEventArgs e)
        {
            repository.AddResume(employee, textBoxComment.Text, vacancy,employer);
          //  repository.SendResume(employer, employee, r);
            NavigationService.Navigate(new EmployeeAccountPage(repository, employee));
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EmployeeAccountPage(repository,employee));
        }
    }
}
