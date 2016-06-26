using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Domain.Entity
{
    public class Tag
    {
        private String Name { get; set; }

        private Tag() { }

        public Tag(String name)
        {
            this.Name = name;
        }
    }
}
