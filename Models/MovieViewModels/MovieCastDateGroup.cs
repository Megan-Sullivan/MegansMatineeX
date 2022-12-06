using System;
using System.ComponentModel.DataAnnotations;

namespace MegansMatineeX.Models.MovieViewModels
{
    public class MovieCastDateGroup
    {
        [DataType(DataType.Date)]
        public DateTime? MovieCastDate { get; set; }

        public int LeadActCount { get; set; }
    }
}
