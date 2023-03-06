using MVC_MobileBankApp.Models;
using MVC_MobileBankApp.Models.DTOs;
using MVC_MobileBankApp.Models.DTOs.UserDto;
// using MVC_MobileBankApp.Repositories;
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

        public CreateUserRequestModel CreateUser(CreateUserRequestModel user)
        {
            var userr = new User{
                Email = user.Email,
                PassWord = user.PassWord,
                IsActive = true,
                Role = user.Role,
            };
           var user2 = _userRepository.CreateUser(userr);  
              return new CreateUserRequestModel{
                Id = user2.Id,
                Email = user.Email,
                PassWord = user.PassWord,
                IsActive = true,
                Role = user.Role,
            };
        }

        public UserResponseModel DeleteUserUsingId(int userId)
        {
           var userr = _userRepository.GetUserById(userId);
            if(userr == null )
            {
                throw new DirectoryNotFoundException();
            }
            userr.IsActive = false;
            var user = _userRepository.DeleteUser(userr);
            return new UserResponseModel{
                Email = user.Email,
                PassWord = user.PassWord,
                IsActive = user.IsActive,
                Role = user.Role
            };
        }

        public IList<UserResponseModel> GetAllUser()
        {
            var users = _userRepository.GetAllUser();
            return users.Select(item => new UserResponseModel{
                Id = item.Id,
                IsActive = item.IsActive,
                Email = item.Email,
                Role = item.Role,
                PassWord = item.PassWord,
            }).ToList();
        }

        public UserResponseModel Login(string email, string passWord)
        {
           var userResponseModel = new UserResponseModel();
            var user = _userRepository.Login(email);
             if(user == null)
            {
                userResponseModel.Message = $"Invalid Email or Password";
                return userResponseModel;
            }
            if(user.IsActive == false)
            {
                userResponseModel.Message = $"You are not an Active User";
                return userResponseModel;

            }
             if( user!= null && BCrypt.Net.BCrypt.Verify(passWord, user.PassWord))
             {
                    userResponseModel.Id  = user.Id;
                    userResponseModel.Email  = user.Email;
                    userResponseModel.IsActive = user.IsActive;
                    userResponseModel.PassWord = user.PassWord;
                    userResponseModel.Role  = user.Role;
        

             }
            return userResponseModel;
            
                    
            
                
        }

        public UpdateUserRequestModel UpdateUser(UpdateUserRequestModel user,int userId)
        {
             var userr = _userRepository.GetUserById(userId);
            if(userr == null )
            {
                throw new DirectoryNotFoundException();
            }
            userr.Email = user.Email ?? userr.Email;
            userr.PassWord = user.PassWord ?? userr.PassWord;
            //  var userUpdate = _userRepository.UpdateUser(userr);   //not neccessary
             return new UpdateUserRequestModel{
                Email =  user.Email ?? userr.Email,
                PassWord =  user.PassWord ?? userr.PassWord,
                IsActive = userr.IsActive

             };

        }
         public bool GetUserByEmail(string email)
         {
            return _userRepository.GetUserByEmail(email);
         }
         public string NumberOfUsers()
         {
            return _userRepository.NumberOfUsers();

         }
         
    }
}