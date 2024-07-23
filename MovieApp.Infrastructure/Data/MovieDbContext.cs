using Microsoft.EntityFrameworkCore;
using MovieApp.Core.Entities;

namespace MovieApp.Infrastructure.Data;

public class MovieDbContext : DbContext
{
    public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options)
    {
    }

    public DbSet<Movie> Movies { get; set; }
    public DbSet<Cast> Casts { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<MovieCast> MovieCasts { get; set; }
    public DbSet<MovieGenre> MovieGenres { get; set; }
    public DbSet<Trailer> Trailers { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
    public DbSet<Favorite> Favorites { get; set; }
    public DbSet<Purchase> Purchases { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<Role> Roles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure MovieGenre
        modelBuilder.Entity<MovieGenre>()
            .HasOne(mg => mg.Movie)
            .WithMany(m => m.MovieGenres)
            .HasForeignKey(mg => mg.MovieId);
        modelBuilder.Entity<MovieGenre>()
            .HasOne(mg => mg.Genre)
            .WithMany(g => g.MovieGenres)
            .HasForeignKey(mg => mg.GenreId);
        
        // Configure MovieCast
        modelBuilder.Entity<MovieCast>()
            .HasKey(mc => new { mc.MovieId, mc.CastId });
        // MovieId Foreign Key
        modelBuilder.Entity<MovieCast>()
            .HasOne(mc => mc.Movie)
            .WithMany(m => m.MovieCasts)
            .HasForeignKey(mc => mc.MovieId);
        // CastId Foreign Key
        modelBuilder.Entity<MovieCast>()
            .HasOne(mc => mc.Cast)
            .WithMany(c => c.MovieCasts)
            .HasForeignKey(mc => mc.CastId);

        // Configure Trailer
        modelBuilder.Entity<Trailer>()
            .HasKey(t => t.Id)
            .HasName("PK_Trailers_Id");
        // MovieId Foreign Key
        modelBuilder.Entity<Trailer>()
            .HasOne(t => t.Movie)
            .WithMany(m => m.Trailers)
            .HasForeignKey(t => t.MovieId);
        
        // Configure Favorite
        modelBuilder.Entity<Favorite>()
            .HasOne(f => f.User)
            .WithMany(u => u.Favorites)
            .HasForeignKey(f => f.UserId);
        modelBuilder.Entity<Favorite>()
            .HasOne(f => f.Movie)
            .WithMany(m => m.Favorites)
            .HasForeignKey(f => f.MovieId);
        
        // Configure UserRole
        modelBuilder.Entity<UserRole>()
            .HasOne(ur => ur.User)
            .WithMany(r => r.UserRoles)
            .HasForeignKey(ur => ur.UserId);
        modelBuilder.Entity<UserRole>()
            .HasOne(ur => ur.Role)
            .WithMany(r => r.UserRoles)
            .HasForeignKey(ur => ur.RoleId);
        
        // Configure Purchase
        modelBuilder.Entity<Purchase>()
            .HasOne(p => p.User)
            .WithMany(u => u.Purchases)
            .HasForeignKey(p => p.UserId);
        modelBuilder.Entity<Purchase>()
            .HasOne(p => p.Movie)
            .WithMany(m => m.Purchases)
            .HasForeignKey(p => p.MovieId);
        
        // Configure Review
        modelBuilder.Entity<Review>()
            .HasOne(r => r.User)
            .WithMany(u => u.Reviews)
            .HasForeignKey(r => r.UserId);
        modelBuilder.Entity<Review>()
            .HasOne(r => r.Movie)
            .WithMany(m => m.Reviews)
            .HasForeignKey(r => r.MovieId);
    }
}