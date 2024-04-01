using System.Reflection;

namespace RailLate.Shared.Caching;

public class CacheKeyGenerator
{
    public string Generate(MethodInfo methodInfo, object[] parameterValues)
    {
        var key = $"{methodInfo.DeclaringType?.FullName}.{methodInfo.Name}";
        if (parameterValues.Length > 0)
        {
            key += "." + string.Join(".", parameterValues.Select(p => p?.ToString()));
        }

        return key;
    } }