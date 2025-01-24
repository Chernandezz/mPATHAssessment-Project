using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Common.ViewModels;
using Logic.BLL;
using Model.Models;

namespace WebAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class DoctorController : ApiController
    {

        [HttpGet]

        public IHttpActionResult GetAll(int count = 10, int page = 0, string searchText = null)
        {
            var response = new ResponseVMR<PagedListVMR<DoctorVMR>>();

            try
            {
                response.data = DoctorBLL.GetAll(count, page, searchText);
            }
            catch(Exception e)
            { 
                response.code = HttpStatusCode.InternalServerError;
                response.data = null;
                response.mesages.Add(e.Message);
                response.mesages.Add(e.ToString());
            }

            return Content(response.code, response);

        }
        /*

        public IHttpActionResult GetById(long id)
        {

        }

        public IHttpActionResult Create(Doctor item)
        {

        }
        public IHttpActionResult Update(long id, DoctorVMR item)
        {

        }
        public IHttpActionResult Delete(List<long> ids)
        {

        }
        */
    }
}
