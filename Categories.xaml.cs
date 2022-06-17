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
    /// Categories.xaml etkileşim mantığı
    /// </summary>
    public partial class Categories : Window
    {
        public Categories()
        {
            InitializeComponent();
        }

        LibManEntities LM = new LibManEntities();

        public void listData()
        {
            dgCate.ItemsSource = LM.cate.ToList(); //tablomuza kaydettiğimiz dataları listeledik.
        }




        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            cate ct = new cate(); 
            ct.NameOfTheType = txttyPe.Text; 
            ct.Stock = txtStock.Text;

            LM.cate.Add(ct); //entity adımızı yazarak, kaydettiğimiz dataları baglantı yoluyla database'e işledik
            LM.SaveChanges(); //""""""//
            MessageBox.Show("Category information has been saved successfully.");
            listData();//listdata fonksiyonu ile dgye listeledik.

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            int cto = Convert.ToInt32(txtCateId.Text);
            var delete = LM.cate.First(x => x.CategoryId == cto);

            LM.cate.Remove(delete);
            LM.SaveChanges();
            MessageBox.Show("Category informations are deleted successfully.");
            listData();

        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            int cto = Convert.ToInt32(txtCateId.Text);
            var update = LM.cate.First(x => x.CategoryId == cto);
            update.NameOfTheType = txttyPe.Text;
            update.Stock = txtStock.Text;

            LM.SaveChanges();
            MessageBox.Show("Category informations are updated.");
            listData();

        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtStock.Text = txttyPe.Text = " ";

        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
