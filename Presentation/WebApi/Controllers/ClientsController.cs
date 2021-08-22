using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using Domain.Exceptions;
using Domain.Responses;
using Domain.Entities;

namespace WebApi.Controllers
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
        public IActionResult Get()
        {
            try
            {
                // pegar pelo usuário loado o id.
                Clients client = _iClientsService.GetClient((long)1);

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

        [HttpPut("{id:long}")]
        public IActionResult Put(long id, [FromBody] Clients client)
        {
            try
            {
                // pegar pelo usuario logado ou comprar...
                _iClientsService.UpdateClient(id, client);

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