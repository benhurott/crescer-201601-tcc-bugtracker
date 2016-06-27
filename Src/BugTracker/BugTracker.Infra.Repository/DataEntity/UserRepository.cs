using BugTracker.Domain.Entity;
using BugTracker.Domain.Interface.Repository;
using System.Linq;

namespace BugTracker.Infra.Repository.DataEntity
{
    public class UserRepository : IUserRepository
    {
        public User FindById(int id)
        {
            using (var db = new DataContext())
            {
                return db.User.Include("Applications").AsNoTracking().FirstOrDefault(_ => _.IDUser == id);
            }
        }

        public void Add(User user)
        {
            using (var db = new DataContext())
            {
                db.Entry<User>(user).State = System.Data.Entity.EntityState.Added;
                db.SaveChanges();
            }
        }
    }
}
