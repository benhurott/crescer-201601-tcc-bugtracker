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
            return this.activationRepository.FindByCode(code);
        }

        public void Add(Activation activation)
        {
            this.activationRepository.Add(activation);
        }
        public void Remove(int id)
        {
            this.activationRepository.Remove(id);
        }
    }
}
