﻿using Microsoft.Data.SqlClient;
using System.Data;
using System.Runtime.CompilerServices;

namespace _420DA3_Demo_Iterative.DataAccess;
internal class SqlServerConnectionProvider {
    private readonly static string instanceName = "SQL2022DEV";
    private readonly static string databaseName = "420da3_07453_demo_iterative";

    private static SqlConnection? connection;

    public static SqlConnection GetConnection() {
        connection ??= CreateConnection();
        return connection;
    }

    public static void OpenConnection() {
        if (GetConnection().State != ConnectionState.Open) {
            GetConnection().Open();
        }
    }

    public static void CloseConnection() {
        if (GetConnection().State == ConnectionState.Open) {
            GetConnection().Close();
        }
    }

    private static SqlConnection CreateConnection() {
        string connectionString = $"Server=.\\{instanceName};Database={databaseName};Integrated Security=true;TrustServerCertificate=true";
        return new SqlConnection(connectionString);
    }

}
