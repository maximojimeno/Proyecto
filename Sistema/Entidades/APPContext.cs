using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Sistema.Entidades
{
    public partial class APPContext : DbContext
    {
        public APPContext()
        {
        }

        public APPContext(DbContextOptions<APPContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Articulos> Articulos { get; set; }
        public virtual DbSet<Clientes> Clientes { get; set; }
        public virtual DbSet<Cotizaciones> Cotizaciones { get; set; }
        public virtual DbSet<CotizacionesDetalle> CotizacionesDetalle { get; set; }
        public virtual DbSet<Facturas> Facturas { get; set; }
        public virtual DbSet<FacturasDetalle> FacturasDetalle { get; set; }
        public virtual DbSet<Pagos> Pagos { get; set; }
        public virtual DbSet<PagosDetalle> PagosDetalle { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=MAXIMOJIMENO-PC\\SQL;Initial Catalog=APP;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Articulos>(entity =>
            {
                entity.HasKey(e => e.ArticuloId)
                    .HasName("Articulos_pk")
                    .IsClustered(false);

                entity.Property(e => e.Codigo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Costo).HasColumnType("money");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Precio).HasColumnType("money");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.Articulos)
                    .HasForeignKey(d => d.UsuarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Articulos___fk__Usuarios");
            });

            modelBuilder.Entity<Clientes>(entity =>
            {
                entity.HasKey(e => e.ClienteId)
                    .HasName("Clientes_pk")
                    .IsClustered(false);

                entity.Property(e => e.Apellidos)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Correo).IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Nombres)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.UsuarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Clientes___fk__Usuario");
            });

            modelBuilder.Entity<Cotizaciones>(entity =>
            {
                entity.HasKey(e => e.CotizacionId)
                    .HasName("Cotizaciones_pk")
                    .IsClustered(false);

                entity.Property(e => e.Descuento).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.HasOne(d => d.Cliente)
                    .WithMany(p => p.Cotizaciones)
                    .HasForeignKey(d => d.ClienteId)
                    .HasConstraintName("Cotizaciones___fk__Clientes");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.Cotizaciones)
                    .HasForeignKey(d => d.UsuarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Cotizaciones___fk__Usuarios");
            });

            modelBuilder.Entity<CotizacionesDetalle>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Precio).HasColumnType("money");

                entity.HasOne(d => d.Articulo)
                    .WithMany()
                    .HasForeignKey(d => d.ArticuloId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CotizacionDetalles___fk__Articulos");

                entity.HasOne(d => d.Cotizacion)
                    .WithMany()
                    .HasForeignKey(d => d.CotizacionId)
                    .HasConstraintName("CotizacionDetalles___fk__Cotizaciones");
            });

            modelBuilder.Entity<Facturas>(entity =>
            {
                entity.HasKey(e => e.FacturaId)
                    .HasName("Facturas_pk")
                    .IsClustered(false);

                entity.Property(e => e.Descuento).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.Property(e => e.FechaVencimiento).HasColumnType("date");

                entity.Property(e => e.Total).HasColumnType("money");

                entity.HasOne(d => d.Cliente)
                    .WithMany(p => p.Facturas)
                    .HasForeignKey(d => d.ClienteId)
                    .HasConstraintName("Facturas___fk__Clientes");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.Facturas)
                    .HasForeignKey(d => d.UsuarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Facturas___fk__Usuarios");
            });

            modelBuilder.Entity<FacturasDetalle>(entity =>
            {
                entity.HasNoKey();

                entity.HasOne(d => d.Articulo)
                    .WithMany()
                    .HasForeignKey(d => d.ArticuloId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FacturaDetalles___fk__Articulos");

                entity.HasOne(d => d.Factura)
                    .WithMany()
                    .HasForeignKey(d => d.FacturaId)
                    .HasConstraintName("FacturaDetalles___fk__Facturas");
            });

            modelBuilder.Entity<Pagos>(entity =>
            {
                entity.HasKey(e => e.PagoId)
                    .HasName("Pagos_pk")
                    .IsClustered(false);

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.Property(e => e.TipoPago)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Cliente)
                    .WithMany(p => p.Pagos)
                    .HasForeignKey(d => d.ClienteId)
                    .HasConstraintName("Pagos___fk__Clientes");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.Pagos)
                    .HasForeignKey(d => d.UsuarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Pagos___fk__Usuarios");
            });

            modelBuilder.Entity<PagosDetalle>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Monto).HasColumnType("money");

                entity.HasOne(d => d.Factura)
                    .WithMany()
                    .HasForeignKey(d => d.FacturaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PagoDetalles___fk__Facturas");

                entity.HasOne(d => d.Pago)
                    .WithMany()
                    .HasForeignKey(d => d.PagoId)
                    .HasConstraintName("PagoDetalles___fk__Pagos");
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasKey(e => e.UsuarioId)
                    .HasName("Usuarios_pk")
                    .IsClustered(false);

                entity.Property(e => e.Apellidos)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nombres)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Role)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
