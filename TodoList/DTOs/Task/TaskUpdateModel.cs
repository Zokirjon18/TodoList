namespace TodoList.DTOs.Task
{
    public class TaskUpdateModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
    }
}
