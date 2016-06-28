using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Domain.Entity
{
    public class BugTracker
    {
        public int IDBugTracker { get; set; }
        public int IDApplication { get; set; }
        public virtual Application Application { get; private set; }
        public BugTrackerStatus Status { get; private set; }
        public String Description { get; private set; }
        public DateTime Date { get; private set; }
        public virtual List<BugTrackerTag> Tags { get; private set; }
        public virtual BugTrackerNavigation Navigations { get; private set; }
            
        private BugTracker() { }

        public BugTracker(Application application, BugTrackerStatus status, String description, DateTime data, List<BugTrackerTag> tags, BugTrackerNavigation navigation)
        {
            this.Application = application;
            this.Status = status;
            this.Description = description;
            this.Date = data;
            this.Tags = tags;
            this.Navigations = navigation;
        }

        public BugTracker(int id, Application application, BugTrackerStatus status, String description, DateTime data, List<BugTrackerTag> tags, BugTrackerNavigation navigation)
            : this(application, status, description, data, tags, navigation)
        {
            this.IDBugTracker = id;
        }
    }
}
