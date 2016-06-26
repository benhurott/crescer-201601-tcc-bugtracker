using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Domain.Entity
{
    public class User
    {
        private int Id { get; set; }
        private String Nome { get; set; }
        private String Email { get; set; }
        private String Password { get; set; }
        private String Image { get; set; }
        private bool Active { get; set; }
        private bool AccountConfirmed { get; set; }

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
