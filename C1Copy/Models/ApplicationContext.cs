using C1Copy.Models;
using Microsoft.EntityFrameworkCore;

public class ApplicationContext : DbContext
{
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<LegalEntities> LegalEntities { get; set; }
    public DbSet<Office> Offices { get; set; }

    public ApplicationContext()
    {
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql("server=localhost;user=root;password=root;database=master;", 
            new MySqlServerVersion(new Version(8, 0, 29)));
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasData(
            new User { Id = 1, Name = "Tom", Age = 37, PhoneNumber = "323232"},
            new User { Id = 2, Name = "Bob", Age = 41, PhoneNumber = "323232" },
            new User { Id = 3, Name = "Sam", Age = 24, PhoneNumber = "323232" }
        );
        var ad = new Role{RoleID= 1,Name = "admin"};
        var us = new Role{RoleID=2,Name = "user"};
        modelBuilder.Entity<Role>().HasData(
            ad,
            us
        );
        modelBuilder.Entity<Account>().HasData(
            new Account{ID = 1,Email = "asd",Password = "123",RoleID = 2},
            new Account{ID = 2,Email = "theanfishow@gmail.com",Password = "123",RoleID = 1}
        );
        
        modelBuilder.Entity<Client>().HasData(
            new Client{ID = 1,Name = "asd",LegalEntitiesID = 1,},
            new Client{ID = 2,Name = "dsadasd", LegalEntitiesID= 1, }
        );
        modelBuilder.Entity<LegalEntities>().HasData(
            new LegalEntities{LegalEntitiesID = 1,Name = "asd"},
            new LegalEntities{LegalEntitiesID = 2,Name = "dsadasd"}
        );
        modelBuilder.Entity<Office>()
            .HasData(
                new Office { OfficeID = 1, ClientID = 1, Adress = "ул.Полевая д.19" },
                new Office { OfficeID = 2,ClientID = 1,Adress = "Некрасова"});

    }
}