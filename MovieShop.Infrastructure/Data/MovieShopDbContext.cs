using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieShop.Core.Entities;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieShop.Infrastructure.Data
{
    public class MovieShopDbContext : DbContext
    {

        public MovieShopDbContext(DbContextOptions<MovieShopDbContext> options): base(options)
        { 
        
        }

        //Cause OnModelCreating is private so we need override it
        //Func<int, int, string> last parmate should be return type,  --> string mymethod(int, int)
        //if we have action(int, int) that will not work, should be void mr(int, int)
        /*Very Important*/
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>(ConfigureMovie);
            modelBuilder.Entity<Trailer>(ConfigureTrailer); 

            modelBuilder.Entity<MovieGenre>(ConfigureMovieGenre);
            modelBuilder.Entity<MovieGenre>()
                .HasOne(mg => mg.Movie)
                .WithMany(m => m.MovieGenres)
                .HasForeignKey(mg => mg.MovieId);
            modelBuilder.Entity<MovieGenre>()
                .HasOne(mg => mg.Genre)
                .WithMany(g => g.MovieGenres)
                .HasForeignKey(mg => mg.GenreId);

            modelBuilder.Entity<Cast>(ConfigureCast);
            
            modelBuilder.Entity<MovieCast>(ConfigureMovieCast);
            modelBuilder.Entity<MovieCast>()
                .HasOne(mc => mc.Movie)
                .WithMany(m => m.MovieCasts)
                .HasForeignKey(mc => mc.MovieId);
            modelBuilder.Entity<MovieCast>()
                .HasOne(mc => mc.Cast)
                .WithMany(c => c.MovieCasts)
                .HasForeignKey(mc => mc.CastId);

            modelBuilder.Entity<Crew>(ConfigureCrew);
            modelBuilder.Entity<MovieCrew>(ConfigureMovieCrew);
            modelBuilder.Entity<MovieCrew>()
                .HasOne(mcr => mcr.Movie)
                .WithMany(m => m.MovieCrews)
                .HasForeignKey(mcr => mcr.MovieId);
            modelBuilder.Entity<MovieCrew>()
                .HasOne(mcr => mcr.Crew)
                .WithMany(c => c.MovieCrews)
                .HasForeignKey(mc => mc.CrewId);

            modelBuilder.Entity<User>(ConfigureUser);
            modelBuilder.Entity<Review>(ConfigureReview);
            modelBuilder.Entity<Review>()
                .HasOne(r => r.Movie)
                .WithMany(m => m.Reviews)
                .HasForeignKey(r => r.MovieId);
            modelBuilder.Entity<Review>()
                .HasOne(r => r.User)
                .WithMany(u => u.Reviews)
                .HasForeignKey(r => r.UserId);

            modelBuilder.Entity<Purchase>(ConfigurePurchase);

        }

        private void ConfigurePurchase(EntityTypeBuilder<Purchase> builder)
        {
            builder.ToTable("Purchase");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.UserId);
            builder.Property(p => p.PurchaseNumber).HasDefaultValueSql("NEWID()");
            builder.Property(p => p.TotalPrice).IsRequired().HasColumnType("decimal(18, 2)");
            builder.Property(p => p.PurchaseDateTime).HasDefaultValueSql("getdate()");
            builder.Property(P => P.MovieId);

        }

        private void ConfigureReview(EntityTypeBuilder<Review> builder)
        {
            builder.ToTable("Review");
            builder.HasKey(r => new { r.MovieId, r.UserId });
            builder.Property(r => r.Rating).IsRequired().HasColumnType("decimal(5, 2)");
            builder.Property(r => r.ReviewText);
        }

        private void ConfigureUser(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.HasKey(u => u.Id);
            builder.Property(u => u.FirstName).HasMaxLength(128);
            builder.Property(u => u.LastName).HasMaxLength(128);
            builder.Property(u => u.DateOfBirth).HasDefaultValueSql("getdate()");
            builder.Property(u => u.Email).HasMaxLength(256);
            builder.Property(u => u.HashedPassword).HasMaxLength(1024);
            builder.Property(u => u.Salt).HasMaxLength(1024);
            builder.Property(u => u.PhoneNumber).HasMaxLength(16);
            //bit --> boolean
            builder.Property(u => u.TwoFactorEnabled).HasDefaultValue(true);
            builder.Property(u => u.LockoutEndDate).HasDefaultValueSql("getdate()");
            builder.Property(u => u.LastLoginDateTime).HasDefaultValueSql("getdate()");
            builder.Property(u => u.IsLocked).HasDefaultValue(true);
            builder.Property(u => u.AccessFailedCount).HasDefaultValue(0);
        }

        private void ConfigureMovieCrew(EntityTypeBuilder<MovieCrew> builder)
        {
            builder.ToTable("MovieCrew");
            builder.HasKey(mcr => new { mcr.MovieId, mcr.CrewId, mcr.Department, mcr.Job });
        }

        private void ConfigureCrew(EntityTypeBuilder<Crew> builder)
        {
            builder.ToTable("Crew");
            builder.HasKey(cr => cr.Id);
            builder.Property(cr => cr.Name).IsRequired().HasMaxLength(128);
            builder.Property(cr => cr.Gender);
            builder.Property(cr => cr.TmdbUrl);
            builder.Property(cr => cr.ProfilePath).HasMaxLength(2084);
        }

        private void ConfigureMovieCast(EntityTypeBuilder<MovieCast> builder)
        {
            builder.ToTable("MovieCast");
            builder.HasKey(mc => new { mc.MovieId, mc.CastId});
            builder.Property(mc => mc.Character).IsRequired().HasMaxLength(450);

        }

        private void ConfigureCast(EntityTypeBuilder<Cast> builder)
        {
            builder.ToTable("Cast");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).IsRequired().HasMaxLength(128);
            builder.Property(c => c.Gender);
            builder.Property(c => c.TmdbUrl);
            builder.Property(c => c.ProfilePath).HasMaxLength(2084);
        }

        private void ConfigureMovieGenre(EntityTypeBuilder<MovieGenre> builder)
        {
            builder.ToTable("MovieGenre");
            builder.HasKey(mg => new { mg.MovieId, mg.GenreId});
        }

        private void ConfigureTrailer(EntityTypeBuilder<Trailer> builder) 
        {
            builder.ToTable("Trailer");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.TrailerUrl).HasMaxLength(2084);
            builder.Property(t => t.Name).HasMaxLength(2084);
        }

        private void ConfigureMovie(EntityTypeBuilder<Movie> builder) 
        { 
            //Place to configure our Movie Entity 
            //part of floaAPI
            builder.ToTable("Movie");
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Title).IsRequired().HasMaxLength(256);
            builder.Property(m => m.Overview).HasMaxLength(4096);
            builder.Property(m => m.Tagline).HasMaxLength(512);
            builder.Property(m => m.ImdbUrl).HasMaxLength(2084);
            builder.Property(m => m.TmdbUrl).HasMaxLength(2084);
            builder.Property(m => m.PosterUrl).HasMaxLength(2084);
            builder.Property(m => m.BackdropUrl).HasMaxLength(2084);
            builder.Property(m => m.OriginalLanguage).HasMaxLength(64);
            builder.Property(m => m.Price).HasColumnType("decimal(5, 2)").HasDefaultValue(9.9m);
            builder.Property(m => m.CreatedDate).HasDefaultValueSql("getdate()");
        }

        public DbSet<Genre> Genres { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Trailer> Trailer { get; set; }
        public DbSet<MovieGenre> MovieGenres { get; set; }
        public DbSet<Cast> Casts { get; set; }
        public DbSet<MovieCast> MovieCasts { get; set; }
        public DbSet<Crew> Crews { get; set; }
        public DbSet<MovieCrew> MovieCrews { get; set; }
        public DbSet<Review> Reviews  { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
    }

    
}
