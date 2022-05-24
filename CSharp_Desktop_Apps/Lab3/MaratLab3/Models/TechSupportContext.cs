using System;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

/*
 * This class (entity) was automatically generated from the the TechSupport DB 
 * using Entity Framework Core Database First
 * Author: Marat Nikitin
 * SAIT, OOSD course
 * When: January 2022
 */

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MaratLab3.Models
{
    public partial class TechSupportContext : DbContext
    {
        public TechSupportContext()
        {
        }

        public TechSupportContext(DbContextOptions<TechSupportContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<Incidents> Incidents { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Registrations> Registrations { get; set; }
        public virtual DbSet<States> States { get; set; }
        public virtual DbSet<Technicians> Technicians { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["TechSupport"].ConnectionString);
                // this way, the connection string is hidden in the "App.config" file
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customers>(entity =>
            {
                entity.Property(e => e.Address).IsUnicode(false);

                entity.Property(e => e.City).IsUnicode(false);

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.Phone).IsUnicode(false);

                entity.Property(e => e.State)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ZipCode).IsUnicode(false);

                entity.HasOne(d => d.StateNavigation)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.State)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_States_Customers");
            });

            modelBuilder.Entity<Incidents>(entity =>
            {
                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.ProductCode)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Title).IsUnicode(false);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Incidents)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Incidents_Customers");

                entity.HasOne(d => d.ProductCodeNavigation)
                    .WithMany(p => p.Incidents)
                    .HasForeignKey(d => d.ProductCode)
                    .HasConstraintName("FK_Incidents_Products");

                entity.HasOne(d => d.Tech)
                    .WithMany(p => p.Incidents)
                    .HasForeignKey(d => d.TechId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Incidents_Technicians");
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.Property(e => e.ProductCode)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Name).IsUnicode(false);
            });

            modelBuilder.Entity<Registrations>(entity =>
            {
                entity.HasKey(e => new { e.CustomerId, e.ProductCode });

                entity.Property(e => e.ProductCode)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Registrations)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Registrations_Customers");

                entity.HasOne(d => d.ProductCodeNavigation)
                    .WithMany(p => p.Registrations)
                    .HasForeignKey(d => d.ProductCode)
                    .HasConstraintName("FK_Registrations_Products");
            });

            modelBuilder.Entity<States>(entity =>
            {
                entity.Property(e => e.StateCode)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.StateName).IsUnicode(false);
            });

            modelBuilder.Entity<Technicians>(entity =>
            {
                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.Phone).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
