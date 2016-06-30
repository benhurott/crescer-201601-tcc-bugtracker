using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Domain.Entity
{
    public class UserRecovery
    {
        public int IDUserRecovery { get; private set; }
        public virtual User RequestUser { get; private set; }
        public int IDUser { get; private set; }
        public DateTime RequestDate { get; private set; }
        public String HashCode { get; private set; }

        private UserRecovery() { }

        public UserRecovery(User requestUser, DateTime requestDate, String hashCode)
        {
            this.RequestUser = requestUser;
            this.RequestDate = requestDate;
            this.HashCode = hashCode;
            this.IDUser = requestUser.IDUser;
        }

        public UserRecovery(int id, User requestUser, DateTime requestDate, String hashCode) 
            : this(requestUser, requestDate, hashCode)
        {
            this.IDUserRecovery = id;
        }
    }
}
