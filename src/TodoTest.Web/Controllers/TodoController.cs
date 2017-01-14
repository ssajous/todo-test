using System;
using System.Collections.Generic;
using System.Web.Http;
using TodoTest.Core.Interfaces;
using TodoTest.Core.Model;

namespace TodoTest.Web.Controllers
{
    public class TodoController : ApiController
    {
        private readonly IRepository<ToDoItem> _repository;

        public TodoController(IRepository<ToDoItem> repository)
        {
            if (repository == null)
                throw new ArgumentNullException(nameof(repository));

            _repository = repository;
        }

        // GET: api/Todo
        public IEnumerable<ToDoItem> Get()
        {
            return _repository.GetAll() ?? new ToDoItem[] {};
        }

        // GET: api/Todo/5
        public ToDoItem Get(int id)
        {
            return _repository.FindById(id);
        }

        // POST: api/Todo
        public void Post([FromBody]string value)
        {
            var todo = new ToDoItem
            {
                Title = value
            };
            _repository.Add(todo);
        }

        // PUT: api/Todo/5
        public void Put(int id, [FromBody]ToDoItem value)
        {
            _repository.Update(value);
        }

        // DELETE: api/Todo/5
        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
