using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using IdentityModule.models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace IdentityModule.repository{
    public class IdentityRepository : IIdentity{
        private readonly UserManager<IdentityModel> _user;
        private readonly SignInManager<IdentityModel> _signmanager;
        private readonly IConfiguration _configuration;

        //Initiates the userManager, signinManager from the identity core with all of inbuilt their methods. 
        public IdentityRepository(UserManager<IdentityModel> user, SignInManager<IdentityModel> signInManager, IConfiguration configuration){
            _user = user;
            _signmanager = signInManager;
            _configuration = configuration;
        }

        //Adds a new user
        public async Task<IdentityResult> SignupAsync(RegisterModel registerModel){
            var identity = new IdentityModel(){
                UserName = registerModel.userName,
                firstName = registerModel.firstName,
                lastName = registerModel.lastName,
                Email = registerModel.Email,
                role = registerModel.Role
            };

            return await _user.CreateAsync(identity, registerModel.password);
        }

        //Logs in the user and generate a unique token to identity the user.
        public async Task<string> LoginAsync(LoginModel loginModel){
            var result = await _signmanager.PasswordSignInAsync(loginModel.Username, loginModel.password, false, false);

            if(!result.Succeeded){
                return null;
            }
            else{
                var authClaims = new List<Claim>{
                    new Claim(ClaimTypes.Name, loginModel.Username),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

                var authSigninKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["JWT:Secret"]));

                var token = new JwtSecurityToken(
                    issuer: _configuration["JWT:ValidIssuer"],
                    audience: _configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddDays(1),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigninKey, SecurityAlgorithms.HmacSha256Signature)
                );  
 
                return new JwtSecurityTokenHandler().WriteToken(token);
            }
        }

        //Used to change password for a particular user account with their email, cuurrent and new password to br set. 
        public async Task ChangePasswordAsync(ChangePasswordModel ChangePasswordModel){
            var result = await _user.FindByEmailAsync(ChangePasswordModel.Email);
            if(result != null){
                await _user.ChangePasswordAsync(result, ChangePasswordModel.current_password,ChangePasswordModel.password);
            }    
        }

        //Give list of all registered user.
        public async Task<List<IdentityModel>> GetAllUsersAsync(){
            var result = await _user.Users.ToListAsync();
            return result;
        }

        //Gives data about particular user by their userId.
        public async Task<IdentityModel> GetAllUsersByIdAsync(string id){
            var result = await _user.FindByIdAsync(id);
            return result;
        }

        //Give data about particular user by their user name.
        public async Task<IdentityModel> GetUserByUsernameAsync(string userName){
            var result = await _user.FindByNameAsync(userName);
            return result;
        }

        //Deletes a user by username.
        public async Task deleteUserAsync(string userName){
            var data = await _user.FindByNameAsync(userName);

            if(data != null){
                await _user.DeleteAsync(data);
            }
        }

        //Updates first and last name of user based on user name.
        public async Task updateUserAsync(string username, UpdateProfileModel updateProfileModel){
            var data = await _user.FindByNameAsync(username);

            if(data != null){
                data.firstName = updateProfileModel.first_name;
                data.lastName = updateProfileModel.last_name;
            }

            await _user.UpdateAsync(data);
        }

        //Logs out the user and destroys their session.    
        public async Task SignOutAsync(){
            await _signmanager.SignOutAsync();
        }
    }
}