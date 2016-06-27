using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Domain.Entity
{
    public class Tag
    {
        public String Name { get; private set; }

        private Tag() { }

        public Tag(String name)
        {
            this.Name = name;
        }
    }
}
