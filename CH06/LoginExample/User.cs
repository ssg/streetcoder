using System.Data.SqlClient;

namespace LoginExample
{
    public class User
    {
        private readonly SqlConnection db;

        public User(SqlConnection db)
        {
            this.db = db;
        }

        public int? GetUserId_naive(string username)
        {
            var cmd = db.CreateCommand();
            cmd.CommandText = @"
    SELECT id
      FROM users
      WHERE name='" + username + "'";
            return cmd.ExecuteScalar() as int?;
        }

        public int? GetUserId_parameterized(string username)
        {
            var cmd = db.CreateCommand();
            cmd.CommandText = @"
    SELECT id
      FROM users
      WHERE name=@username";
            cmd.Parameters.AddWithValue("username", username);
            return cmd.ExecuteScalar() as int?;
        }
    }
}