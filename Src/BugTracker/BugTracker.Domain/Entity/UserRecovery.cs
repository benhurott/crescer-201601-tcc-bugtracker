using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Domain.Entity
{
    public class UserRecovery
    {
        public int Id { get; private set; }
        public User RequestUser { get; private set; }
        public DateTime RequestDate { get; private set; }
        public String HashCode { get; private set; }

        private UserRecovery() { }

        public UserRecovery(User requestUser, DateTime requestDate, String hashCode)
        {
            this.RequestUser = requestUser;
            this.RequestDate = requestDate;
            this.HashCode = hashCode;
        }

        public UserRecovery(int id, User requestUser, DateTime requestDate, String hashCode) 
            : this(requestUser, requestDate, hashCode)
        {
            this.Id = id;
        }
    }
}
