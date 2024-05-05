using Application.Handler.User;
using Domain.Entities.User;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controller;

[ApiController,Route("/api/[controller]")]
public class UserController(ISender mediator) : ControllerBase
{
    [HttpPost(),Route("create"),Authorize(Roles =nameof(RoleEnum.Admin))]
    public async Task<CreateUserResponse> CreateUser([FromBody] CreateUserCommand createUserCommand) =>
       await mediator.Send(createUserCommand);
    
    [HttpPost,Route("login")]
    public async Task<GetUserResponse> CreateUser([FromBody] GetUserCommand getUserCommand) =>
        await mediator.Send(getUserCommand);
}