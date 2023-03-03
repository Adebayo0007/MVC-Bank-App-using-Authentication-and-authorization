using MVC_MobileBankApp.Models;
using MVC_MobileBankApp.Models.DTOs;
using MVC_MobileBankApp.Models.DTOs.UserDto;

namespace MVC_MobileBankApp.Services.Interfaces
{
    public interface IUserService
    {
        UpdateUserRequestModel UpdateUser(UpdateUserRequestModel user,int userId);
        UserResponseModel DeleteUserUsingId(int userId);
        CreateUserRequestModel CreateUser(CreateUserRequestModel user);
        UserResponseModel Login(string email,string passWord);
        bool GetUserByEmail(string email);
        IList<UserResponseModel> GetAllUser();
        string NumberOfUsers();
    }
}