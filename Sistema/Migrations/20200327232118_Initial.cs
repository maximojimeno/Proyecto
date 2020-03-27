using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sistema.Migrations
{
    public partial class Initial : Migration
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
                        name: "Articulos___fk_Usuarios",
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
                    Telefono = table.Column<int>(nullable: false),
                    Direccion = table.Column<string>(unicode: false, nullable: false)
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
                        name: "Cotizaciones___fk__Clientes",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "Cotizaciones___fk__Usuarios",
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
                        name: "Facturas___fk__Clientes",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "Facturas___fk__Usuarios",
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
                    Fecha = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Pagos_pk", x => x.PagoId);
                    table.ForeignKey(
                        name: "Pagos___fk__Clientes",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "Pagos___fk__Usuarios",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CotizacionDetalles",
                columns: table => new
                {
                    CotizacionId = table.Column<int>(nullable: false),
                    ArticuloId = table.Column<int>(nullable: false),
                    Cantidad = table.Column<int>(nullable: false),
                    Impuesto = table.Column<double>(nullable: true),
                    SubTotal = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "CotizacionDetalles___fk__Articulos",
                        column: x => x.ArticuloId,
                        principalTable: "Articulos",
                        principalColumn: "ArticuloId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "CotizacionDetalles___fk__Cotizaciones",
                        column: x => x.CotizacionId,
                        principalTable: "Cotizaciones",
                        principalColumn: "CotizacionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FacturaDetalles",
                columns: table => new
                {
                    FacturaId = table.Column<int>(nullable: false),
                    ArticuloId = table.Column<int>(nullable: false),
                    Cantidad = table.Column<int>(nullable: false),
                    Impuesto = table.Column<double>(nullable: true),
                    Precio = table.Column<int>(nullable: false),
                    SubTotal = table.Column<decimal>(type: "money", nullable: false)
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
                name: "PagoDetalles",
                columns: table => new
                {
                    PagoId = table.Column<int>(nullable: false),
                    FacturaId = table.Column<int>(nullable: false),
                    FechaPago = table.Column<DateTime>(type: "date", nullable: false),
                    TipoPago = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    MontoPago = table.Column<decimal>(type: "money", nullable: false)
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
                name: "IX_CotizacionDetalles_ArticuloId",
                table: "CotizacionDetalles",
                column: "ArticuloId");

            migrationBuilder.CreateIndex(
                name: "IX_CotizacionDetalles_CotizacionId",
                table: "CotizacionDetalles",
                column: "CotizacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Cotizaciones_ClienteId",
                table: "Cotizaciones",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Cotizaciones_UsuarioId",
                table: "Cotizaciones",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_FacturaDetalles_ArticuloId",
                table: "FacturaDetalles",
                column: "ArticuloId");

            migrationBuilder.CreateIndex(
                name: "IX_FacturaDetalles_FacturaId",
                table: "FacturaDetalles",
                column: "FacturaId");

            migrationBuilder.CreateIndex(
                name: "IX_Facturas_ClienteId",
                table: "Facturas",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Facturas_UsuarioId",
                table: "Facturas",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_PagoDetalles_FacturaId",
                table: "PagoDetalles",
                column: "FacturaId");

            migrationBuilder.CreateIndex(
                name: "IX_PagoDetalles_PagoId",
                table: "PagoDetalles",
                column: "PagoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pagos_ClienteId",
                table: "Pagos",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Pagos_UsuarioId",
                table: "Pagos",
                column: "UsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CotizacionDetalles");

            migrationBuilder.DropTable(
                name: "FacturaDetalles");

            migrationBuilder.DropTable(
                name: "PagoDetalles");

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
