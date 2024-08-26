using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DIRS21.Mapper.Rules
{
    public class DefaultRule : IRule
    {
        public object? GetPropertyValue(object source, IEnumerable<PropertyInfo> sourceProperties, params string[] parameters)
        {
            return sourceProperties.First().GetValue(source);
        }
    }
}
