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
using System.Windows.Shapes;

namespace phar2
{
    /// <summary>
    /// Writers.xaml etkileşim mantığı
    /// </summary>
    public partial class Writers : Window
    {
        public Writers()
        {
            InitializeComponent();
        }
        LibManEntities LM = new LibManEntities();

        public void listData()
        {
            dgWriter.ItemsSource = LM.Writer.ToList(); //tablomuza kaydettiğimiz dataları listeledik.
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Writer wt = new Writer(); 
            wt.Name = txtNameW.Text; 
            wt.Age = txtAge.Text;
            wt.Publisher = txtPW.Text;

            LM.Writer.Add(wt); //entity adımızı yazarak, kaydettiğimiz dataları baglantı yoluyla database'e işledik
            LM.SaveChanges(); //""""""//
            MessageBox.Show("Writer has been saved successfully.");
            listData();//listdata fonksiyonu ile dgye listeledik.

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            int wrt = Convert.ToInt32(txtWriterId.Text);
            var delete = LM.Writer.First(x => x.WriterId == wrt);

            LM.Writer.Remove(delete);
            LM.SaveChanges();
            MessageBox.Show("Writer's informations are deleted successfully.");
            listData();

        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            int wrt = Convert.ToInt32(txtWriterId.Text);
            var update = LM.Writer.First(x => x.WriterId == wrt);
            update.Name = txtNameW.Text;
            update.Age = txtAge.Text;
            update.Publisher = txtPW.Text;

            LM.SaveChanges();
            MessageBox.Show("Writer's informations are updated.");
            listData();

        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtNameW.Text = txtPW.Text = txtAge.Text = " "; //girdiğimiz dataları kaydettikten sonra temizleyen fonksiyon.

        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
