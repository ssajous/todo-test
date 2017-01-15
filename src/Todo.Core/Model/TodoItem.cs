namespace Todo.Core.Model
{
    public class TodoItem
    {
        public int TodoItemId { get; set; }

        public string Title { get; set; }

        public bool IsCompleted { get; set; }
    }
}