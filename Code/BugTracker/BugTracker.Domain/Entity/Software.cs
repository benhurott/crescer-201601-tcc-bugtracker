using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Domain.Entity
{
    public class Software
    {
        private String Name { get; set; }
        private String Version { get; set; }

        public Software() { }

        public Software(String name, String version)
        {
            this.Name = name;
            this.Version = version;
        }
    }
}
