using BugTracker.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Infra.Repository.Map
{
    class ActivationMap : EntityTypeConfiguration<Activation>
    {
        public ActivationMap()
        {
            ToTable("Activation");
            HasKey(a => a.IDActivation);

            HasRequired(a => a.Code);

            HasRequired(a => a.User)
                .WithMany(_ => _.Activations)
                .HasForeignKey(a => a.IDUser)
                .WillCascadeOnDelete(false);
        }
    }
}
