using TodoList.Domain;
using TodoList.Enums;

namespace TodoList.DTOs.Task
{
    public class TaskCreateModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public long UserId { get; set; }
    }
}
