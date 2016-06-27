using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Domain.Entity
{
    public class Browser : Software
    {
        public String Version { get; private set; }

        private Browser() { }

        public Browser(String name, String version) :base(name)
        {
            this.Version = version;
        }
    }
}
