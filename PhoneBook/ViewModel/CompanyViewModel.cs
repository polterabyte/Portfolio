using PhoneBook.Model;

namespace PhoneBook.ViewModel;

public class CompanyViewModel : ViewModel
{
    private Company _company;
    public CompanyViewModel(Company company)
    {
        _company = company;
    }

    public string Name
    {
        get => _company.Name;
        set
        {
            if (string.IsNullOrEmpty(value) || value == _company.Name) return;

            _company.Name = value;
            OnPropertyChanged();
        }
    }
}