using BugTracker.Domain.Entity;
using BugTracker.Domain.Interface.Repository;
using BugTracker.Domain.Interface.Service;

namespace BugTracker.Domain.Service
{
    public class UserService : IUserService
    {
        IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public User FindById(int id)
        {
            return this.userRepository.FindById(id);
        }

        public void Add(User user)
        {
            userRepository.Add(user);
        }

        public User FindByEmail(string email)
        {
            return userRepository.FindByEmail(email);
        }
    }
}
