using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace LoginExample;

internal class UserEF
{
    private readonly UserContext dataContext;

    public UserEF(UserContext dataContext)
    {
        this.dataContext = dataContext;
    }

    public int? GetUserId(string username)
    {
        return dataContext.Users
          .FromSqlInterpolated(
            $@"SELECT * FROM users WHERE username={username}")
          .Select(u => (int?)u.Id)
          .FirstOrDefault();
    }
}