using CrossCutting;
using Domains.Helpers;
using Interfaces.Services.Clients;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using Domain = Domains.Clients;

namespace WebApi.Controllers.Clients
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientsController : DefaultController
    {
        private readonly IClientsService _iClientsService;

        public ClientsController(IClientsService iClientsService)
        {
            _iClientsService = iClientsService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                Domain.Clients client = _iClientsService.GetClient((long)1);

                return CustomResponse.Response(HttpStatusCode.OK, CustomResponseMessage.HTTP.OK, client);
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