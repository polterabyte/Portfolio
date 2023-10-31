using System;
using System.Collections.Generic;
using System.Windows.Shapes;
using Microsoft.EntityFrameworkCore;
using PhoneBook.Model;

namespace PhoneBook;

public sealed class DatabaseContext : DbContext
{
    private const string DB_NAME = "phone-book";
    public DbSet<Contact> Contact { get; set; } = null!;
    public DbSet<Company> Company { get; set; } = null!;

    private readonly DataBaseEnum _usedDb;

    public DatabaseContext(DataBaseEnum usedDb)
    {
        _usedDb = usedDb;
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
        switch (_usedDb)
        {
            case DataBaseEnum.SQLITE:
                optionsBuilder.UseSqlite($"Filename={DB_NAME}.db");

                break;
            case DataBaseEnum.NPGSQL:
                optionsBuilder.UseNpgsql();

                break;
            case DataBaseEnum.MONGO:
                optionsBuilder.UseMongoDB("", DB_NAME);

                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}