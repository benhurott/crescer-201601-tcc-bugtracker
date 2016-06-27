using BugTracker.Domain.Entity;
using BugTracker.Infra.Repository.Map;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace BugTracker.Infra.Repository
{
    public class DataContext : DbContext
    {
        public DataContext() : base("Conn"){ }

        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            this.Configuration.ProxyCreationEnabled = false;
            this.Configuration.LazyLoadingEnabled = false;
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties<string>()
             .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));

            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new ApplicationMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
