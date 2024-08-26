using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DIRS21.Mapper.Rules
{
    public class StringJoinRule : IRule
    {
        public object? GetPropertyValue(object source, IEnumerable<PropertyInfo> sourceProperties, params string[] parameters)
        {
            var sourcePropertyValues = sourceProperties.Select(property =>
            {
                var value = property.GetValue(source) as string;
                if (value == null)
                {
                    throw new Exception();
                }
                return value;
            }).ToArray();

            return string.Join(" ", sourcePropertyValues);
        }
    }
}
