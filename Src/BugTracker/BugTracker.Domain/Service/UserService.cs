using System;
using BugTracker.Domain.Entity;
using BugTracker.Domain.Interface.Repository;
using BugTracker.Domain.Interface.Service;
using System.Security.Cryptography;
using System.Text;

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

        public User Add(User user)
        {
            return userRepository.Add(user);
        }

        public User FindByEmail(string email)
        {
            return userRepository.FindByEmail(email);
        }

        public User FindByAuthentication(string email, string password)
        {
            return userRepository.FindByAuthentication(email, Encrypt(password));
        }

        //TODO: Trocar o metodo de criptografia
        private string Encrypt(string password)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder sBuilder = new StringBuilder();

                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }

                return sBuilder.ToString();
            }
        }
    }
}
