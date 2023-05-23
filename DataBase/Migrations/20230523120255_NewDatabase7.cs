using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataBase.Migrations
{
    /// <inheritdoc />
    public partial class NewDatabase7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "name",
                table: "tickerDataList");

            migrationBuilder.DropColumn(
                name: "timestampend",
                table: "tickerDataList");

            migrationBuilder.RenameColumn(
                name: "timestampstart",
                table: "tickerDataList",
                newName: "timestamp");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "timestamp",
                table: "tickerDataList",
                newName: "timestampstart");

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "tickerDataList",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "timestampend",
                table: "tickerDataList",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
