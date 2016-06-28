using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain = BugTracker.Domain.Entity;

namespace BugTracker.Domain.Interface.Service
{
    public interface IBugTrackerService
    {
        ICollection<Domain.Entity.BugTracker> FindByIDApplication(int id);
        void Add(Domain.Entity.BugTracker bugTracker);
    }
}
