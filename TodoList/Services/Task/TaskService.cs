using TodoList.Constants;
using TodoList.Domain;
using TodoList.DTOs.Task;
using TodoList.Enums;
using TodoList.Exceptions;
using TodoList.Extentions;
using TodoList.Helpers;

namespace TodoList.Services.Task
{
    public class TaskService : ITaskService
    {
        public void Create(TaskCreateModel model)
        {
            List<UserTask> tasks = FileHelper.ReadFromFile<UserTask>(PathHolder.Task);

            List<TaskCategory> categories = FileHelper.ReadFromFile<TaskCategory>(PathHolder.Category);

            var category = categories.FirstOrDefault(category => category.Id == model.CategoryId && category.UserId == model.UserId)
                ?? throw new NotFoundException($"Category was not found with this ID{model.CategoryId} for the user{model.UserId}!");

            if (string.IsNullOrWhiteSpace(model.Title))
            {
                throw new ArgumentNotValid("Title cannot be null or empty!");
            }

            tasks.Add(model.Map());
            FileHelper.WriteToFile(PathHolder.Task, tasks);
        }

        public void Update(int id,long chatId, TaskUpdateModel model)
        {
            List<UserTask> tasks = FileHelper.ReadFromFile<UserTask>(PathHolder.Task);

            List<TaskCategory> categories = FileHelper.ReadFromFile<TaskCategory>(PathHolder.Category);

            var taskForUpdation = tasks.Find(task => task.Id == id)
                ?? throw new NotFoundException($"Task was not found with this ID >>> {id}!");

            var category = categories.FirstOrDefault(category => category.Id == model.CategoryId 
                 && category.UserId == chatId)
                    ?? throw new NotFoundException($"" +
                        $"Category was not found with this ID{model.CategoryId} for the user{chatId}!");

            if (string.IsNullOrWhiteSpace(model.Title))
            {
                throw new ArgumentNotValid("Title cannot be null or empty!");
            }

            taskForUpdation.Map(model);

            FileHelper.WriteToFile(PathHolder.Task, tasks);
        }

        public void Delete(int id, long chatId)
        {
            List<UserTask> tasks = FileHelper.ReadFromFile<UserTask>(PathHolder.Task);



        }

        public UserTask Get(int id, long chatId)
        {
            throw new NotImplementedException();
        }

        public List<UserTask> GetAll(string? search, Status isCompleted = Status.Any)
        {
            throw new NotImplementedException();
        }


    }
}
