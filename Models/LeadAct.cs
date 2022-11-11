using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MegansMatineeX.Models
{
    public class LeadAct
    {
        public int ID { get; set; }

        [Display(Name = "Lead Actor/Actress"), StringLength(60, ErrorMessage = "Name cannot be shorter than 3 characters.", MinimumLength = 3), Required]
        public string LeadActName { get; set; }

        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Birthdate { get; set; }

        [Display(Name = "Actor/Actress Details"), StringLength(10000, MinimumLength = 3)]
        public string LeadActDetails { get; set; }

        [Display(Name = "Additional Info"), StringLength(10000, MinimumLength = 3), DataType(DataType.Url)]
        public string AdditionalInfo { get; set; }

        public ICollection<MovieCast> MovieCasts { get; set; }
    }
}
