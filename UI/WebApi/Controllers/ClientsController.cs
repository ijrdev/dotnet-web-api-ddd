﻿using Domain.Domain.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using Domain.Domain.Core.Exceptions;
using Domain.Domain.Core.Responses;
using Domain.Domain.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using Domain.Domain.Core.Consts;

namespace UI.WebApi.Core.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientsController : AccessController
    {
        private readonly IClientsService _iClientsService;

        public ClientsController(IClientsService iClientsService)
        {
            _iClientsService = iClientsService;
        }

        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            try
            {
                ClaimsPrincipal userAuthenticated = UserAuthenticated();
                
                string id = userAuthenticated.FindFirstValue(AutenticatedUser.Id);

                Clients client = _iClientsService.GetClient(Convert.ToInt64(id));

                return CustomResponse.Response(HttpStatusCode.OK, CustomResponseMessage.HTTP.OK, new { client });
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

        [HttpPost]
        public IActionResult Post([FromBody] Clients client)
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

                _iClientsService.AddClient(client);

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

        [HttpPut("{id:long}")]
        [Authorize]
        public IActionResult Put(long id, [FromBody] Clients client)
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

                string userId = userAuthenticated.FindFirstValue(AutenticatedUser.Id);

                long userIdConverted = Convert.ToInt64(userId);

                if (id != userIdConverted)
                {
                    return CustomResponse.Response(HttpStatusCode.Forbidden, CustomResponseMessage.HTTP.FORBIDDEN);
                }

                client.Id = userIdConverted;

                _iClientsService.UpdateClient(client);

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