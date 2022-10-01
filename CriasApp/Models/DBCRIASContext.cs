using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CriasApp.Models
{
    public partial class DBCRIASContext : DbContext
    {
        public DBCRIASContext()
        {
        }

        public DBCRIASContext(DbContextOptions<DBCRIASContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cria> Cria { get; set; } = null!;
        public virtual DbSet<Proveedor> Proveedores { get; set; } = null!;
        public virtual DbSet<Sensores> Sensores { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
         


        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cria>(entity =>
            {
                entity.ToTable("CRIA");

                entity.Property(e => e.Costo).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasColumnType("bit(1)");

                entity.Property(e => e.Clasificacion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.oProveedor)
                    .WithMany(p => p.Cria)
                    .HasForeignKey(d => d.IdProveedor)
                    .HasConstraintName("FK_Proveedor");

                entity.HasOne(d => d.oSensores)
                    .WithMany(p => p.Cria)
                    .HasForeignKey(d => d.IdSensores)
                    .HasConstraintName("FK_Sensores");

                 
    

            });

            modelBuilder.Entity<Proveedor>(entity =>
            {
                entity.ToTable("PROVEEDOR");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Sensores>(entity =>
            {
                entity.ToTable("SENSORES");


            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
