using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PointS.Api.Repositories;
using PointS.Api.Services;
using PointS.Api.Context;

namespace PointS.Api.Controllers;
public class BaseController : ControllerBase
{
    protected internal IRepositoryFactory RepositoryFactory
    {
        get;
        private set;
    }

    protected internal IServiceFactory ServiceFactory
    {
        get;
        private set;
    }

    public BaseController(IDbContextFactory<DataContext> context, IRepositoryFactory repositoryFactory, IServiceFactory serviceFactory)
    {
        RepositoryFactory = repositoryFactory ?? new RepositoryFactory(context);
        ServiceFactory = serviceFactory ?? new ServiceFactory(RepositoryFactory);
    }
}