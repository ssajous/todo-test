using System.ComponentModel.DataAnnotations;

namespace TodoTest.Core.Model
{
    public class TodoItem
    {
        [Key]
        public int TodoItemId { get; set; }

        public string Title { get; set; }

        public bool isCompleted { get; set; }
    }
}
