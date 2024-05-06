using System.Data;
using Dapper;
using Domain.Dtos.RoleOperation;
using Domain.Entities.RoleOperation;
using Infrastructure.Data;
using Infrastructure.Repositories.Cache;

namespace Infrastructure.Repositories.RoleOperation;

public class RoleOperationRepository : IRoleOperationRepository
{
    private readonly IDbConnection _dbConnection = new DapperContext().CreateConnection();
    private readonly ICacheRepository _cacheRepository;

    public RoleOperationRepository(ICacheRepository cacheRepository)
    {
        _cacheRepository = cacheRepository;
    }

    public async Task<List<string>> GetRoleOperations(int roleId)
    {
        var cacheOperation = _cacheRepository.GetFromCache($"RoleOperation_{roleId}");

        if (cacheOperation is not null) return (List<string>)cacheOperation;
        
        var sql = @$"SELECT o.ResourceName
        FROM RoleOperation ro
        JOIN Operation o ON ro.OperationId = o.Id
        WHERE ro.RoleId = {roleId}";

        var result = await _dbConnection.QueryAsync<GetOperationDto>(sql);
        var resultString = result.Select(r => r.ResourceName).ToList();

        _cacheRepository.SetInCache($"RoleOperation_{roleId}", resultString, TimeSpan.FromMinutes(10));
        return resultString;

    }
}