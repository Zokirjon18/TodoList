using TodoList.Domain;

namespace TodoList.Services.Category
{
    public interface ICategoryService
    {
        void Create(long chatId,string name);
        void Update(int id,long chatId,string name);
        void Delete(int id, long chatId);
        TaskCategory Get(int id, long chatId);
        List<TaskCategory> GetList(long chatId);
    }
}
