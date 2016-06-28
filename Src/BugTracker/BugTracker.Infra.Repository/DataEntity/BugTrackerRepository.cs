﻿using BugTracker.Domain.Interface.Repository;
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
                db.SaveChanges();
            }
        }
    }
}
