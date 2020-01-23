using jwtAuthDotNet.Models;
using jwtAuthDotNet.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace jwtAuthDotNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController: ControllerBase
    {

        private readonly IAuthenticateService _authService;

        public AuthenticateController(IAuthenticateService authService)
        {
            _authService = authService;
        }

        [AllowAnonymous]
        [Route("request")]
        [HttpPost]
        public ActionResult RequestToken([FromBody] TokenRequest request){
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }

            string token;
            if(_authService.IsAuthenticated(request, out token)){
                return Ok(token);
            }

            return BadRequest("Invalid Request");
        }
    }
}