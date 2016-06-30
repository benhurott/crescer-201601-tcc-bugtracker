using BugTracker.Domain.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Infra.Repository.DataEntity
{
    public class BugTrackerRepository : IBugTrackerRepository
    {
        public void Add(Domain.Entity.BugTracker bugTracker)
        {
            using (var db = new DataContext())
            {
                db.Entry<Domain.Entity.BugTracker>(bugTracker).State = System.Data.Entity.EntityState.Added;
                db.Entry<Domain.Entity.BugTrackerNavigation>(bugTracker.Navigation).State = System.Data.Entity.EntityState.Detached;
                db.Entry<Domain.Entity.User>(bugTracker.Application.User).State = System.Data.Entity.EntityState.Unchanged;
                db.Entry<Domain.Entity.Application>(bugTracker.Application).State = System.Data.Entity.EntityState.Unchanged;
                db.SaveChanges();
            }
        }

        public ICollection<Domain.Entity.BugTracker> FindByIDApplication (int idApplication)
        {
            using (var db = new DataContext())
            {
                return db.BugTrucker
                    .Include("Tags")
                    .Include("Navigation")
                    .Where(_ => _.IDApplication == idApplication)
                    .ToList();
            }
        }

        public ICollection<Domain.Entity.BugTracker> FindByApplicationPagined(int idApplication, int limit, int page)
        {
            using (var db = new DataContext())
            {
                return db.BugTrucker
                    .Include("Tags")
                    .Include("Navigation")
                    .OrderBy(_ => _.IDBugTracker)
                    .Skip(limit * (page - 1))
                    .Take(limit)
                    .Where(_ => _.IDApplication == idApplication)
                    .ToList();
            }
        }
    }
}
