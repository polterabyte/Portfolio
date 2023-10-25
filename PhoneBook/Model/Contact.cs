using System.Collections.Generic;

namespace PhoneBook.Model;

public class Contact
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? LastName { get; set; } = "";
    public string Phone { get; set; }
    public int? CompanyId { get; set; }
    public Company? Company { get; set; }
    public ICollection<Contact> Friends { get; set; } = new List<Contact>();
}