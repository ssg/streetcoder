using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

public class UserStats
{
    public int Received { get; set; }
    public int Sent { get; set; }
}

[Route("stats/{action}")]
public class StatsController(IConfiguration config) : ControllerBase
{
    private readonly IConfiguration config = config;

    [HttpGet]
    public UserStats Get(int userId)
    {
        var result = new UserStats();
        string connectionString = config.GetConnectionString("DB");
        using (var conn = new SqlConnection(connectionString))
        {
            conn.Open();
            var cmd = conn.CreateCommand();
            cmd.CommandText =
              "SELECT COUNT(*) FROM Messages WHERE FromId={0}";
            cmd.Parameters.Add(userId);
            result.Sent = (int)cmd.ExecuteScalar();
            cmd.CommandText =
              "SELECT COUNT(*) FROM Messages WHERE ToId={0}";
            result.Received = (int)cmd.ExecuteScalar();
        }

        return result;
    }
}