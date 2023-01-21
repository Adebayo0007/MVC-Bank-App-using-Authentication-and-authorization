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
            var admin =_context.Admins.SingleOrDefault(a => a.StaffId == staffId);
            // return _context.Admins.Find(adminId);
            return admin;
        }

        public IList<Admin> GetAllAdmin()
        {
            return _context.Admins.ToList();
        }

        public Admin Login(string email, string passWord)
        {
           return _context.Admins.SingleOrDefault(a => a.Email == email && a.PassWord == passWord);
        }

        public Admin UpdateAdmin(Admin admin)
        {
           
            _context.Admins.Update(admin);
            _context.SaveChanges();
            return admin;
        }

        // Admin IAdminRepository.CreateAdmin(Admin admin)
        // {
        //     throw new NotImplementedException();
        // }
    }
}