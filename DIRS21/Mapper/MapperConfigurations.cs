namespace DIRS21.Mapper
{
    public class MapperConfigurations
    {
        public Config[] configs { get; set; }
    }

    public class Config
    {
        public ModelInfo source { get; set; }
        public ModelInfo target { get; set; }
        public MappingInfo[] mappings { get; set; }
    }

    public class ModelInfo
    {
        public string identifier { get; set; }
        public string typeName { get; set; }
    }

    public class MappingInfo
    {
        public string targetName { get; set; }
        public string[] sourceNames { get; set; }
        public string[] paramters { get; set; }
        public string ruleType { get; set; }
    }

}
