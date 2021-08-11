using Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
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
        public string Add()
        {
            _iClientsService.AddClient();

            return "Hello World";
        }

        [HttpPut]
        public string Put()
        {
            return "Hello World";
        }
    }
}