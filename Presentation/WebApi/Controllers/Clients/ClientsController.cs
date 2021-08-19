using CrossCutting;
using Domains.DTO;
using Domains.Helpers;
using Interfaces.Services.Clients;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;

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

        [HttpPost]
        public IActionResult Add([FromBody] AccountClientDTO accountClient)
        {
            try
            {
                //_iClientsService.Add(clientAccount);

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