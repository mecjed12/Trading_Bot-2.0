using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataBase.Migrations
{
    /// <inheritdoc />
    public partial class NewDatabase3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TradingPairItems");

            migrationBuilder.DropTable(
                name: "TradingPairList");

            migrationBuilder.CreateTable(
                name: "tickerDataList",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: true),
                    timestampstart = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    timestampend = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    datasize = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tickerDataList", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tickerDataItems",
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
                    TickerDataListListId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tickerDataItems", x => x.id);
                    table.ForeignKey(
                        name: "FK_tickerDataItems_tickerDataList_TickerDataListListId",
                        column: x => x.TickerDataListListId,
                        principalTable: "tickerDataList",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_tickerDataItems_TickerDataListListId",
                table: "tickerDataItems",
                column: "TickerDataListListId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tickerDataItems");

            migrationBuilder.DropTable(
                name: "tickerDataList");

            migrationBuilder.CreateTable(
                name: "TradingPairList",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    datasize = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TradingPairList", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TradingPairItems",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ListId = table.Column<int>(type: "integer", nullable: false),
                    base_decimals = table.Column<int>(type: "integer", nullable: false),
                    counter_decimals = table.Column<int>(type: "integer", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    instant_and_market_orders = table.Column<string>(type: "text", nullable: true),
                    instant_order_counter_decimals = table.Column<int>(type: "integer", nullable: false),
                    minimum_order = table.Column<string>(type: "text", nullable: true),
                    name = table.Column<string>(type: "text", nullable: true),
                    trading = table.Column<string>(type: "text", nullable: true),
                    url_symbol = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TradingPairItems", x => x.id);
                    table.ForeignKey(
                        name: "FK_TradingPairItems_TradingPairList_ListId",
                        column: x => x.ListId,
                        principalTable: "TradingPairList",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TradingPairItems_ListId",
                table: "TradingPairItems",
                column: "ListId");
        }
    }
}
