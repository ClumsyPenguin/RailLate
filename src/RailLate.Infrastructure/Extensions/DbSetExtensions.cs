using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace RailLate.Infrastructure.Extensions;

public static class DbSetExtensions
{
    public static T AddIfNotExists<T>(this DbSet<T> dbSet, T entity, Expression<Func<T, bool>>? predicate = null) where T : class, new()
    {
        var exists = predicate != null ? dbSet.Any(predicate) : dbSet.Any();
        if (!exists)
        {
            dbSet.Add(entity);
            return entity;
        }
        return null!;
    }
    
    public static async Task AddRangeIfNotExistsAsync<T>(
        this DbSet<T> dbSet,
        IEnumerable<T> entities,
        Func<T, Expression<Func<T, bool>>> predicateBuilder,
        CancellationToken cancellationToken = default) where T : class, new()
    {
        var entitiesToAdd = new List<T>();

        foreach (var entity in entities)
        {
            var predicate = predicateBuilder(entity);
            var exists = await dbSet.AnyAsync(predicate, cancellationToken);
            if (!exists)
            {
                entitiesToAdd.Add(entity);
            }
        }

        if (entitiesToAdd.Count != 0)
        {
            await dbSet.AddRangeAsync(entitiesToAdd, cancellationToken);
        }
    }
}