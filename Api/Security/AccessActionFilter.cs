using Infrastructure.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Utility.Security;

namespace Api.Security;

public class AccessActionFilter :IActionFilter
{
    private string OperationResource { get; set; }
    private readonly IUnitOfWork _unitOfWork;

    public AccessActionFilter(IUnitOfWork unitOfWork,string operationResource)
    {
        _unitOfWork = unitOfWork;
        OperationResource = operationResource;
    }

    public async void OnActionExecuting(ActionExecutingContext context)
    {
        var jwtToken = context.HttpContext.Request.Headers["Authorization"].FirstOrDefault();
        if (jwtToken is null)
        {
            context.Result = new ForbidResult();
            return;
        }

        var role = JwtService.GetRole(jwtToken.Split(' ').Last());

        var roleOperations =await _unitOfWork.RoleOperationRepository.GetRoleOperations(int.Parse(role));

        if (roleOperations.Contains(OperationResource)) return;
        
        context.Result = new UnauthorizedResult();
        return;
    }

   

    public void OnActionExecuted(ActionExecutedContext context)
    {
        
    }
}