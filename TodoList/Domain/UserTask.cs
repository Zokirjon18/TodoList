using TodoList.Constants;
using TodoList.Enums;
using TodoList.Helpers;

namespace TodoList.Domain;

public class UserTask : BaseEntity
{
    public UserTask() 
    {
        Id = GeneratorHelper.GenerateId<UserTask>(PathHolder.Task);
    }

    public string Title { get; set; }
    public string Description { get; set; }
    public Status IsCompleted { get; set; } = Status.Any;
    public int CategoryId { get; set; }
    public long UserId { get; set; }
}
