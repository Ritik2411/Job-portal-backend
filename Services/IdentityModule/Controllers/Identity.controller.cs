using System.Threading.Tasks;
using IdentityModule.models;
using IdentityModule.repository;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace IdentityModule.controller{
    [ApiController]
    [Route("api/[action]")]
    public class IdentityController : ControllerBase{
        public readonly IIdentity _identity;

        public IdentityController(IIdentity identity){
            _identity = identity;
        }

        [HttpPost]
        public async Task<IActionResult> register(RegisterModel registerModel){
            var result = await _identity.SignupAsync(registerModel);
            if(result.Succeeded){
                return Ok(result);
            }
            else{
                return Unauthorized(result);
            }
        }

        [HttpPost]
        public async Task<IActionResult> login([FromBody]LoginModel loginModel){
            var result = await _identity.LoginAsync(loginModel);
            var reponse_data = new ResponseModel(){
                msg = result
            };

            if(string.IsNullOrEmpty(result)){
                return Unauthorized();
            }
            else{
                return Ok(reponse_data);
            }
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword([FromBody]ChangePasswordModel changePasswordModel){
            await _identity.ChangePasswordAsync(changePasswordModel);
            return Ok(true);
        }

        [HttpGet]
        public async Task<IActionResult> getAllUsers(){
            var result = await _identity.GetAllUsersAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> getUsersById([FromRoute]string id){
            var result = await _identity.GetAllUsersByIdAsync(id);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> signOut(){
            await _identity.SignOutAsync();
            return Ok(true);
        }

        [HttpGet("{user}")]
        public async Task<IActionResult> getUserByUsername(string user){
            var result = await _identity.GetUserByUsernameAsync(user);
            return Ok(result);
        }

        [HttpDelete("{user}")]
        public async Task<IActionResult> deleteUser(string user){
            await _identity.deleteUserAsync(user);
            return Ok(true);
        }

        [HttpPut("{user_name}")]
        public async Task<IActionResult> updateUser([FromRoute]string user_name, [FromBody]UpdateProfileModel updateProfileModel){
            await _identity.updateUserAsync(user_name, updateProfileModel);    
            return Ok(true);
        }
    }
}