using System.Linq.Expressions;
using SpellBook.Backend.Domain.Common;
using SpellBook.Backend.Domain.Repositories;

namespace SpellBook.Backend.Infrastructure.Data.Repositories;

public class EntityRepository<T> : IEntityRepository<T> where T : BaseEntity
{
    public Task<T?> GetByIdAsync(int id, bool asNoTracking = true, CancellationToken ct = default,
        bool includeSoftDeleted = false)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<T?>> GetAllAsync(Expression<Func<T, bool>>? predicate = null, bool asNoTracking = true,
        CancellationToken ct = default,
        bool includeSoftDeleted = false, params Expression<Func<T, object>>[] includes)
    {
        throw new NotImplementedException();
    }

    public Task AddAsync(T entity, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public Task AddRangeAsync(IEnumerable<T> entities, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(T entity, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(T entity, bool soft = true, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public Task DeleteRangeAsync(IEnumerable<T> entities, bool soft = true, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }
}
