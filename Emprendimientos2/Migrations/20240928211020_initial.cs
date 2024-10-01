using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Emprendimientos2.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EMPRENDIMIENTO",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__EMPRENDI__3213E83F19B14256", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "PRODUCTO",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    cantidad_inventario = table.Column<int>(type: "int", nullable: false),
                    precio_unitario = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    ruta_foto = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    emprendimiento_id = table.Column<int>(type: "int", nullable: false),
                    costo_fabricacion = table.Column<decimal>(type: "decimal(10,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__PRODUCTO__3213E83F3DE5A967", x => x.id);
                    table.ForeignKey(
                        name: "FK__PRODUCTO__empren__66603565",
                        column: x => x.emprendimiento_id,
                        principalTable: "EMPRENDIMIENTO",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "TRANSACCION_FINANCIERA",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fecha = table.Column<DateOnly>(type: "date", nullable: false),
                    tipo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    monto = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    emprendimiento_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TRANSACC__3213E83F0A4F99E6", x => x.id);
                    table.ForeignKey(
                        name: "FK__TRANSACCI__empre__6383C8BA",
                        column: x => x.emprendimiento_id,
                        principalTable: "EMPRENDIMIENTO",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "usuario",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    contrasena = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    emprendimiento_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__USUARIO__3213E83F7F71B665", x => x.id);
                    table.ForeignKey(
                        name: "FK__USUARIO__emprend__5FB337D6",
                        column: x => x.emprendimiento_id,
                        principalTable: "EMPRENDIMIENTO",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Producto_EmprendimientoId",
                table: "PRODUCTO",
                column: "emprendimiento_id");

            migrationBuilder.CreateIndex(
                name: "IX_TransaccionFinanciera_EmprendimientoId",
                table: "TRANSACCION_FINANCIERA",
                column: "emprendimiento_id");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_EmprendimientoId",
                table: "usuario",
                column: "emprendimiento_id");

            migrationBuilder.CreateIndex(
                name: "UQ__USUARIO__AB6E61649EB75FF7",
                table: "usuario",
                column: "email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PRODUCTO");

            migrationBuilder.DropTable(
                name: "TRANSACCION_FINANCIERA");

            migrationBuilder.DropTable(
                name: "usuario");

            migrationBuilder.DropTable(
                name: "EMPRENDIMIENTO");
        }
    }
}
