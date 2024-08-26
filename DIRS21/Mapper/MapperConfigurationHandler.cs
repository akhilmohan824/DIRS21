using System.Text.Json;

namespace DIRS21.Mapper
{
    public static class MapperConfigurationHandler
    {
        private static List<Config> mapperConfigurations = new();
        private static readonly string _folderPath = "./Configs/Mapper";
        public static void LoadConfiguration()
        {
            foreach (string file in Directory.EnumerateFiles(_folderPath, "*.json"))
            {
                string contents = File.ReadAllText(file);
                try
                {
                    var configs = JsonSerializer.Deserialize<Config[]>(contents);
                    mapperConfigurations.AddRange(configs);
                }
                catch (Exception ex) 
                { 
                    Console.WriteLine($"Error on deserializing {file}. {ex.Message}");
                }
            }
        }

        public static Config? GetConfig(string sourceType, string targetType)
        {
            return mapperConfigurations?
                .FirstOrDefault(config => 
                    config.source.identifier == sourceType && config.target.identifier == targetType
                );
        }
    }
}
