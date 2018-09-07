using Dontwaste.Api.Data.ViewModel;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace DontWaste.Api.Business.Contracts
{
    public interface IBusinessEngine
    {
        Task<object> Login(LoginModel model);
        bool UserExists(string UserEmail);
        Task<object> Register(RegisterModel model);
        Task<object> GenerateJwtToken(string email, IdentityUser user);
    }
}
