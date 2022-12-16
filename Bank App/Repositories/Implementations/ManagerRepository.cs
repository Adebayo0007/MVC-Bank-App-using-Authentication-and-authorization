using Bank_App.Repositories.Interfaces;
using MVC_MobileBankApp.ApplicationContext;
using MVC_MobileBankApp.Models;

namespace Bank_App.Repositories.Implementations
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
           return _context.Managers.ToList();
        }

        public Manager GetManagerById(string managerId)
        {
            var manager =_context.Managers.SingleOrDefault(a => a.ManagerId == managerId);
            return manager;
        }

        public Manager Login(string email, string passWord)
        {
            var manager = _context.Managers.SingleOrDefault(a => a.Email == email && a.PassWord == passWord);
            return manager;
        }

        public Manager UpdateManager(Manager manager)
        {
               _context.Managers.Update(manager);
            _context.SaveChanges();
            return manager;
        }
    }
}