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

        public DbSet<MegansMatineeX.Models.Movie> Movies { get; set; }
        public DbSet<MegansMatineeX.Models.MovieCast> MovieCasts { get; set; }
        public DbSet<MegansMatineeX.Models.MovieDirector> MovieDirectors { get; set; }
        public DbSet<MegansMatineeX.Models.LeadAct> LeadActs { get; set; }
        public DbSet<MegansMatineeX.Models.Director> Directors { get; set; }
        
        
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>().ToTable(nameof(Movie))
                .HasMany(c => c.Directors)
                .WithMany(i => i.Movies);
            modelBuilder.Entity<LeadAct>().ToTable(nameof(LeadAct));
            modelBuilder.Entity<Director>().ToTable(nameof(Director));
        }
    }
}
