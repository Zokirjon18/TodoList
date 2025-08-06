using TodoList.Constants;
using TodoList.Domain;
using TodoList.DTOs.Task;
using TodoList.Helpers;

namespace TodoList.Extentions;

public static class ModelMappingExtentions
{
#region
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

    public static TaskViewModel Map(this UserTask model)
    {
        List<TaskCategory> categories = FileHelper.ReadFromFile<TaskCategory>(PathHolder.Category);

        string categoryName = categories.FirstOrDefault(category => category.Id == model.CategoryId).Name;

        return new TaskViewModel
        {
            Title = model.Title,
            Description = model.Description,
            CategoryName = categoryName,
        };
    }
# endregion

}
