using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Domain.Entity
{
    public class Application
    {
        public int Id { get; private set; }
        public String Title { get; private set; }
        public String Description { get; private set; }
        public String Url { get; private set; }
        public bool Active { get; private set; }
        public String Image { get; private set; }
        public Tag SpecialTag { get; private set; }
        public virtual User User { get; private set; }

        private Application() { }

        public Application(String title, String description, String url, bool active, String image, Tag tag, User user)
        {
            this.Title = title;
            this.Description = description;
            this.Url = url;
            this.Active = active;
            this.Image = image;
            this.SpecialTag = tag;
            this.User = user;
        }

        public Application(int id, String title, String description, String url, bool active, String image, Tag tag, User user)
            : this(title, description, url, active, image, tag, user)
        {
            this.Id = Id;
        }
    }
}
