using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using PhoneBook.Model;
using PhoneBook.View;

namespace PhoneBook.ViewModel;

public class PhoneBookViewModel : ViewModel
{
    private readonly Window _owner;
    private readonly PhoneBookRepository _repository;
    public ObservableCollection<Contact> Contacts => _repository.Contacts;
    private Contact? _selectedContact;
    public Contact? SelectedContact
    {
        get => _selectedContact;
        set => SetField(ref _selectedContact, value);
    }

    public ICommand AddContactCommand => new Command(o =>
    {
        var contact = new Contact();
        _repository.Contacts.Add(contact);
        var dialog = new ContactView(_repository, contact)
        {
            Owner = _owner,
        };
        dialog.Show();
    });

    public ICommand RemoveContactCommand => new Command(o =>
    {
        if (o is Contact contact)
        {
            _repository.Contacts.Remove(contact);
        }
    }, o => o != null);

    public ICommand EditContactCommand => new Command(o =>
    {
        if (o is Contact contact)
        {
            var dialog = new ContactView(_repository, contact)
            {
                Owner = _owner
            };
            dialog.Show();
        }
    }, o => o != null);

    public PhoneBookViewModel(Window owner, PhoneBookRepository repository)
    {
        _owner = owner;
        _repository = repository;
    }
}