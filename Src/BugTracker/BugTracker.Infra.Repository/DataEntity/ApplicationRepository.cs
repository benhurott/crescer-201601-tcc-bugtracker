using BugTracker.Domain.Interface.Repository;
using System.Linq;
using BugTracker.Domain.Entity;
using System.Collections.Generic;
using System;

namespace BugTracker.Infra.Repository.DataEntity
{
    public class ApplicationRepository : IApplicationRepository
    {
        public ICollection<Application> FindByIDUser(int IDUser)
        {
            using (var db = new DataContext())
            {
                return db.Application.AsNoTracking().Where(_ => _.IDUser == IDUser).ToList();
            }
        }

        public void Add(Application application)
        {
            using (var db = new DataContext())
            {
                db.Entry<Application>(application).State = System.Data.Entity.EntityState.Added;
                db.Entry<User>(application.User).State = System.Data.Entity.EntityState.Unchanged;
                db.SaveChanges();
            }
        }

        public Application FindByUrl(string url)
        {
            using (var db = new DataContext())
            {
                return db.Application
                    .Include("User")
                    .AsNoTracking()
                    .FirstOrDefault(_ => _.Url == url);
            }

        }

        public void Edit(Application application)
        {
            throw new NotImplementedException();
        }

        public Application FindById(int id)
        {
            using (var db = new DataContext())
            {
                return db.Application.AsNoTracking().FirstOrDefault(_ => _.IDUser == id);
            }
        }
    }
}
