using CrossCutting;
using Domains.DTO;
using Domains.Helpers;
using Interfaces.Services.Accounts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
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
        public IActionResult Add([FromBody] AccountClientDTO accountClient)
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

                    return CustomResponse.Response(HttpStatusCode.PreconditionFailed, CustomResponseMessage.HTTP.PRECONDITION_FAILED, errors);
                }

                _iAccountsService.AddAccount(accountClient);

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

        [HttpDelete]
        public IActionResult Delete([FromBody] AccountClientDTO accountClient)
        {
            try
            {
                return CustomResponse.Response(HttpStatusCode.OK, CustomResponseMessage.HTTP.OK);
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