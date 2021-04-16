using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace LoginExample
{
    internal class UserEF
    {
        private readonly UserContext _dataContext;

        public UserEF(UserContext dataContext)
        {
            _dataContext = dataContext;
        }

        public int? GetUserId(string username)
        {
            return _dataContext.Users
              .FromSqlInterpolated(
                $@"SELECT * FROM users WHERE username={username}")
              .Select(u => (int?)u.Id)
              .FirstOrDefault();
        }
    }
}