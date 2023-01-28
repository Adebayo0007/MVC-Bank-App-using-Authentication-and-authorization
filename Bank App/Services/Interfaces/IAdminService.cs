using MVC_MobileBankApp.Models;
using MVC_MobileBankApp.Models.DTOs;

namespace MVC_MobileBankApp.Services.Interfaces
{
    public interface IAdminService
    {
       Admin CreateAdmin (AdminDTO admin);
       void UpdateAdmin (AdminRequestModel admin);
       Admin DeleteAdminUsingId(string adminId);
       Admin Login (string email, string passWord);
       AdminRequestModel GetAdminById(string adminId);
       IList<Admin> GetAllAdmin();
        IList<Admin> GetAdmins(int adminPass);
         
    }
}