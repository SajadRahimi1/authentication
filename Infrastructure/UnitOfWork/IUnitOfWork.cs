using Domain.Entities.User;
using Infrastructure.Data;
using MediatR;

namespace Infrastructure.UnitOfWork;

public interface IUnitOfWork
{
    public IUserRepository UserRepository { get; }
    
}