using PointS.Api.Core.Services;
using PointS.Api.Entity;

namespace PointS.Api.Services;
public interface ITaskService : IServiceBase<TaskEntity>
{
    Task<TaskEntity> CreateAsync(TaskEntity task);
    Task<bool> EditAsync(TaskEntity task);
    Task<bool> EditStatusAsync(long id, PointS.Api.Entity.TaskStatus status);
}
