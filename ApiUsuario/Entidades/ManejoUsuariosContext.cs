using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ApiUsuario.Entidades
{
    public partial class ManejoUsuariosContext : DbContext
    {
        public ManejoUsuariosContext()
        {
        }

        public ManejoUsuariosContext(DbContextOptions<ManejoUsuariosContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Empleado> Empleados { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("name=DefaultConnection");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.HasKey(e => e.CodigoEmpleado)
                    .HasName("PK__Empleado__324FED7352499827");

                entity.ToTable("Empleado");

                entity.Property(e => e.CodigoEmpleado)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FechaNacimiento)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Pais)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PrimerApellido)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.PrimerNombre)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.SegundoApellido)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.SegundoNombre)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.TelefonoMovil)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("Usuario");

                entity.Property(e => e.Contrasenia)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NombreUsuario)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });
            modelBuilder.Entity<Empleado>().Property(e => e.Id)
                        .ValueGeneratedOnAdd()
                        .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
