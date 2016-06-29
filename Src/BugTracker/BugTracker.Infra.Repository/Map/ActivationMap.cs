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

            HasRequired(_ => _.User)
                .WithRequiredDependent(u => u.Activation);
    
	}
    }
}
