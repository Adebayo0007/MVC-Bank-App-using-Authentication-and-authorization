using MVC_MobileBankApp.Models;
using MVC_MobileBankApp.Models.DTOs.CustomerDto;
using MVC_MobileBankApp.Models.DTOs.UserDto;
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
        public CreateCustomerRequestModel CreateCustomer(CreateCustomerRequestModel customer)
        {
             var Age = DateTime.Now.Year - customer.DOB.Year;
              
              if(Age < 10)
             {
                customer.Message = $"Customer under 10 Years old are not allowed in this Application";
                return customer;
             }

              var user = new CreateUserRequestModel
            {
                Email = customer.Email,
                PassWord = BCrypt.Net.BCrypt.HashPassword(customer.PassWord),
                  IsActive = true,
                  Role = "Customer"
            };
            var use = _userRepo.CreateUser(user);
               Random random = new Random();
                Random rand = new Random();
                // customer.AccountNumber = $"{random.Next(300,700).ToString()}{random.Next(100, 900).ToString()}{rand.Next(100,400).ToString()}0";
                // customer.UserId = use.Id;
                // customer.IsActive = true;
                 var legitCustomer = new Customer {

                IsActive = true,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Address = customer.Address,
                Age = DateTime.Now.Year - customer.DOB.Year,
                Gender = customer.Gender,
                MaritalStatus = customer.MaritalStatus,
                Email = customer.Email,
                PhoneNumber = customer.PhoneNumber,
                // PassWord = BCrypt.Net.BCrypt.HashPassword(customer.PassWord),
                DateCreated = DateTime.Now,
                UserId = use.Id,
                AccountNumber = $"{random.Next(300,700).ToString()}{random.Next(100, 900).ToString()}{rand.Next(100,400).ToString()}0",
                Pin = customer.Pin,
                AccountType = customer.AccountType,
                ProfilePicture = customer.ProfilePicture
                
             };
            
               _repo.CreateCustomer(legitCustomer); 
             
              return customer;
           
            
            
        }

        public CustomerResponseModel DeleteCustomer(string customerId)
        {
      
              var customer = _repo.GetCustomerByAccountnumber(customerId);
               _userRepo.DeleteUserUsingId(customer.UserId);
               customer.IsActive = false;
              var customerr = _repo.DeleteCustomer(customer);
             return new CustomerResponseModel {
           
                IsActive = customerr.IsActive,
                FirstName = customerr.FirstName,
                LastName = customerr.LastName,
                Address = customerr.Address,
                Age = customerr.Age,
                Gender = customerr.Gender,
                MaritalStatus = customerr.MaritalStatus,
                Email = customerr.Email,
                PhoneNumber = customerr.PhoneNumber,
                // PassWord = customerr.PassWord,
                DateCreated = customerr.DateCreated,
                AccountNumber = customerr.AccountNumber,
                Pin = customerr.Pin,
                AccountType = customerr.AccountType,
                AccountBalance = customerr.AccountBalance

            };
        }

        public  IList<CustomerResponseModel> GetAllCustomer()
        {
              var customer = _repo.GetAllCustomer();
              return customer.Select(item => new CustomerResponseModel{
                IsActive = item.IsActive,
                FirstName = item.FirstName,
                LastName = item.LastName,
                Address = item.Address,
                Age = item.Age,
                Gender = item.Gender,
                MaritalStatus = item.MaritalStatus,
                Email = item.Email,
                PhoneNumber = item.PhoneNumber,
                // PassWord = customerr.PassWord,
                DateCreated = item.DateCreated,
                AccountNumber = item.AccountNumber,
                // Pin = item.Pin,
                AccountType = item.AccountType,
                AccountBalance = item.AccountBalance


              }).ToList();
        }

        public CustomerResponseModel GetCustomerByAccountnumber(string accountNumber)
        {
            var customer =  _repo.GetCustomerByAccountnumber(accountNumber);
            return new CustomerResponseModel {
           
                IsActive = customer.IsActive,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Address = customer.Address,
                Age = customer.Age,
                Gender = customer.Gender,
                MaritalStatus = customer.MaritalStatus,
                Email = customer.Email,
                PhoneNumber = customer.PhoneNumber,
                // PassWord = customer.PassWord,
                DateCreated = customer.DateCreated,
                AccountNumber = customer.AccountNumber,
                Pin = customer.Pin,
                AccountType = customer.AccountType,
                AccountBalance = customer.AccountBalance,
                ProfilePicture = customer.ProfilePicture
                

            };
        }


        public void UpdateCustomer(UpdateCustomerRequestModel customer)
        {
                var customerr = _repo.GetCustomerByAccountnumber(customer.AccountNumber);
            if(customerr == null )
            {
                throw new DirectoryNotFoundException();
            }
              var user = new UpdateUserRequestModel();
            
                user.Email = customer.Email;
                if(customer.PassWord != null)
                {
                   user.PassWord =  BCrypt.Net.BCrypt.HashPassword(customer.PassWord);
                }
            
            
              _userRepo.UpdateUser(user,customerr.UserId);
            
            customerr.FirstName = customer.FirstName ?? customerr.FirstName;
            customerr.LastName = customer.LastName ?? customerr.LastName;
            customerr.Email = customer.Email ??  customerr.Email;
            // customerr.PassWord = customer.PassWord ?? customerr.PassWord;
            customerr.Age = customer.Age != customerr.Age? customer.Age : customerr.Age;
            customerr.Address = customer.Address ?? customerr.Address;
            customerr.MaritalStatus = customer.MaritalStatus;
            customerr.AccountType = customer.AccountType;
            customerr.Pin = customer.Pin ?? customerr.Pin; 
            customerr.DateModified = DateTime.Now;
            _repo.UpdateCustomer(customerr);
        }

        public string NumberOfCustomer()
        {
            return _repo.NumberOfCustomer();
        }

          public CustomerResponseModel  GetCustomerByEmail(string email)
         {
            var customer = _repo.GetCustomerByEmail(email);
            return new CustomerResponseModel {
                 IsActive = customer.IsActive,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Address = customer.Address,
                Age = customer.Age,
                Gender = customer.Gender,
                MaritalStatus = customer.MaritalStatus,
                Email = customer.Email,
                PhoneNumber = customer.PhoneNumber,
                // PassWord = customer.PassWord,
                DateCreated = customer.DateCreated,
                AccountNumber = customer.AccountNumber,
                Pin = customer.Pin,
                AccountType = customer.AccountType,
                AccountBalance = customer.AccountBalance,
                ProfilePicture = customer.ProfilePicture

            };
         }
    }
}