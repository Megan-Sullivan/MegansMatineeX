// This file replaced OfficeAssignment from ContosoUniversity tutorial

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MegansMatineeX.Models
{
    public class SiteAssignment
    {
        [Key]
        public int ProducerID { get; set; }
        [StringLength(50)]
        [Display(Name = "Filming Location")]
        public string Location { get; set; }

        public Producer Producer { get; set; }
    }
}
