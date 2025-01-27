using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Common.ViewModels;
using Logic.BLL;
using Model.Models;
using System.Web.Http.Cors;

namespace WebAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class PatientController : ApiController
    {

        

            [HttpGet]

            public IHttpActionResult GetAll(int count = 10, int page = 0, string searchText = null)
            {
                var response = new ResponseVMR<PagedListVMR<PatientVMR>>();

                try
                {
                    response.data = PatientBLL.GetAll(count, page, searchText);
                }
                catch (Exception e)
                {
                    response.code = HttpStatusCode.InternalServerError;
                    response.data = null;
                    response.mesages.Add(e.Message);
                    response.mesages.Add(e.ToString());
                }

                return Content(response.code, response);

            }

            [HttpGet]
            public IHttpActionResult GetById(long id)
            {
                var response = new ResponseVMR<PatientVMR>();

                try
                {
                    response.data = PatientBLL.GetById(id);
                }
                catch (Exception e)
                {
                    response.code = HttpStatusCode.InternalServerError;
                    response.data = null;
                    response.mesages.Add(e.Message);
                    response.mesages.Add(e.ToString());
                }

                if (response.data == null && response.mesages.Count() == 0)
                {
                    response.code = HttpStatusCode.NotFound;
                    response.mesages.Add("Item not found");
                }

                return Content(response.code, response);
            }

            [HttpPost]
            public IHttpActionResult Create(Patient item)
            {

                var response = new ResponseVMR<long?>();

                try
                {
                    response.data = PatientBLL.Create(item);
                }
                catch (Exception e)
                {
                    response.code = HttpStatusCode.InternalServerError;
                    response.data = null;
                    response.mesages.Add(e.Message);
                    response.mesages.Add(e.ToString());
                }

                return Content(response.code, response);

            }


            [HttpPut]
            public IHttpActionResult Update(long id, PatientVMR item)
            {
                var response = new ResponseVMR<bool>();

                try
                {
                    item.id = id;
                    PatientBLL.Update(item);
                    response.data = true;
                }
                catch (Exception e)
                {
                    response.code = HttpStatusCode.InternalServerError;
                    response.data = false;
                    response.mesages.Add(e.Message);
                    response.mesages.Add(e.ToString());
                }

                return Content(response.code, response);

            }

            [HttpDelete]
            public IHttpActionResult Delete(List<long> ids)
            {
                var response = new ResponseVMR<bool>();

                try
                {
                    PatientBLL.Delete(ids);
                    response.data = true;
                }
                catch (Exception e)
                {
                    response.code = HttpStatusCode.InternalServerError;
                    response.data = false;
                    response.mesages.Add(e.Message);
                    response.mesages.Add(e.ToString());
                }

                return Content(response.code, response);
            }

        
    }
}
