using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Microservices.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class ChangingTheTableName3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Logs",
                table: "Logs");

            migrationBuilder.RenameTable(
                name: "Logs",
                newName: "logs");

            migrationBuilder.RenameColumn(
                name: "RaiseDate",
                table: "logs",
                newName: "raisedate");

            migrationBuilder.RenameColumn(
                name: "PropsTest",
                table: "logs",
                newName: "propstest");

            migrationBuilder.RenameColumn(
                name: "Properties",
                table: "logs",
                newName: "properties");

            migrationBuilder.RenameColumn(
                name: "MessageTemplate",
                table: "logs",
                newName: "messagetemplate");

            migrationBuilder.RenameColumn(
                name: "Message",
                table: "logs",
                newName: "message");

            migrationBuilder.RenameColumn(
                name: "MachineName",
                table: "logs",
                newName: "machinename");

            migrationBuilder.RenameColumn(
                name: "Level",
                table: "logs",
                newName: "level");

            migrationBuilder.RenameColumn(
                name: "Exception",
                table: "logs",
                newName: "exception");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "logs",
                newName: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_logs",
                table: "logs",
                column: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_logs",
                table: "logs");

            migrationBuilder.RenameTable(
                name: "logs",
                newName: "Logs");

            migrationBuilder.RenameColumn(
                name: "raisedate",
                table: "Logs",
                newName: "RaiseDate");

            migrationBuilder.RenameColumn(
                name: "propstest",
                table: "Logs",
                newName: "PropsTest");

            migrationBuilder.RenameColumn(
                name: "properties",
                table: "Logs",
                newName: "Properties");

            migrationBuilder.RenameColumn(
                name: "messagetemplate",
                table: "Logs",
                newName: "MessageTemplate");

            migrationBuilder.RenameColumn(
                name: "message",
                table: "Logs",
                newName: "Message");

            migrationBuilder.RenameColumn(
                name: "machinename",
                table: "Logs",
                newName: "MachineName");

            migrationBuilder.RenameColumn(
                name: "level",
                table: "Logs",
                newName: "Level");

            migrationBuilder.RenameColumn(
                name: "exception",
                table: "Logs",
                newName: "Exception");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Logs",
                newName: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Logs",
                table: "Logs",
                column: "Id");
        }
    }
}
