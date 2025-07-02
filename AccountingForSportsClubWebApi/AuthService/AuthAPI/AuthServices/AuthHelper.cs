using System;
using System.IO;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using API.BaseModels;
using API.Models;
using Application.User;
using Application.User.CrudOperation;
using Application.User.Registration;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http;
using Microsoft.Extensions.Configuration;

namespace API.AuthServices
{
    public static class AuthHelper
    {
        public static async Task<bool> CreateSession(this ICrudHandler crud ,HttpContext context, User user) 
        {
            context.Session.SetString(Sessions.SessionUser.ToString(), JsonSerializer.Serialize(user));
            var item = context.Session.GetString(Sessions.SessionUser.ToString());

            if (!string.IsNullOrEmpty(item)) 
                return true;

            await crud.DeleteUser(user.Email);

            return false;
        }

        public static async Task<string> CreateEntity(this ICrudHandler crud, RegistrationQuery request, string token, IMapper mapper, IConfiguration configuration)
        {
            var httpRequest = (HttpWebRequest)WebRequest.Create(configuration.GetSection("AnotherService:ServiceAccounting").Get<string>() + $"/{request.Role}/{CrudOperation.Create}");
            httpRequest.Method = HttpMethod.Post.ToString();
            httpRequest.ContentType = ContentTypeApplication.ApplicationJson;
            httpRequest.Headers.Add($"{nameof(Authorization)}", token);

            await using (var requestStream = httpRequest.GetRequestStream())
            await using (var writer = new StreamWriter(requestStream))
            {
                await writer.WriteAsync(JsonSerializer.Serialize(mapper.Map<RegistrationEntity>(request)));
            }

            try
            {
                using var httpResponse = httpRequest.GetResponse();
                await using var responseStream = httpResponse.GetResponseStream();
                using var reader = new StreamReader(responseStream ?? throw new InvalidOperationException());
                return  await reader.ReadToEndAsync();
            }
            catch
            {
                await crud.DeleteUser(request.Email);
                return null;
            }
        }
    }
}
