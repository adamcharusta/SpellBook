using System.Linq.Expressions;
using SpellBook.Backend.Domain.Common;

namespace SpellBook.Backend.Domain.Repositories;

public interface IEntityRepository<T> where T : BaseEntity
{
    Task<T?> GetByIdAsync(int id, bool asNoTracking = true, CancellationToken ct = default,
        bool includeSoftDeleted = false);

    Task<IEnumerable<T?>> GetAllAsync(Expression<Func<T, bool>>? predicate = null,
        bool asNoTracking = true,
        CancellationToken ct = default,
        bool includeSoftDeleted = false,
        params Expression<Func<T, object>>[] includes);

    Task AddAsync(T entity, CancellationToken ct = default);
    Task AddRangeAsync(IEnumerable<T> entities, CancellationToken ct = default);
    Task UpdateAsync(T entity, CancellationToken ct = default);
    Task DeleteAsync(T entity, bool soft = true, CancellationToken ct = default);
    Task DeleteRangeAsync(IEnumerable<T> entities, bool soft = true, CancellationToken ct = default);
}
