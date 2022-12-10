// This file replaced instructor from ContosoUniversity tutorial

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace MegansMatineeX.Models
{
    public class Producer
    {
        public int ID { get; set; }

        [Required]
        [Column("ProducerName")]
        [Display(Name = "Producer Name")]
        [StringLength(50)]
        public string ProducerName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Establishment Date")]
        public DateTime EstablishmentDate { get; set; }

        public ICollection<Movie> Movies { get; set; }
        public SiteAssignment SiteAssignment { get; set; }
    }
}
