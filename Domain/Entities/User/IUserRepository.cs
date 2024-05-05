namespace Domain.Entities.User;

public interface IUserRepository
{
    public Task<UserEntity?> GetUserByUserName(string username);
    public Task<int> AddUser(UserEntity userEntity);
}