using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MegansMatineeX.Models.MovieViewModels
{
    public class LeadActIndexData
    {
        public IEnumerable<LeadAct> LeadActs { get; set; }
        public IEnumerable<Movie> Movies { get; set; }
        public IEnumerable<MovieCast> MovieCasts { get; set; }
    }
}
