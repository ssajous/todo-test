using System.Data.Entity;
using TodoTest.Core.Model;

namespace TodoTest.DataAccess
{
    public class TodoContext : DbContext
    {
        public DbSet<ToDoItem> TodoItems { get; set; }
    }
}
