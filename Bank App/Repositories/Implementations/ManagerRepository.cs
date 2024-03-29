using Microsoft.EntityFrameworkCore;
using MVC_MobileBankApp.ApplicationContext;
using MVC_MobileBankApp.Models;
using MVC_MobileBankApp.Repositories.Interfaces;

namespace MVC_MobileBankApp.Repositories.Implementations
{
    public class ManagerRepository : IManagerRepository
    {
        private readonly ApplicationDbContext _context;
        public ManagerRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public Manager CreateManager(Manager manager)
        {
             _context.Managers.Add(manager);
             _context.SaveChanges();
            return manager;
        }

        public Manager DeleteManager(Manager manager)
        {
             _context.Managers.Update(manager);
             _context.SaveChanges();
            return manager;
        }

        public IList<Manager> GetAllManager()
        {
           return _context.Managers.Where( m => m.IsActive == true).ToList();
        }

        public Manager GetManagerById(string managerId)
        {
            var manager = _context.Managers.SingleOrDefault(a => a.ManagerId == managerId);
            return manager;
        }
          public Manager Code(int code)
        {
            var manager = _context.Managers.SingleOrDefault(a => a.AdminRegistrationCode == code);
            return manager;
        }

        public  Manager UpdateManager(Manager manager)
        {
               //_context.Managers.Update(manager);  //not neccessary
              _context.SaveChanges();
            return manager;
        }
        public string NumberOfManager()
        {
             var manager = _context.Managers.Where( m => m.IsActive == true).Count();
             return manager.ToString();
        }

         public Manager GetManagerByEmail(string email)
        {
            var manager = _context.Managers.SingleOrDefault(a => a.Email == email);
            return manager;
        }

    }
}