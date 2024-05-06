using Domain.Dtos.RoleOperation;

namespace Domain.Entities.RoleOperation;

public interface IRoleOperationRepository
{
    Task<List<string>> GetRoleOperations(int roleId);
}