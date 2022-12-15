using Bank_App.Repositories.Interfaces;
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

        public void DeleteUserUsingEmail(User user)
        {
             _context.Users.Remove(user);
            _context.SaveChanges();
        }

        public IList<User> GetAllUser()
        {
            return _context.Users.ToList();
        }

        public MVC_MobileBankApp.Models.User Login(string email, string passWord)
        { 
            return _context.Users.SingleOrDefault(a => a.Email  == email && a.PassWord == passWord);
        }

        public User UpdateUser(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
            return user;
        }
         public User GetUserByEmail(string email)
        {
            var user =_context.Users.SingleOrDefault(a => a.Email == email);
            return user;
        }
    }
}