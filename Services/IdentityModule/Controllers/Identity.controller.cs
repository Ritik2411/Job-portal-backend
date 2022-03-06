using System.Threading.Tasks;
using IdentityModule.models;
using IdentityModule.repository;
using Microsoft.AspNetCore.Mvc;

namespace IdentityModule.controller{
    [ApiController]
    [Route("[action]")]
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
            if(string.IsNullOrEmpty(result)){
                return Unauthorized();
            }
            else{
                return Ok(result);
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
        public async Task<IActionResult> getAllUsersById([FromRoute]string id){
            var result = await _identity.GetAllUsersByIdAsync(id);
            return Ok(result);
        }
    }
}