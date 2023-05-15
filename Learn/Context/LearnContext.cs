using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Learn.Models;

#nullable disable

namespace Learn.Context
{
    public partial class LearnContext : DbContext
    {
        public LearnContext()
        {
        }

        public LearnContext(DbContextOptions<LearnContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Appointment> Appointments { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<ServicePhoto> ServicePhotos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=Learn;Trusted_Connection=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.ToTable("Appointment");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ClientId).HasColumnName("ClientID");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.ServiceId).HasColumnName("ServiceID");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Appointme__Clien__3E52440B");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.ServiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Appointme__Servi__3F466844");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("Client");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.ToTable("Service");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Image).HasColumnType("image");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<ServicePhoto>(entity =>
            {
                entity.ToTable("ServicePhoto");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Photo)
                    .IsRequired()
                    .HasColumnType("image");

                entity.Property(e => e.ServiceId).HasColumnName("ServiceID");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.ServicePhotos)
                    .HasForeignKey(d => d.ServiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ServicePh__Servi__398D8EEE");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
