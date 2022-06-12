using Microsoft.EntityFrameworkCore.Migrations;

namespace DbEntities_Class_Library.Migrations
{
    public partial class UsernamePasswordAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Customers",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Customers",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "Password", "Username" },
                values: new object[] { "johndoe", "jdoe" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "Password", "Username" },
                values: new object[] { "sarawilliams", "swilliams" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "Password", "Username" },
                values: new object[] { "kenwong", "kwong" });

            migrationBuilder.UpdateData(
                table: "Dock",
                keyColumn: "ID",
                keyValue: 3,
                column: "Name",
                value: "Dock C");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "Customers");

            migrationBuilder.UpdateData(
                table: "Dock",
                keyColumn: "ID",
                keyValue: 3,
                column: "Name",
                value: "DockC");
        }
    }
}
