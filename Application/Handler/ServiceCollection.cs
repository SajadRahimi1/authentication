using System.Reflection;
using Domain.Entities.RoleOperation;
using Domain.Entities.User;
using Infrastructure.Data;
using Infrastructure.Repositories.Cache;
using Infrastructure.Repositories.RoleOperation;
using Infrastructure.Repositories.User;
using Infrastructure.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Handler;

public abstract class ServiceCollection
{
    public static void Configure(IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IRoleOperationRepository, RoleOperationRepository>();
        services.AddScoped<ICacheRepository, MemoryCacheRepository>();
        services.AddScoped<IUnitOfWork, Infrastructure.UnitOfWork.UnitOfWork>();
        services.AddSingleton<DapperContext>();

        services.AddMemoryCache();
    }
}