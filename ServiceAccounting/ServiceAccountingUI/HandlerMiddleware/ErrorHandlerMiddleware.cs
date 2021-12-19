using System;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;

namespace ServiceAccountingUI.HandlerMiddleware
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IHostEnvironment _environment;

        public ErrorHandlerMiddleware(RequestDelegate next, IHostEnvironment environment)
        {
            _next = next;
            _environment = environment;
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
                    case UserNotFoundException or
                     RoleNotFoundException _:
                        // not found error
                        response.StatusCode = (int)HttpStatusCode.NotFound;

                        var result = JsonSerializer.Serialize(new
                        {
                            message = error?.Message,
                            details = _environment.IsDevelopment() ? error?.StackTrace : null,
                            developerMessages = _environment.IsDevelopment() ? GetAllMessages(error) : null,
                        });

                        await response.WriteAsync(result);
                        break;

                    default:
                        // unhandled error
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;

                        var result2 = JsonSerializer.Serialize(new
                        {
                            message = error?.Message,
                        });

                        await response.WriteAsync(result2);

                        break;
                }
            }
        }

        private static IEnumerable<string> GetAllMessages(Exception exception)
        {
            var current = exception;
            var messages = new List<string>();

            do
            {
                messages.Add(exception.Message);
                current = current.InnerException;
            } while (current?.InnerException != null);

            return messages;
        }
    }

    public class RoleNotFoundException : Exception
    {
    }

    public class UserNotFoundException : Exception
    {
    }
}
