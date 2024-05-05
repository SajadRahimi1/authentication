using System.Reflection;
using Domain.Entities.User;
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
        services.AddScoped<IUnitOfWork, Infrastructure.UnitOfWork.UnitOfWork>();
        
    }
}