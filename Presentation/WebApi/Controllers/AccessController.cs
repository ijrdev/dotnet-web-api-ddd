using Microsoft.AspNetCore.Mvc;
using System.Security.Principal;

namespace WebApi.Controllers
{
    public class AccessController : ControllerBase
    {
        protected IIdentity UserAuthenticated()
        {
            return User.Identity;
        }
    }
}
