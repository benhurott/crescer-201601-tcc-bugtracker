using BugTracker.Domain.Entity;
using BugTracker.Domain.Interface.Repository;
using BugTracker.Domain.Interface.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Domain.Service
{
    public class UserRecoveryService : IUserRecoveryService
    {
        IUserRecoveryRepository userRecoveryRepository;

        public UserRecoveryService(IUserRecoveryRepository applicationRepository)
        {
            this.userRecoveryRepository = applicationRepository;
        }

        public void Add(UserRecovery userRecovery)
        {
            userRecoveryRepository.Add(userRecovery);
        }


        public UserRecovery FindByEmail(string email)
        {
            return userRecoveryRepository.FindByEmail(email);
        }
    }
}
