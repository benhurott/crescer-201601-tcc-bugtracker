using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Domain.Entity
{
    public class Activation
    {
        public int IDActivation { get; private set; }
        public string Code { get; private set; }
        public DateTime DateRequest { get; private set; }
        public int IDUser { get; private set; }
        public User User { get; set; }

        public Activation() {  }

        public Activation(string code, int idUser, User user)
        {
            this.Code = code;
            this.IDUser = idUser;
            this.User = user;
            this.DateRequest = DateTime.Today;
        }
    }
}
