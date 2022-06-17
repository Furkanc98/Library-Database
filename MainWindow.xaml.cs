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

namespace phar2
{
    /// <summary>
    /// MainWindow.xaml etkileşim mantığı
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnBooks_Click(object sender, RoutedEventArgs e)
        {
            Books books = new Books();  
            books.Show();

        }

        private void btnWriters_Click(object sender, RoutedEventArgs e)
        {
            Writers writers = new Writers();    
            writers.Show(); 

        }

        private void btnCate_Click(object sender, RoutedEventArgs e)
        {
            Categories categories = new Categories();   
            categories.Show();  

        }
    }
}
