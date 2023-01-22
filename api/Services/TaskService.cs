using PointS.Api.Core.Services;
using PointS.Api.Entity;
using PointS.Api.Repositories;

namespace PointS.Api.Services;

public class TaskService : ServiceBase<TaskEntity>, ITaskService
{
    public TaskService(IRepositoryFactory repositoryFactory) : base(repositoryFactory)
    {
    }

    public async Task<TaskEntity> CreateAsync(TaskEntity task)
    {
        if (!IsValid(task))
        {
            return null;
        }

        return await RepositoryFactory.TaskRepository.CreateAsync(task);
    }

    public async Task<bool> EditAsync(TaskEntity task)
    {
        if (!IsValid(task))
        {
            return false;
        }

        return await RepositoryFactory.TaskRepository.UpdateAsync(task);
    }

    public async Task<bool> EditStatusAsync(long id, PointS.Api.Entity.TaskStatus status)
    {
        var task = await RepositoryFactory.TaskRepository.GetAsync(id);
        task.Status = status;

        return await RepositoryFactory.TaskRepository.UpdateAsync(task);
    }

    protected override bool IsValid(TaskEntity task)
    {
        if (string.IsNullOrWhiteSpace(task.Title))
        {
            throw new Exception("Task title is a required field");
        }

        if (!string.IsNullOrWhiteSpace(task.Title) && task.Title.Length > TaskEntity.TITLE_MAX_LENGTH)
        {
            throw new Exception($"Task title cannot exceed {TaskEntity.TITLE_MAX_LENGTH} characters");
        }

        if (!string.IsNullOrWhiteSpace(task.Description) && task.Description.Length > TaskEntity.DESCRIPTION_MAX_LENGTH)
        {
            throw new Exception($"Task description cannot exceed {TaskEntity.DESCRIPTION_MAX_LENGTH} characters");
        }

        return true;
    }
}