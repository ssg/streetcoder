using System.Data.Entity;

namespace Blabber.DB
{
    public class BlabberContext : DbContext
    {
        public BlabberContext(string connectionString)
          : base(connectionString)
        {
            Database.SetInitializer<BlabberContext>(null);
        }

        protected override void OnModelCreating(DbModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<BlabEntity> Blabs { get; set; }
    }
}