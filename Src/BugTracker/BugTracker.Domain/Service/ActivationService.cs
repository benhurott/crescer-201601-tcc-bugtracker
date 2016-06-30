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
    public class ActivationService : IActivationService
    {
        IActivationRepository activationRepository;

        public ActivationService(IActivationRepository activationRepository)
        {
            this.activationRepository = activationRepository;
        }

        public Activation FindByCode(string code)
        {
            var activation = this.activationRepository.FindByCode(code);
            if (activation != null && activation.DateRequest.CompareTo(DateTime.Now) < 1)
                return activation;
            return null;
        }

        public void Add(Activation activation)
        {
            this.activationRepository.Add(activation);
        }
    }
}
