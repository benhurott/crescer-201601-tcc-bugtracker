using BugTracker.Domain.Interface.Repository;
using System.Linq;
using BugTracker.Domain.Entity;

namespace BugTracker.Infra.Repository.DataEntity
{
    public class ApplicationRepository : IApplicationRepository
    {
        public IQueryable<Application> FindByIDUser(int IDUser)
        {
            using (var db = new DataContext())
            {
                return db.Application.AsNoTracking().Where(_ => _.IDUser == IDUser);
            }
        }

        public void Add(Application application)
        {
            using (var db = new DataContext())
            {
                db.Entry<Application>(application).State = System.Data.Entity.EntityState.Added;
                db.SaveChanges();
            }
        }
    }
}
