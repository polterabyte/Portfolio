using System.Collections.ObjectModel;
using System.Windows.Input;
using PhoneBook.Model;
using PhoneBook.View;

namespace PhoneBook.ViewModel;

public class ContactViewModel : ViewModel
{
    private readonly PhoneBookRepository _repository;
    private readonly Contact _contact;
    public ObservableCollection<Company> Companies => _repository.Companies;
    public ObservableCollection<Contact> Friends { get; }

    public ICommand AddNewCompanyCommand => new Command(o =>
    {
        var company = new Company();
        var companyView = new CompanyView(company);
        if (companyView.ShowDialog() == true)
        {
            _repository.Companies.Add(company);
        }
    });

    public ICommand EditCompanyCommand => new Command(o =>
    {
        if (o is not Company company) return;
        var companyView = new CompanyView(company);
        companyView.Show();
    });

    public Company? Company
    {
        get => _contact.Company; 
        set
        {
            if (value == null || value == _contact.Company) return;
            
            _contact.Company = value;
            _contact.CompanyId = value.Id;
            OnPropertyChanged();
        }
    }

    public string? Name
    {
        get => _contact.Name;
        set
        {
            if (value == _contact.Name) return;

            _contact.Name = value;
            OnPropertyChanged();
        }
    }

    public string? LastName
    {
        get => _contact.LastName;
        set
        {
            if (value == _contact.LastName) return;

            _contact.LastName = value;
            OnPropertyChanged();
        }
    }

    public string Phone
    {
        get => _contact.Phone;
        set
        {
            if (string.IsNullOrEmpty(value) || value == _contact.Phone) return;

            _contact.Phone = value;
            OnPropertyChanged();
        }
    }

    public ContactViewModel(PhoneBookRepository repository, Contact contact)
    {
        _repository = repository;
        _contact = contact;
        Friends = new ObservableCollection<Contact>(contact.Friends);
    }
}