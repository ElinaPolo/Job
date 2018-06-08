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
        public AddNewResumePage(IRepository r,Employee e, Employer er)
        {
            InitializeComponent();
            repository = r;
            employee = e;
            employer = er;
        }

        private void Send_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EmployeeAccountPage(repository,employee));
        }
    }
}
