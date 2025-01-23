using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Common.ViewModels;
using Model.Models;

namespace WebAPI.Controllers
{
    public class DoctorController : ApiController
    {
        public IHttpActionResult GetAll(int count = 10, int page = 0, string searchText = null)
        {

        }

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
    }
}
