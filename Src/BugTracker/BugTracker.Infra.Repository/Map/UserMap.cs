using BugTracker.Domain.Entity;
using System.Data.Entity.ModelConfiguration;

namespace BugTracker.Infra.Repository.Map
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            ToTable("User");
            HasKey(_ => _.IDUser);

            Property(_ => _.Name).HasMaxLength(150).IsRequired();
            Property(_ => _.Name).HasMaxLength(200).IsOptional();
        }
    }
}
