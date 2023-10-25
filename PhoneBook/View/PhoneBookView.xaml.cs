using System.ComponentModel;
using System.Windows;
using PhoneBook.ViewModel;

namespace PhoneBook.View;

public partial class PhoneBookView : Window
{
    private readonly PhoneBookRepository _repository;

    public PhoneBookView(PhoneBookRepository repository)
    {
        _repository = repository;
        InitializeComponent();

        DataContext = new PhoneBookViewModel(this, repository);
    }

    protected override void OnClosing(CancelEventArgs e)
    {
        _repository.SaveChanges();
    }
}