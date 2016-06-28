using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Domain.Entity
{
    public class BugTrackerNavigation
    {
        public int IDBugTrackerNavigation { get; private set; }
        public virtual Browser Browser { get; private set; }
        public virtual OperationalSystem OperationalSystem { get; private set; }
        public virtual BugTracker BugTracker { get; private set; }
        public int IDBugTracker { get; private set; }

        private BugTrackerNavigation() { }

        public BugTrackerNavigation(Browser browser, OperationalSystem operationalSystem)
        {
            this.Browser = browser;
            this.OperationalSystem = operationalSystem;
        }

        public BugTrackerNavigation(int id, Browser browser, OperationalSystem operationalSystem)
            : this(browser, operationalSystem)
        {
            this.IDBugTrackerNavigation = id;
        }
    }
}
