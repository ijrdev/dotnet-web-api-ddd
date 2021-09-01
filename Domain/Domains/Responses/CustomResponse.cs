using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace Domain.Domain.Core.Responses
{
    public static class CustomResponse
    {
        public static IActionResult Response(HttpStatusCode statusCode, string message, dynamic data = null)
        {
            ObjectResult result = new ObjectResult(
                new
                {
                    statusCode,
                    message,
                    data,
                    currentDate = DateTime.Now
                }
            );

            result.StatusCode = (int) statusCode;

            return result;
        }
    }
}
