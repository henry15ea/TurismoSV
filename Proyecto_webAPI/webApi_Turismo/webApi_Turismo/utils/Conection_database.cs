namespace webApi_Turismo.utils.Conection_database;

using System;
using System.Data.SqlClient;

public class Conection_database
{
    private string connectionString = @"Server=LAPTOP-8S0156K3\SQLEXPRESS;Database=BD_TURISMO;User Id=henry15ea;Password=demolition;";

    public Conection_database()
    {
        //this.connectionString = connectionString;
    }

    protected string ConnectionString { get => connectionString; set => connectionString = value; }
    public SqlConnection GetConnection()
    {
        return new SqlConnection(connectionString);
    }
}


