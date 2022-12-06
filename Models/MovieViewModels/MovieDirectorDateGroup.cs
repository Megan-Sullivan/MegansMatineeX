using System;
using System.ComponentModel.DataAnnotations;

namespace MegansMatineeX.Models.MovieViewModels
{
    public class MovieDirectorDateGroup
    {
        [DataType(DataType.Date)]
        public DateTime? MovieDirectorDate { get; set; }

        public int DirectorCount { get; set; }
    }
}
