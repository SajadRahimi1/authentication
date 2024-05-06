using Api.Security;
using Application.Handler.User;
using Domain.Entities.User;
using Infrastructure.UnitOfWork;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controller;

[ApiController, Route("/api/[controller]/[action]")]
public class UserController(ISender mediator) : ControllerBase
{
    [HttpPost]
    [TypeFilter(typeof(AccessActionFilter), Arguments = new object[] { "AddUser" })]
    public async Task<CreateUserResponse> CreateUser([FromBody] CreateUserCommand createUserCommand) =>
        await mediator.Send(createUserCommand);

    [HttpPost]
    public async Task<GetUserResponse> LoginUser([FromBody] GetUserCommand getUserCommand) =>
        await mediator.Send(getUserCommand);
}