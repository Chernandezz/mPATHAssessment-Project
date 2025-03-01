﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http.Cors;
using System.Web.Http;
using Common.ViewModels;
using Logic.BLL;
using Model.Models;

namespace WebAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class AdmissionController : ApiController
    {
        [HttpGet]

        public IHttpActionResult GetAll(int count = 10, int page = 0, string searchText = null)
        {
            var response = new ResponseVMR<PagedListVMR<AdmissionVMR>>();

            try
            {
                response.data = AdmissionBLL.GetAll(count, page, searchText);
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
            var response = new ResponseVMR<AdmissionVMR>();

            try
            {
                response.data = AdmissionBLL.GetById(id);
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
        public IHttpActionResult Create(Admission item)
        {

            var response = new ResponseVMR<long?>();

            try
            {
                response.data = AdmissionBLL.Create(item);
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
        public IHttpActionResult Update(long id, AdmissionVMR item)
        {
            var response = new ResponseVMR<bool>();

            try
            {
                item.id = id;
                AdmissionBLL.Update(item);
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
        /*
        [HttpDelete]
        public IHttpActionResult Delete(List<long> ids)
        {
            var response = new ResponseVMR<bool>();

            try
            {
                DoctorBLL.Delete(ids);
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
        }*/
    }
}
