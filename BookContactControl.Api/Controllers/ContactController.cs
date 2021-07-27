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
        [Authorize]
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
                response = Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }

            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(response);
            return tsc.Task;
        }

        // api/contact/update - Post(Update) (Content-Type: application/json)
        [Route("update")]
        [HttpPost]
        [Authorize]
        public Task<HttpResponseMessage> Update(ChangeInformationModel model)
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
        [HttpPost]
        [Authorize]
        public Task<HttpResponseMessage> GetContacts(ListContactsModel model)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                var contacts =  _service.GetContacts(model.Order, model.Skip, model.Take);

                object[] contactsList = new object[contacts.Count];
                for (var c = 0; c < contacts.Count; c++)
                {
                    contactsList[c] = new { name = contacts[c].Name, email = contacts[c].Email, phone = contacts[c].Phone };
                }

                response = Request.CreateResponse(HttpStatusCode.OK, contactsList);
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
