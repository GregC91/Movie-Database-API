using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MoviesApi.DbModels
{

        public class DataContext : DbContext
        {
            public DataContext(DbContextOptions<DataContext> options)
                : base(options)
            {
            }

            public DbSet<Genre> Genres { get; set; }
            public DbSet<Movie> Movies { get; set; }
            public DbSet<MovieGenre> MovieGenres { get; set; }
            public DbSet<User> Users { get; set; }
            public DbSet<Rating> Ratings { get; set; }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<MovieGenre>()
                    .HasKey(o => new { o.MovieId, o.GenreId });

                modelBuilder.Entity<MovieGenre>()
                    .HasOne(m => m.Movie)
                    .WithMany(g => g.MovieGenres)
                    .HasForeignKey(m => m.MovieId);

                modelBuilder.Entity<MovieGenre>()
                    .HasOne(g => g.Genre)
                    .WithMany(m => m.MovieGenres)
                    .HasForeignKey(g => g.GenreId);
            }
        }
}

