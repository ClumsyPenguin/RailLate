using ZiggyCreatures.Caching.Fusion;

namespace RailLate.Shared.Caching;

[AttributeUsage(AttributeTargets.Method, Inherited = false)]
public class CacheAttribute(int itemDuration) : Attribute
{
    public TimeSpan ItemDuration { get; } = TimeSpan.FromMinutes(itemDuration);
}