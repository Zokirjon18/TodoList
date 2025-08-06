using Newtonsoft.Json;
using TodoList.Domain;

namespace TodoList.Helpers;

public static class GeneratorHelper
{
    public static int GenerateId<T>(string path)
    {
        if (File.Exists(path))
        {
            string text = File.ReadAllText(path);
            var models = JsonConvert.DeserializeObject<List<T>>(text);

            var baseModels = JsonConvert.DeserializeObject<List<BaseEntity>>(text);

            int maxId = default;
            if (baseModels != null || baseModels.Count > 0)
            {
                 maxId = baseModels.MaxBy(t => t.Id).Id;
            }

            return ++maxId;
        }

        return 1;

    }
}