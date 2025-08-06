using Newtonsoft.Json;

namespace TodoList.Helpers;

public static class FileHelper
{
    public static List<T> ReadFromFile<T>(string path)
    {
        if (!File.Exists(path))
        {
            File.Create(path).Close();
        }

        string text = File.ReadAllText(path);
        return JsonConvert.DeserializeObject<List<T>>(text) ?? Enumerable.Empty<T>().ToList();
    }

    public static void WriteToFile<T>(string path, List<T> models)
    {
        string jsonContent = JsonConvert.SerializeObject(models, Formatting.Indented);

        File.WriteAllText(path, jsonContent);
    }
}
