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

        [HttpPost]
        public IActionResult Add([FromBody] Domain.Clients client)
        {
            try
            {
                _iClientsService.AddClient(client);

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

        [HttpPut("{id:int}")]
        public IActionResult Put(long id, [FromBody] Domain.Clients client)
        {
            try
            {
                _iClientsService.UpdateClient(id, client);

                return CustomResponse.Response(HttpStatusCode.OK, CustomResponseMessage.OK);
            }
            catch (CustomException cex)
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