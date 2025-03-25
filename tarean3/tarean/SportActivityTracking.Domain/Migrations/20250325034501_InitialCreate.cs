using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SportActivityTracking.Domain.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActividadesDeportivas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DuracionMinutos = table.Column<int>(type: "int", nullable: false),
                    TipoDeporte = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Usuario = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActividadesDeportivas", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ActividadesDeportivas",
                columns: new[] { "Id", "Descripcion", "DuracionMinutos", "Fecha", "TipoDeporte", "Usuario" },
                values: new object[,]
                {
        { 1, "Carrera matutina en el parque", 45, new DateTime(2025, 3, 24, 7, 0, 0), "Running", "Franyeli@gmail.com" },
        { 2, "Sesión de natación", 60, new DateTime(2025, 3, 23, 18, 30, 0), "Natación", "Franklin@gmail.com" },
        { 3, "Partido de fútbol", 90, new DateTime(2025, 3, 22, 16, 0, 0), "Fútbol", "pedro@hotmail.com" },
        { 4, "Clases de yoga en casa", 30, new DateTime(2025, 3, 21, 8, 0, 0), "Yoga", "luisafernandez@outlook.com" },
        { 5, "Entrenamiento de fuerza en el gimnasio", 50, new DateTime(2025, 3, 20, 19, 0, 0), "Gimnasio", "carlosm@gmail.com" },
        { 6, "Ruta en bicicleta por la montaña", 120, new DateTime(2025, 3, 19, 10, 0, 0), "Ciclismo", "sofiaj@yahoo.com" },
        { 7, "Partido de baloncesto con amigos", 60, new DateTime(2025, 3, 18, 17, 0, 0), "Baloncesto", "daniel@gmail.com" }
                });

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActividadesDeportivas");
        }
    }
}
