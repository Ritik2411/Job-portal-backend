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
        public IdentityRepository(UserManager<IdentityModel> user, SignInManager<IdentityModel> signInManager, IConfiguration configuration){
            _user = user;
            _signmanager = signInManager;
            _configuration = configuration;
        }

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

        public async Task<string> LoginAsync(LoginModel loginModel){
            var result = await _signmanager.PasswordSignInAsync(loginModel.Email, loginModel.password, false, false);

            if(!result.Succeeded){
                return null;
            }
            else{
                var authClaims = new List<Claim>{
                    new Claim(ClaimTypes.Name, loginModel.Email),
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

        public async Task ChangePasswordAsync(ChangePasswordModel ChangePasswordModel){
            var result = await _user.FindByEmailAsync(ChangePasswordModel.Email);
            if(result != null){
                await _user.ChangePasswordAsync(result, ChangePasswordModel.current_password,ChangePasswordModel.password);
            }    
        }

        public async Task<List<IdentityModel>> GetAllUsersAsync(){
            var result = await _user.Users.ToListAsync();
            return result;
        }

        public async Task<IdentityModel> GetAllUsersByIdAsync(string id){
            var result = await _user.FindByIdAsync(id);
            return result;
        }
    }
}