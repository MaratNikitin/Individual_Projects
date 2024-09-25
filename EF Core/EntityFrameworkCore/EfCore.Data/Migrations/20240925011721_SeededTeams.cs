using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EfCore.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeededTeams : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "TeamId", "CreatedDate", "TeamName" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 9, 25, 1, 17, 20, 743, DateTimeKind.Unspecified).AddTicks(9456), "Tivoli Gardens FC" },
                    { 2, new DateTime(2024, 9, 25, 1, 17, 20, 743, DateTimeKind.Unspecified).AddTicks(9482), "Waterhouse FC" },
                    { 3, new DateTime(2024, 9, 25, 1, 17, 20, 743, DateTimeKind.Unspecified).AddTicks(9493), "Humble Lions FC" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "TeamId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "TeamId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "TeamId",
                keyValue: 3);
        }
    }
}
