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
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        private IRepository repository;
        private bool ifemployer;
        public LoginPage(IRepository r,bool i )
        {
            InitializeComponent();
            ifemployer = i;
            r = repository;
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            if(ifemployer==true)
            {
                
            }
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
