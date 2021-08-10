using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientsController : DefaultController
    {
        [HttpGet]
        public IEnumerable Get()
        {
            return new Enumerable();
        }
    }
}