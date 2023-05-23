using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataBase.Migrations
{
    /// <inheritdoc />
    public partial class NewDatabase4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tickerDataItems_tickerDataList_TickerDataListListId",
                table: "tickerDataItems");

            migrationBuilder.DropIndex(
                name: "IX_tickerDataItems_TickerDataListListId",
                table: "tickerDataItems");

            migrationBuilder.DropColumn(
                name: "TickerDataListListId",
                table: "tickerDataItems");

            migrationBuilder.AddColumn<int>(
                name: "ListId",
                table: "tickerDataItems",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_tickerDataItems_ListId",
                table: "tickerDataItems",
                column: "ListId");

            migrationBuilder.AddForeignKey(
                name: "FK_tickerDataItems_tickerDataList_ListId",
                table: "tickerDataItems",
                column: "ListId",
                principalTable: "tickerDataList",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tickerDataItems_tickerDataList_ListId",
                table: "tickerDataItems");

            migrationBuilder.DropIndex(
                name: "IX_tickerDataItems_ListId",
                table: "tickerDataItems");

            migrationBuilder.DropColumn(
                name: "ListId",
                table: "tickerDataItems");

            migrationBuilder.AddColumn<int>(
                name: "TickerDataListListId",
                table: "tickerDataItems",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tickerDataItems_TickerDataListListId",
                table: "tickerDataItems",
                column: "TickerDataListListId");

            migrationBuilder.AddForeignKey(
                name: "FK_tickerDataItems_tickerDataList_TickerDataListListId",
                table: "tickerDataItems",
                column: "TickerDataListListId",
                principalTable: "tickerDataList",
                principalColumn: "id");
        }
    }
}
