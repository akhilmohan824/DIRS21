using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DIRS21.Mapper.Rules
{
    public class SubStringRule : IRule
    {
        public object? GetPropertyValue(object source, IEnumerable<PropertyInfo> sourceProperties, params string[] parameters)
        {
            try
            {
                var sourcePropertyValue = sourceProperties.First().GetValue(source) as string;
                var separator = parameters[0] as string;
                var subStringIndex = Convert.ToInt32(parameters[1]);

                return sourcePropertyValue.Split(separator)[subStringIndex];
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error on mapping using SubStringRule. {ex.Message}");
            }
            return null;
        }
    }
}
