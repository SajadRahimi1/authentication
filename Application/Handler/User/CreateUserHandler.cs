using Domain.Entities.User;
using Infrastructure.UnitOfWork;
using MediatR;
using Utility.Helper;

namespace Application.Handler.User;

public class CreateUserHandler(IUnitOfWork unitOfWork) : IRequestHandler<CreateUserCommand, CreateUserResponse>
{
    public async Task<CreateUserResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        request.password = PasswordEncoder.EncodePasswordToBase64(request.password);
        var user =await unitOfWork.UserRepository.GetUserByUserName(request.userName);
        
        if (user is not null)
        {
            return new CreateUserResponse { Messgae = "username is not available" };
        }
        
        var userId = await unitOfWork.UserRepository.AddUser(new UserEntity()
        {
            Password = request.password,
            UserName = request.userName,
            Role =request.RoleEnum
        });
        return new CreateUserResponse()
        {
            Messgae = "Created Successful", UserName = request.userName, RoleEnum = request.RoleEnum, Id = userId
        };
    }
}

public class CreateUserCommand : IRequest<CreateUserResponse>
{
    public string userName { get; set; }
    public string password { get; set; }
    public RoleEnum RoleEnum { get; set; }
}

public class CreateUserResponse
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public RoleEnum RoleEnum { get; set; }
    public string Messgae { get; set; }
}