using BugTracker.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Domain.Interface.Service
{
    public interface IApplicationService
    {
        ICollection<Application> FindByIDUser(int id);
        Application FindByUrl(string url);
        void Add(Application application);
        void Edit(Application application);
        Application FindById(int id);
    }
}
