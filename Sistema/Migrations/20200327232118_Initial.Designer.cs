﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Sistema.Data;

namespace Sistema.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20200327232118_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3");

            modelBuilder.Entity("Sistema.Models.Articulos", b =>
                {
                    b.Property<int>("ArticuloId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Codigo")
                        .HasColumnType("TEXT")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<int>("Contidad")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Costo")
                        .HasColumnType("money");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<double?>("Impuesto")
                        .HasColumnType("REAL");

                    b.Property<decimal>("Precio")
                        .HasColumnType("money");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ArticuloId")
                        .HasName("Articulos_pk");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Articulos");
                });

            modelBuilder.Entity("Sistema.Models.Clientes", b =>
                {
                    b.Property<int>("ClienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Apellidos")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<int>("Cedula")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Correo")
                        .HasColumnType("TEXT")
                        .IsUnicode(false);

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .IsUnicode(false);

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<int>("Telefono")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ClienteId")
                        .HasName("Clientes_pk");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("Sistema.Models.CotizacionDetalles", b =>
                {
                    b.Property<int>("ArticuloId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Cantidad")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CotizacionId")
                        .HasColumnType("INTEGER");

                    b.Property<double?>("Impuesto")
                        .HasColumnType("REAL");

                    b.Property<decimal>("SubTotal")
                        .HasColumnType("money");

                    b.HasIndex("ArticuloId");

                    b.HasIndex("CotizacionId");

                    b.ToTable("CotizacionDetalles");
                });

            modelBuilder.Entity("Sistema.Models.Cotizaciones", b =>
                {
                    b.Property<int>("CotizacionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClienteId")
                        .HasColumnType("INTEGER");

                    b.Property<decimal?>("Descuento")
                        .HasColumnType("decimal(18, 0)");

                    b.Property<DateTime?>("Fecha")
                        .HasColumnType("date");

                    b.Property<double?>("ImpuestoTotal")
                        .HasColumnType("REAL");

                    b.Property<int>("NumeroCotizacion")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Total")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("INTEGER");

                    b.HasKey("CotizacionId")
                        .HasName("Cotizaciones_pk");

                    b.HasIndex("ClienteId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Cotizaciones");
                });

            modelBuilder.Entity("Sistema.Models.FacturaDetalles", b =>
                {
                    b.Property<int>("ArticuloId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Cantidad")
                        .HasColumnType("INTEGER");

                    b.Property<int>("FacturaId")
                        .HasColumnType("INTEGER");

                    b.Property<double?>("Impuesto")
                        .HasColumnType("REAL");

                    b.Property<int>("Precio")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("SubTotal")
                        .HasColumnType("money");

                    b.HasIndex("ArticuloId");

                    b.HasIndex("FacturaId");

                    b.ToTable("FacturaDetalles");
                });

            modelBuilder.Entity("Sistema.Models.Facturas", b =>
                {
                    b.Property<int>("FacturaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClienteId")
                        .HasColumnType("INTEGER");

                    b.Property<decimal?>("Descuento")
                        .HasColumnType("decimal(18, 0)");

                    b.Property<DateTime?>("Fecha")
                        .HasColumnType("date");

                    b.Property<DateTime>("FechaVencimiento")
                        .HasColumnType("date");

                    b.Property<double?>("ImpuestoTotal")
                        .HasColumnType("REAL");

                    b.Property<int>("NumeroFactura")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Total")
                        .HasColumnType("money");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("INTEGER");

                    b.HasKey("FacturaId")
                        .HasName("Facturas_pk");

                    b.HasIndex("ClienteId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Facturas");
                });

            modelBuilder.Entity("Sistema.Models.PagoDetalles", b =>
                {
                    b.Property<int>("FacturaId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("FechaPago")
                        .HasColumnType("date");

                    b.Property<decimal>("MontoPago")
                        .HasColumnType("money");

                    b.Property<int>("PagoId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("TipoPago")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.HasIndex("FacturaId");

                    b.HasIndex("PagoId");

                    b.ToTable("PagoDetalles");
                });

            modelBuilder.Entity("Sistema.Models.Pagos", b =>
                {
                    b.Property<int>("PagoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClienteId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("date");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("INTEGER");

                    b.HasKey("PagoId")
                        .HasName("Pagos_pk");

                    b.HasIndex("ClienteId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Pagos");
                });

            modelBuilder.Entity("Sistema.Models.Usuarios", b =>
                {
                    b.Property<int>("UsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Apellidos")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(1)
                        .IsUnicode(false);

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("UsuarioId")
                        .HasName("Usuarios_pk");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("Sistema.Models.Articulos", b =>
                {
                    b.HasOne("Sistema.Models.Usuarios", "Usuario")
                        .WithMany("Articulos")
                        .HasForeignKey("UsuarioId")
                        .HasConstraintName("Articulos___fk_Usuarios")
                        .IsRequired();
                });

            modelBuilder.Entity("Sistema.Models.Clientes", b =>
                {
                    b.HasOne("Sistema.Models.Usuarios", "Usuario")
                        .WithMany("Clientes")
                        .HasForeignKey("UsuarioId")
                        .HasConstraintName("Clientes___fk__Usuario")
                        .IsRequired();
                });

            modelBuilder.Entity("Sistema.Models.CotizacionDetalles", b =>
                {
                    b.HasOne("Sistema.Models.Articulos", "Articulo")
                        .WithMany()
                        .HasForeignKey("ArticuloId")
                        .HasConstraintName("CotizacionDetalles___fk__Articulos")
                        .IsRequired();

                    b.HasOne("Sistema.Models.Cotizaciones", "Cotizacion")
                        .WithMany()
                        .HasForeignKey("CotizacionId")
                        .HasConstraintName("CotizacionDetalles___fk__Cotizaciones")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Sistema.Models.Cotizaciones", b =>
                {
                    b.HasOne("Sistema.Models.Clientes", "Cliente")
                        .WithMany("Cotizaciones")
                        .HasForeignKey("ClienteId")
                        .HasConstraintName("Cotizaciones___fk__Clientes")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sistema.Models.Usuarios", "Usuario")
                        .WithMany("Cotizaciones")
                        .HasForeignKey("UsuarioId")
                        .HasConstraintName("Cotizaciones___fk__Usuarios")
                        .IsRequired();
                });

            modelBuilder.Entity("Sistema.Models.FacturaDetalles", b =>
                {
                    b.HasOne("Sistema.Models.Articulos", "Articulo")
                        .WithMany()
                        .HasForeignKey("ArticuloId")
                        .HasConstraintName("FacturaDetalles___fk__Articulos")
                        .IsRequired();

                    b.HasOne("Sistema.Models.Facturas", "Factura")
                        .WithMany()
                        .HasForeignKey("FacturaId")
                        .HasConstraintName("FacturaDetalles___fk__Facturas")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Sistema.Models.Facturas", b =>
                {
                    b.HasOne("Sistema.Models.Clientes", "Cliente")
                        .WithMany("Facturas")
                        .HasForeignKey("ClienteId")
                        .HasConstraintName("Facturas___fk__Clientes")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sistema.Models.Usuarios", "Usuario")
                        .WithMany("Facturas")
                        .HasForeignKey("UsuarioId")
                        .HasConstraintName("Facturas___fk__Usuarios")
                        .IsRequired();
                });

            modelBuilder.Entity("Sistema.Models.PagoDetalles", b =>
                {
                    b.HasOne("Sistema.Models.Facturas", "Factura")
                        .WithMany()
                        .HasForeignKey("FacturaId")
                        .HasConstraintName("PagoDetalles___fk__Facturas")
                        .IsRequired();

                    b.HasOne("Sistema.Models.Pagos", "Pago")
                        .WithMany()
                        .HasForeignKey("PagoId")
                        .HasConstraintName("PagoDetalles___fk__Pagos")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Sistema.Models.Pagos", b =>
                {
                    b.HasOne("Sistema.Models.Clientes", "Cliente")
                        .WithMany("Pagos")
                        .HasForeignKey("ClienteId")
                        .HasConstraintName("Pagos___fk__Clientes")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sistema.Models.Usuarios", "Usuario")
                        .WithMany("Pagos")
                        .HasForeignKey("UsuarioId")
                        .HasConstraintName("Pagos___fk__Usuarios")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}