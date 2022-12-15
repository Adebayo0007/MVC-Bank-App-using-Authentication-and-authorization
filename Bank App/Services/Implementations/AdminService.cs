using Bank_App.Repositories.Interfaces;
using MVC_MobileBankApp.Models;
using MVC_MobileBankApp.Repositories;
using MVC_MobileBankApp.Services.Interfaces;

namespace MVC_MobileBankApp.Services.Implementations
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _repo;
         private readonly IUserRepository _userRepo;

        public AdminService(IAdminRepository repo,IUserRepository userRepo)
        {
            _repo = repo;
            _userRepo = userRepo;
        }
        public Admin CreateAdmin(Admin admin)
        {
            //  var user = new User
            // {
            //     Email = admin.Email,
            //     PassWord = admin.PassWord
            
            // };
            // _userRepo.CreateUser(user);
             var rand = new Random();
             admin.StaffId = "ZENITH-ADMIN-"+rand.Next(0, 9).ToString()+rand.Next(50, 99).ToString()+"-" +admin.FirstName[0]+admin.FirstName[1]+admin.FirstName[2]+rand.Next(0,9).ToString();
             return  _repo.CreateAdmin(admin);  
        }

        public void DeleteAdminUsingId(string adminId)
        {
            // var obj = _repo.DeleteAdminUsingId(adminId.StaffId);
            var admin = _repo.GetAdminById(adminId);
           _repo.DeleteAdminUsingId(admin);
        }

        public Admin GetAdminById(string adminId)
        {
            return _repo.GetAdminById(adminId);
        }

        public IList<Admin> GetAllAdmin()
        {
            return _repo.GetAllAdmin();
        }

        public Admin Login(string email, string passWord)
        {
              return _repo.Login(email,passWord);
        }

        public Admin UpdateAdmin(Admin admin)
        { 
            
            var adminn = _repo.GetAdminById(admin.StaffId);
            if(adminn == null )
            {
                throw new DirectoryNotFoundException();
            }
            
            adminn.FirstName = admin.FirstName ?? adminn.FirstName;
            adminn.LastName = admin.LastName ?? adminn.LastName;
            adminn.Email = admin.Email ?? adminn.Email;
            adminn.PassWord = admin.PassWord ?? adminn.PassWord;
            adminn.Age = admin.Age != adminn.Age? admin.Age : adminn.Age;
            adminn.Address = admin.Address ?? adminn.Address;
            adminn.MaritalStatus = admin.MaritalStatus;
            return _repo.UpdateAdmin(adminn);
        }
    }
}