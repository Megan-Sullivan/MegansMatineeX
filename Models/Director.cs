// First of two files replacing Student
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MegansMatineeX.Models
{
    public class Director
    {
        public int ID { get; set; }

        [Display(Name = "Director Name"), StringLength(60, ErrorMessage = "Name cannot be shorter than 3 characters.", MinimumLength = 3), Required]
        public string DirectorName { get; set; }

        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Birthdate { get; set; }

        [Display(Name = "Director Details"), StringLength(10000, MinimumLength = 3)]
        public string DirectorDetails { get; set; }

        [Display(Name = "Additional Info"), StringLength(10000, MinimumLength = 3), DataType(DataType.Url)]
        public string AdditionalInfo { get; set; }

        public ICollection<MovieDirector> MovieDirectors { get; set; }
        //public ICollection<Movie> Movies { get; set; }
    }
}
