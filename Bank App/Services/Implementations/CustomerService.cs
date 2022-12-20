using MVC_MobileBankApp.Models;
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
        public Customer CreateCustomer(Customer customer)
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
             return  _repo.CreateCustomer(customer);  
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

        public Customer GetCustomerByAccountnumber(string accountNumber)
        {
            return _repo.GetCustomerByAccountnumber(accountNumber);
        }

        public Customer Login(string email, string passWord)
        {
            return _repo.Login(email,passWord);
        }

        public Customer UpdateCustomer(Customer customer)
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
            return _repo.UpdateCustomer(customerr);
        }
    }
}