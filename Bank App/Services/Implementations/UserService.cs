using Bank_App.Models;
using MVC_MobileBankApp.Models;
using Bank_App.Repositories.Interfaces;
using Bank_App.Services.Interfaces;
using MVC_MobileBankApp.Repositories;

namespace Bank_App.Services.Implementations
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

        public void DeleteUserUsingEmail(User user)
        {
           var userr = _userRepository.GetUserByEmail(user.Email);
           _userRepository.DeleteUserUsingEmail(userr);
        }

        public IList<User> GetAllUser()
        {
            return _userRepository.GetAllUser();
        }

        public User Login(string email, string passWord)
        {
            var ceo = _ceoRepository.Login(email,passWord);
            var customer = _customerRepository.Login(email,passWord);
            var admin = _adminRepository.Login(email,passWord);
            var manager = _managerRepository.Login(email,passWord);
            var user = _userRepository.Login(email,passWord);
            if(user != null )
            {
                if(ceo != null)
                {
                    user.Ceo = _ceoRepository.Login(email,passWord);
                }
                
                if(customer != null)
                {
                    user.Customer = _customerRepository.Login(email,passWord);
                }
                if(admin != null)
                {
                    user.Admin = _adminRepository.Login(email,passWord);
                }
                 if(manager != null)
                {
                    user.Manager = _managerRepository.Login(email,passWord);
                }
            }
                return user;
        }

        public User UpdateUser(User user)
        {
             var userr = _userRepository.GetUserByEmail(user.Email);
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