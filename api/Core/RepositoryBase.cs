using Microsoft.EntityFrameworkCore;
using PointS.Api.Context;
using PointS.Api.Core.Entities;

namespace PointS.Api.Core.Repositories;
public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : EntityBase
{
    protected readonly DataContext _dbContext;
    private DbSet<TEntity> _dbSet;

    public RepositoryBase(IDbContextFactory<DataContext> dbContextFactory)
    {
        _dbContext = dbContextFactory.CreateDbContext();
        _dbSet = _dbContext.Set<TEntity>();
    }

    public async Task<TEntity> GetAsync(long id)
    {
        try
        {
            var item = await _dbSet.Where(x => x.Id == id).AsNoTracking().FirstOrDefaultAsync();
            if (item == null)
            {
                throw new Exception($"Couldn't find entity with id={id}");
            }
            return item;
        }
        catch
        {
            throw new Exception($"Couldn't find entity with id={id}");
        }
    }

    public Task<List<TEntity>> GetAllAsync()
    {
        try
        {
            return _dbSet.AsNoTracking<TEntity>().ToListAsync();
        }
        catch
        {
            throw new Exception("Couldn't retrieve entities");
        }
    }

    public async Task<TEntity> CreateAsync(TEntity entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }

        try
        {
            await _dbSet.AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }
        catch
        {
            throw new Exception($"{nameof(entity)} could not be saved");
        }
    }

    public async Task<bool> UpdateAsync(TEntity entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }

        try
        {
            _dbSet.Update(entity);
            await _dbContext.SaveChangesAsync();

            return true;
        }
        catch
        {
            throw new Exception($"{nameof(entity)} could not be updated");
        }
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var entity = await _dbSet.FindAsync(id);
        return await DeleteAsync(entity);
    }

    public async Task<bool> DeleteAsync(TEntity entity)
    {
        if (entity == null)
        {
            throw new Exception($"{nameof(entity)} could not be found.");
        }

        try
        {
            _dbSet.Remove(entity);
            await _dbContext.SaveChangesAsync();

            return true;
        }
        catch
        {
            return false;
        }
    }
}