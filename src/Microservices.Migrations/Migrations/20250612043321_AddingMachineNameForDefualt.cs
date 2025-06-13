using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Microservices.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class AddingMachineNameForDefualt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MachineName",
                table: "Logs",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MachineName",
                table: "Logs");
        }
    }
}
