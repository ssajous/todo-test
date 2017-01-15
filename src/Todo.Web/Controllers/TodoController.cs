using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Todo.Core.Interfaces;
using Todo.Core.Model;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Todo.Web.Controllers
{
    [Route("api/[controller]")]
    public class TodoController : Controller
    {
        private readonly IRepository<TodoItem> _repository;

        public TodoController(IRepository<TodoItem> repository)
        {
            if (repository == null)
                throw new ArgumentNullException(nameof(repository));

            _repository = repository;
        }

        // GET: api/todo
        [HttpGet]
        public IEnumerable<TodoItem> Get()
        {
            return _repository.GetAll();
        }

        // GET api/todo/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var todo = _repository.FindById(id);
            return todo == null ? NotFound() as IActionResult : new ObjectResult(todo);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]TodoItem value)
        {
            try
            {
                var saved = _repository.Add(value);
                return Created($"{Request.Path}/{saved.TodoItemId}", saved);
            }
            catch
            {
                return BadRequest();
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]TodoItem value)
        {
            if (id != value.TodoItemId)
            {
                return BadRequest("Id in the URL must match the todoItemId in the JSON object");
            }

            try
            {
                _repository.Update(value);

                return Ok(value);
            }
            catch
            {
                return BadRequest();
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _repository.Delete(id);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
