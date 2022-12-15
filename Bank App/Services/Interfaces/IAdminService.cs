using MVC_MobileBankApp.Models;

namespace MVC_MobileBankApp.Services.Interfaces
{
    public interface IAdminService
    {
       Admin CreateAdmin (Admin admin);
       Admin UpdateAdmin (Admin admin);
       void DeleteAdminUsingId(string adminId);
       Admin Login (string email, string passWord);
       Admin GetAdminById(string adminId);
       IList<Admin> GetAllAdmin();
         
    }
}