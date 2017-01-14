using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TodoTest.Core.Interfaces;
using TodoTest.Core.Model;

namespace TodoTest.Web.Controllers
{
    public class TodoController : ApiController
    {
        private readonly IRepository<TodoItem> _repository;

        public TodoController(IRepository<TodoItem> repository)
        {
            if (repository == null)
                throw new ArgumentNullException(nameof(repository));

            _repository = repository;
        }

        // GET: api/Todo
        public IEnumerable<TodoItem> Get()
        {
            return _repository.GetAll() ?? new TodoItem[] {};
        }

        // GET: api/Todo/5
        public HttpResponseMessage Get(int id)
        {
            var todo = _repository.FindById(id);
            return todo == null ? Request.CreateResponse(HttpStatusCode.NotFound) : Request.CreateResponse(HttpStatusCode.OK, todo);
        }

        // POST: api/Todo
        public HttpResponseMessage Post([FromBody]TodoItem value)
        {
            try
            {
                var saved = _repository.Add(value);
                return Request.CreateResponse(HttpStatusCode.Created, saved);
            }
            catch
            {
                return BadRequestResponse();
            }
        }

        // PUT: api/Todo/5
        public HttpResponseMessage Put(int id, [FromBody]TodoItem value)
        {
            if (id != value.TodoItemId)
            {
                return BadRequestResponse();
            }

            try
            {
                _repository.Update(value);

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch
            {
                return BadRequestResponse();
            }
        }

        // DELETE: api/Todo/5
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                _repository.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch
            {
                return BadRequestResponse();
            }
        }

        private HttpResponseMessage BadRequestResponse()
        {
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }
    }
}
