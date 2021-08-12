using CrossCutting;
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
        public IActionResult Add()
        {
            try
            {
                _iClientsService.AddClient();

                return CustomResponse.Response(HttpStatusCode.OK, "Hello World", new { });
            }
            catch(CustomException cex)
            {
                return CustomResponse.Response(cex.Status, cex.Msg, cex.Info);
            }
            catch (Exception)
            {
                return CustomResponse.Response(HttpStatusCode.InternalServerError, "Internal Server Error");
            }
        }

        [HttpPut]
        public string Put()
        {
            return "Hello World";
        }
    }
}