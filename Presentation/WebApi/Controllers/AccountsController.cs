using Domain.Exceptions;
using Domain.Responses;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Net;
using Domain.Entities;
using System.Security.Claims;
using Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Domain.Consts;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountsController : AccessController
    {
        private readonly IAccountsService _iAccountsService;

        public AccountsController(IAccountsService iAccountsService)
        {
            _iAccountsService = iAccountsService;
        }

        [HttpPost]
        [Authorize]
        public IActionResult AddAccount([FromBody] Accounts account)
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

                    return CustomResponse.Response(HttpStatusCode.PreconditionFailed, CustomResponseMessage.HTTP.PRECONDITION_FAILED, new { errors });
                }

                ClaimsPrincipal userAuthenticated = UserAuthenticated();

                string id = userAuthenticated.FindFirstValue(AutenticatedUser.Id);

                _iAccountsService.AddAccount(Convert.ToInt64(id), account);

                return CustomResponse.Response(HttpStatusCode.OK, CustomResponseMessage.HTTP.OK);
            }
            catch(CustomException cex)
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