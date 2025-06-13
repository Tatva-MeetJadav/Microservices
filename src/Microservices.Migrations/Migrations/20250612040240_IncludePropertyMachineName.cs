using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Microservices.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class IncludePropertyMachineName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LogEvent",
                table: "Logs",
                newName: "PropsTest");

            migrationBuilder.AddColumn<string>(
                name: "MachineName",
                table: "Logs",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MachineName",
                table: "Logs");

            migrationBuilder.RenameColumn(
                name: "PropsTest",
                table: "Logs",
                newName: "LogEvent");
        }
    }
}
