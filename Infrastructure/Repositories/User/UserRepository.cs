using System.Data;
using Dapper;
using Domain.Entities.User;
using Infrastructure.Data;
using Infrastructure.UnitOfWork;

namespace Infrastructure.Repositories.User;

public class UserRepository : IUserRepository
{
    private readonly IDbConnection _dbConnection = DapperContext.Instance.CreateConnection();

    public async Task<UserEntity?> GetUserByUserName(string username)
    {
      return await _dbConnection.QuerySingleOrDefaultAsync<UserEntity?>("select * from Users where Username=@username",
            new { username = username });
    }

    public async Task<int> AddUser(UserEntity userEntity)
    {
     return await  _dbConnection.QuerySingleAsync<int>("INSERT INTO Users (UserName, Password, Role) OUTPUT INSERTED.Id VALUES  (@UserName, @Password, @Role)",
            new
            {
                UserName=userEntity.UserName,
                Password=userEntity.Password,
                Role=userEntity.Role
            });
    }
}