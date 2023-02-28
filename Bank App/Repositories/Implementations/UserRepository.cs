using Microsoft.EntityFrameworkCore;
using MVC_MobileBankApp.ApplicationContext;
using MVC_MobileBankApp.Models;
using MVC_MobileBankApp.Repositories.Interfaces;

namespace MVC_MobileBankApp.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }
          public User CreateUser(User user)
        {
             _context.Users.Add(user);
              _context.SaveChanges();
            return user;
        }

        public User DeleteUser(User user)
        {
             _context.Users.Update(user);
             _context.SaveChanges();
            return user;
        }

        public IList<User> GetAllUser()
        {
            return _context.Users.Where(u => u.IsActive == true).ToList();
        }

        public MVC_MobileBankApp.Models.User Login(string email, string passWord)
        { 
            // return _context.Users
            //        .Include(x => x.Customer)
            //        .Include(x => x.Manager)
            //        .Include(x => x.Admin)
            //        .Include(x =>x.Ceo)
            //        .SingleOrDefault(a => a.Email  == email && a.PassWord == passWord);

                     return _context.Users.SingleOrDefault(a => a.Email  == email && a.PassWord == passWord);
        }
        

        public User UpdateUser(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
            return user;
        }
         public User GetUserById(int id)
        {
            var user = _context.Users.SingleOrDefault(a => a.Admin.UserId == id || a.Ceo.UserId == id || a.Manager.UserId == id || a.Customer.UserId == id);
            // var use =_context.Users.Include(x => x.Ceo.CEOId);
            return user;
        }
          public User GetUserByEmail(string email)
        {
            var user =  _context.Users.SingleOrDefault(a => a.Email == email);
            // var use =_context.Users.Include(x => x.Ceo.CEOId);
            return user;
        }

        public string NumberOfUsers()
        {
             var user = _context.Users.Where( m => m.IsActive == true).Count();
             return user.ToString();
        }
    }
}