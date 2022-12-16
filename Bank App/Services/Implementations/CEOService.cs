using Bank_App.Models;
using Bank_App.Repositories.Interfaces;
using Bank_App.Services.Interfaces;
using MVC_MobileBankApp.Models;
using MVC_MobileBankApp.Repositories;

namespace Bank_App.Services.Implementations
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
        public CEO CreateCEO(CEO ceo)
        {
              var user = new User
            {
                Email = ceo.Email,
                PassWord = ceo.PassWord,
                IsActive = true,
                Role = "CEO"
            };
            var use = _userRepo.CreateUser(user);
             var rand = new Random();
             ceo.CEOId= "ZENITH-CEO-"+rand.Next(0, 9).ToString()+rand.Next(50, 99).ToString()+"-" +ceo.FirstName[0]+ceo.FirstName[1]+ceo.FirstName[2]+rand.Next(0,9).ToString();
             ceo.UserId = use.Id;
             ceo.IsActive = true;
             return  _repo.CreateCEO(ceo); 
        }

        public CEO DeleteCEO(string ceoId)
        {
            var ceo = _repo.GetCEOById(ceoId);
            _userRepo.DeleteUserUsingId(ceo.UserId);
            ceo.IsActive = false;
           return _repo.DeleteCEO(ceo);
        }

        public IList<CEO> GetAllCEO()
        {
           return _repo.GetAllCEO();
        }

        public CEO GetCEOById(string ceoId)
        {
            return _repo.GetCEOById(ceoId);
        }

        public CEO Login(string email, string passWord)
        {
            return _repo.Login(email,passWord);
        }

        public CEO UpdateCEO(CEO ceo)
        {
               var ceoo = _repo.GetCEOById(ceo.CEOId);
            if(ceoo == null )
            {
                throw new DirectoryNotFoundException();
            }
              var user = new User
            {
                Email = ceo.Email,
                PassWord = ceo.PassWord
            
            };
            _userRepo.UpdateUser(user,ceoo.UserId);
            
            ceoo.FirstName = ceo.FirstName ?? ceoo.FirstName;
            ceoo.LastName = ceo.LastName ?? ceoo.LastName;
            ceoo.Email = ceo.Email ?? ceoo.Email;
            ceoo.PassWord = ceo.PassWord ?? ceoo.PassWord;
            ceoo.Age = ceo.Age != ceoo.Age? ceo.Age : ceoo.Age;
            ceoo.Address = ceo.Address ?? ceoo.Address;
            ceoo.MaritalStatus = ceo.MaritalStatus;
            return _repo.UpdateCEO(ceoo);
        }
    }
}