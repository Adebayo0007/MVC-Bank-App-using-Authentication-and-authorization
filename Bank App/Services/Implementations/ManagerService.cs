using Bank_App.Repositories.Interfaces;
using Bank_App.Services.Interfaces;
using MVC_MobileBankApp.Models;

namespace Bank_App.Services.Implementations
{
    public class ManagerService : IManagerService
    {
        private readonly IManagerRepository _repo;

        public ManagerService(IManagerRepository repo)
        {
            _repo = repo;
        }
        public Manager CreateManager(Manager manager)
        {
            //   var user = new User
            // {
            //     Email = manager.Email,
            //     PassWord = manager.PassWord
            // };
            var rand = new Random();
             manager.ManagerId = "ZENITH-MANAGER-"+rand.Next(0, 9).ToString()+rand.Next(50, 99).ToString()+"-" +manager.FirstName[0]+manager.FirstName[1]+manager.FirstName[2]+rand.Next(0,9).ToString();
             return  _repo.CreateManager(manager);  
        }

        public void DeleteManagerUsingId(string managerId)
        {
              var manager = _repo.GetManagerById(managerId);
           _repo.DeleteManagerUsingId(manager);
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
             return _repo.Login(email,passWord);
        }

        public Manager UpdateManager(Manager manager)
        {
               var managerr = _repo.GetManagerById(manager.ManagerId);
            if(managerr == null )
            {
                throw new DirectoryNotFoundException();
            }
            
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