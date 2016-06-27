using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Domain.Entity
{
    public class User
    {
        public int Id { get; set; }
        public String Nome { get; set; }
        public String Email { get; set; }
        public String Password { get; set; }
        public String Image { get; set; }
        public bool Active { get; set; }
        public bool AccountConfirmed { get; set; }

        private User() { }

        public User(String nome, String email, String Password, String Image, bool Active, bool AccountConfirmed)
        {
            this.Nome = nome;
            this.Email = email;
            this.Password = Password;
            this.Image = Image;
            this.Active = Active;
            this.AccountConfirmed = AccountConfirmed;
        }

        public User(int id, String nome, String email, String Password, String Image, bool Active, bool AccountConfirmed) 
            : this(nome, email, Password, Image, Active, AccountConfirmed)
        {
            this.Id = id;
        }
    }
}
