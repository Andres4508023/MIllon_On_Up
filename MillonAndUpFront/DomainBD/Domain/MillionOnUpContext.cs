using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DomainBD.Domain
{
    public partial class MillionOnUpContext : DbContext
    {
        public MillionOnUpContext()
        {
        }

        public MillionOnUpContext(DbContextOptions<MillionOnUpContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Owner> Owner { get; set; }
        public virtual DbSet<Property> Property { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-95OPKV9;Database=MillionOnUp; Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Owner>(entity =>
            {
                entity.HasKey(e => e.IdOwner);

                entity.Property(e => e.AdressOwner)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.NamesOwner)
                    .HasMaxLength(60)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Property>(entity =>
            {
                entity.HasKey(e => e.IdProperty);

                entity.Property(e => e.Adress)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ImagePath).HasMaxLength(2000);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUser);

                entity.Property(e => e.DateCreation).HasColumnType("datetime");

                entity.Property(e => e.Password)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Users)
                    .HasMaxLength(60)
                    .IsUnicode(false);
            });
        }
    }
}
