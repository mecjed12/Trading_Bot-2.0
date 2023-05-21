using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataBase.Migrations
{
    /// <inheritdoc />
    public partial class Database4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_historiacalDataItems_Historicaldatalist_listId",
                table: "historiacalDataItems");

            migrationBuilder.RenameColumn(
                name: "listId",
                table: "historiacalDataItems",
                newName: "ListId");

            migrationBuilder.RenameIndex(
                name: "IX_historiacalDataItems_listId",
                table: "historiacalDataItems",
                newName: "IX_historiacalDataItems_ListId");

            migrationBuilder.AddForeignKey(
                name: "FK_historiacalDataItems_Historicaldatalist_ListId",
                table: "historiacalDataItems",
                column: "ListId",
                principalTable: "Historicaldatalist",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_historiacalDataItems_Historicaldatalist_ListId",
                table: "historiacalDataItems");

            migrationBuilder.RenameColumn(
                name: "ListId",
                table: "historiacalDataItems",
                newName: "listId");

            migrationBuilder.RenameIndex(
                name: "IX_historiacalDataItems_ListId",
                table: "historiacalDataItems",
                newName: "IX_historiacalDataItems_listId");

            migrationBuilder.AddForeignKey(
                name: "FK_historiacalDataItems_Historicaldatalist_listId",
                table: "historiacalDataItems",
                column: "listId",
                principalTable: "Historicaldatalist",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
