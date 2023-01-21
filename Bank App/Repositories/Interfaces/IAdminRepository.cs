using MVC_MobileBankApp.Models;
using MVC_MobileBankApp.Models.DTOs;

namespace MVC_MobileBankApp.Repositories
{
    public interface IAdminRepository
    {
       Admin CreateAdmin (Admin admin);
       Admin UpdateAdmin (Admin admin);
       Admin DeleteAdminUsingId(Admin admin);
       Admin Login (string email, string passWord);
       Admin GetAdminById(string staffId);
       IList<Admin> GetAllAdmin();
         
    }
}