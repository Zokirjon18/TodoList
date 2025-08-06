namespace TodoList.Constants
{
    public class PathHolder
    {
        public static string GetProjectRoot()
        {
            var current = Directory.GetCurrentDirectory();

            while (current != null)
            {
                if (Directory.EnumerateFiles(current, "*.csproj").Any())
                    return current;

                current = Directory.GetParent(current)?.FullName;
            }

            throw new Exception("Project root (.csproj file) not found.");
        }

        public static readonly string Task = Path.Combine(GetProjectRoot(), "Data", "userTasks.json");
        public static readonly string Category = Path.Combine(GetProjectRoot(), "Data", "categories.json");
    }
}
