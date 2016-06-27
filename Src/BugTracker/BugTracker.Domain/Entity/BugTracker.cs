using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Domain.Entity
{
    public class BugTracker
    {
        public int Id { get; set; }
        public Application Application { get; private set; }
        public BugTrackerStatus Status { get; private set; }
        public String Description { get; private set; }
        public DateTime Date { get; private set; }
        public List<Tag> Tags { get; private set; }
        public Navigation Navigation { get; private set; }

        private BugTracker() { }

        public BugTracker(Application application, BugTrackerStatus status, String description, DateTime data, List<Tag> tags, Navigation navigation)
        {
            this.Application = application;
            this.Status = status;
            this.Description = description;
            this.Date = data;
            this.Tags = tags;
            this.Navigation = navigation;
        }

        public BugTracker(int id, Application application, BugTrackerStatus status, String description, DateTime data, List<Tag> tags, Navigation navigation)
            : this(application, status, description, data, tags, navigation)
        {
            this.Id = id;
        }
    }
}
