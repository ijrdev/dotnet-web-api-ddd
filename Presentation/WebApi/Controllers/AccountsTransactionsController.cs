using Domain.DTO;
using Domain.Enums;
using Domain.Exceptions;
using Domain.Interfaces.Services;
using Domain.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Net;
using System.Security.Claims;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountsTransactionsController : AccessController
    {
        private readonly IAccountsTransactionsService _iAccountsTransactionsService;

        public AccountsTransactionsController(IAccountsTransactionsService iAccountsTransactionsService)
        {
            _iAccountsTransactionsService = iAccountsTransactionsService;
        }

        [HttpPost("Deposit")]
        [Authorize]
        public IActionResult Deposit([FromBody] DepositWithdrawTransactionsDTO depositWithdrawTransaction)
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

                _iAccountsTransactionsService.Deposit(depositWithdrawTransaction);

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

        [HttpPost("Withdraw")]
        [Authorize]
        public IActionResult Withdraw([FromBody] DepositWithdrawTransactionsDTO depositWithdrawTransaction)
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

                string id = userAuthenticated.FindFirstValue(CustomClaimsType.Id.ToString());

                _iAccountsTransactionsService.Withdraw(Convert.ToInt64(id), depositWithdrawTransaction);

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

        [HttpPost("Transfer")]
        [Authorize]
        public IActionResult Transfer([FromBody] TransferTransactionsDTO transferTransaction)
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

                string id = userAuthenticated.FindFirstValue(CustomClaimsType.Id.ToString());

                _iAccountsTransactionsService.Transfer(Convert.ToInt64(id), transferTransaction);

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
