using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MegansMatineeX.Models;

namespace MegansMatineeX.Data
{
    public class MegansMatineeXContext : DbContext
    {
        public MegansMatineeXContext (DbContextOptions<MegansMatineeXContext> options)
            : base(options)
        {
        }

        public DbSet<MegansMatineeX.Models.LeadAct> LeadActs { get; set; }
        public DbSet<MegansMatineeX.Models.Director> Directors { get; set; }
        public DbSet<MegansMatineeX.Models.MovieCast> MovieCasts { get; set; }
        public DbSet<MegansMatineeX.Models.Movie> Movies { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>().ToTable("Movie");
            modelBuilder.Entity<MovieCast>().ToTable("MovieCast");
            modelBuilder.Entity<LeadAct>().ToTable("LeadAct");
            modelBuilder.Entity<Director>().ToTable("Director");
        }
    }
}
