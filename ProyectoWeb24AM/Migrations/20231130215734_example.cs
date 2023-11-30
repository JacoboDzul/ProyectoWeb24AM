using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProyectoWeb24AM.Migrations
{
    /// <inheritdoc />
    public partial class example : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Articulo",
                columns: table => new
                {
                    PKArticulo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UrlImagenPath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articulo", x => x.PKArticulo);
                });

            migrationBuilder.CreateTable(
                name: "Libros",
                columns: table => new
                {
                    PKLibro = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Images = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Libros", x => x.PKLibro);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    PKRol = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.PKRol);
                });

            migrationBuilder.CreateTable(
                name: "Promocion",
                columns: table => new
                {
                    PKPromocion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descuento = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UrlImagenPath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FkArticulo = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promocion", x => x.PKPromocion);
                    table.ForeignKey(
                        name: "FK_Promocion_Articulo_FkArticulo",
                        column: x => x.FkArticulo,
                        principalTable: "Articulo",
                        principalColumn: "PKArticulo");
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    PKUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FKRol = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.PKUsuario);
                    table.ForeignKey(
                        name: "FK_Usuarios_Roles_FKRol",
                        column: x => x.FKRol,
                        principalTable: "Roles",
                        principalColumn: "PKRol");
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "PKRol", "Nombre" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "SA" }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "PKUsuario", "Apellido", "FKRol", "Nombre", "Password", "UserName" },
                values: new object[] { 1, "Dzul", 1, "Jacob", "1501", "MurderBunny" });

            migrationBuilder.CreateIndex(
                name: "IX_Promocion_FkArticulo",
                table: "Promocion",
                column: "FkArticulo");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_FKRol",
                table: "Usuarios",
                column: "FKRol");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Libros");

            migrationBuilder.DropTable(
                name: "Promocion");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Articulo");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
