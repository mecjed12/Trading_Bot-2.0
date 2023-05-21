using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataBase.Migrations
{
    /// <inheritdoc />
    public partial class Database6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_historiacalDataItems_tradingPair_tradingPairId",
                table: "historiacalDataItems");

            migrationBuilder.DropTable(
                name: "tradingPair");

            migrationBuilder.DropIndex(
                name: "IX_historiacalDataItems_tradingPairId",
                table: "historiacalDataItems");

            migrationBuilder.DropColumn(
                name: "tradingPairId",
                table: "historiacalDataItems");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "tradingPairId",
                table: "historiacalDataItems",
                type: "integer",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.CreateIndex(
                name: "IX_historiacalDataItems_tradingPairId",
                table: "historiacalDataItems",
                column: "tradingPairId");

            migrationBuilder.AddForeignKey(
                name: "FK_historiacalDataItems_tradingPair_tradingPairId",
                table: "historiacalDataItems",
                column: "tradingPairId",
                principalTable: "tradingPair",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
