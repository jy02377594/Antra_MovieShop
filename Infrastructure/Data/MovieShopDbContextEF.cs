using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Infrastructure.Data
{
    public class MovieShopDbContextEF : DbContext
    {
        public MovieShopDbContextEF(DbContextOptions<MovieShopDbContextEF> options) : base(options)
        {

        }
        // DbSets as properties
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Trailer> Trailers { get; set; }
        public DbSet<MovieGenre> MovieGenres { get; set; }
        public DbSet<Crew> Crews { get; set; }
        public DbSet<MovieCrew> MovieCrews { get; set; }
        public DbSet<Cast> Casts { get; set; }
        public DbSet<MovieCast> MovieCasts { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>(ConfigureMovie);
            modelBuilder.Entity<User>(ConfigureUser);
            modelBuilder.Entity<Trailer>(ConfigureTrailer);
            modelBuilder.Entity<MovieGenre>(ConfigureMovieGenre);
            modelBuilder.Entity<MovieCrew>(ConfigureMovieCrew);
            modelBuilder.Entity<MovieCast>(ConfigureMovieCast);
            modelBuilder.Entity<Review>(ConfigureReview);
            modelBuilder.Entity<UserRole>(ConfigureUserRole);
            modelBuilder.Entity<Favorite>(ConfigureFavorite);
            modelBuilder.Entity<Purchase>(ConfigurePurchase);
            modelBuilder.Entity<Role>().ToTable("Role");
            modelBuilder.Entity<Cast>().ToTable("Cast");
            modelBuilder.Entity<Crew>().ToTable("Crew");
        }



        private void ConfigureUserRole(EntityTypeBuilder<UserRole> obj)
        {
            obj.ToTable("UserRole");
            obj.HasKey(ur => new { ur.RoleId, ur.UserId });
            obj.HasOne(ur => ur.User)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(ur => ur.UserId);

            obj.HasOne(ur => ur.Role)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(ur => ur.RoleId);
        }

        private void ConfigurePurchase(EntityTypeBuilder<Purchase> obj)
        {
            obj.ToTable("Purchase");
            obj.HasOne(p => p.Movie)
                .WithMany(m => m.Purchases)
                .HasForeignKey(p => p.MovieId);

            obj.HasOne(p => p.User)
                .WithMany(u => u.Purchases)
                .HasForeignKey(p => p.UserId);

            obj.Property(p => p.TotalPrice).HasColumnType("decimal(18,2)").HasDefaultValue(9.9m);
        }

        private void ConfigureFavorite(EntityTypeBuilder<Favorite> obj)
        {
            obj.ToTable("Favorite");
            obj.HasKey(f => f.Id);
            obj.HasOne(f => f.Movie)
               .WithMany(m => m.Favorites)
               .HasForeignKey(f => f.MovieId);

            obj.HasOne(f => f.User)
                .WithMany(u => u.Favorites)
                .HasForeignKey(f => f.UserId);
        }

        private void ConfigureReview(EntityTypeBuilder<Review> obj)
        {
            obj.ToTable("Review");
            obj.HasKey(r => new { r.MovieId, r.UserId });
            obj.HasOne(r => r.Movie)
                .WithMany(m => m.Reviews)
                .HasForeignKey(r => r.MovieId);
            obj.HasOne(r => r.User)
                .WithMany(u => u.Reviews)
                .HasForeignKey(r => r.UserId);

            obj.Property(r => r.Rating).HasColumnType("decimal(3, 2)").HasDefaultValue(9.9m);
        }

        private void ConfigureMovieCast(EntityTypeBuilder<MovieCast> builder)
        {
            builder.ToTable("MovieCast");
            builder.HasKey(mc => new { mc.CastId, mc.MovieId, mc.Character });
            builder.HasOne(mc => mc.Movie)
                .WithMany(m => m.MovieCasts)
                .HasForeignKey(mc => mc.MovieId);
            builder.HasOne(mc => mc.Cast)
                .WithMany(c => c.MovieCasts)
                .HasForeignKey(mc => mc.CastId);
        }

        private void ConfigureMovieCrew(EntityTypeBuilder<MovieCrew> builder)
        {
            builder.ToTable("MovieCrew");
            builder.HasKey(mc => new { mc.MovieId, mc.CrewId, mc.Department, mc.Job });
            builder.HasOne(mc => mc.Crew)
                .WithMany(c => c.MovieCrews)
                .HasForeignKey(mc => mc.CrewId);
            builder.HasOne(mc => mc.Movie)
                .WithMany(m => m.MovieCrews)
                .HasForeignKey(mc => mc.MovieId);
        }

        private void ConfigureMovieGenre(EntityTypeBuilder<MovieGenre> builder)
        {
            builder.ToTable("MovieGenre");
            builder.HasKey(mg => new { mg.GenreId, mg.MovieId });
            builder.HasOne(mg => mg.Movie)
                .WithMany(m => m.MovieGenres)
                .HasForeignKey(mg => mg.MovieId);
            builder.HasOne(mg => mg.Genre)
                .WithMany(g => g.MovieGenres)
                .HasForeignKey(mg => mg.GenreId);
        }

        private void ConfigureTrailer(EntityTypeBuilder<Trailer> builder)
        {
            builder.ToTable("Trailer");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.TrailerUrl).HasMaxLength(2048);
            builder.Property(t => t.Name).HasMaxLength(2048);
        }

        private void ConfigureUser(EntityTypeBuilder<User> obj)
        {
            obj.ToTable("User");
            obj.HasKey(u => u.Id);
        }

        private void ConfigureMovie(EntityTypeBuilder<Movie> builder)
        {
            // sepcify all the Fluent API rules for this model
            builder.ToTable("Movie");
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Title).HasMaxLength(256).IsRequired();
            builder.Property(m => m.Overview).HasMaxLength(4096);
            builder.Property(m => m.Tagline).HasMaxLength(512);
            builder.Property(m => m.ImdbUrl).HasMaxLength(2084);
            builder.Property(m => m.TmdbUrl).HasMaxLength(2084);
            builder.Property(m => m.PosterUrl).HasMaxLength(2084);
            builder.Property(m => m.BackdropUrl).HasMaxLength(2084);
            builder.Property(m => m.OriginalLanguage).HasMaxLength(64);
            builder.Property(m => m.Price).HasColumnType("decimal(5, 2)").HasDefaultValue(9.9m);
            builder.Property(m => m.Budget).HasColumnType("decimal(18, 4)").HasDefaultValue(9.9m);
            builder.Property(m => m.Revenue).HasColumnType("decimal(18, 4)").HasDefaultValue(9.9m);
            builder.Property(m => m.CreatedDate).HasDefaultValueSql("getdate()");
            builder.Ignore(m => m.Rating); //Ignore意味着不在数据库建立这个字段
        }
    }
}
