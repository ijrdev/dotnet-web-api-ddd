using Microsoft.AspNetCore.Mvc;
using UI.WebApi.Core.Filters;

namespace UI.WebApi.Core.Controllers
{
    [LogFilter]
    abstract public class DefaultController : ControllerBase
    {
        
    }
}