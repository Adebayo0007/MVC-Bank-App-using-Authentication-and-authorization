using MVC_MobileBankApp.Models.DTOs;
using MVC_MobileBankApp.Models;
using MVC_MobileBankApp.Repositories;
using MVC_MobileBankApp.Services.Interfaces;

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
        public AdminDTO CreateAdmin(AdminDTO admin)
        {
             var Age = DateTime.Now.Year - admin.DOB.Year;
              
              if(Age < 18)
             {
                admin.Message = $"Manager under 18 Years old are not allowed in this Application";
                return admin;
             }
             var user = new User
            {
                Email = admin.Email,
                PassWord = admin.PassWord,
                IsActive = true,
                Role = "Admin" 
            };
            var use = _userRepo.CreateUser(user);
             var rand = new Random();
             admin.StaffId = "ZENITH-ADMIN-"+rand.Next(0, 9).ToString()+rand.Next(50, 99).ToString()+"-" +admin.FirstName[0]+admin.FirstName[1]+admin.FirstName[2]+rand.Next(0,9).ToString();
             admin.UserId = use.Id;
             admin.IsActive = true;     
             
               var legitAdmin = new Admin {
                StaffId = admin.StaffId,
                IsActive = admin.IsActive,
                FirstName = admin.FirstName,
                LastName = admin.LastName,
                Address = admin.Address,
                Age = DateTime.Now.Year - admin.DOB.Year,
                Gender = admin.Gender,
                MaritalStatus = admin.MaritalStatus,
                Email = admin.Email,
                PhoneNumber = admin.PhoneNumber,
                PassWord = admin.PassWord,
                DateCreated = admin.DateCreated,
                UserId = use.Id,
                ManagerPass = admin.ManagerPass,
                ProfilePicture = admin.ProfilePicture
                
             };
           
             _repo.CreateAdmin(legitAdmin);  
             
             return admin; 
             
        }

        public AdminRequestModel DeleteAdminUsingId(string adminId)
        {
            // var obj = _repo.DeleteAdminUsingId(adminId.StaffId);
            var admin = _repo.GetAdminById(adminId);
            _userRepo.DeleteUserUsingId(admin.UserId);
            admin.IsActive = false;
           var adminn = _repo.DeleteAdminUsingId(admin);
           return new AdminRequestModel{
                StaffId = admin.StaffId,
                FirstName = admin.FirstName,
                LastName = admin.LastName,
                Address = admin.Address,
                Age = admin.Age,
                Gender = admin.Gender,
                MaritalStatus = admin.MaritalStatus,
                Email = admin.Email,
                PhoneNumber = admin.PhoneNumber,
                PassWord = admin.PassWord,
                DateCreated = admin.DateCreated,
                IsActive = admin.IsActive
           };
        }

        public AdminRequestModel GetAdminById(string adminId)
        {
            var admin = _repo.GetAdminById(adminId);
            return new AdminRequestModel {
                StaffId = admin.StaffId,
                FirstName = admin.FirstName,
                LastName = admin.LastName,
                Address = admin.Address,
                Age = admin.Age,
                Gender = admin.Gender,
                MaritalStatus = admin.MaritalStatus,
                Email = admin.Email,
                PhoneNumber = admin.PhoneNumber,
                PassWord = admin.PassWord,
                DateCreated = admin.DateCreated,
                IsActive = admin.IsActive,
                ProfilePicture = admin.ProfilePicture

            };
        }

        public IList<Admin> GetAllAdmin()
        {
            return _repo.GetAllAdmin();
        }

        public Admin Login(string email, string passWord)
        {
              return _repo.Login(email,passWord);
        }

        public void UpdateAdmin(AdminRequestModel admin)
        { 
            
            var adminn = _repo.GetAdminById(admin.StaffId);
            if(adminn == null )
            {
                throw new DirectoryNotFoundException();
            }

             var user = new User
            {
                Email = admin.Email,
                PassWord = admin.PassWord
            
            };
            _userRepo.UpdateUser(user,adminn.UserId);
            
            adminn.FirstName = admin.FirstName ?? adminn.FirstName;
            adminn.LastName = admin.LastName ?? adminn.LastName;
            adminn.Email = admin.Email ?? adminn.Email;
            adminn.PassWord = admin.PassWord ?? adminn.PassWord;
            adminn.Age = admin.Age != adminn.Age? admin.Age : adminn.Age;
            adminn.Address = admin.Address ?? adminn.Address;
            adminn.MaritalStatus = admin.MaritalStatus;
            _repo.UpdateAdmin(adminn);
        }

         public IList<Admin> GetAdmins(int adminPass)
         {
             return _repo.GetAdmins(adminPass);  
         }

         public  string NumberOfAdmin()
         {
            return _repo.NumberOfAdmin();
         }

           public Admin  GetAdminByEmail(string email)
         {
            return _repo.GetAdminByEmail(email);
         }

       
    }
}