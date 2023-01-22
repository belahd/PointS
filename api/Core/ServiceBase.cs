using PointS.Api.Core.Entities;
using PointS.Api.Repositories;

namespace PointS.Api.Core.Services;

public class ServiceBase<T> : IServiceBase<T> where T : EntityBase
{
    protected IRepositoryFactory RepositoryFactory { get; }

    public ServiceBase(IRepositoryFactory repositoryFactory)
    {
        RepositoryFactory = repositoryFactory;
    }

    protected virtual bool IsValid(T entity) => true;
}