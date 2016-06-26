using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Domain.Entity
{
    public class BugTracker
    {
        private int Id {get; set;}
        private Application Application { get; set; }
        private BugTrackerStatus Status { get; set; }
        private String Description { get; set; }
        private DateTime Date { get; set; }
        private List<Tag> Tags { get; set; }
        private Navigation Navigation { get; set; }

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
