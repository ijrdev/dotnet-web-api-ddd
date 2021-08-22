using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace Domain.Responses
{
    public static class CustomResponse
    {
        public static IActionResult Response(HttpStatusCode statusCode, string message, object data = null)
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
