using PointS.Api.Repositories;

namespace PointS.Api.Services;
public class ServiceFactory : IServiceFactory
{
    TaskService _taskService;
    IRepositoryFactory _repositoryFactory;

    public TaskService TaskService => _taskService ?? (_taskService = new TaskService(_repositoryFactory));

    public ServiceFactory(IRepositoryFactory repositoryFactory)
    {
        this._repositoryFactory = repositoryFactory;
    }
}