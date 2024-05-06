using Infrastructure.UnitOfWork;
using MediatR;

namespace Application.Handler.RoleOperation;

public class GetRoleOperationHandler(IUnitOfWork unitOfWork):IRequestHandler<GetRoleOperationQuery,GetRoleOperationResponse>
{
    
    public async Task<GetRoleOperationResponse> Handle(GetRoleOperationQuery request, CancellationToken cancellationToken)
    {
        var sqlResult =await unitOfWork.RoleOperationRepository.GetRoleOperations(request.RoleId);
        return new GetRoleOperationResponse { Operations = sqlResult };
    }
}


public class GetRoleOperationQuery : IRequest<GetRoleOperationResponse>
{
    public int RoleId { get; set; }
}

public class GetRoleOperationResponse
{
    public List<string> Operations { get; set; }
}