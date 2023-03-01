using MVC_MobileBankApp.Models;
using MVC_MobileBankApp.Models.DTOs;
using MVC_MobileBankApp.Models.DTOs.AdminDto;

namespace MVC_MobileBankApp.Services.Interfaces
{
    public interface IAdminService
    {
       CreateAdminRequestModel CreateAdmin (CreateAdminRequestModel admin);
       void UpdateAdmin (UpdateAdminRequestModel admin);
      AdminResponseModel DeleteAdminUsingId(string adminId);
       AdminResponseModel GetAdminById(string adminId);
       IList<AdminResponseModel> GetAllAdmin();
        string NumberOfAdmin();
        IList<AdminResponseModel> GetAdmins(int adminPass);
        AdminResponseModel  GetAdminByEmail(string email);
         
    }
}