using TodoList.Constants;
using TodoList.Domain;
using TodoList.Exceptions;
using TodoList.Helpers;

namespace TodoList.Services.Category
{
    public class CategoryService : ICategoryService
    {
        public void Create(long chatId, string name)
        {
            var categories = FileHelper.ReadFromFile<TaskCategory>(PathHolder.Category);

            TaskCategory? category = categories.FirstOrDefault(c => c.Name == name && c.UserId == chatId);  

            if (category != null)
            {
                throw new AlreadyExistException("Category with this name already exists!");
            }

            categories.Add(new TaskCategory
            {
                Name = name,
                UserId = chatId
            });
             
            FileHelper.WriteToFile(PathHolder.Category, categories);
        }

        public void Update(int id, long chatId, string name)
        {
            var categories = FileHelper.ReadFromFile<TaskCategory>(PathHolder.Category);

            TaskCategory? categoryForUpdation = categories.FirstOrDefault(c => c.Id == id && c.UserId == chatId)
                ?? throw new NotFoundException($"Category with this ID {id} was not found!");

            TaskCategory? forChecking = categories.FirstOrDefault(c => c.Name == name && c.UserId == chatId);

            if(forChecking != null)
            {
                throw new AlreadyExistException($"Category with this ID {id} already exists!");
            }

            categoryForUpdation.Name = name;

            FileHelper.WriteToFile(PathHolder.Category, categories);
        }

        public void Delete(int id, long chatId)
        {
            var categories = FileHelper.ReadFromFile<TaskCategory>(PathHolder.Category);

            TaskCategory? categoryForDeletion = categories.FirstOrDefault(c => c.Id == id && c.UserId == chatId)
                ?? throw new NotFoundException($"Category with this ID {id} was not found!");

            categories.Remove(categoryForDeletion);

            FileHelper.WriteToFile(PathHolder.Category, categories);    
        }

        public TaskCategory Get(int id, long chatId)
        {
            var categories = FileHelper.ReadFromFile<TaskCategory>(PathHolder.Category);

            TaskCategory? category = categories.FirstOrDefault(c => c.Id == id && c.UserId == chatId)
             ?? throw new NotFoundException($"Category with this ID {id} was not found!");

            return category;
        }

        public List<TaskCategory> GetList(long chatId)
        {
            var categories = FileHelper.ReadFromFile<TaskCategory>(PathHolder.Category);

            List<TaskCategory> category = categories.Where(c => c.UserId == chatId).ToList();

            if (categories.Count == 0)
            {

            }

            return Enumerable.Empty<TaskCategory>().ToList();
        }

    }
}
