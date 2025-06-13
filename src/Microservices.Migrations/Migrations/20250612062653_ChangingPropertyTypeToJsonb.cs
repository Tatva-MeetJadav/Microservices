using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Microservices.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class ChangingPropertyTypeToJsonb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                @"ALTER TABLE ""logs"" ALTER COLUMN ""properties"" TYPE jsonb USING ""properties""::jsonb;"
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "properties",
                table: "logs",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "jsonb",
                oldNullable: true);
        }
    }
}
