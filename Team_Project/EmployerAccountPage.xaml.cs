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
    /// Логика взаимодействия для EmployerAccountPage.xaml
    /// </summary>
    public partial class EmployerAccountPage : Page
    {
        private IRepository repository;
        private Employer employer;
        public EmployerAccountPage(IRepository r, Employer e)
        {
            InitializeComponent();
            repository = r;
            employer = e;
            // ComboBoxGrades.ItemsSource = repository.Grades;
           // ComboBoxSpecializations.ItemsSource = repository.Specialization;
        }
    }
}
