using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Domain.Entity
{
    public class UserRecovery
    {
        private int Id { get; set; }
        private User RequestUser { get;  set; }
        private DateTime RequestDate { get; set; }
        private String HashCode { get; set; }

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
