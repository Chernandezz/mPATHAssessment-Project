using System;
using System.Net;
using System.Web.Http;
using Common.ViewModels;
using Common.Helpers;
using Logic.BLL;

namespace WebAPI.Controllers
{
    [RoutePrefix("api/auth")]
    public class AuthController : ApiController
    {
        [HttpPost]
        [Route("login")]
        public IHttpActionResult Login(string email, string password)
        {
            var response = new ResponseVMR<AuthVMR>();

            try
            {
                var passwordHash = Utils.EncryptPassword(password);
                var user = AuthBLL.Login(email, passwordHash);

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
