using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Todo.Core.Interfaces;
using Todo.Core.Model;

namespace Todo.DataAccess
{
    public class TodoRepository : IRepository<TodoItem>
    {
        private readonly TodoContext _context;

        public TodoRepository(TodoContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            _context = context;
        }

        public IEnumerable<TodoItem> GetAll()
        {
            return _context.TodoItems;
        }

        public TodoItem Add(TodoItem item)
        {
            _context.TodoItems.Add(item);
            _context.SaveChanges();

            return item;
        }

        public void Update(TodoItem item)
        {
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public TodoItem FindById(int id)
        {
            return _context.TodoItems.FirstOrDefault(t => t.TodoItemId == id);
        }

        public void Delete(int id)
        {
            var todo = new TodoItem { TodoItemId = id };
            _context.Entry(todo).State = EntityState.Deleted;
            _context.SaveChanges();
        }
    }
}
