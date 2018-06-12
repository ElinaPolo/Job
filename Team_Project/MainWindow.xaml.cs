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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Repository rep = new Repository();
        DataBaseRepository repp = new DataBaseRepository();
        public MainWindow()
        {
            InitializeComponent();

            FirstWindow.Navigate(new Welcome());
            using (var context = new Context())
            {
                var Spez = context.Specializations_.ToList();
                
            }
        }
    }
}