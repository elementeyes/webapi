using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DB.Models
{
    public partial class moviesContext : DbContext
    {
        public moviesContext()
        {
        }

        public moviesContext(DbContextOptions<moviesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Movie> Movie { get; set; }
        public virtual DbSet<Movieexec> Movieexec { get; set; }
        public virtual DbSet<Moviestar> Moviestar { get; set; }
        public virtual DbSet<Starsin> Starsin { get; set; }
        public virtual DbSet<Studio> Studio { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-E7P6GSC;Database=movies;Trusted_Connection=True;");
                //optionsBuilder
                //.UseLazyLoadingProxies()
                //.UseSqlServer("Server=DESKTOP-E7P6GSC;Database=movies;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>(entity =>
            {
                entity.HasKey(e => new { e.Title, e.Year });

                entity.ToTable("MOVIE");

                entity.Property(e => e.Title)
                    .HasColumnName("TITLE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Year).HasColumnName("YEAR");

                entity.Property(e => e.Incolor)
                    .HasColumnName("INCOLOR")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Length).HasColumnName("LENGTH");

                entity.Property(e => e.Producerc).HasColumnName("PRODUCERC#");

                entity.Property(e => e.Studioname)
                    .HasColumnName("STUDIONAME")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.ProducercNavigation)
                    .WithMany(p => p.Movie)
                    .HasForeignKey(d => d.Producerc)
                    .HasConstraintName("FK_MOVIE_MOVIEEXEC");

                entity.HasOne(d => d.StudionameNavigation)
                    .WithMany(p => p.Movie)
                    .HasForeignKey(d => d.Studioname)
                    .HasConstraintName("FK_MOVIE_STUDIO");
            });

            modelBuilder.Entity<Movieexec>(entity =>
            {
                entity.HasKey(e => e.Cert);

                entity.ToTable("MOVIEEXEC");

                entity.Property(e => e.Cert)
                    .HasColumnName("CERT#")
                    .ValueGeneratedNever();

                entity.Property(e => e.Address)
                    .HasColumnName("ADDRESS")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasColumnName("NAME")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Networth).HasColumnName("NETWORTH");
            });

            modelBuilder.Entity<Moviestar>(entity =>
            {
                entity.HasKey(e => e.Name);

                entity.ToTable("MOVIESTAR");

                entity.Property(e => e.Name)
                    .HasColumnName("NAME")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Address)
                    .HasColumnName("ADDRESS")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Birthdate)
                    .HasColumnName("BIRTHDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Gender)
                    .HasColumnName("GENDER")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Starsin>(entity =>
            {
                entity.HasKey(e => new { e.Movietitle, e.Movieyear, e.Starname });

                entity.ToTable("STARSIN");

                entity.Property(e => e.Movietitle)
                    .HasColumnName("MOVIETITLE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Movieyear).HasColumnName("MOVIEYEAR");

                entity.Property(e => e.Starname)
                    .HasColumnName("STARNAME")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.StarnameNavigation)
                    .WithMany(p => p.Starsin)
                    .HasForeignKey(d => d.Starname)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_STARSIN_MOVIESTAR");

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.Starsin)
                    .HasForeignKey(d => new { d.Movietitle, d.Movieyear })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_STARSIN_MOVIE");
            });

            modelBuilder.Entity<Studio>(entity =>
            {
                entity.HasKey(e => e.Name);

                entity.ToTable("STUDIO");

                entity.Property(e => e.Name)
                    .HasColumnName("NAME")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Address)
                    .HasColumnName("ADDRESS")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Presc).HasColumnName("PRESC#");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
