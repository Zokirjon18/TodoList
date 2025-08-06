using TodoList.Constants;
using TodoList.Helpers;

namespace TodoList.Domain;

public class TaskCategory : BaseEntity
{
    public TaskCategory()
    {
        Id = GeneratorHelper.GenerateId<TaskCategory>(PathHolder.Task);
    }

    public string Name { get; set; }
    public long UserId { get; set; }
}
