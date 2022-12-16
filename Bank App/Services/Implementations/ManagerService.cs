using Bank_App.Repositories.Interfaces;
using Bank_App.Services.Interfaces;
using MVC_MobileBankApp.Models;

namespace Bank_App.Services.Implementations
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
        public Manager CreateManager(Manager manager)
        {
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
             manager.UserId = use.Id;
             manager.IsActive = true;
             return  _repo.CreateManager(manager);  
        }

        public Manager DeleteManager(string managerId)
        {

              var manager = _repo.GetManagerById(managerId);
               _userRepo.DeleteUserUsingId(manager.UserId);
               manager.IsActive = false;
              return _repo.DeleteManager(manager);
        }

        public IList<Manager> GetAllManager()
        {
             return _repo.GetAllManager();
        }

        public Manager GetManagerById(string managerId)
        {
            return _repo.GetManagerById(managerId);
        }

        public Manager Login(string email, string passWord)
        {
             var manager = _repo.Login(email,passWord);
             return manager;
        }

        public Manager UpdateManager(Manager manager)
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
            return _repo.UpdateManager(managerr);
        }
    }
}