using MySql.Data.MySqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Connections;

public class ConnectionPooling(IDummyDbContext context)
{
    private MySqlConnection? customerConnection;
    private const string connectionString = "Some Connection String";
    private IDummyDbContext context = context;

    public void UpdateCustomerPreferences(string name, string prefs)
    {
        int? result = MySqlHelper.ExecuteScalar(customerConnection,
            "SELECT id FROM customers WHERE name=@name",
            new MySqlParameter("name", name)) as int?;
        if (result.HasValue)
        {
            MySqlHelper.ExecuteNonQuery(customerConnection,
                "UPDATE customer_prefs SET pref=@prefs",
                new MySqlParameter("prefs", prefs));
        }
    }

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
    public static async Task<int> Sum(int a, int b)
    {
        return a + b;
    }
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously

    public void UpdateCustomerPreferences2(string name, string prefs)
    {
        using var connection = new MySqlConnection(connectionString);
        connection.Open();
        int? result = MySqlHelper.ExecuteScalar(customerConnection,
            "SELECT id FROM customers WHERE name=@name",
            new MySqlParameter("name", name)) as int?;
        //connection.Close();
        //connection.Open();
        if (result.HasValue)
        {
            MySqlHelper.ExecuteNonQuery(customerConnection,
                "UPDATE customer_prefs SET pref=@prefs",
                new MySqlParameter("prefs", prefs));
        }
    }

    public void UpdateCustomerPreferences3(string name, string prefs)
    {
        int? result = context.Customers
          .Where(c => c.Name == name)
          .Select(c => c.Id)
          .Cast<int?>()
          .SingleOrDefault();
        if (result.HasValue)
        {
            var pref = context.CustomerPrefs
              .Where(p => p.CustomerId == result)
              .Single();
            pref.Prefs = prefs;
            context.SaveChanges();
        }
    }

    public async Task UpdateCustomerPreferencesAsync(string name,
      string prefs)
    {
        int? result = await MySqlHelper.ExecuteScalarAsync(
          customerConnection,
          "SELECT id FROM customers WHERE name=@name",
          new MySqlParameter("name", name)) as int?;
        if (result.HasValue)
        {
            await MySqlHelper.ExecuteNonQueryAsync(customerConnection,
                "UPDATE customer_prefs SET pref=@prefs",
                new MySqlParameter("prefs", prefs));
        }
    }
}

public interface IDummyDbContext
{
    public IQueryable<Customer> Customers { get; }
    public IQueryable<CustomerPreference> CustomerPrefs { get; }

    void SaveChanges();
}

public class CustomerPreference(int customerId, string prefs)
{
    public int CustomerId { get; set; } = customerId;
    public string Prefs { get; set; } = prefs;
}

public class Customer(string name, int id)
{
    public string Name { get; set; } = name;
    public int Id { get; set; } = id;
}