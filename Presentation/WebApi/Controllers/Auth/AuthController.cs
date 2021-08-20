using Microsoft.AspNetCore.Mvc;
using CrossCutting;
using System;
using System.Net;
using Interfaces.Services.Auth;
using Domains.DTO;

namespace WebApi.Controllers.Auth
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : DefaultController
    {
        private readonly IAuthService _iAuthService;

        public AuthController(IAuthService iAuthService)
        {
            _iAuthService = iAuthService;
        }

        [HttpPost]
        public IActionResult Login([FromBody] AuthDTO auth)
        {
            try
            {
                AuthClientDTO authClient = _iAuthService.Login(auth);

                return CustomResponse.Response(HttpStatusCode.OK, CustomResponseMessage.HTTP.OK, authClient);
            }
            catch (CustomException cex)
            {
                return CustomResponse.Response(cex.Status, cex.Msg, cex.Info);
            }
            catch (Exception)
            {
                return CustomResponse.Response(HttpStatusCode.InternalServerError, CustomResponseMessage.HTTP.INTERNAL_SERVER_ERROR);
            }
        }
    }
}
