using BugTracker.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Interface.Presentation.Models.BugTracker
{
    public class BugTrackerPostModel
    {
        public BugTrackerStatus Status { get; set; }
        public List<BugTrackerTag> Tags { get; set; }
        public String Trace { get; set; }
    }
}