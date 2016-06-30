using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio = BugTracker.Domain.Entity;

namespace BugTracker.Infra.Repository.Map
{
    public class BugTrackerMap : EntityTypeConfiguration<Dominio.BugTracker>
    {
        public BugTrackerMap()
        {
            ToTable("BugTracker");
            HasKey(_ => _.IDBugTracker);
            HasRequired(_ => _.Application)
                .WithMany(u => u.BugTrackers)
                .HasForeignKey(a => a.IDApplication)
                .WillCascadeOnDelete(false);
        }
    }
}
