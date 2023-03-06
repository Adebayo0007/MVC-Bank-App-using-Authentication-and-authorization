using Microsoft.EntityFrameworkCore;
using MVC_MobileBankApp.Models;

namespace MVC_MobileBankApp.ApplicationContext
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<CEO> CEOs { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating (ModelBuilder modelBuilder){

              modelBuilder.Entity<User>().HasData(
                new User
                {
                       Id = 99,
                       Email = "ceo93@gmail.com",
                       Role = "CEO",
                      IsActive = true,
                      PassWord = "Ceo0004"
                }
              );


            
            modelBuilder.Entity<CEO>().HasData(
                new CEO
                {
                    CEOId = "ZENITH-CEO-100",
                    FirstName = "uthman",
                    LastName = "Tijani",
                    Address = "10,Abayomi street",
                    UserId = 99,
                    Age = 22,
                    Gender = Enum.GenderType.Male,
                    MaritalStatus = Enum.MaritalStatusType.Married,
                    Email = "ceo93@gmail.com",
                    PhoneNumber = "+2348087054632",
                    IsActive = true, 
                    DateCreated = DateTime.Now
                }
            );
        }

    }
}