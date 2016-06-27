using BugTracker.Domain.Entity;
using BugTracker.Domain.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Infra.Repository.DataEntity
{
    public class UserRepository : IUserRepository
    {
        public User FindById(int id)
        {
            using (var db = new DataContext())
            {
                return db.User.AsNoTracking().FirstOrDefault(_ => _.Id == id);
            }
        }
    }
}
