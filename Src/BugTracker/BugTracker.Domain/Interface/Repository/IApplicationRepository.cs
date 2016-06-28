using BugTracker.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Domain.Interface.Repository
{
    public interface IApplicationRepository
    {
        ICollection<Application> FindByIDUser(int id);
        Application FindByUrl(string url);
        void Add(Application application);
    }
}
