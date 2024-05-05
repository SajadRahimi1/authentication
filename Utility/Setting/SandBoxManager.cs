using Microsoft.Extensions.Configuration;

namespace Utility.Setting;

public class SandBoxManager
{
    static string ConnectionJson = Path.Combine(Directory.GetCurrentDirectory(), "SandBox\\Connection.json");

    public static string DataBaseConnection()
    {
        var builder = new ConfigurationBuilder().AddJsonFile(ConnectionJson);
        var connectionString = builder.Build().GetSection("ConnectionStrings");
        return connectionString.GetSection("Db").Value ?? "";
    }
    
    public static JwtConfig JwtSecretKey()
    {
        var jwtConfig = new JwtConfig();
        var builder = new ConfigurationBuilder().AddJsonFile(ConnectionJson);
        var connectionString = builder.Build().GetSection("Jwt");
        jwtConfig.SecrectKey= connectionString.GetSection("secretKey").Value ?? "";
        jwtConfig.Issuer= connectionString.GetSection("Issuer").Value ?? "";
        jwtConfig.Audience= connectionString.GetSection("Audience").Value ?? "";

        return jwtConfig;
    }
}