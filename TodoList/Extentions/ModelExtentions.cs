using TodoList.Domain;
using TodoList.DTOs.Task;

namespace TodoList.Extentions;

public static class ModelExtentions
{
    public static UserTask Map(this TaskCreateModel model)
    {
        return new UserTask
        {
            Title = model.Title,
            Description = model.Description,
            CategoryId = model.CategoryId,
            UserId = model.UserId,
        };
    }

    public static void Map(this UserTask model, TaskUpdateModel updateModel)
    {
        model.Title = model.Title;
        model.Description = model.Description;
        model.CategoryId = model.CategoryId;
    }
}
