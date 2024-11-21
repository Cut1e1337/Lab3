using Microsoft.EntityFrameworkCore;
using Core.Models;

namespace lab3.Repositories.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<ContentRating> ContentRatings { get; set; }
        public DbSet<Application> Applications { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Installation> Installations { get; set; }
        public DbSet<AppType> AppTypes { get; set; }
        public DbSet<Pricing> Pricings { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<AppGenre> AppGenres { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=CUT1E228;Database=Lab3;Integrated Security=True;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Categories
            modelBuilder.Entity<Category>()
                .HasKey(c => c.CategoryID);

            modelBuilder.Entity<Category>()
                .Property(c => c.CategoryName)
                .IsRequired()
                .HasMaxLength(100);

            // ContentRatings
            modelBuilder.Entity<ContentRating>()
                .HasKey(cr => cr.ContentRatingID);

            modelBuilder.Entity<ContentRating>()
                .Property(cr => cr.RatingName)
                .IsRequired()
                .HasMaxLength(50);

            // Applications
            modelBuilder.Entity<Application>()
                .HasKey(a => a.ApplicationID);

            modelBuilder.Entity<Application>()
                .Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(255);

            modelBuilder.Entity<Application>()
                .HasOne(a => a.Category)
                .WithMany(c => c.Applications)
                .HasForeignKey(a => a.CategoryID);

            modelBuilder.Entity<Application>()
                .HasOne(a => a.ContentRating)
                .WithMany(cr => cr.Applications)
                .HasForeignKey(a => a.ContentRatingID);

            // Reviews
            modelBuilder.Entity<Review>()
                .HasKey(r => r.ReviewID);

            modelBuilder.Entity<Review>()
                .Property(r => r.Rating)
                .IsRequired()
                .HasPrecision(2, 1);

            modelBuilder.Entity<Review>()
                .Property(r => r.ReviewCount)
                .IsRequired();

            modelBuilder.Entity<Review>()
                .HasOne(r => r.Application)
                .WithMany(a => a.Reviews)
                .HasForeignKey(r => r.ApplicationID);

            // Installations
            modelBuilder.Entity<Installation>()
                .HasKey(i => i.InstallationID);

            modelBuilder.Entity<Installation>()
                .Property(i => i.Installs)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Installation>()
                .HasOne(i => i.Application)
                .WithMany(a => a.Installations)
                .HasForeignKey(i => i.ApplicationID);

            // AppTypes
            modelBuilder.Entity<AppType>()
                .HasKey(at => at.TypeID);

            modelBuilder.Entity<AppType>()
                .Property(at => at.TypeName)
                .IsRequired()
                .HasMaxLength(50);

            // Pricing
            modelBuilder.Entity<Pricing>()
                .HasKey(p => p.PricingID);

            modelBuilder.Entity<Pricing>()
                .Property(p => p.Price)
                .IsRequired()
                .HasPrecision(5, 2);

            modelBuilder.Entity<Pricing>()
                .HasOne(p => p.Application)
                .WithMany(a => a.Pricings)
                .HasForeignKey(p => p.ApplicationID);

            modelBuilder.Entity<Pricing>()
                .HasOne(p => p.AppType)
                .WithMany(at => at.Pricings)
                .HasForeignKey(p => p.TypeID);

            // Genres
            modelBuilder.Entity<Genre>()
                .HasKey(g => g.GenreID);

            modelBuilder.Entity<Genre>()
                .Property(g => g.GenreName)
                .IsRequired()
                .HasMaxLength(100);

            // AppGenres
            modelBuilder.Entity<AppGenre>()
                .HasKey(ag => ag.AppGenreID);

            modelBuilder.Entity<AppGenre>()
                .HasOne(ag => ag.Application)
                .WithMany(a => a.AppGenres)
                .HasForeignKey(ag => ag.ApplicationID);

            modelBuilder.Entity<AppGenre>()
                .HasOne(ag => ag.Genre)
                .WithMany(g => g.AppGenres)
                .HasForeignKey(ag => ag.GenreID);

            // UserRoles
            modelBuilder.Entity<UserRole>()
                .HasKey(ur => ur.RoleID);

            modelBuilder.Entity<UserRole>()
                .Property(ur => ur.RoleName)
                .IsRequired()
                .HasMaxLength(50);

            // Users
            modelBuilder.Entity<User>()
                .HasKey(u => u.UserID);

            modelBuilder.Entity<User>()
                .Property(u => u.Username)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<User>()
                .Property(u => u.PasswordHash)
                .IsRequired()
                .HasMaxLength(255);

            modelBuilder.Entity<User>()
                .Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<User>()
                .HasOne(u => u.Role)
                .WithMany(ur => ur.Users)
                .HasForeignKey(u => u.RoleID);

            base.OnModelCreating(modelBuilder);
        }
    }
}
