using System;
using System.Collections.Generic;
using Emprendimientos2.Models;
using Microsoft.EntityFrameworkCore;

namespace Emprendimientos2.Context;

public partial class GestionEmprendimientoContext : DbContext
{
    public GestionEmprendimientoContext()
    {
    }

    public GestionEmprendimientoContext(DbContextOptions<GestionEmprendimientoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Emprendimiento> Emprendimientos { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<TransaccionFinanciera> TransaccionFinancieras { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=Connection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Emprendimiento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__EMPRENDI__3213E83F19B14256");

            entity.ToTable("EMPRENDIMIENTO");

            entity.HasIndex(e => e.CodigoAcceso, "UQ_emprendimiento_codigo_acceso").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CodigoAcceso)
                .HasMaxLength(50)
                .HasColumnName("codigo_acceso");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(500)
                .HasColumnName("descripcion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PRODUCTO__3213E83F3DE5A967");

            entity.ToTable("PRODUCTO");

            entity.HasIndex(e => e.EmprendimientoId, "IX_Producto_EmprendimientoId");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CantidadInventario).HasColumnName("cantidad_inventario");
            entity.Property(e => e.CostoFabricacion)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("costo_fabricacion");
            entity.Property(e => e.EmprendimientoId).HasColumnName("emprendimiento_id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
            entity.Property(e => e.PrecioUnitario)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("precio_unitario");

            entity.HasOne(d => d.Emprendimiento).WithMany(p => p.Productos)
                .HasForeignKey(d => d.EmprendimientoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PRODUCTO__empren__66603565");
        });

        modelBuilder.Entity<TransaccionFinanciera>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TRANSACC__3213E83F0A4F99E6");

            entity.ToTable("TRANSACCION_FINANCIERA");

            entity.HasIndex(e => e.EmprendimientoId, "IX_TransaccionFinanciera_EmprendimientoId");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .HasColumnName("descripcion");
            entity.Property(e => e.EmprendimientoId).HasColumnName("emprendimiento_id");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.Monto)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("monto");
            entity.Property(e => e.Tipo)
                .HasMaxLength(10)
                .HasColumnName("tipo");

            entity.HasOne(d => d.Emprendimiento).WithMany(p => p.TransaccionFinancieras)
                .HasForeignKey(d => d.EmprendimientoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TRANSACCI__empre__6383C8BA");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__USUARIO__3213E83F7F71B665");

            entity.ToTable("usuario");

            entity.HasIndex(e => e.Email, "UQ__USUARIO__AB6E61649EB75FF7").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CodigoAcceso)
                .HasMaxLength(50)
                .HasColumnName("codigo_acceso");
            entity.Property(e => e.Contrasena)
                .HasMaxLength(255)
                .HasColumnName("contrasena");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");

            entity.HasOne(d => d.CodigoAccesoNavigation).WithMany(p => p.Usuarios)
                .HasPrincipalKey(p => p.CodigoAcceso)
                .HasForeignKey(d => d.CodigoAcceso)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_usuario_emprendimiento");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
