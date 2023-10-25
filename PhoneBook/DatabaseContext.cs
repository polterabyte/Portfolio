using System;
using System.Collections.Generic;
using System.Windows.Shapes;
using Microsoft.EntityFrameworkCore;
using PhoneBook.Model;

namespace PhoneBook;

public sealed class DatabaseContext : DbContext
{
    private static string _dbPath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "phone-book.db");
    public DbSet<Contact> Contact { get; set; } = null!;
    public DbSet<Company> Company { get; set; } = null!;

    private readonly bool _useSQLite;

    public DatabaseContext(bool useSQLite)
    {
        _useSQLite = useSQLite;

        if (System.IO.Path.Exists(_dbPath)) return;
        
        Database.EnsureDeleted();
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var oracele = new Company() {Id  = 1, Name = "Oracle" };
        var microsoft = new Company() {Id  = 2,  Name = "Microsoft" };
        var nokia = new Company() {Id  = 3,  Name = "Nokia" };
        
        var tom = new Contact()
        {
            Id  = 1, 
            Name = "Tom", LastName = "Tom's",
            Phone = "+123456789",
            CompanyId = oracele.Id,
        };
        var yan = new Contact()
        {
            Id  = 2, 
            Name = "Yan", LastName = "Yan's",
            Phone = "+987654321",
            CompanyId = microsoft.Id,
            //Friends = new List<Contact>(){tom}
        };
        
        modelBuilder.Entity<Company>().HasData(oracele, microsoft, nokia);
        modelBuilder.Entity<Contact>().HasData(tom, yan);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (_useSQLite)
            optionsBuilder.UseSqlite();
        else
            optionsBuilder.UseNpgsql();
        
        optionsBuilder.UseSqlite("Filename=phone-book.db");
    }
}