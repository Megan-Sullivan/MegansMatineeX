// This file replaced Department from ContosoUniversity tutorial

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MegansMatineeX.Models
{
    public class Production
    {
        public int ProductionID { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public decimal Budget { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",
                       ApplyFormatInEditMode = true)]
        [Display(Name = "Filming Start Date")]
        public DateTime StartDate { get; set; }

        public int? ProducerID { get; set; }

        [Timestamp]
        public byte[] ConcurrencyToken { get; set; }

        public Producer Administrator { get; set; }
        public ICollection<Movie> Movies { get; set; }
    }
}
