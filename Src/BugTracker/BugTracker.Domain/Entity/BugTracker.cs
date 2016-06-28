﻿using System;
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
        public string Description { get; private set; }
        public DateTime OccurredDate { get; private set; }
        public virtual ICollection<BugTrackerTag> Tags { get; private set; }
        public virtual BugTrackerNavigation Navigations { get; private set; }
            
        private BugTracker() { }

        public BugTracker(Application application, BugTrackerStatus status, String description, DateTime data, List<BugTrackerTag> tags, BugTrackerNavigation navigation)
        {
            this.Application = application;
            this.Status = status;
            this.Description = description;
            this.OccurredDate = data;
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
