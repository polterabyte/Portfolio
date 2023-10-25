using System.Windows;
using PhoneBook.Model;
using PhoneBook.ViewModel;

namespace PhoneBook.View;

public partial class CompanyView : Window
{
    public CompanyView(Company company)
    {
        InitializeComponent();

        DataContext = new CompanyViewModel(company);
    }
}