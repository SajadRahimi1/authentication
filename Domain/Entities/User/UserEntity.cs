namespace Domain.Entities.User;

public class UserEntity:BaseEntity
{
    public string? UserName { get; set; }
    public string? Password { get; set; }
    public RoleEnum? Role { get; set; }
}