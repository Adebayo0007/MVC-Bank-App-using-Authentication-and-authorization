using MVC_MobileBankApp.Models;
using MVC_MobileBankApp.Models.DTOs;
using MVC_MobileBankApp.Repositories.Interfaces;
using MVC_MobileBankApp.Services.Interfaces;

namespace MVC_MobileBankApp.Services.Implementations
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repo;
         private readonly IUserService _userRepo;


        public CustomerService(ICustomerRepository repo,IUserService userRepo)
        {
            _repo = repo;
            _userRepo = userRepo;
        }
        public Customer CreateCustomer(CustomerDTO customer)
        {
              var user = new User
            {
                Email = customer.Email,
                PassWord = customer.PassWord,
                  IsActive = true,
                  Role = "Customer"
            };
            var use = _userRepo.CreateUser(user);
               Random random = new Random();
                Random rand = new Random();
                customer.AccountNumber = $"{random.Next(300,700).ToString()}{random.Next(100, 900).ToString()}{rand.Next(100,400).ToString()}0";
                customer.UserId = use.Id;
                customer.IsActive = true;

                 var legitCustomer = new Customer {

                IsActive = customer.IsActive,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Address = customer.Address,
                Age = DateTime.Now.Year - customer.DOB.Year,
                Gender = customer.Gender,
                MaritalStatus = customer.MaritalStatus,
                Email = customer.Email,
                PhoneNumber = customer.PhoneNumber,
                PassWord = customer.PassWord,
                DateCreated = customer.DateCreated,
                UserId = use.Id,
                AccountNumber = customer.AccountNumber,
                Pin = customer.Pin,
                AccountType = customer.AccountType
                
             };
            
             return  _repo.CreateCustomer(legitCustomer);  
        }

        public Customer DeleteCustomer(string customerId)
        {
      
              var customer = _repo.GetCustomerByAccountnumber(customerId);
               _userRepo.DeleteUserUsingId(customer.UserId);
               customer.IsActive = false;
              return _repo.DeleteCustomer(customer);
        }

        public IList<Customer> GetAllCustomer()
        {
              return _repo.GetAllCustomer();
        }

        public CustomerRequestModel GetCustomerByAccountnumber(string accountNumber)
        {
            var customer = _repo.GetCustomerByAccountnumber(accountNumber);
            return new CustomerRequestModel {
           
                IsActive = customer.IsActive,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Address = customer.Address,
                Age = customer.Age,
                Gender = customer.Gender,
                MaritalStatus = customer.MaritalStatus,
                Email = customer.Email,
                PhoneNumber = customer.PhoneNumber,
                PassWord = customer.PassWord,
                DateCreated = customer.DateCreated,
                AccountNumber = customer.AccountNumber,
                Pin = customer.Pin,
                AccountType = customer.AccountType

            };
        }

        public Customer Login(string email, string passWord)
        {
            return _repo.Login(email,passWord);
        }

        public void UpdateCustomer(CustomerRequestModel customer)
        {
                var customerr = _repo.GetCustomerByAccountnumber(customer.AccountNumber);
            if(customerr == null )
            {
                throw new DirectoryNotFoundException();
            }
              var user = new User
            {
                Email = customer.Email,
                PassWord = customer.PassWord
            
            };
           _userRepo.UpdateUser(user,customerr.UserId);
            
            customerr.FirstName = customer.FirstName ?? customerr.FirstName;
            customerr.LastName = customer.LastName ?? customerr.LastName;
            customerr.Email = customer.Email ??  customerr.Email;
            customerr.PassWord = customer.PassWord ?? customerr.PassWord;
            customerr.Age = customer.Age != customerr.Age? customer.Age : customerr.Age;
            customerr.Address = customer.Address ?? customerr.Address;
            customerr.MaritalStatus = customer.MaritalStatus;
            customerr.AccountType = customer.AccountType;
            customerr.Pin = customer.Pin ?? customerr.Pin; 
            _repo.UpdateCustomer(customerr);
        }
    }
}