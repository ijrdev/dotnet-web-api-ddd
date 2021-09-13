using Domain.Domain.Core.Exceptions;
using Domain.Domain.Core.Responses;
using Domain.Domain.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Net;
using Domain.Domain.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Domain.Domain.Core.Consts;
using System.Threading.Tasks;

namespace UI.WebApi.Core.Controllers
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
        public async Task<IActionResult> AddAccount([FromBody] Accounts account)
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

                long id = UserAuthenticated<long>(AutenticatedUser.Id);

                await _iAccountsService.AddAccount(id, account);

                return CustomResponse.Response(HttpStatusCode.OK, ResponseMessages.HTTP.OK);
            }
            catch(CustomException cex)
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