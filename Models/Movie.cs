// Replaces Course
using Microsoft.CodeAnalysis;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MegansMatineeX.Models
{
    public enum GenreType
    {
        Action,
        Anime,
        British,
        Classic,
        Comedy,
        Crime,
        Docuseries,
        Drama,
        Fantasy,
        Horror,
        International,
        Kids,
        LGBTQ,
        Mystery,
        Nature,
        Reality,
        Romance,
        Science,
        SciFi,
        Spanish,
        Teen,
        Thriller,
        Western
    }

    public enum RatingType
    {
        G,
        PG,
        [Display(Name = "PG-13")] PG13,
        R,
        [Display(Name = "NC-17")] NC17,
        [Display(Name = "TV-G")] TVG,
        [Display(Name = "TV-PG")] TVPG,
        [Display(Name = "TV-14")] TV14,
        [Display(Name = "TV-MA")] TVMA,
        [Display(Name = "Not Rated")] NA
    }

    public class Movie
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Number")]
        public int MovieID { get; set; }

        [StringLength(60, MinimumLength = 3), Required]
        public string Title { get; set; }

        [StringLength(60, MinimumLength = 3)]
        public string Director { get; set; }

        [Display(Name = "Lead Actor/Actress"), StringLength(60, MinimumLength = 3)]
        public string LeadAct { get; set; }

        [Display(Name = "Release Date"), DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        [Display(Name = "Where To Watch"), StringLength(60, MinimumLength = 3), DataType(DataType.Url)]
        public string WhereToWatch { get; set; }

        //[RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$"), Required, StringLength(30)]
        public GenreType Genre { get; set; }

        //[RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$"), StringLength(5), Required]
        public RatingType Rating { get; set; }

        [StringLength(10000, MinimumLength = 3)]
        public string Review { get; set; }

        // Replacing Department
        public int ProductionID { get; set; }
        public Production Production { get; set; } 

        public ICollection<MovieCast> MovieCasts { get; set; }

        public ICollection<MovieDirector> MovieDirectors { get; set; }
        //public ICollection<Director> Directors { get; set; }
        public ICollection<Producer> Producers { get; set; }
    }
}