﻿using System.Data;
using Microsoft.Data.SqlClient;
using Utility.Setting;

namespace Infrastructure.Data;

public class DapperContext
{
    private readonly IDbConnection? _connection;


    public DapperContext()
    {
        var connectionString = SandBoxManager.DataBaseConnection();
        _connection=new SqlConnection(connectionString);
    }

    public IDbConnection CreateConnection()
    {
        if (_connection?.State != ConnectionState.Open)
        {
            _connection?.Open();
        }

        return _connection;
    }

    public void CloseConnection()
    {
        _connection?.Close();
    }
}