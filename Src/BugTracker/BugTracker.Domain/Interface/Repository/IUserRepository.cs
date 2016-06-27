﻿using BugTracker.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Domain.Interface.Repository
{
    public interface IUserRepository
    {
        User FindById(int id);
        User FindByEmail(string email);
        void Add(User user);
    }
}
