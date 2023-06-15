using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataBase.Migrations
{
    /// <inheritdoc />
    public partial class NewDatabase11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HystoriaclCryptoDataistListId",
                table: "historiacalDataItems",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "HystoricalCryptoDataList",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TimestampStart = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TimestampEnd = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DataSize = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HystoricalCryptoDataList", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "HystoricalCryptoDataItems",
                columns: table => new
                {
                    Volume = table.Column<decimal>(type: "numeric", nullable: false),
                    Open = table.Column<decimal>(type: "numeric", nullable: false),
                    High = table.Column<decimal>(type: "numeric", nullable: false),
                    Low = table.Column<decimal>(type: "numeric", nullable: false),
                    EndTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Period = table.Column<TimeSpan>(type: "interval", nullable: false),
                    DataType = table.Column<int>(type: "integer", nullable: false),
                    IsFillForward = table.Column<bool>(type: "boolean", nullable: false),
                    Time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Symbol = table.Column<string>(type: "text", nullable: true),
                    Value = table.Column<decimal>(type: "numeric", nullable: false),
                    Pric = table.Column<decimal>(type: "numeric", nullable: false),
                    ListId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HystoricalCryptoDataItems", x => x.Volume);
                    table.ForeignKey(
                        name: "FK_HystoricalCryptoDataItems_HystoricalCryptoDataList_ListId",
                        column: x => x.ListId,
                        principalTable: "HystoricalCryptoDataList",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_historiacalDataItems_HystoriaclCryptoDataistListId",
                table: "historiacalDataItems",
                column: "HystoriaclCryptoDataistListId");

            migrationBuilder.CreateIndex(
                name: "IX_HystoricalCryptoDataItems_ListId",
                table: "HystoricalCryptoDataItems",
                column: "ListId");

            migrationBuilder.AddForeignKey(
                name: "FK_historiacalDataItems_HystoricalCryptoDataList_HystoriaclCry~",
                table: "historiacalDataItems",
                column: "HystoriaclCryptoDataistListId",
                principalTable: "HystoricalCryptoDataList",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_historiacalDataItems_HystoricalCryptoDataList_HystoriaclCry~",
                table: "historiacalDataItems");

            migrationBuilder.DropTable(
                name: "HystoricalCryptoDataItems");

            migrationBuilder.DropTable(
                name: "HystoricalCryptoDataList");

            migrationBuilder.DropIndex(
                name: "IX_historiacalDataItems_HystoriaclCryptoDataistListId",
                table: "historiacalDataItems");

            migrationBuilder.DropColumn(
                name: "HystoriaclCryptoDataistListId",
                table: "historiacalDataItems");
        }
    }
}
