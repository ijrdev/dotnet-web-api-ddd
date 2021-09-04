using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;

namespace UI.WebApi.Core.Controllers
{
    public class AccessController : ControllerBase
    {
        protected ClaimsPrincipal UserAuthenticated()
        {
            return User;
        }

        protected T UserAuthenticated<T>(string claimType)
        {
            ClaimsPrincipal userAuthenticated = UserAuthenticated();

            return (T) Convert.ChangeType(userAuthenticated.FindFirstValue(claimType), typeof(T));
        }
    }
}
