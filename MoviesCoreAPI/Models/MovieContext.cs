using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MoviesCoreAPI.Models
{
    public partial class MovieContext : DbContext
    {
        public MovieContext()
        {
        }

        public MovieContext(DbContextOptions<MovieContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Movies> Movies { get; set; }
        public virtual DbSet<Records> Records { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=HBSTUDENT48\\SQLEXPRESS;Database=MoviiumDB;Trusted_Connection=True;");
                optionsBuilder.UseLazyLoadingProxies();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>()
                .HasIndex(p => new { p.Email, p.Username })
                .IsUnique(true);
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Movies>(entity =>
        //    {
        //        entity.HasKey(e => e.MovieId);

        //        entity.Property(e => e.ImdbRating).HasColumnName("imdbRating");
        //    });

        //    modelBuilder.Entity<Records>(entity =>
        //    {
        //        entity.HasKey(e => e.RecordId);

        //        entity.HasIndex(e => e.MovieId);

        //        entity.HasIndex(e => e.UserId);

        //        entity.HasOne(d => d.Movie)
        //            .WithMany(p => p.Records)
        //            .HasForeignKey(d => d.MovieId);

        //        entity.HasOne(d => d.User)
        //            .WithMany(p => p.Records)
        //            .HasForeignKey(d => d.UserId);
        //    });

        //    modelBuilder.Entity<Users>(entity =>
        //    {
        //        entity.HasKey(e => e.UserId);
        //    });

        //    OnModelCreatingPartial(modelBuilder);
        //}

        //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
