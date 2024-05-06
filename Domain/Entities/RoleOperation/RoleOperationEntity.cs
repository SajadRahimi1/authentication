using Domain.Entities.Operation;
using Domain.Entities.Role;

namespace Domain.Entities.RoleOperation;

public class RoleOperationEntity:BaseEntity
{
    public RoleEntity Role { get; set; }
    public OperationEntity OperationEntity { get; set; }
}