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
            return _context.Admins.Where(a => a.IsActive == true).ToList();
        }
         public string NumberOfAdmin()
        {
            return _context.Admins.Where(a => a.IsActive == true).Count().ToString();
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
        public IList<Admin> GetAdmins(int adminPass)
        {
             return _context.Admins.Where(a => a.ManagerPass == adminPass && a.IsActive == true).ToList();
        }

        // Admin IAdminRepository.CreateAdmin(Admin admin)
        // {
        //     throw new NotImplementedException();
        // }

        
      public Admin GetAdminByEmail(string email)
        {
            var admin =_context.Admins.SingleOrDefault(a => a.Email == email);
            // var use =_context.Users.Include(x => x.Ceo.CEOId);
            return admin;
        }
    }

}