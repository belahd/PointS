using Microsoft.EntityFrameworkCore;
using PointS.Api.Context;

namespace PointS.Api.Repositories;

public class RepositoryFactory : IRepositoryFactory
{
    TaskRepository _taskRepository;
    IDbContextFactory<DataContext> _dbContext;

    public TaskRepository TaskRepository => _taskRepository ?? (_taskRepository = new TaskRepository(_dbContext));

    public RepositoryFactory(IDbContextFactory<DataContext> dbContext)
    {
        this._dbContext = dbContext;
    }
}