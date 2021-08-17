using CrossCutting;
using Domains.DTO;
using Domains.Helpers;
using Interfaces.Services.Accounts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using Domain = Domains.Accounts;

namespace WebApi.Controllers.Accounts
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountsController : DefaultController
    {
        private readonly IAccountsService _iAccountsService;

        public AccountsController(IAccountsService iAccountsService)
        {
            _iAccountsService = iAccountsService;
        }

        [HttpPost]
        public IActionResult Add([FromBody] ClientAccountDTO clientAccount)
        {
            try
            { // COLOCAR ISSO EM UM MIDDLEWARE??
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

                    return CustomResponse.Response(HttpStatusCode.PreconditionFailed, CustomResponseMessage.PRECONDITION_FAILED, errors);
                }

                _iAccountsService.AddAccount(clientAccount);

                return CustomResponse.Response(HttpStatusCode.OK, CustomResponseMessage.OK);
            }
            catch(CustomException cex)
            {
                return CustomResponse.Response(cex.Status, cex.Msg, cex.Info);
            }
            catch (Exception)
            {
                return CustomResponse.Response(HttpStatusCode.InternalServerError, CustomResponseMessage.INTERNAL_SERVER_ERROR);
            }
        }
    }
}