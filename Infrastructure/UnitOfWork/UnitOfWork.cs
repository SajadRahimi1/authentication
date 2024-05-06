using Domain.Entities.RoleOperation;
using Domain.Entities.User;
using Infrastructure.Data;
using MediatR;

namespace Infrastructure.UnitOfWork;

public class UnitOfWork(IUserRepository userRepository,IRoleOperationRepository roleOperationRepository)
    : IUnitOfWork
{
    public IUserRepository UserRepository { get; } = userRepository;
    public IRoleOperationRepository RoleOperationRepository { get; } = roleOperationRepository;
}