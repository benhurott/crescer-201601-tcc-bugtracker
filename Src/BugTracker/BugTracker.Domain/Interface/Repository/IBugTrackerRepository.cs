using System;
using System.Collections.Generic;

namespace BugTracker.Domain.Interface.Repository
{
    public interface IBugTrackerRepository
    {
        ICollection<Domain.Entity.BugTracker> FindByIDApplication(int id);
        ICollection<Domain.Entity.BugTracker> FindByApplicationPagined(int idApplication, int limit, int page, string trace, List<Domain.Entity.BugTrackerStatus> status);
        IList<dynamic> GetGraphicModelByIdApplication(int id);
        IList<dynamic> GetCountBugsByApp(int idApplication, string trace, List<Domain.Entity.BugTrackerStatus> status);
        void Add(Domain.Entity.BugTracker bugTracker);
    }
}
