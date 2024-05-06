using Application.Handler.RoleOperation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controller;


[ApiController, Route("/api/[controller]/[action]")]
public class RoleOperationController(ISender sender):ControllerBase
{
    [HttpGet]
    public async Task<GetRoleOperationResponse> GetRoleOperations([FromQuery] GetRoleOperationQuery operationQuery) =>
       await sender.Send(operationQuery);
}