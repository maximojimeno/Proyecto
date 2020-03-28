using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sistema.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombres = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    Apellidos = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    Role = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    UserName = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Password = table.Column<string>(unicode: false, maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Usuarios_pk", x => x.UsuarioId);
                });

            migrationBuilder.CreateTable(
                name: "Articulos",
                columns: table => new
                {
                    ArticuloId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UsuarioId = table.Column<int>(nullable: false),
                    Codigo = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Descripcion = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    Costo = table.Column<decimal>(type: "money", nullable: false),
                    Impuesto = table.Column<double>(nullable: true),
                    Precio = table.Column<decimal>(type: "money", nullable: false),
                    Contidad = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Articulos_pk", x => x.ArticuloId);
                    table.ForeignKey(
                        name: "Articulos___fk___Usuarios",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    ClienteId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UsuarioId = table.Column<int>(nullable: false),
                    Nombres = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    Apellidos = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    Cedula = table.Column<int>(nullable: false),
                    Correo = table.Column<string>(unicode: false, nullable: true),
                    Telefono = table.Column<int>(nullable: true),
                    Direccion = table.Column<string>(unicode: false, nullable: false),
                    Celular = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Clientes_pk", x => x.ClienteId);
                    table.ForeignKey(
                        name: "Clientes___fk__Usuario",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cotizaciones",
                columns: table => new
                {
                    CotizacionId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UsuarioId = table.Column<int>(nullable: false),
                    ClienteId = table.Column<int>(nullable: false),
                    Fecha = table.Column<DateTime>(type: "date", nullable: true),
                    NumeroCotizacion = table.Column<int>(nullable: false),
                    Descuento = table.Column<decimal>(type: "decimal(18, 0)", nullable: true),
                    ImpuestoTotal = table.Column<double>(nullable: true),
                    Total = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Cotizaciones_pk", x => x.CotizacionId);
                    table.ForeignKey(
                        name: "Cotizaciones___fk___Clientes",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "Cotizaciones___fk___Usuarios",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Facturas",
                columns: table => new
                {
                    FacturaId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UsuarioId = table.Column<int>(nullable: false),
                    ClienteId = table.Column<int>(nullable: false),
                    NumeroFactura = table.Column<int>(nullable: false),
                    Fecha = table.Column<DateTime>(type: "date", nullable: true),
                    FechaVencimiento = table.Column<DateTime>(type: "date", nullable: false),
                    Descuento = table.Column<decimal>(type: "decimal(18, 0)", nullable: true),
                    ImpuestoTotal = table.Column<double>(nullable: true),
                    Total = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Facturas_pk", x => x.FacturaId);
                    table.ForeignKey(
                        name: "Facturas___fk___Clientes",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "Facturas___fk___Usuarios",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pagos",
                columns: table => new
                {
                    PagoId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UsuarioId = table.Column<int>(nullable: false),
                    ClienteId = table.Column<int>(nullable: false),
                    Fecha = table.Column<DateTime>(type: "date", nullable: false),
                    TipoPago = table.Column<string>(unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Pagos_pk", x => x.PagoId);
                    table.ForeignKey(
                        name: "Pagos___fk___Clientes",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "Pagos___fk___Usuarios",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CotizacionesDetalle",
                columns: table => new
                {
                    CotizacionId = table.Column<int>(nullable: false),
                    ArticuloId = table.Column<int>(nullable: false),
                    Codigo = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true),
                    Costo = table.Column<decimal>(nullable: false),
                    Impuesto = table.Column<double>(nullable: true),
                    Precio = table.Column<decimal>(type: "money", nullable: false),
                    Contidad = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "CotizacionDetalles___fk___Articulos",
                        column: x => x.ArticuloId,
                        principalTable: "Articulos",
                        principalColumn: "ArticuloId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "CotizacionDetalles___fk___Cotizaciones",
                        column: x => x.CotizacionId,
                        principalTable: "Cotizaciones",
                        principalColumn: "CotizacionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FacturasDetalle",
                columns: table => new
                {
                    FacturaId = table.Column<int>(nullable: false),
                    ArticuloId = table.Column<int>(nullable: false),
                    Codigo = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true),
                    Costo = table.Column<decimal>(nullable: false),
                    Impuesto = table.Column<double>(nullable: true),
                    Precio = table.Column<decimal>(nullable: false),
                    Contidad = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FacturaDetalles___fk__Articulos",
                        column: x => x.ArticuloId,
                        principalTable: "Articulos",
                        principalColumn: "ArticuloId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FacturaDetalles___fk__Facturas",
                        column: x => x.FacturaId,
                        principalTable: "Facturas",
                        principalColumn: "FacturaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PagosDetalle",
                columns: table => new
                {
                    PagoId = table.Column<int>(nullable: false),
                    FacturaId = table.Column<int>(nullable: false),
                    Monto = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "PagoDetalles___fk__Facturas",
                        column: x => x.FacturaId,
                        principalTable: "Facturas",
                        principalColumn: "FacturaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "PagoDetalles___fk__Pagos",
                        column: x => x.PagoId,
                        principalTable: "Pagos",
                        principalColumn: "PagoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Articulos_UsuarioId",
                table: "Articulos",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_UsuarioId",
                table: "Clientes",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Cotizaciones_ClienteId",
                table: "Cotizaciones",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Cotizaciones_UsuarioId",
                table: "Cotizaciones",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_CotizacionesDetalle_ArticuloId",
                table: "CotizacionesDetalle",
                column: "ArticuloId");

            migrationBuilder.CreateIndex(
                name: "IX_CotizacionesDetalle_CotizacionId",
                table: "CotizacionesDetalle",
                column: "CotizacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Facturas_ClienteId",
                table: "Facturas",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Facturas_UsuarioId",
                table: "Facturas",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_FacturasDetalle_ArticuloId",
                table: "FacturasDetalle",
                column: "ArticuloId");

            migrationBuilder.CreateIndex(
                name: "IX_FacturasDetalle_FacturaId",
                table: "FacturasDetalle",
                column: "FacturaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pagos_ClienteId",
                table: "Pagos",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Pagos_UsuarioId",
                table: "Pagos",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_PagosDetalle_FacturaId",
                table: "PagosDetalle",
                column: "FacturaId");

            migrationBuilder.CreateIndex(
                name: "IX_PagosDetalle_PagoId",
                table: "PagosDetalle",
                column: "PagoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CotizacionesDetalle");

            migrationBuilder.DropTable(
                name: "FacturasDetalle");

            migrationBuilder.DropTable(
                name: "PagosDetalle");

            migrationBuilder.DropTable(
                name: "Cotizaciones");

            migrationBuilder.DropTable(
                name: "Articulos");

            migrationBuilder.DropTable(
                name: "Facturas");

            migrationBuilder.DropTable(
                name: "Pagos");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
