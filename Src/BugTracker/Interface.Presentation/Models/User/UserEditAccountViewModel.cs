using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Interface.Presentation.Models.User
{
    public class UserEditAccountViewModel
    {
        public int? Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [DisplayName("E-mail")]
        [EmailAddress]
        public string Email { get; set; }

        public String Image { get; set; }

        [DisplayName("New Photo")]
        public HttpPostedFileBase File { get; set; }
    }
}