using MySql.Data.MySqlClient;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Threading.Tasks;

namespace Connections {
  public class ConnectionPooling {
    private MySqlConnection customerConnection;
    private const string connectionString = "Some Connection String";
    private IDummyDbContext context;

    public void UpdateCustomerPreferences(string name, string prefs) {
      int? result = MySqlHelper.ExecuteScalar(customerConnection,
          "SELECT id FROM customers WHERE name=@name",
          new MySqlParameter("name", name)) as int?;
      if (result.HasValue) {
        MySqlHelper.ExecuteNonQuery(customerConnection,
            "UPDATE customer_prefs SET pref=@prefs",
            new MySqlParameter("prefs", prefs));
      }
    }
    public static async Task<int> Sum(int a, int b) {
      return a + b;
    }

    public async Task UpdateCustomerPreferencesAsync(string name,
      string prefs) {
      int? result = await MySqlHelper.ExecuteScalarAsync(
        customerConnection,
        "SELECT id FROM customers WHERE name=@name",
        new MySqlParameter("name", name)) as int?;
      if (result.HasValue) {
        await MySqlHelper.ExecuteNonQueryAsync(customerConnection,
            "UPDATE customer_prefs SET pref=@prefs",
            new MySqlParameter("prefs", prefs));
      }
    }

    public void UpdateCustomerPreferences2(string name, string prefs) {
      using var connection = new MySqlConnection(connectionString);
      connection.Open();
      int? result = MySqlHelper.ExecuteScalar(customerConnection,
          "SELECT id FROM customers WHERE name=@name",
          new MySqlParameter("name", name)) as int?;
      //connection.Close();
      //connection.Open();
      if (result.HasValue) {
        MySqlHelper.ExecuteNonQuery(customerConnection,
            "UPDATE customer_prefs SET pref=@prefs",
            new MySqlParameter("prefs", prefs));
      }
    }

    public void UpdateCustomerPreferences3(string name, string prefs) {
      int? result = context.Customers
        .Where(c => c.Name == name)
        .Select(c => c.Id)
        .Cast<int?>()
        .SingleOrDefault();
      if (result.HasValue) {
        var pref = context.CustomerPrefs
          .Where(p => p.CustomerId == result)
          .Single();
        pref.Prefs = prefs;
        context.SaveChanges();
      }
    }

  }

  internal interface IDummyDbContext {
    public IQueryable<Customer> Customers { get; }
    public IQueryable<CustomerPreference> CustomerPrefs { get; }

    void SaveChanges();
  }

  public class CustomerPreference {
    public int CustomerId { get; set; }
    public string Prefs { get; set; }
  }

  public class Customer {
    public string Name { get; set; }
    public int Id { get; set; }
  }
}