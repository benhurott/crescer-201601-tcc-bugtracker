using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Domain.Entity
{
    public class Navigation
    {
        public int Id { get; private set; }
        public Browser Browser { get; private set; }
        public OperationalSystem OperationalSystem { get; private set; }

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
