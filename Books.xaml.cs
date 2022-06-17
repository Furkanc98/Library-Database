using System;
using System.Collections.Generic;
using System.Data;
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
    /// Books.xaml etkileşim mantığı
    /// </summary>
    public partial class Books : Window
    {
        public Books()
        {
            InitializeComponent();
        }
        LibManEntities LM = new LibManEntities();

        public void listData()
        {
            dgBook.ItemsSource = LM.Books.ToList(); //tablomuza kaydettiğimiz dataları listeledik.
        }


        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();  
            mainWindow.Show();  
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Books bk = new Books(); //Books tableımıza bk adında yeni bir obje olusturduk
            bk.NameOfTheBook = txtName.Text; 
            bk.WriterOfTheBook = txtWriter.Text;
            bk.TypeOfTheBook = txtType.Text;

            LM.Books.Add(bk); //entity adımızı yazarak, kaydettiğimiz dataları baglantı yoluyla database'e işledik
            LM.SaveChanges(); //""""""//
            MessageBox.Show("Book has been saved successfully."); //feedback verdik
            listData();//listdata fonksiyonu ile sağ tarafa listeledik.


        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            int bko = Convert.ToInt32(txtBookId.Text);
            var delete = LM.Books.First(x => x.BookId == bko);

            LM.Books.Remove(delete);
            LM.SaveChanges();
            MessageBox.Show("Book's informations are deleted successfully.");
            listData();

        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            int bko = Convert.ToInt32(txtBookId.Text);
            var update = LM.Books.First(x => x.BookId == bko);
            update.NameOfTheBook = txtName.Text;
            update.TypeOfTheBook = txtType.Text;
            update.WriterOfTheBook = txtWriter.Text;

            LM.SaveChanges();
            MessageBox.Show("Book's informations are updated.");
            listData();
        }


        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtType.Text = txtName.Text = txtWriter.Text = " "; //girdiğimiz dataları kaydettikten sonra temizleyen fonksiyon.

        }

        private void dgBook_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid valueRead = sender as DataGrid;
            DataRowView dataRow = valueRead.SelectedItem as DataRowView;
            if (dataRow != null)
            {
                txtName.Text = dataRow["NameOfTheBook"].ToString();  
                txtType.Text = dataRow["TypeOfTheBook"].ToString();
                txtWriter.Text = dataRow["WriterOfTheBook"].ToString();
            }
        }
    }
}
