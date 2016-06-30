using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BugTracker.Domain.Entity;

namespace Interface.Presentation.Models.BugTracker
{
    public class BugTrackerViewModel
    {
        public String Trace { get; set; }
        public DateTime OccuredDate { get; set; }
        public BugTrackerStatus Status { get; set; }
        public ICollection<BugTrackerTag> Tags { get; set; }
        public String BrowserName { get; set; }
        public String BrowserVersion { get; set; }
        public String OperationSystem { get; set; }

        public BugTrackerViewModel(String trace, DateTime occurredDate, BugTrackerStatus status, ICollection<BugTrackerTag> tags, string browserName, string browserVersion, string operationSystem)
        {
            this.Trace = trace;
            this.OccuredDate = occurredDate;
            this.Status = status;
            this.Tags = tags;
            this.BrowserName = browserName;
            this.BrowserVersion = browserVersion;
            this.OperationSystem = operationSystem;
        }
    }
}