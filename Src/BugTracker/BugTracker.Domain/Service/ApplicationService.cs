using BugTracker.Domain.Entity;
using BugTracker.Domain.Interface.Repository;
using BugTracker.Domain.Interface.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Domain.Service
{
    public class ApplicationService : IApplicationService
    {
        IApplicationRepository applicationRepository;

        public ApplicationService(IApplicationRepository applicationRepository)
        {
            this.applicationRepository = applicationRepository;
        }

        public IQueryable<Application> FindByIDUser(int id)
        {
            return applicationRepository.FindByIDUser(id);
        }
    }
}
