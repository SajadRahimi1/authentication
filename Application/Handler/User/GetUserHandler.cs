using Domain.Entities.User;
using Infrastructure.UnitOfWork;
using MediatR;
using Utility.Helper;
using Utility.Security;

namespace Application.Handler.User;

public class GetUserHandler(IUnitOfWork unitOfWork):IRequestHandler<GetUserCommand,GetUserResponse>
{
    public async Task<GetUserResponse> Handle(GetUserCommand request, CancellationToken cancellationToken)
    {
        var response = new GetUserResponse { Message = "user or password is incorrect" };
        var user = await unitOfWork.UserRepository.GetUserByUserName(request.username);
        if (user is null)
        {
            return response;
        }

        var verifyPassword = PasswordEncoder.VerifyPassword(request.password,user.Password);
        if (verifyPassword)
        {
            return new GetUserResponse
            {
                Username = request.username,
                Message = "login successful",
                Id = user.Id,
                Token = JwtService.GenerateToken(user.UserName,user.Role.ToString())
            };
        }

        return response;
    }
}

public class GetUserCommand : IRequest<GetUserResponse>
{
    public string username { get; set; }
    public string password { get; set; }
}

public class GetUserResponse
{
    public string Message { get; set; }
    public int Id { get; set; }
    public string Username { get; set; }
    public string Token { get; set; }
}