using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Reflection;
using System.Data.SqlTypes;
using System.Data;

public class DbHelper
{
    private static readonly DbHelper instance = new DbHelper();
    private readonly string connectionString;

    // Private constructor to prevent instantiation outside of the class
    private DbHelper()
    {
        // Read the connection string from the configuration file
        //GetConnectionString();
        this.connectionString = "Data Source=DESKTOP-K4PF9UL;Initial Catalog=Test1;Integrated Security=True";
    }

    public static DbHelper Instance
    {
        get { return instance; }
    }

    private string GetConnectionString()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

        var configuration = builder.Build();
        return configuration.GetConnectionString("DbConnectionString");
    }

    public void ExecuteNonQuery(string query)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.ExecuteNonQuery();
            }
        }
    }

    public IEnumerable<T> ExecuteQuery<T>(string query, Func<T> createInstance)
        where T : class
    {
        List<T> results = new List<T>();

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        yield return MapDataReaderToType(reader, createInstance);
                        //results.Add(instance);
                    }
                }
            }
        }
        //return results;
    }

    public T MapDataReaderToType<T>(SqlDataReader reader, Func<T> constructor) where T : class
    {
        T instance = constructor();

        for (int i = 0; i < reader.FieldCount; i++)
        {
            string columnName = reader.GetName(i);
            PropertyInfo property = typeof(T).GetProperty(columnName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);

            if (property != null && property.CanWrite)
            {
                object value = reader.GetValue(i);
                property.SetValue(instance, value == DBNull.Value ? null : value);
            }
        }

        return instance;
    }
}
