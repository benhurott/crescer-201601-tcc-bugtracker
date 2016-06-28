using BugTracker.Domain.Entity;
using BugTracker.Domain.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Infra.Repository.DataEntity
{
    public class UserRecoveryRepository : IUserRecoveryRepository
    {
        public void Add(UserRecovery userRecovery)
        {
            using (var db = new DataContext())
            {
                db.Entry<UserRecovery>(userRecovery).State = System.Data.Entity.EntityState.Added;
                db.SaveChanges();
            }
        }

        public UserRecovery FindByEmail(string email)
        {
            using (var db = new DataContext())
            {
                return db.UserRecovery.FirstOrDefault(_ => _.RequestUser.Email == email);
            }
        }
    }
}
