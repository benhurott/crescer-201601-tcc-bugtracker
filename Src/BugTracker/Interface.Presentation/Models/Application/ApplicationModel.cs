using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Interface.Presentation.Models
{
    public class ApplicationModel
    {
        public int? Id { get; set; }

        [Required]
        [DisplayName("Title")]
        [StringLength(50)]
        public string Title { get; set; }

        [Required]
        [DisplayName("Description")]
        [StringLength(100)]
        public string Description { get; set; }

        [Required]
        [DisplayName("Url Application")]
        [StringLength(100)]
        public string Url { get; set; }

        [Required]
        [DisplayName("Icon Application")]
        [StringLength(100)]
        public string Icon { get; set; }

        [Required]
        [DisplayName("Special Tag Error")]
        [StringLength(100)]
        public string Tag { get; set; }

        [Required]
        [DisplayName("Icon Application")]
        public HttpPostedFileBase File { get; set; }

    }
}