using BugTracker.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Interface.Presentation.Models.BugTracker
{
    public class BugTrackerFilterModel
    {
        public string Trace { get; set; }
        public int idApplication { get; set; }
        public int Page { get; set; }
        public List<BugTrackerStatus> Status { get; set; }
    }
}