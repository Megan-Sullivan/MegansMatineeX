using System.ComponentModel.DataAnnotations;

namespace MegansMatineeX.Models
{
    public enum Rank2
    {
        A, B, C, D, F
    }
    public class MovieDirector
    {
        public int MovieDirectorID { get; set; }
        public int MovieID { get; set; }
        //public int LeadActID { get; set; }
        public int DirectorID { get; set; }

        [DisplayFormat(NullDisplayText = "Not Ranked")]
        public Rank2? Rank2 { get; set; }
        public Movie Movie { get; set; }
        //public LeadAct LeadAct { get; set; }
        public Director Director { get; set; }
    }
}
