using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DataAccess.Entities
{
    public partial class DBDKContextDefault : DbContext
    {
        public DBDKContextDefault()
        {
        }

        public DBDKContextDefault(DbContextOptions<DBDKContextDefault> options)
            : base(options)
        {
        }

        
        public virtual DbSet<Clientes> Clientes { get; set; }
        
        public virtual DbSet<Estados> Estados { get; set; }
        
        public virtual DbSet<Localidades> Localidades { get; set; }
        
        public virtual DbSet<Provincias> Provincias { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AI");

   

            modelBuilder.Entity<Clientes>(entity =>
            {
                entity.HasKey(e => e.IdCliente);

                entity.Property(e => e.Cpa)
                    .IsRequired()
                    .HasMaxLength(8)
                    .HasColumnName("CPA");

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Email).HasMaxLength(75);

             
                entity.Property(e => e.NumeroDocumento).HasColumnType("decimal(11, 0)");

             
                entity.Property(e => e.RazonSocial)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Telefono).HasMaxLength(30);

               

                entity.HasOne(d => d.IdEstadoNavigation)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.IdEstado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Clientes_Estados");

                entity.HasOne(d => d.IdLocalidadNavigation)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.IdLocalidad)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Clientes_Localidades");

                entity.HasOne(d => d.IdProvinciaNavigation)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.IdProvincia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Clientes_Provincias");

               
            });

            modelBuilder.Entity<Estados>(entity =>
            {
                entity.HasKey(e => e.IdEstado)
                    .HasName("PK_EstadosClientes");

                entity.HasIndex(e => new { e.TipoEstado, e.NombreEstado }, "IX_Estados_TipoEstado_NombreEstado")
                    .IsUnique();

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.FechaUltimaModificacion).HasColumnType("datetime");

                entity.Property(e => e.NombreEstado)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TipoEstado)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UsuarioCreacion)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UsuarioUltimaModificacion).HasMaxLength(50);

               
            });

            modelBuilder.Entity<Localidades>(entity =>
            {
                entity.HasKey(e => e.IdLocalidad);

                entity.HasIndex(e => e.NombreLocalidad, "IX_Table_Nombre");

                entity.Property(e => e.IdLocalidad).ValueGeneratedNever();

                entity.Property(e => e.CodigoPostal).HasMaxLength(8);

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.FechaUltimaModificacion).HasColumnType("datetime");

                entity.Property(e => e.NombreLocalidad)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.UsuarioCreacion)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UsuarioUltimaModificacion).HasMaxLength(50);

               
            });

            modelBuilder.Entity<Provincias>(entity =>
            {
                entity.HasKey(e => e.IdProvincia);

                entity.Property(e => e.IdProvincia).ValueGeneratedNever();

           
                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.FechaUltimaModificacion).HasColumnType("datetime");

                entity.Property(e => e.LetraCpa)
                    .IsRequired()
                    .HasMaxLength(1)
                    .HasColumnName("LetraCPA");

                entity.Property(e => e.NombreProvincia)
                    .IsRequired()
                    .HasMaxLength(100);

            
                entity.Property(e => e.UsuarioCreacion)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UsuarioUltimaModificacion).HasMaxLength(50);

             
            });

 

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
