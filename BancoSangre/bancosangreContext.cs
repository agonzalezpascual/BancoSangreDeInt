using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BancoSangre
{
    public partial class bancosangreContext : DbContext
    {
        public bancosangreContext()
        {
        }

        public bancosangreContext(DbContextOptions<bancosangreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Donacion> Donacions { get; set; } = null!;
        public virtual DbSet<Donante> Donantes { get; set; } = null!;
        public virtual DbSet<Sanitario> Sanitarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=bancosangre;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Donacion>(entity =>
            {
                entity.ToTable("Donacion");

                entity.Property(e => e.Cantidad)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("cantidad");

                entity.Property(e => e.Centro)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("centro");

                entity.Property(e => e.CodSanitario)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Dni)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("DNI")
                    .IsFixedLength();

                entity.Property(e => e.Fecha)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("fecha");

                entity.HasOne(d => d.CodSanitarioNavigation)
                    .WithMany(p => p.Donacions)
                    .HasForeignKey(d => d.CodSanitario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CodSan");
            });

            modelBuilder.Entity<Donante>(entity =>
            {
                entity.HasKey(e => e.Dni)
                    .HasName("PK__Donante__C035B8DC335BB8A1");

                entity.ToTable("Donante");

                entity.Property(e => e.Dni)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("DNI")
                    .IsFixedLength();

                entity.Property(e => e.Apellido)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("apellido");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("direccion");

                entity.Property(e => e.Email)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Grupo)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("grupo");

                entity.Property(e => e.Nacimiento)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("nacimiento")
                    .IsFixedLength();

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Rh)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("rh")
                    .IsFixedLength();

                entity.Property(e => e.Telefono)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("telefono")
                    .IsFixedLength();
            });

            modelBuilder.Entity<Sanitario>(entity =>
            {
                entity.HasKey(e => e.CodSanitario)
                    .HasName("PK__Sanitari__EA309A2BE12EC3AA");

                entity.ToTable("Sanitario");

                entity.Property(e => e.CodSanitario)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
