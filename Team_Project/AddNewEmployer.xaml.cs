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
    /// Логика взаимодействия для AddNewEmployer.xaml
    /// </summary>
    public partial class AddNewEmployer : Page
    {
        private IRepository repository;
        public AddNewEmployer(IRepository r)
        {
            InitializeComponent();
            repository = r;
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxCompanyname.Text !="" && textBoxLogin.Text != "" && PasswordBox.Password !="")
            {
                bool clush = false;
                repository.ReadEmployers();
                    foreach (var r in repository.employer)
                    {
                        if (r.Login == textBoxLogin.Text)
                        {
                            MessageBox.Show("Create another login!");
                            clush = true;
                        }
                    }
                    if (clush == false)
                    {
                        repository.SaveEmployer(textBoxCompanyname.Text, textBoxLogin.Text, PasswordBox.Password);
                        NavigationService.Navigate(new LoginPage(repository, true));
                    }
                
            }
            else
            {
                MessageBox.Show("Please, fill all information!");
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new LoginPage(repository,true));
        }
    }
}
