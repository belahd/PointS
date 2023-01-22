
using PointS.Api.Core.Entities;

namespace PointS.Api.Core.Repositories;
public interface IRepositoryBase<TEntity> where TEntity : EntityBase
{
    Task<TEntity> GetAsync(long id);
    Task<List<TEntity>> GetAllAsync();
    Task<TEntity> CreateAsync(TEntity entity);
    Task<bool> UpdateAsync(TEntity entity);
    Task<bool> DeleteAsync(long id);
    Task<bool> DeleteAsync(TEntity entity);
}