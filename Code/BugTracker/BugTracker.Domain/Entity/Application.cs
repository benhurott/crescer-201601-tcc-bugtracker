using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Domain.Entity
{
    public class Application
    {
        private int Id { get; set; }
        private String Title { get; set; }
        private String Description { get; set; }
        private String Url { get; set; }
        private bool Active { get; set; }
        private String Image { get; set; }
        private Tag SpecialTag { get; set; }

        private Application() { }

        public Application(String title, String description, String url, bool active, String image, Tag tag)
        {
            this.Title = title;
            this.Description = description;
            this.Url = url;
            this.Active = active;
            this.Image = image;
            this.SpecialTag = tag;
        }

        public Application(int id, String title, String description, String url, bool active, String image, Tag tag)
            : this(title, description, url, active, image, tag)
        {
            this.Id = Id;
        }
    }
}
