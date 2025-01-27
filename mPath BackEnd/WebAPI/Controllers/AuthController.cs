using System;
using System.Net;
using System.Web.Http;
using Common.ViewModels;
using Common.Helpers;
using Logic.BLL;
using System.Web.Http.Cors;

namespace WebAPI.Controllers
{
    [RoutePrefix("api/auth")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class AuthController : ApiController
    {
        [HttpPost]
        [Route("login")]
        public IHttpActionResult Login([FromBody] LoginRequest loginRequest)
        {
            var response = new ResponseVMR<AuthVMR>();

            try
            {
                var passwordHash = Utils.EncryptPassword(loginRequest.Password);
                var user = AuthBLL.Login(loginRequest.Email, passwordHash);

                if (user == null)
                {
                    response.code = HttpStatusCode.Unauthorized;
                    response.mesages.Add("Invalid credentials");
                    return Content(response.code, response);
                }

                response.data = user;
            }
            catch (Exception e)
            {
                response.code = HttpStatusCode.InternalServerError;
                response.mesages.Add(e.Message);
            }

            return Content(response.code, response);
        }

        public class LoginRequest
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }
        [HttpPost]
        [Route("register")]
        public IHttpActionResult Register(string email, string password, string role)
        {
            var response = new ResponseVMR<bool>();

            try
            {
                var success = AuthBLL.Register(email, password, role);

                if (!success)
                {
                    response.code = HttpStatusCode.BadRequest;
                    response.mesages.Add("User already exists");
                    return Content(response.code, response);
                }

                response.data = true;
            }
            catch (Exception e)
            {
                response.code = HttpStatusCode.InternalServerError;
                response.mesages.Add(e.Message);
            }

            return Content(response.code, response);
        }
    }
}
