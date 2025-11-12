using Microsoft.EntityFrameworkCore;
using backend.Models;

namespace backend.Data
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieUser> MovieUsers { get; set; }
        public DbSet<Favorites> FavoritesLists { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // One-to-many: Category -> Movies
            modelBuilder.Entity<Category>()
                .HasMany(c => c.Movies)
                .WithOne(m => m.Category)
                .HasForeignKey(m => m.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            // Many-to-many: Movie <-> MovieUser
            modelBuilder.Entity<Movie>()
                .HasMany(m => m.MovieUsers)
                .WithMany(mu => mu.Movies)
                .UsingEntity<Dictionary<string, object>>(
                    "MovieMovieUsers",
                    j => j.HasOne<MovieUser>().WithMany().HasForeignKey("MovieUserId"),
                    j => j.HasOne<Movie>().WithMany().HasForeignKey("MovieId")
                );

            // One-to-many: MovieUser -> Favorites
            modelBuilder.Entity<MovieUser>()
                .HasMany(mu => mu.FavoritesLists)
                .WithOne(f => f.MovieUser)
                .HasForeignKey(f => f.MovieUserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Many-to-many: Favorites <-> Movie
            modelBuilder.Entity<Favorites>()
                .HasMany(f => f.Movies)
                .WithMany(m => m.FavoritesLists)
                .UsingEntity<Dictionary<string, object>>(
                    "FavoritesMovies",
                    j => j.HasOne<Movie>().WithMany().HasForeignKey("MovieId"),
                    j => j.HasOne<Favorites>().WithMany().HasForeignKey("FavoritesId")
                );
        }
    }
}
// Checklist (x for done):
// - [x] Create class structure
// - [x] Implement navigation properties if needed
// - [x] Add data annotations for validation
// - [x] Configure relationships in OnModelCreating
// - [x] Add necessary using directives
