using Common.Global.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Common.Global.API.Middlewares
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";

                switch (error)
                {
                    case ValidationException e:
                        var validationData = new
                        {
                            errors = e.Errors
                        };
                        var validationDataJson = JsonSerializer.Serialize(validationData);
                        await response.WriteAsync(validationDataJson);
                        break;
                    case CustomException e:
                        response.StatusCode = 420;
                        var customData = new
                        {
                            code = e.Code
                        };
                        var customDataJson = JsonSerializer.Serialize(customData);
                        await response.WriteAsync(customDataJson);
                        break;
                    default:
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }

            }
        }
    }
}
