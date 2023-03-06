using MVC_MobileBankApp.Models;

namespace MVC_MobileBankApp.Repositories.Interfaces
{
    public interface IUserRepository
    {
        // User UpdateUser(User user); //not neccessary
        User DeleteUser(User user);
        User CreateUser(User user);
        User Login(string email);
        User GetUserById(int id);
        bool GetUserByEmail(string email);
        IList<User> GetAllUser(); 
         string NumberOfUsers();

    }
}