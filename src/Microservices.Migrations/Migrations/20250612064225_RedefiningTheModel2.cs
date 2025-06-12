using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Microservices.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class RedefiningTheModel2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                @"ALTER TABLE ""logs"" ALTER COLUMN ""properties"" TYPE jsonb USING ""properties""::jsonb;"
            );

            migrationBuilder.AlterColumn<string>(
                name: "machinename",
                table: "logs",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.Sql(
                @"ALTER TABLE ""logs"" ALTER COLUMN ""level"" TYPE integer USING ""level""::integer;"
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                @"ALTER TABLE ""logs"" ALTER COLUMN ""properties"" TYPE jsonb USING ""properties""::jsonb;"
            );

            migrationBuilder.AlterColumn<string>(
                name: "machinename",
                table: "logs",
                type: "character varying(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.Sql(
                @"ALTER TABLE ""logs"" ALTER COLUMN ""level"" TYPE integer USING ""level""::integer;"
            );
        }
    }
}
