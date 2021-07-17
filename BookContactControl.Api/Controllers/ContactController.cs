using BookContactControl.Api.Models;
using BookContactControl.Domain.Models;
using BookContactControl.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace BookContactControl.Api.Controllers
{
    [RoutePrefix("api/v1/contact")]
    public class ContactController : ApiController
    {
        private IContactService _service;

        public ContactController(IContactService service)
        {
            _service = service;
        }

        // api/contact/insert - Put(Insert) (Content-Type: application/json)
        [Route("insert")]
        [HttpPut]
        public Task<HttpResponseMessage> Register(RegisterContactModel model) 
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                _service.Register(model.Email, model.Name, model.Phone);
                response = Request.CreateResponse(HttpStatusCode.OK, new { name = model.Name, phone = model.Phone });
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, "*** " + ex.Message);
            }

            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(response);
            return tsc.Task;
        }

        // api/contact/update - Post(Update) (Content-Type: application/json)
        [Route("update")]
        [HttpPost]
        [Authorize]
        public Task<HttpResponseMessage> Update(RegisterContactModel model)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                _service.ChangeInformation(model.Email, model.Name, model.Phone);
                response = Request.CreateResponse(HttpStatusCode.OK, new { name = model.Name, phone = model.Phone });
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }

            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(response);
            return tsc.Task;
        }


        // api/contact/list - Get(List) (Content-Type: application/json)
        [Route("list")]
        [HttpGet]
        [Authorize]
        public Task<HttpResponseMessage> List(RegisterContactModel model)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                _service.ChangeInformation(model.Email, model.Name, model.Phone);
                response = Request.CreateResponse(HttpStatusCode.OK, new { name = model.Name, phone = model.Phone });
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }

            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(response);
            return tsc.Task;
        }


        protected override void Dispose(bool disposing)
        {
            _service.Dispose();
        }
    }
}
