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
        //TODO: adicionar o ICollection de aplication no user
        // já implementado --  ApplicationViewModel.CollectionToViewModel(u.Applications)
        public LoggedUserViewModel(BugTracker.Domain.Entity.User u) : 
            this(u.IDUser, u.Nome, u.Email, u.Image, null, u.AccountConfirmed) {  }
    }
}