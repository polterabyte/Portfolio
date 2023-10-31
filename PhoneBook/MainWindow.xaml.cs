using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Reflection.Metadata;
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
using PhoneBook.View;

namespace PhoneBook
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void UsePostgreSQL_Click(object sender, RoutedEventArgs e)
        {
            ShowPhoneBook(DataBaseEnum.NPGSQL);
        }

        private void UseSQLite_Click(object sender, RoutedEventArgs e)
        {
            ShowPhoneBook(DataBaseEnum.SQLITE);
        }        
        private void UseMongoDB_Click(object sender, RoutedEventArgs e)
        {
            ShowPhoneBook(DataBaseEnum.MONGO);
        }

        private void ShowPhoneBook(DataBaseEnum usedDb)
        {
            var phoneBookView = new PhoneBookView(new PhoneBookRepository(usedDb))
            {
                Owner = this
            };
            phoneBookView.Show();
        }


    }
}
