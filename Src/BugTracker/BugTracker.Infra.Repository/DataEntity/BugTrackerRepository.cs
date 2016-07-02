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
                    .AsNoTracking()
                    .Include("Tags")
                    .Where(_ => _.IDApplication == idApplication)
                    .ToList();
            }
        }

        public ICollection<Domain.Entity.BugTracker> FindByApplicationPagined(int idApplication, int limit, int page, string trace, List<Domain.Entity.BugTrackerStatus> status)
        {
            using (var db = new DataContext())
            {
                var query = db.BugTrucker
                    .AsNoTracking()
                    .Include("Tags")
                    .OrderBy(_ => _.IDBugTracker)
                    .Skip(limit * (page - 1))
                    .Take(limit)
                    .Where(_ => _.IDApplication == idApplication);

                return addFilter(query, trace, status).ToList();
            }
        }

        public IList<dynamic> GetCountBugsByApp(int idApplication, string trace, List<Domain.Entity.BugTrackerStatus> status)
        {
            using (var db = new DataContext())
            {
                var query = db.BugTrucker
                    .AsNoTracking()
                    .Where(_ => _.IDApplication == idApplication);

                 return addFilter(query, trace, status)
                        .GroupBy(x => x.Status)
                        .Select(s => new
                        {
                            Status = s.Key,
                            Count = s.Count()
                        }).ToArray();
            }
        }

        private IEnumerable<Domain.Entity.BugTracker> addFilter(IEnumerable<Domain.Entity.BugTracker> query, string trace, List<Domain.Entity.BugTrackerStatus> status)
        {
            if (!string.IsNullOrEmpty(trace))
            {
                query = query.Where(_ => _.Description.Contains(trace));
            }

            if (status != null )
            {
                query = query.Where(_ => status.Contains(_.Status));
            }

            return query;
        }

        //TODO: dois métodos praticamente iguais
        public IList<dynamic> GetGraphicModelByIdApplication(int id)
        {
            using (var db = new DataContext())
            {
                DateTime dateLimit = DateTime.Now.AddDays(-7);

                return db.BugTrucker
                    .AsNoTracking()
                    .Where(_ => _.IDApplication == id && _.OccurredDate >= dateLimit)
                    .GroupBy(x => x.Status)
                    .Select(s => new
                     {
                            Status = s.Key,
                            Count = s.Count()
                     })
                    .ToArray();
            }
        }
    }
}
