using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace UI.WebApi.Core.Controllers
{
    public class AccessController : ControllerBase
    {
        protected ClaimsPrincipal UserAuthenticated()
        {
            return User;
        }
    }
}
