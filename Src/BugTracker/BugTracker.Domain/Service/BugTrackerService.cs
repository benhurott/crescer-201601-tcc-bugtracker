using BugTracker.Domain.Exceptions;
using BugTracker.Domain.Interface.Repository;
using BugTracker.Domain.Interface.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Domain.Service
{
    public class BugTrackerService : IBugTrackerService
    {
        private IBugTrackerRepository bugTrackerRepository;

        public BugTrackerService(IBugTrackerRepository bugTrackerRepository)
        {
            this.bugTrackerRepository = bugTrackerRepository;
        }

        public void Add(Entity.BugTracker bugTracker)
        {
            if (bugTracker.ValidateTags())
            {
                bugTrackerRepository.Add(bugTracker);

                var existeTagMaster = bugTracker.ContainsSpecialTag();

                if (existeTagMaster != null)
                {
                    //enviar email;   
                }
            }
            else
            {
                throw new TagVeryLargeException();
            }
        }

        public ICollection<Entity.BugTracker> FindByIDApplication(int id)
        {
            return bugTrackerRepository.FindByIDApplication(id);
        }
    }
}
