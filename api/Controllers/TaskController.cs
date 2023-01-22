using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PointS.Api.Context;
using PointS.Api.Entity;
using PointS.Api.Repositories;
using PointS.Api.Services;

namespace PointS.Api.Controllers;
[ApiController]
[Route("api/[controller]")]
public class TaskController : BaseController
{
    public TaskController(IDbContextFactory<DataContext> context, IRepositoryFactory repositoryFactory, IServiceFactory serviceFactory) : base(context, repositoryFactory, serviceFactory)
    {
    }

    [HttpGet("all")]
    public Task<List<TaskEntity>> GetTasks() => RepositoryFactory.TaskRepository.GetAllAsync();

    [HttpGet("one")]
    public Task<TaskEntity> GetTaskById(long id) => RepositoryFactory.TaskRepository.GetAsync(id);

    [HttpPost("create")]
    public Task<TaskEntity> CreateTask([FromBody] TaskEntity task) => ServiceFactory.TaskService.CreateAsync(task);

    [HttpPut("edit")]
    public Task<bool> EditTask([FromBody] TaskEntity task) => ServiceFactory.TaskService.EditAsync(task);

    [HttpPatch("edit/status")]
    public Task<bool> EditTaskStatus(long id, PointS.Api.Entity.TaskStatus status) => ServiceFactory.TaskService.EditStatusAsync(id, status);

    [HttpDelete("delete")]
    public Task<bool> DeleteTask(int id) => RepositoryFactory.TaskRepository.DeleteAsync(id);
}
