using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MegansMatineeX.Models.MovieViewModels
{
    public class ProducerIndexData
    {
        public IEnumerable<Producer> Producers { get; set; }
        public IEnumerable<Movie> Movies { get; set; }
        public IEnumerable<MovieCast> MovieCasts { get; set; }
        public IEnumerable<MovieDirector> MovieDirectors { get; set; }
    }
}
