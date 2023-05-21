using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataBase.Migrations
{
    /// <inheritdoc />
    public partial class Database3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "historiacalData");

            migrationBuilder.CreateTable(
                name: "Historicaldatalist",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    timestampstart = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    timestampend = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    datasize = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Historicaldatalist", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tradingPair",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tradingPair", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "historiacalDataItems",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    tradingPairId = table.Column<int>(type: "integer", nullable: false),
                    timeStamp = table.Column<int>(type: "integer", nullable: false),
                    open = table.Column<decimal>(type: "numeric", nullable: false),
                    high = table.Column<decimal>(type: "numeric", nullable: false),
                    low = table.Column<decimal>(type: "numeric", nullable: false),
                    close = table.Column<decimal>(type: "numeric", nullable: false),
                    volume = table.Column<decimal>(type: "numeric", nullable: false),
                    listId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_historiacalDataItems", x => x.id);
                    table.ForeignKey(
                        name: "FK_historiacalDataItems_Historicaldatalist_listId",
                        column: x => x.listId,
                        principalTable: "Historicaldatalist",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_historiacalDataItems_tradingPair_tradingPairId",
                        column: x => x.tradingPairId,
                        principalTable: "tradingPair",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_historiacalDataItems_listId",
                table: "historiacalDataItems",
                column: "listId");

            migrationBuilder.CreateIndex(
                name: "IX_historiacalDataItems_tradingPairId",
                table: "historiacalDataItems",
                column: "tradingPairId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "historiacalDataItems");

            migrationBuilder.DropTable(
                name: "Historicaldatalist");

            migrationBuilder.DropTable(
                name: "tradingPair");

            migrationBuilder.CreateTable(
                name: "historiacalData",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    close = table.Column<decimal>(type: "numeric", nullable: false),
                    high = table.Column<decimal>(type: "numeric", nullable: false),
                    low = table.Column<decimal>(type: "numeric", nullable: false),
                    open = table.Column<decimal>(type: "numeric", nullable: false),
                    timeStamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    tradingPairId = table.Column<int>(type: "integer", nullable: false),
                    volume = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_historiacalData", x => x.id);
                });
        }
    }
}
