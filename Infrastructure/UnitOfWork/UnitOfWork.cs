using Domain.Entities.User;
using Infrastructure.Data;
using MediatR;

namespace Infrastructure.UnitOfWork;

public class UnitOfWork(IUserRepository userRepository)
    : IUnitOfWork
{
    public IUserRepository UserRepository { get; } = userRepository;
    
}