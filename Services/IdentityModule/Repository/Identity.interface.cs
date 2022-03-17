using System.Collections.Generic;
using System.Threading.Tasks;
using IdentityModule.models;
using Microsoft.AspNetCore.Identity;

namespace IdentityModule.repository{
    public interface IIdentity{
        Task<IdentityResult> SignupAsync(RegisterModel registerModel);
        Task<string> LoginAsync(LoginModel loginModel);
        Task ChangePasswordAsync(ChangePasswordModel ChangePasswordModel);
        Task<List<IdentityModel>> GetAllUsersAsync();

        Task<IdentityModel> GetAllUsersByIdAsync(string id);
        Task SignOutAsync();
        Task<IdentityModel> GetUserByUsernameAsync(string Username);
        Task deleteUserAsync(string userName);
    }
}