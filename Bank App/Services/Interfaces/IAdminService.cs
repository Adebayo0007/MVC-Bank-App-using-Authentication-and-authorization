using MVC_MobileBankApp.Models;
using MVC_MobileBankApp.Models.DTOs;

namespace MVC_MobileBankApp.Services.Interfaces
{
    public interface IAdminService
    {
       AdminDTO CreateAdmin (AdminDTO admin);
       void UpdateAdmin (AdminRequestModel admin);
       AdminRequestModel DeleteAdminUsingId(string adminId);
       AdminRequestModel GetAdminById(string adminId);
       IList<Admin> GetAllAdmin();
        string NumberOfAdmin();
        IList<Admin> GetAdmins(int adminPass);
        Admin  GetAdminByEmail(string email);
         
    }
}