using System.Collections.Generic;

namespace PhoneBook.Model;

public class Company
{
    public int Id { get; set; }
    public string Name { get; set; } = "";

    public ICollection<Contact> Contacts { get; set; } = new List<Contact>();

    public override string ToString() => Name;
}