using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using Domain.Domain.Core.Interfaces.Services;
using Domain.Domain.Core.DTO;
using Domain.Domain.Core.Responses;
using Domain.Domain.Core.Exceptions;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using UI.WebApi.Core.Filters;

namespace UI.WebApi.Core.Controllers
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
        public IActionResult Login([FromBody] AuthInDTO authIn)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    IList<string> errors = new List<string>();

                    foreach (KeyValuePair<string, ModelStateEntry> state in ModelState)
                    {
                        foreach (ModelError error in state.Value.Errors)
                        {
                            errors.Add(error.ErrorMessage);
                        }
                    }

                    return CustomResponse.Response(HttpStatusCode.PreconditionFailed, ResponseMessages.HTTP.PRECONDITION_FAILED, new { errors });
                }

                AuthOutDTO authOut = _iAuthService.Login(authIn);

                return CustomResponse.Response(HttpStatusCode.OK, ResponseMessages.HTTP.OK, authOut);
            }
            catch (CustomException cex)
            {
                return CustomResponse.Response(cex.Status, cex.Msg, cex.Info);
            }
            catch (Exception)
            {
                return CustomResponse.Response(HttpStatusCode.InternalServerError, ResponseMessages.HTTP.INTERNAL_SERVER_ERROR);
            }
        }
    }
}
