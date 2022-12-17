using Domain.Data.Mappings;
using Domain.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Infra
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> opts) : base(opts) { }

        #region DbSet
        public DbSet<User> User { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder builder)
        {
            _ = new UserMapping(builder.Entity<User>());

            base.OnModelCreating(builder);
        }

        public class DesignTImeDbContextFactory : IDesignTimeDbContextFactory<Context>
        {
            public Context CreateDbContext(string[] args)
            {
                var builder = new DbContextOptionsBuilder<Context>();
                builder.UseNpgsql("Server=localhost;Database=DockerSimpleApp;Port=5432;User Id=postgres;Password=Rapadura69@;Ssl Mode=Disable;");
                return new Context(builder.Options);
            }
        }

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();
            _ = ChangeTracker.Entries().Where(x => x.State == EntityState.Added || x.State == EntityState.Modified).ToList();

            try
            {
                ChangeTracker.AutoDetectChangesEnabled = false;
                var result = base.SaveChanges();
                ChangeTracker.AutoDetectChangesEnabled = true;
                return result;
            }
            catch (DbUpdateException e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message + " - " + e.InnerException ?? "");
                throw;
            }
        }

        public override Task<int> SaveChangesAsync(CancellationToken token = default)
        {
            ChangeTracker.DetectChanges();
            _ = ChangeTracker.Entries().Where(x => x.State == EntityState.Added || x.State == EntityState.Modified).ToList();

            try
            {
                ChangeTracker.AutoDetectChangesEnabled = false;
                var result = base.SaveChangesAsync(token);
                ChangeTracker.AutoDetectChangesEnabled = true;
                return result;
            }
            catch (DbUpdateException e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message + " - " + e.InnerException ?? "");
                throw;
            }
        }
    }
}
