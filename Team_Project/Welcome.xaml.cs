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
    /// Логика взаимодействия для Welcome.xaml
    /// </summary>
    public partial class Welcome : Page
    {
       IRepository repository = new DataBaseRepository();
       private bool ifemployer = true;
        public Welcome()
        {
            InitializeComponent();
        }

        private void EmployerButton_Click(object sender, RoutedEventArgs e)
        {
            bool ifemployer = true;
            //if()
            NavigationService.Navigate(new LoginPage(repository, ifemployer));
        }

        private void EmployeeButton_Click(object sender, RoutedEventArgs e)
        {
            bool ifemployer = false;
            NavigationService.Navigate(new LoginPage(repository, ifemployer));
        }
    }
}
