// using MVC_MobileBankApp.Models;
// using MVC_MobileBankApp.Models.DTOs;
using MVC_MobileBankApp.Models.DTOs.ManagerDto;

namespace MVC_MobileBankApp.Services.Interfaces
{
    public interface IManagerService
    {
        CreateManagerRequestModel CreateManager (CreateManagerRequestModel manager);
        void UpdateManager (UpdateManagerRequestModel manager);
        ManagerResponseModel DeleteManager(string managerId);
        ManagerResponseModel Code(int code);
        ManagerResponseModel GetManagerById(string managerId);
        IList<ManagerResponseModel> GetAllManager();
        string NumberOfManager();
        ManagerResponseModel GetManagerByEmail(string email);
         
    }
}