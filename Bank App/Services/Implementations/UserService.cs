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
         private readonly ICustomerRepository _customerRepository;
         private readonly IAdminRepository _adminRepository;
         private readonly IManagerRepository _managerRepository;
         private readonly ICEORepository _ceoRepository;
        public UserService(IUserRepository userRepository,ICustomerRepository customerRepository,IAdminRepository adminRepository,IManagerRepository managerRepository,ICEORepository ceoRepository)
        {
            _userRepository = userRepository;
            _ceoRepository = ceoRepository;
            _customerRepository = customerRepository;
            _adminRepository = adminRepository;
            _managerRepository = managerRepository;
        }

        public User CreateUser(User user)
        {
             return  _userRepository.CreateUser(user);  
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
           
            var user = _userRepository.Login(email,passWord);
            return new UserDTO{
                    Id  = user.Id,
                    Email  = user.Email,
                    Customer = user.Customer,
                    Admin = user.Admin,
                    Manager = user.Manager,
                    Ceo = user.Ceo,
                    IsActive = user.IsActive,
                    PassWord = user.PassWord,
                    Role  = user.Role
            };
                
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
    }
}