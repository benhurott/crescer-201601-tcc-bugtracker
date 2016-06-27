using Interface.Presentation.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Interface.Presentation.Models.Application
{
    public class ApplicationViewModel
    {
        public int IDApplication { get; private set; }
        public String Title { get; private set; }
        public String Description { get; private set; }
        public String Url { get; private set; }
        public String Image { get; private set; }
        public String SpecialTag { get; private set; }
        public LoggedUserViewModel User { get; private set; }

        public ApplicationViewModel(int idApplication,String title,String description,String url,String image,String specialTag,LoggedUserViewModel user)
        {
            this.IDApplication = idApplication;
            this.Title = title;
            this.Description = description;
            this.Url = url;
            this.Image = image;
            this.SpecialTag = specialTag;
            this.User = user;
        }
    }
}