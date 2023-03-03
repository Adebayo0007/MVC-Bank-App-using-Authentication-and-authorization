// using Bank_App.Models.DTOs.CEODto;
using MVC_MobileBankApp.Models;
using MVC_MobileBankApp.Models.DTOs.CEODto;
using MVC_MobileBankApp.Models.DTOs.UserDto;
using MVC_MobileBankApp.Repositories;
using MVC_MobileBankApp.Services.Interfaces;

namespace MVC_MobileBankApp.Services.Implementations
{
    public class CEOService : ICEOService
    {
         private readonly ICEORepository _repo;
          private readonly IUserService _userRepo;

        public CEOService(ICEORepository repo,IUserService userRepo)
        {
            _repo = repo;
            _userRepo = userRepo;
        }
        public CreateCeoRequestModel CreateCEO(CreateCeoRequestModel ceo)
        {
              var Age = DateTime.Now.Year - ceo.DOB.Year;
              
              if(Age < 18)
             {
                ceo.Message = $"Manager under 18 Years old are not allowed in this Application";
                return ceo;
             }

              var user = new CreateUserRequestModel
            {
                Email = ceo.Email,
                PassWord = BCrypt.Net.BCrypt.HashPassword(ceo.PassWord),
                IsActive = true,
                Role = "CEO"
            };
            var use = _userRepo.CreateUser(user);
           
             var rand = new Random(); 
             
               var legitCeo = new CEO {
                CEOId = "ZENITH-CEO-"+rand.Next(0, 9).ToString()+rand.Next(50, 99).ToString()+"-" +ceo.FirstName[0]+ceo.FirstName[1]+ceo.FirstName[2]+rand.Next(0,9).ToString(),
                IsActive = true,
                FirstName = ceo.FirstName,
                LastName = ceo.LastName,
                Address = ceo.Address,
                Age = DateTime.Now.Year - ceo.DOB.Year,
                Gender = ceo.Gender,
                MaritalStatus = ceo.MaritalStatus,
                Email = ceo.Email,
                PhoneNumber = ceo.PhoneNumber,
                // PassWord = BCrypt.Net.BCrypt.HashPassword(admin.PassWord),
                DateCreated = DateTime.Now,
                UserId = use.Id
                
             };
           
              _repo.CreateCEO(legitCeo);  
             
             return ceo; 
        }

        // public CEO DeleteCEO(string ceoId)
        // {
        //     var ceo = _repo.GetCEOById(ceoId);
        //     _userRepo.DeleteUserUsingId(ceo.UserId);
        //     ceo.IsActive = false;
        //    return _repo.DeleteCEO(ceo);
        // }

        // public IList<CEO> GetAllCEO()
        // {
        //    return _repo.GetAllCEO();
        // }

        // public CEO GetCEOById(string ceoId)
        // {
        //     return _repo.GetCEOById(ceoId);
        // }

        // public CEO UpdateCEO(CEO ceo)
        // {
        //        var ceoo = _repo.GetCEOById(ceo.CEOId);
        //     if(ceoo == null )
        //     {
        //         throw new DirectoryNotFoundException();
        //     }
        //       var user = new User
        //     {
        //         Email = ceo.Email,
        //         PassWord = ceo.PassWord
            
        //     };
        //     _userRepo.UpdateUser(user,ceoo.UserId);
            
        //     ceoo.FirstName = ceo.FirstName ?? ceoo.FirstName;
        //     ceoo.LastName = ceo.LastName ?? ceoo.LastName;
        //     ceoo.Email = ceo.Email ?? ceoo.Email;
        //     // ceoo.PassWord = ceo.PassWord ?? ceoo.PassWord;
        //     ceoo.Age = ceo.Age != ceoo.Age? ceo.Age : ceoo.Age;
        //     ceoo.Address = ceo.Address ?? ceoo.Address;
        //     ceoo.MaritalStatus = ceo.MaritalStatus;
        //     return  _repo.UpdateCEO(ceoo);
        // }
    }
}