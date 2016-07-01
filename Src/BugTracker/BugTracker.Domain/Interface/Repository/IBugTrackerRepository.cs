using System;
using System.Collections.Generic;

namespace BugTracker.Domain.Interface.Repository
{
    public interface IBugTrackerRepository
    {
        ICollection<Domain.Entity.BugTracker> FindByIDApplication(int id);
        ICollection<Domain.Entity.BugTracker> FindByApplicationPagined(int idApplication, int limit, int page);
        int GetCountBugsByApp(int idApplication);
        void Add(Domain.Entity.BugTracker bugTracker);
    }
}
