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

            var category = categories.FirstOrDefault(category => category.Id == model.CategoryId)
                ?? throw new NotFoundException($"Category was not found with this ID{model.CategoryId}!");

            if (string.IsNullOrWhiteSpace(model.Title))
            {
                throw new ArgumentNotValid("Title cannot be null or empty!");
            }

            tasks.Add(model.Map());
            FileHelper.WriteToFile(PathHolder.Task, tasks);
        }

        public void Update(int id, TaskUpdateModel model)
        {
            List<UserTask> tasks = FileHelper.ReadFromFile<UserTask>(PathHolder.Task);

            List<TaskCategory> categories = FileHelper.ReadFromFile<TaskCategory>(PathHolder.Category);

            var taskForUpdation = tasks.Find(task => task.Id == id)
                ?? throw new NotFoundException($"Task was not found with this ID >>> {id}!");

            var category = categories.FirstOrDefault(category => category.Id == model.CategoryId)
                ?? throw new NotFoundException($"Category was not found with this ID {model.CategoryId}!");

            if (string.IsNullOrWhiteSpace(model.Title))
            {
                throw new ArgumentNotValid("Title cannot be null or empty!");
            }

            taskForUpdation.Map(model);

            FileHelper.WriteToFile(PathHolder.Task, tasks);
        }

        public void Delete(int id)
        {
            List<UserTask> tasks = FileHelper.ReadFromFile<UserTask>(PathHolder.Task);

            UserTask taskForDeletion = tasks.FirstOrDefault(task => task.Id == id)
                ?? throw new NotFoundException($"task was not found on ID >>> {id}");

            tasks.Remove(taskForDeletion);

            FileHelper.WriteToFile(PathHolder.Task, tasks);
        }

        public TaskViewModel Get(int id)
        {
            List<UserTask> tasks = FileHelper.ReadFromFile<UserTask>(PathHolder.Task);

            UserTask task = tasks.FirstOrDefault(task => task.Id == id)
                ?? throw new NotFoundException($"task was not found on ID >>> {id}");

            return task.Map();
        }

        public List<UserTask> GetAll(string? search, Status isCompleted = Status.Any)
        {
            throw new NotImplementedException();
        }


    }
}
