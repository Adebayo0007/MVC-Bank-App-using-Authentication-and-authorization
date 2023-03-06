using Microsoft.EntityFrameworkCore;
using MVC_MobileBankApp.ApplicationContext;
using MVC_MobileBankApp.Models;

namespace MVC_MobileBankApp.Repositories.Implementations
{
    public class AdminRepository : IAdminRepository
    {
         private readonly ApplicationDbContext _context;

        public AdminRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Admin CreateAdmin(Admin admin)
        {
             _context.Admins.Add(admin);
              _context.SaveChanges();
            return admin;
        }

        public Admin DeleteAdminUsingId(Admin admin)
        {
                  _context.Admins.Update(admin);
                 _context.SaveChanges();
            return admin;
        }

        public Admin GetAdminById(string staffId)
        {
            var admin = _context.Admins.SingleOrDefault(a => a.StaffId == staffId);
            return admin;
        }

        public IList<Admin> GetAllAdmin()
        {
            return _context.Admins.Where(a => a.IsActive == true).ToList();
        }
         public string NumberOfAdmin()
        {
            var admin =  _context.Admins.Where(a => a.IsActive == true).Count();
            return admin.ToString();
        }

        public Admin UpdateAdmin(Admin admin)
        {
             //_context.Admins.Update(admin);   //not neccessary
            _context.SaveChanges();
            return admin;
        }
        public IList<Admin> GetAdmins(int adminPass)
        {
             return _context.Admins.Where(a => a.ManagerPass == adminPass && a.IsActive == true).ToList();
        }

        
      public Admin GetAdminByEmail(string email)
        {
            var admin =  _context.Admins.SingleOrDefault(a => a.Email == email);
            return admin;
        }
    }

}