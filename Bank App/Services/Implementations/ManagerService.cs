using MVC_MobileBankApp.Models;
using MVC_MobileBankApp.Models.DTOs;
using MVC_MobileBankApp.Repositories.Interfaces;
using MVC_MobileBankApp.Services.Interfaces;

namespace MVC_MobileBankApp.Services.Implementations
{
    public class ManagerService : IManagerService
    {
        private readonly IManagerRepository _repo;
        private readonly IUserService _userRepo;

        public ManagerService(IManagerRepository repo,IUserService userRepo)
        {
            _repo = repo;
            _userRepo = userRepo;

        }
        public ManagerDTO CreateManager(ManagerDTO manager)
        {
             var Age = DateTime.Now.Year - manager.DOB.Year;
              
              if(Age < 18)
             {
                manager.Message = $"Manager under 18 Years old are not allowed in this Application";
                return manager;
             }

              var user = new User
            {
                Email = manager.Email,
                PassWord = manager.PassWord,
                  IsActive = true,
                  Role = "Manager"
            };
            var use = _userRepo.CreateUser(user);
            var rand = new Random();
             manager.ManagerId = "ZENITH-MANAGER-"+rand.Next(0, 9).ToString()+rand.Next(50, 99).ToString()+"-" +manager.FirstName[0]+manager.FirstName[1]+manager.FirstName[2]+rand.Next(0,9).ToString();
             manager.AdminRegistrationCode = AdminRegistrationCode();
             manager.UserId = use.Id;
             manager.IsActive = true;

              var legitManager = new Manager {
                ManagerId = manager.ManagerId,
                IsActive = manager.IsActive,
                FirstName = manager.FirstName,
                LastName = manager.LastName,
                Address = manager.Address,
                Age = DateTime.Now.Year - manager.DOB.Year,
                Gender = manager.Gender,
                MaritalStatus = manager.MaritalStatus,
                Email = manager.Email,
                PhoneNumber = manager.PhoneNumber,
                PassWord = manager.PassWord,
                DateCreated = manager.DateCreated,
                UserId = use.Id,
                AdminRegistrationCode = manager.AdminRegistrationCode,
                ProfilePicture = manager.ProfilePicture
             };
               _repo.CreateManager(legitManager);  
             return manager;     
        }

        public ManagerRequestModel DeleteManager(string managerId)
        {

              var manager =  _repo.GetManagerById(managerId);
               _userRepo.DeleteUserUsingId(manager.UserId);
               manager.IsActive = false;
              var managerr = _repo.DeleteManager(manager);
              return new ManagerRequestModel {
                 ManagerId = managerr.ManagerId,
                FirstName = managerr.FirstName,
                LastName = managerr.LastName,
                Address = managerr.Address,
                Age = managerr.Age,
                Gender = managerr.Gender,
                MaritalStatus = managerr.MaritalStatus,
                Email = managerr.Email,
                PhoneNumber = managerr.PhoneNumber,
                PassWord = managerr.PassWord,
                DateCreated = managerr.DateCreated,
                IsActive = managerr.IsActive,
                AdminRegistrationCode = managerr.AdminRegistrationCode
                

            };
        }

        public IList<Manager> GetAllManager()
        {
             return _repo.GetAllManager();
        }

        public ManagerRequestModel GetManagerById(string managerId)
        {
            var manager = _repo.GetManagerById(managerId);
                return new ManagerRequestModel {
                 ManagerId = manager.ManagerId,
                FirstName = manager.FirstName,
                LastName = manager.LastName,
                Address = manager.Address,
                Age = manager.Age,
                Gender = manager.Gender,
                MaritalStatus = manager.MaritalStatus,
                Email = manager.Email,
                PhoneNumber = manager.PhoneNumber,
                PassWord = manager.PassWord,
                DateCreated = manager.DateCreated,
                IsActive = manager.IsActive,
                AdminRegistrationCode = manager.AdminRegistrationCode,
                ProfilePicture = manager.ProfilePicture
                

            };
        }

    
        public Manager Code(int code)
        {
             var manager = _repo.Code(code);
             return manager;

        }

        public void UpdateManager(ManagerRequestModel manager)
        {
               var managerr = _repo.GetManagerById(manager.ManagerId);
            if(managerr == null )
            {
                throw new DirectoryNotFoundException();
            }
             var user = new User
            {
                Email = manager.Email,
                PassWord = manager.PassWord
            
            };
             _userRepo.UpdateUser(user,managerr.UserId);
            
            
            managerr.FirstName = manager.FirstName ?? managerr.FirstName;
            managerr.LastName = manager.LastName ?? managerr.LastName;
            managerr.Email = manager.Email ?? managerr.Email;
            managerr.PassWord = manager.PassWord ?? managerr.PassWord;
            managerr.Age = manager.Age != managerr.Age? manager.Age : managerr.Age;
            managerr.Address = manager.Address ?? managerr.Address;
            managerr.MaritalStatus = manager.MaritalStatus;
             _repo.UpdateManager(managerr);
        }

         public string NumberOfManager()
        {
           return _repo.NumberOfManager();
        }

          public Manager GetManagerByEmail(string email)
         {
            return _repo.GetManagerByEmail(email);
         }

            public int AdminRegistrationCode()
        {
             
                var code = new Random().Next(100,300);
                return code;   

        }
       

    }
}