using Microsoft.EntityFrameworkCore;
using Todo.Core.Model;

namespace Todo.DataAccess
{
    public class TodoContext : DbContext
    {
        public DbSet<TodoItem> TodoItems { get; set; }
    }
}
