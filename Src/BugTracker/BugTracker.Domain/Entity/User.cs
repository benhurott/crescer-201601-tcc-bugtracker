using System;
using System.Collections.Generic;

namespace BugTracker.Domain.Entity
{
    public class User
    {
        public int IDUser { get; set; }
        public String Nome { get; set; }
        public String Email { get; set; }
        public String Password { get; set; }
        public String Image { get; set; }
        public virtual ICollection<Application> Applications { get; set; }
        public bool Active { get; set; }
        public bool AccountConfirmed { get; set; }

        public User() { }

        public User(String nome, String email, String Password, String Image, List<Application> applications, bool Active, bool AccountConfirmed)
        {
            this.Nome = nome;
            this.Email = email;
            this.Password = Password;
            this.Image = Image;
            this.Applications = applications;
            this.Active = Active;
            this.AccountConfirmed = AccountConfirmed;
        }

        public User(int id, String nome, String email, String password, String Image, List<Application> applications, bool active, bool accountConfirmed) 
            : this(nome, email, password, Image, applications,  active, accountConfirmed)
        {
            this.IDUser = id;
        }
    }
}
