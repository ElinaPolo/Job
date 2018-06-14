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
    /// Логика взаимодействия для EmployeeInvitations.xaml
    /// </summary>
    public partial class EmployeeInvitations : Page
    {
        private IRepository repository;
        private Employee employee;
        public EmployeeInvitations(IRepository r, Employee e)
        {
            InitializeComponent();
            repository = r;
            employee = e;
            repository.GetInvitations(employee);

            DataGridResult.ItemsSource = null;
            DataGridResult.ItemsSource = Helper.EmployeeInvitations(employee, repository.invitations);
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            var g = DataGridResult.SelectedItem as Invitation;
            repository.DeleteInvitation(employee, g);
            NavigationService.Navigate(new EmployeeInvitations(repository, employee));
        }
    }
}
