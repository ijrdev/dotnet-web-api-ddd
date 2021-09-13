using Domain.Domain.Core.Consts;
using Domain.Domain.Core.DTO;
using Domain.Domain.Core.Exceptions;
using Domain.Domain.Core.Interfaces.Services;
using Domain.Domain.Core.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace UI.WebApi.Core.Controllers
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
        public async Task<IActionResult> Deposit([FromBody] DepositWithdrawTransactionsDTO depositWithdrawTransaction)
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

                await _iAccountsTransactionsService.Deposit(depositWithdrawTransaction);

                return CustomResponse.Response(HttpStatusCode.OK, ResponseMessages.HTTP.OK);
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

        [HttpPost("Withdraw")]
        [Authorize]
        public async Task<IActionResult> Withdraw([FromBody] DepositWithdrawTransactionsDTO depositWithdrawTransaction)
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

                await _iAccountsTransactionsService.Withdraw(id, depositWithdrawTransaction);

                return CustomResponse.Response(HttpStatusCode.OK, ResponseMessages.HTTP.OK);
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

        [HttpPost("Transfer")]
        [Authorize]
        public async Task<IActionResult> Transfer([FromBody] TransferTransactionsDTO transferTransaction)
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

                await _iAccountsTransactionsService.Transfer(id, transferTransaction);

                return CustomResponse.Response(HttpStatusCode.OK, ResponseMessages.HTTP.OK);
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

        [HttpGet("Statements")]
        [Authorize]
        public async Task<IActionResult> Statements()
        {
            try
            {
                long id = UserAuthenticated<long>(AutenticatedUser.Id);

                AccountsStatementsDTO accountStatements = await _iAccountsTransactionsService.GetStatements(id);

                return CustomResponse.Response(HttpStatusCode.OK, ResponseMessages.HTTP.OK, accountStatements);
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
