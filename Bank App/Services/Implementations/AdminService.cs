using MVC_MobileBankApp.Models.DTOs;
using MVC_MobileBankApp.Models;
using MVC_MobileBankApp.Repositories;
using MVC_MobileBankApp.Services.Interfaces;
using MVC_MobileBankApp.Models.DTOs.AdminDto;
using MVC_MobileBankApp.Models.DTOs.UserDto;

namespace MVC_MobileBankApp.Services.Implementations
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _repo;
         private readonly IUserService _userRepo;

        public AdminService(IAdminRepository repo,IUserService userRepo)
        {
            _repo = repo;
            _userRepo = userRepo;
        }
        public CreateAdminRequestModel CreateAdmin(CreateAdminRequestModel admin)
        {
             var Age = DateTime.Now.Year - admin.DOB.Year;
              
              if(Age < 18)
             {
                admin.Message = $"Manager under 18 Years old are not allowed in this Application";
                return admin;
             }
             var user = new CreateUserRequestModel
            {
                Email = admin.Email,
                PassWord =  BCrypt.Net.BCrypt.HashPassword(admin.PassWord),
                IsActive = true,
                Role = "Admin" 
            };
            var use = _userRepo.CreateUser(user);
             var rand = new Random();     
             
               var legitAdmin = new Admin {
                StaffId = "ZENITH-ADMIN-"+rand.Next(0, 9).ToString()+rand.Next(50, 99).ToString()+"-" +admin.FirstName[0]+admin.FirstName[1]+admin.FirstName[2]+rand.Next(0,9).ToString(),

                IsActive = true,
                FirstName = admin.FirstName,
                LastName = admin.LastName,
                Address = admin.Address,
                Age = DateTime.Now.Year - admin.DOB.Year,
                Gender = admin.Gender,
                MaritalStatus = admin.MaritalStatus,
                Email = admin.Email,
                PhoneNumber = admin.PhoneNumber,
                // PassWord = BCrypt.Net.BCrypt.HashPassword(admin.PassWord),
                DateCreated = DateTime.Now,
                UserId = use.Id,
                ManagerPass = admin.ManagerPass,
                ProfilePicture = admin.ProfilePicture
                
             };
           
              _repo.CreateAdmin(legitAdmin);  
             
             return admin; 
             
        }

        public AdminResponseModel DeleteAdminUsingId(string adminId)
        {
        

            var admin =   _repo.GetAdminById(adminId);
            _userRepo.DeleteUserUsingId(admin.UserId);
            admin.IsActive = false;
           var adminn = _repo.DeleteAdminUsingId(admin);
           return new AdminResponseModel{
                StaffId = admin.StaffId,
                FirstName = admin.FirstName,
                LastName = admin.LastName,
                Address = admin.Address,
                Age = admin.Age,
                Gender = admin.Gender,
                MaritalStatus = admin.MaritalStatus,
                Email = admin.Email,
                PhoneNumber = admin.PhoneNumber,
                // PassWord = admin.PassWord,
                DateCreated = admin.DateCreated,
                IsActive = admin.IsActive
           };
        }

        public AdminResponseModel GetAdminById(string adminId)
        {
            var admin = _repo.GetAdminById(adminId);
            return new AdminResponseModel {
                StaffId = admin.StaffId,
                FirstName = admin.FirstName,
                LastName = admin.LastName,
                Address = admin.Address,
                Age = admin.Age,
                Gender = admin.Gender,
                MaritalStatus = admin.MaritalStatus,
                Email = admin.Email,
                PhoneNumber = admin.PhoneNumber,
                // PassWord = admin.PassWord,
                DateCreated = admin.DateCreated,
                IsActive = admin.IsActive,
                ProfilePicture = admin.ProfilePicture

            };
        }

        public IList<AdminResponseModel> GetAllAdmin()
        {
            var admins = _repo.GetAllAdmin();
        
              return admins.Select(item => new AdminResponseModel{
                StaffId = item.StaffId,
                FirstName = item.FirstName,
                LastName = item.LastName,
                Address = item.Address,
                Age = item.Age,
                Gender = item.Gender,
                MaritalStatus = item.MaritalStatus,
                Email = item.Email,
                PhoneNumber = item.PhoneNumber,
                // PassWord = item.PassWord,
                DateCreated = item.DateCreated,
                IsActive = item.IsActive,
                ProfilePicture = item.ProfilePicture

              }).ToList();
           

        }
        public void UpdateAdmin(UpdateAdminRequestModel admin)
        { 
            
            var adminn = _repo.GetAdminById(admin.StaffId);
            if(adminn == null )
            {
                throw new DirectoryNotFoundException();
            }

            var user = new UpdateUserRequestModel();
            
                user.Email = admin.Email;
                if(admin.PassWord != null)
                {
                   user.PassWord =  BCrypt.Net.BCrypt.HashPassword(admin.PassWord);
                }
             _userRepo.UpdateUser(user,adminn.UserId);
            
            adminn.FirstName = admin.FirstName ?? adminn.FirstName;
            adminn.LastName = admin.LastName ?? adminn.LastName;
            adminn.Email = admin.Email ?? adminn.Email;
            // adminn.PassWord = admin.PassWord ?? adminn.PassWord;
            adminn.Age = admin.Age != adminn.Age? admin.Age : adminn.Age;
            adminn.Address = admin.Address ?? adminn.Address;
            adminn.MaritalStatus = admin.MaritalStatus;
            _repo.UpdateAdmin(adminn);
        }

         public IList<AdminResponseModel> GetAdmins(int adminPass)
         {
             var admins = _repo.GetAdmins(adminPass); 
             return admins.Select(item => new AdminResponseModel{
                 StaffId = item.StaffId,
                FirstName = item.FirstName,
                LastName = item.LastName,
                Address = item.Address,
                Age = item.Age,
                Gender = item.Gender,
                MaritalStatus = item.MaritalStatus,
                Email = item.Email,
                PhoneNumber = item.PhoneNumber,
                // PassWord = item.PassWord,
                DateCreated = item.DateCreated,
                IsActive = item.IsActive,
                ProfilePicture = item.ProfilePicture

             }).ToList();
         }

         public string NumberOfAdmin()
         {
            return _repo.NumberOfAdmin();
         }

           public AdminResponseModel GetAdminByEmail(string email)
         {
            var admin = _repo.GetAdminByEmail(email);
            return new AdminResponseModel{
                 StaffId = admin.StaffId,
                FirstName = admin.FirstName,
                LastName = admin.LastName,
                Address = admin.Address,
                Age = admin.Age,
                Gender = admin.Gender,
                MaritalStatus = admin.MaritalStatus,
                Email = admin.Email,
                PhoneNumber = admin.PhoneNumber,
                // PassWord = admin.PassWord,
                DateCreated = admin.DateCreated,
                IsActive = admin.IsActive,
                ProfilePicture = admin.ProfilePicture

            };
         }
         
    }
}