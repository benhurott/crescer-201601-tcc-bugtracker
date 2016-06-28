using BugTracker.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Infra.Repository.Map
{
    public class BugTrackerNavigationMap : EntityTypeConfiguration<BugTrackerNavigation>
    {
        public BugTrackerNavigationMap()
        {
            ToTable("BugTrackerNavigation");
            HasKey(_ => _.IDBugTrackerNavigation);

            HasRequired(_ => _.BugTracker)
                .WithRequiredDependent(p => p.Navigations);

            Property(_ => _.Browser.Name).HasColumnName("BrowserName");
            Property(_ => _.Browser.Version).HasColumnName("BrowserVersion");
            Property(_ => _.OperationalSystem.Name).HasColumnName("PlatformName");
        }
    }
}
