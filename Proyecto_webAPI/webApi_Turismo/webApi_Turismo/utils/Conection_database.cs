namespace webApi_Turismo.utils.Conection_database;

using System;
using System.Data.SqlClient;

public class Conection_database
{
    private string connectionString = @"Server=DESKTOP-OFBBKK3\RONALD;Database=BD_TURISMO;Integrated Security=True";

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


