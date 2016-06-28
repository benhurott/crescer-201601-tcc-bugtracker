using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain = BugTracker.Domain.Entity;

namespace BugTracker.Domain.Interface.Repository
{
    public interface IBugTrackerRepository
    {
        void Add(Domain.Entity.BugTracker bugTracker);
    }
}
