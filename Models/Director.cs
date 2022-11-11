﻿using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MegansMatineeX.Models
{
    public class Director
    {
        public int ID { get; set; }

        [Display(Name = "Director Name"), StringLength(60, MinimumLength = 3), Required]
        public string DirectorName { get; set; }

        [DataType(DataType.Date)]
        public DateTime Birthdate { get; set; }

        [Display(Name = "Director Details"), StringLength(10000, MinimumLength = 3)]
        public string DirectorDetails { get; set; }

        [Display(Name = "Additional Info"), StringLength(10000, MinimumLength = 3), DataType(DataType.Url)]
        public string AdditionalInfo { get; set; }

        public ICollection<MovieCast> MovieCasts { get; set; }
    }
}
