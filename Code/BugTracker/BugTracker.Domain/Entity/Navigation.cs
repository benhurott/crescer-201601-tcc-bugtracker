using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Domain.Entity
{
    public class Navigation
    {
        private int Id { get; set; }
        private Browser Browser { get; set; }
        private OperationalSystem OperationalSystem { get; set; }

        private Navigation() { }

        public Navigation(Browser browser, OperationalSystem operationalSystem)
        {
            this.Browser = browser;
            this.OperationalSystem = operationalSystem;
        }

        public Navigation(int id, Browser browser, OperationalSystem operationalSystem)
            : this(browser, operationalSystem)
        {
            this.Id = Id;
        }
    }
}
