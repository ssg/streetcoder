using Microsoft.EntityFrameworkCore;

namespace LoginExample;

public class UserContext : DbContext
{
    public DbSet<UserEntity> Users { get; set; } = null!;

    public UserContext() : base()
    {
    }
}