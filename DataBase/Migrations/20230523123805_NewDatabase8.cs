using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataBase.Migrations
{
    /// <inheritdoc />
    public partial class NewDatabase8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tickerHourDataList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    timestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    datasize = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tickerHourDataList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tickerHourDataItems",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    lastprice = table.Column<decimal>(type: "numeric", nullable: false),
                    highestPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    lowestPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    volume_weighted_average_price = table.Column<decimal>(type: "numeric", nullable: false),
                    volume = table.Column<decimal>(type: "numeric", nullable: false),
                    highest_buy_order = table.Column<decimal>(type: "numeric", nullable: false),
                    lowest_sell_order = table.Column<decimal>(type: "numeric", nullable: false),
                    timestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    first_price_of_day = table.Column<decimal>(type: "numeric", nullable: false),
                    open_24 = table.Column<decimal>(type: "numeric", nullable: false),
                    percent_change_24 = table.Column<decimal>(type: "numeric", nullable: false),
                    ListId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tickerHourDataItems", x => x.id);
                    table.ForeignKey(
                        name: "FK_tickerHourDataItems_tickerHourDataList_ListId",
                        column: x => x.ListId,
                        principalTable: "tickerHourDataList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tickerHourDataItems_ListId",
                table: "tickerHourDataItems",
                column: "ListId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tickerHourDataItems");

            migrationBuilder.DropTable(
                name: "tickerHourDataList");
        }
    }
}
