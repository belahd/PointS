using Microsoft.EntityFrameworkCore;
using PointS.Api.Context;
using PointS.Api.Core.Repositories;
using PointS.Api.Entity;

namespace PointS.Api.Repositories;
public class TaskRepository : RepositoryBase<TaskEntity>, ITaskRepository
{
    public TaskRepository(IDbContextFactory<DataContext> dbContext) : base(dbContext)
    {
    }
}