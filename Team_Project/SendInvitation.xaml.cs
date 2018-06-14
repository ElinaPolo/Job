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
    /// Логика взаимодействия для SendInvitation.xaml
    /// </summary>
    public partial class SendInvitation : Page
    {
        private IRepository repository;
        private Employer employer;
        private Resume resume;
        public SendInvitation(IRepository r,Employer e, Resume res)
        {
            InitializeComponent();
            repository = r;
            employer = e;
            resume = res;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EmployerAccountPage(repository, employer));
        }

        private void Send_Click(object sender, RoutedEventArgs e)
        {
            var ee = resume.Employee;        
            repository.SendInvitation(ee, resume.Vacancy, textBoxComment.Text);

        }
    }
}
