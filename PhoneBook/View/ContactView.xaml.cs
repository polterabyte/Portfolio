using System.Windows;
using PhoneBook.Model;
using PhoneBook.ViewModel;

namespace PhoneBook.View;

public partial class ContactView : Window
{
    private readonly PhoneBookRepository _repository;

    public ContactView(PhoneBookRepository repository, Contact contact)
    {
        _repository = repository;
        InitializeComponent();

        DataContext = new ContactViewModel(repository, contact);
    }
}