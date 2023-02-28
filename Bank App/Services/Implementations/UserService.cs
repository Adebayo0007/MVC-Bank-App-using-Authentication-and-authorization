using MVC_MobileBankApp.Models;
using MVC_MobileBankApp.Models.DTOs;
using MVC_MobileBankApp.Repositories;
using MVC_MobileBankApp.Repositories.Interfaces;
using MVC_MobileBankApp.Services.Interfaces;

namespace MVC_MobileBankApp.Services.Implementations
{
    public class UserService : IUserService
    {
         private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User CreateUser(User user)
        {
             return _userRepository.CreateUser(user);  
        }

        public User DeleteUserUsingId(int userId)
        {
           var userr = _userRepository.GetUserById(userId);
            if(userr == null )
            {
                throw new DirectoryNotFoundException();
            }
            userr.IsActive = false;
            return _userRepository.DeleteUser(userr);
        }

        public IList<User> GetAllUser()
        {
            return _userRepository.GetAllUser();
        }

        public UserDTO Login(string email, string passWord)
        {
           var userDto = new UserDTO();
            var user = _userRepository.Login(email,passWord);
             if(user == null)
            {
                userDto.Message = $"Invalid Email or Password";
                return userDto;
            }
            if(user.IsActive == false)
            {
                userDto.Message = $"You are not an Active User";
                return userDto;

            }
            
                    userDto.Id  = user.Id;
                    userDto.Email  = user.Email;
                    userDto.IsActive = user.IsActive;
                    userDto.PassWord = user.PassWord;
                    userDto.Role  = user.Role;
        
            
            return userDto;
                
        }

        public User UpdateUser(User user,int userId)
        {
             var userr = _userRepository.GetUserById(userId);
            if(userr == null )
            {
                throw new DirectoryNotFoundException();
            }
            userr.Email = user.Email ?? userr.Email;
            userr.PassWord = user.PassWord ?? userr.PassWord;
            return _userRepository.UpdateUser(userr);
        }
         public User GetUserByEmail(string email)
         {
            return _userRepository.GetUserByEmail(email);
         }
         public string NumberOfUsers()
         {
            return _userRepository.NumberOfUsers();

         }
         
    }
}