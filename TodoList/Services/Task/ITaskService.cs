using TodoList.Domain;
using TodoList.DTOs.Task;
using TodoList.Enums;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TodoList.Services.Task
{
    public interface ITaskService
    {
        void Create(TaskCreateModel model);
        void Update(int Id,long userId,TaskUpdateModel model);
        void Delete(int id,long chatId);
        UserTask Get(int id,long chatId);
        List<UserTask> GetAll(string? search, Status isCompleted = Status.Any)
;
    }
}
