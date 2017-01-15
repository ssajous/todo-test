using Microsoft.EntityFrameworkCore;
using Todo.Core.Model;

namespace Todo.DataAccess
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<TodoItem> TodoItems { get; set; }
    }
}
