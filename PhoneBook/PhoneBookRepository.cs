using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhoneBook.Model;

namespace PhoneBook
{
    public class PhoneBookRepository
    {
        private readonly DatabaseContext _db;
        public ObservableCollection<Company> Companies { get; private set; }
        public ObservableCollection<Contact> Contacts { get; private set; }


        public PhoneBookRepository(DataBaseEnum usedDb)
        {
            _db = new DatabaseContext(usedDb);
            _db.Database.EnsureCreated();

            Companies = _db.Company.Local.ToObservableCollection();
            Contacts = _db.Contact.Local.ToObservableCollection();

            _db.Company.Load();
            _db.Contact.Load();
        }

        public void SaveChanges()
        {
            _db.SaveChanges();
        }
    }
}
