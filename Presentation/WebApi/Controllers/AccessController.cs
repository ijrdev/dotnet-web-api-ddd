using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WebApi.Controllers
{
    public class AccessController : ControllerBase
    {
        protected ClaimsPrincipal UserAuthenticated()
        {
            return User;
        }
    }
}
