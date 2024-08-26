using DIRS21.Mapper.Rules;
using System.Reflection;

namespace DIRS21.Mapper
{
    public class MapHandler
    {
        public object? Map(object data, string sourceType, string targetType)
        {
            var mapperConfig = MapperConfigurationHandler.GetConfig(sourceType, targetType);
            if (mapperConfig == null)
            {
                Console.WriteLine($"Mapper not available for the sourcetype: {sourceType} and targettype: {targetType}");
                return null;
            }

            var _sourceType = Type.GetType(mapperConfig.source.typeName);
            var _targetType = Type.GetType(mapperConfig.target.typeName);
            if (_sourceType == null || _targetType == null)
            {
                Console.WriteLine($"Wrong value configured for sourcetype: {mapperConfig.source.typeName} or targettype: {mapperConfig.target.typeName}");
                return null;
            }

            return map(data, mapperConfig, _sourceType, _targetType);
        }

        private object? map(object data, Config mapperConfig, Type _sourceType, Type _targetType)
        {
            var destination = createInstance(_targetType);
            var sourceProperties = _sourceType.GetProperties();
            var destinationProperties = _targetType.GetProperties();
            foreach (var destinationProperty in destinationProperties)
            {
                var mapRule = getMappingInfo(mapperConfig, destinationProperty.Name);
                object? sourceValue;
                if (mapRule == null)
                {
                    sourceValue = matchingNameBasedMapping(data, destination, sourceProperties, destinationProperty.Name);
                }
                else
                {
                    sourceValue = ruleBasedMapping(data, destination, sourceProperties, mapRule);
                }
                if (sourceValue != null) 
                {
                    try
                    {
                        destinationProperty.SetValue(destination, sourceValue);
                    }
                    catch (Exception ex) 
                    {
                        Console.WriteLine($"Error on setting value for {destinationProperty.Name} with value: {sourceValue}. {ex.Message}");
                    }
                }
            }

            return destination;
        }

        private object? ruleBasedMapping(object data, object? destination, PropertyInfo[] sourceProperties, MappingInfo mapRule)
        {
            var properties = sourceProperties.Where(property => mapRule.sourceNames.Contains(property.Name));
            IRule rule;
            if (mapRule.ruleType != null)
            {
                var ruleType = Type.GetType(mapRule.ruleType);
                if (ruleType == null)
                {
                    Console.WriteLine($"Rule not found: {mapRule.ruleType}");
                    return null;
                }

                rule = Activator.CreateInstance(ruleType) as IRule;
                if (rule == null)
                {
                    Console.WriteLine($"{ruleType} is not an instcane of IRule");
                    return null;
                }
            }
            else
            {
                rule = new DefaultRule();
            }
            return rule.GetPropertyValue(data, properties, mapRule.paramters);
        }

        private object? matchingNameBasedMapping(object data, object? destination, PropertyInfo[] sourceProperties, string destinationPropertyName)
        {
            var property = sourceProperties.FirstOrDefault(property => property.Name == destinationPropertyName);
            if (property != null)
            {
                return property.GetValue(data);
            }
            return null;
        }

        private MappingInfo? getMappingInfo(Config mapperConfig, string targetName)
        {
            var mapping = mapperConfig.mappings?.FirstOrDefault(mapping => mapping.targetName == targetName);

            return mapping;
            
        }

        private object? createInstance(Type type)
        {
            return Activator.CreateInstance(type);
        }
    }
}
