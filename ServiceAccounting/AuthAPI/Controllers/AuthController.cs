using System;
using API.AuthServices;
using API.BaseModels;
using Application.Exceptions;
using Application.User.CrudOperation;
using Application.User.Login;
using Application.User.Registration;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Threading.Tasks;
using API.Models;
using EFData.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ILoginHandler loginHandler;
        private readonly IRegistrationHandler registrationHandler;
        private readonly IMapper mapper;
        private readonly ICrudHandler crud;
        private readonly IConfiguration configuration;

        public AuthController(ILoginHandler loginHandler, IRegistrationHandler registrationHandler, IMapper mapper, ICrudHandler crud, IConfiguration configuration)
        {
            this.loginHandler = loginHandler;
            this.registrationHandler = registrationHandler;
            this.mapper = mapper;
            this.crud = crud;
            this.configuration = configuration;
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<ActionResult<string>> LoginAsync([FromBody] LoginQuery request)
        {
            if (request is null)
                throw new RestException(HttpStatusCode.BadRequest, $"{nameof(LoginQuery)} is null");

            var user = await loginHandler.Login(request);

            if (user is null)
                throw new RestException(HttpStatusCode.Unauthorized, $"{nameof(user)} is null");

            var isSuccessed = await crud.CreateSession(HttpContext, user);

            if (!isSuccessed)
                throw new RestException(HttpStatusCode.Conflict, $"Can't append Session as {nameof(Sessions.SessionUser)}");

            var jwtToken = $"{JwtBearerDefaults.AuthenticationScheme}" + " " + $"{user.Token}";

            return new JsonResult(new { Response = "Success", Token = jwtToken, user.Email, user.Role });
        }

        [AllowAnonymous]
        [HttpPost("RegistrationUser")]
        public async Task<ActionResult<string>> RegistrationUserAsync([FromBody] RegistrationUserQuery request)
        {
            if (request is null)
                throw new RestException(HttpStatusCode.BadRequest, $"{nameof(RegistrationUserQuery)} is null");

            var registrationQuery = mapper.Map<RegistrationQuery>(request);

            var user = await registrationHandler.Registration(registrationQuery);

            if (user is null)
                throw new RestException(HttpStatusCode.Unauthorized, $"{nameof(user)} is null");

            var jwtToken = $"{JwtBearerDefaults.AuthenticationScheme}" + " " + $"{user.Token}";

            var isSuccessed = await crud.CreateSession(HttpContext, user);

            if (!isSuccessed)
                throw new RestException(HttpStatusCode.Conflict, $"Can't append Session as {nameof(Sessions.SessionUser)}");

            var responseEntity = await crud.CreateEntity(registrationQuery, jwtToken, mapper, configuration);

            if (responseEntity is null)
                throw new RestException(HttpStatusCode.Conflict, "Request is not valid, can not create Entity");

            return new JsonResult(new { Response = responseEntity, Token = jwtToken, request.Email, Role = Roles.User.ToString() });
        }

        [Authorize(Policy = PolicyAuth.Admin)]
        [HttpPost("Registration")]
        public async Task<ActionResult<string>> RegistrationAsync([FromBody] RegistrationQuery request)
        {
            if (request is null)
                throw new RestException(HttpStatusCode.BadRequest, $"{nameof(RegistrationQuery)} is null");

            var jwtToken = HttpContext.Request.Headers[$"{ nameof(Authorization)}"];

            if (string.IsNullOrEmpty(jwtToken))
                throw new RestException(HttpStatusCode.Unauthorized, $"{nameof(User)} do not have necessary token");

            var user = await registrationHandler.Registration(request);

            if (user is null)
                throw new RestException(HttpStatusCode.Unauthorized, $"{nameof(User)} is null");

            var responseEntity = await crud.CreateEntity(request, jwtToken, mapper, configuration);

            if (responseEntity is null)
                throw new RestException(HttpStatusCode.Conflict, "Request is not valid, can not create Entity");

            return new JsonResult(new { Response = responseEntity });
        }

        [AllowAnonymous]
        [HttpGet("Logout")]
        public async Task<ActionResult<string>> Logout()
        {
            var session = HttpContext.Session;

            if (session.IsAvailable)
                session.Remove(Sessions.SessionUser.ToString());

            await Task.CompletedTask;

            return new JsonResult(new { Response = HttpStatusCode.OK });
        }

        [Authorize(Policy = PolicyAuth.Admin)]
        [HttpPost("DeleteUserByEmail")]
        public async Task<ActionResult<string>> DeleteUserByEmail([FromBody] AcceptDeleteUserByEmail acceptDeleteUserByEmail)
        {
            if (acceptDeleteUserByEmail is null)
                throw new NullReferenceException();

            await crud.DeleteUser(acceptDeleteUserByEmail.Email);

            return new JsonResult("Delete In Auth");
        }
    }
}