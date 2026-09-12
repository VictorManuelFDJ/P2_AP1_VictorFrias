using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace P2_AP1_VictorFrias.Migrations
{
    /// <inheritdoc />
    public partial class Tercera : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Componentes",
                columns: new[] { "ComponenteId", "Descripcion", "Existencia", "Precio" },
                values: new object[,]
                {
                    { 1, "Teclado", 0, 0m },
                    { 2, "Procesador", 0, 0m },
                    { 3, "HDI", 0, 0m },
                    { 4, "Cable sata", 0, 0m },
                    { 5, "Ram", 0, 0m },
                    { 6, "Disco duro", 0, 0m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Componentes",
                keyColumn: "ComponenteId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Componentes",
                keyColumn: "ComponenteId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Componentes",
                keyColumn: "ComponenteId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Componentes",
                keyColumn: "ComponenteId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Componentes",
                keyColumn: "ComponenteId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Componentes",
                keyColumn: "ComponenteId",
                keyValue: 6);
        }
    }
}
