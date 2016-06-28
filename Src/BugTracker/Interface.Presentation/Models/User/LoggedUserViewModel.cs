using Interface.Presentation.Models.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BugTracker.Domain.Entity;

namespace Interface.Presentation.Models.User
{
    public class LoggedUserViewModel
    {
        public int IDUser { get; private set; }
        public String Nome { get; private set; }
        public String Email { get; private set; }
        public String Image { get; private set; }
        public ICollection<ApplicationViewModel> Applications { get; private set; }
        public bool AccountConfirmed { get; private set; }

        public LoggedUserViewModel(int idUser,String nome,String email,String image,ICollection<ApplicationViewModel> applications,bool accountConfirmed)
        {
            this.IDUser = idUser;
            this.Nome = nome;
            this.Email = email;
            this.Image = image;
            this.Applications = applications;
            this.AccountConfirmed = accountConfirmed;
        }

        public LoggedUserViewModel(BugTracker.Domain.Entity.User u) : 
            this(u.IDUser, u.Nome, u.Email, u.Image, ApplicationViewModel.CollectionToViewModel(u.Applications), u.AccountConfirmed) {  }
    }
}