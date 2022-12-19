using Bank_App.Models.RequestModel;
using MVC_MobileBankApp.Models;

namespace MVC_MobileBankApp.Services.Interfaces
{
    public interface IAdminService
    {
       Admin CreateAdmin (AdminRequestModel admin);
       Admin UpdateAdmin (AdminUpdateRequestModel admin);
       Admin DeleteAdminUsingId(string adminId);
       Admin Login (string email, string passWord);
       Admin GetAdminById(string adminId);
       IList<Admin> GetAllAdmin();
         
    }
}