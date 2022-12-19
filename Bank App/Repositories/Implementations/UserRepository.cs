using Bank_App.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using MVC_MobileBankApp.ApplicationContext;
using MVC_MobileBankApp.Models;

namespace Bank_App.Repositories.Implementations
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
            return _context.Users.ToList();
        }

        public MVC_MobileBankApp.Models.User Login(string email, string passWord)
        { 
            return _context.Users.Include(x => x.Customer).SingleOrDefault(a => a.Email  == email && a.PassWord == passWord);
        }

        public User UpdateUser(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
            return user;
        }
         public User GetUserById(int id)
        {
            var user =_context.Users.SingleOrDefault(a => a.Admin.UserId == id || a.Ceo.UserId == id || a.Manager.UserId == id || a.Customer.UserId == id);
            // var use =_context.Users.Include(x => x.Ceo.CEOId);
            return user;
        }
    }
}