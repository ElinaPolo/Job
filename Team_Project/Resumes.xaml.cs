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
    /// Логика взаимодействия для Resumes.xaml
    /// </summary>
    public partial class Resumes : Page
    {
        private IRepository repository;
        private Employer employer;
        public Resumes(IRepository r, Employer e)
        {
            InitializeComponent();
            repository = r;
            employer = e;
            repository.ReadData();
        }

        private void ButtonRemoveResume_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonAddResume_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
