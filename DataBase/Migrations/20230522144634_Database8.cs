using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataBase.Migrations
{
    /// <inheritdoc />
    public partial class Database8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    name = table.Column<string>(type: "text", nullable: true),
                    url_symbol = table.Column<string>(type: "text", nullable: true),
                    base_decimals = table.Column<decimal>(type: "numeric", nullable: false),
                    counter_decimals = table.Column<decimal>(type: "numeric", nullable: false),
                    instant_order_counter_decimals = table.Column<decimal>(type: "numeric", nullable: false),
                    minimum_order = table.Column<decimal>(type: "numeric", nullable: false),
                    trading = table.Column<string>(type: "text", nullable: true),
                    instant_and_market_orders = table.Column<string>(type: "text", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    ListId = table.Column<int>(type: "integer", nullable: false)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TradingPairItems");

            migrationBuilder.DropTable(
                name: "TradingPairList");
        }
    }
}
