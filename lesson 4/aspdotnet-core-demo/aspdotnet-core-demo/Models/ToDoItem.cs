namespace aspdotnet_core_demo.Models
{
    public class ToDoItem
    {
        public ToDoItem(string title, string description)
        {
            Title = title;
            Description = description;
            Id = new Random().Next();
            IsDone = false;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsDone { get; set; }
    }
}

