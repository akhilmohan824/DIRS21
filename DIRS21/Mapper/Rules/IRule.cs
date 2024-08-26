using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DIRS21.Mapper.Rules
{
    public interface IRule
    {
        object? GetPropertyValue(object source, IEnumerable<PropertyInfo> sourceProperties, params string[] parameters);
    }
}
