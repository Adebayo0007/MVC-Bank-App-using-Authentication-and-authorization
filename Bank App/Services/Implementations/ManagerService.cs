using MVC_MobileBankApp.Models;
using MVC_MobileBankApp.Models.DTOs.ManagerDto;
using MVC_MobileBankApp.Models.DTOs.UserDto;
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
        public CreateManagerRequestModel CreateManager(CreateManagerRequestModel manager)
        {
             var Age = DateTime.Now.Year - manager.DOB.Year;
              
              if(Age < 18)
             {
                manager.Message = $"Manager under 18 Years old are not allowed in this Application";
                return manager;
             }
             var user = new CreateUserRequestModel
            {
                Email = manager.Email,
                PassWord =  BCrypt.Net.BCrypt.HashPassword(manager.PassWord),
                IsActive = true,
                Role = "Manager" 
            };
            var use = _userRepo.CreateUser(user);
           
             var rand = new Random();     
             
               var legitManager = new Manager {
                ManagerId = "ZENITH-MANAGER-"+rand.Next(0, 9).ToString()+rand.Next(50, 99).ToString()+"-" +manager.FirstName[0]+manager.FirstName[1]+manager.FirstName[2]+rand.Next(0,9).ToString(),
                IsActive = true,
                AdminRegistrationCode = AdminRegistrationCode(),
                FirstName = manager.FirstName,
                LastName = manager.LastName,
                Address = manager.Address,
                Age = DateTime.Now.Year - manager.DOB.Year,
                Gender = manager.Gender,
                MaritalStatus = manager.MaritalStatus,
                Email = manager.Email,
                PhoneNumber = manager.PhoneNumber,
                DateCreated = DateTime.Now,
                UserId = use.Id,
                ProfilePicture = manager.ProfilePicture
                
             };
           
              _repo.CreateManager(legitManager);  
             
             return manager;    
        }

        public ManagerResponseModel DeleteManager(string managerId)
        {

              var manager =  _repo.GetManagerById(managerId);
               _userRepo.DeleteUserUsingId(manager.UserId);
               manager.IsActive = false;
              var managerr = _repo.DeleteManager(manager);
              return new ManagerResponseModel {
                 ManagerId = managerr.ManagerId,
                FirstName = managerr.FirstName,
                LastName = managerr.LastName,
                Address = managerr.Address,
                Age = managerr.Age,
                Gender = managerr.Gender,
                MaritalStatus = managerr.MaritalStatus,
                Email = managerr.Email,
                PhoneNumber = managerr.PhoneNumber,
                DateCreated = managerr.DateCreated,
                IsActive = managerr.IsActive,
                AdminRegistrationCode = managerr.AdminRegistrationCode
                

            };
        }

        public IList<ManagerResponseModel> GetAllManager()
        {
             var managers = _repo.GetAllManager();
             return managers.Select(item => new ManagerResponseModel{
                ManagerId = item.ManagerId,
                FirstName = item.FirstName,
                LastName = item.LastName,
                Address = item.Address,
                Age = item.Age,
                Gender = item.Gender,
                MaritalStatus = item.MaritalStatus,
                Email = item.Email,
                PhoneNumber = item.PhoneNumber,
                DateCreated = item.DateCreated,
                IsActive = item.IsActive,
                AdminRegistrationCode = item.AdminRegistrationCode

             }).ToList();
        }

        public ManagerResponseModel GetManagerById(string managerId)
        {
            var manager = _repo.GetManagerById(managerId);
                return new ManagerResponseModel {
                 ManagerId = manager.ManagerId,
                FirstName = manager.FirstName,
                LastName = manager.LastName,
                Address = manager.Address,
                Age = manager.Age,
                Gender = manager.Gender,
                MaritalStatus = manager.MaritalStatus,
                Email = manager.Email,
                PhoneNumber = manager.PhoneNumber,
                DateCreated = manager.DateCreated,
                IsActive = manager.IsActive,
                AdminRegistrationCode = manager.AdminRegistrationCode,
                ProfilePicture = manager.ProfilePicture
                

            };
        }

    
        public ManagerResponseModel Code(int code)
        {
             var manager = _repo.Code(code);
            return new ManagerResponseModel {
                 ManagerId = manager.ManagerId,
                FirstName = manager.FirstName,
                LastName = manager.LastName,
                Address = manager.Address,
                Age = manager.Age,
                Gender = manager.Gender,
                MaritalStatus = manager.MaritalStatus,
                Email = manager.Email,
                PhoneNumber = manager.PhoneNumber,
                DateCreated = manager.DateCreated,
                IsActive = manager.IsActive,
                AdminRegistrationCode = manager.AdminRegistrationCode,
                ProfilePicture = manager.ProfilePicture
                

            };

        }

        public void UpdateManager(UpdateManagerRequestModel manager)
        {
               var managerr = _repo.GetManagerById(manager.ManagerId);
            if(managerr == null )
            {
                throw new DirectoryNotFoundException();
            }
           var user = new UpdateUserRequestModel();
            
                user.Email = manager.Email;
                if(manager.PassWord != null)
                {
                   user.PassWord =  BCrypt.Net.BCrypt.HashPassword(manager.PassWord);
                }
             _userRepo.UpdateUser(user,managerr.UserId);
            
            managerr.FirstName = manager.FirstName ?? managerr.FirstName;
            managerr.LastName = manager.LastName ?? managerr.LastName;
            managerr.Email = manager.Email ?? managerr.Email;
            managerr.Age = manager.Age != managerr.Age? manager.Age : managerr.Age;
            managerr.Address = manager.Address ?? managerr.Address;
            managerr.MaritalStatus = manager.MaritalStatus;
            managerr.DateModified = DateTime.Now;
             _repo.UpdateManager(managerr);
        }

         public string NumberOfManager()
        {
           return _repo.NumberOfManager();
        }

          public ManagerResponseModel GetManagerByEmail(string email)
         {
            var manager = _repo.GetManagerByEmail(email);
             return new ManagerResponseModel {
                 ManagerId = manager.ManagerId,
                FirstName = manager.FirstName,
                LastName = manager.LastName,
                Address = manager.Address,
                Age = manager.Age,
                Gender = manager.Gender,
                MaritalStatus = manager.MaritalStatus,
                Email = manager.Email,
                PhoneNumber = manager.PhoneNumber,
                DateCreated = manager.DateCreated,
                IsActive = manager.IsActive,
                AdminRegistrationCode = manager.AdminRegistrationCode,
                ProfilePicture = manager.ProfilePicture
            };

         }

            public int AdminRegistrationCode()
        {
             
                var code = new Random().Next(100,300);
                return code;   

        }
       

    }
}