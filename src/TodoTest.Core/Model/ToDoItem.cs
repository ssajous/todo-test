using System.ComponentModel.DataAnnotations;

namespace TodoTest.Core.Model
{
    public class ToDoItem
    {
        [Key]
        public int TodoItemId { get; set; }

        public string Title { get; set; }

        public bool isCompleted { get; set; }
    }
}
