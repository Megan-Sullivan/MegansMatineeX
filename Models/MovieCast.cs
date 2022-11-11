using System.ComponentModel.DataAnnotations;

namespace MegansMatineeX.Models
{
    public enum Rank
    {
        A, B, C, D, F
    }
    public class MovieCast
    {
        public int MovieCastID { get; set; }
        public int MovieID { get; set; }
        public int LeadActID { get; set; }
        public int DirectorID { get; set; }
        [DisplayFormat(NullDisplayText = "Not Ranked")]
        public Rank? Rank { get; set; }

        public Movie Movie { get; set; }
        public LeadAct LeadAct { get; set; }
        public Director Director { get; set; }
    }
}
