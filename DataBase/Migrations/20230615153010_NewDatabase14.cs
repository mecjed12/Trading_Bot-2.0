using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataBase.Migrations
{
    /// <inheritdoc />
    public partial class NewDatabase14 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_historiacalDataItems_HystoricalCryptoDataList_HystoriaclCry~",
                table: "historiacalDataItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HystoricalCryptoDataItems",
                table: "HystoricalCryptoDataItems");

            migrationBuilder.DropIndex(
                name: "IX_historiacalDataItems_HystoriaclCryptoDataistListId",
                table: "historiacalDataItems");

            migrationBuilder.DropColumn(
                name: "HystoriaclCryptoDataistListId",
                table: "historiacalDataItems");

            migrationBuilder.AddColumn<int>(
                name: "id",
                table: "HystoricalCryptoDataItems",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_HystoricalCryptoDataItems",
                table: "HystoricalCryptoDataItems",
                column: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_HystoricalCryptoDataItems",
                table: "HystoricalCryptoDataItems");

            migrationBuilder.DropColumn(
                name: "id",
                table: "HystoricalCryptoDataItems");

            migrationBuilder.AddColumn<int>(
                name: "HystoriaclCryptoDataistListId",
                table: "historiacalDataItems",
                type: "integer",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_HystoricalCryptoDataItems",
                table: "HystoricalCryptoDataItems",
                column: "Volume");

            migrationBuilder.CreateIndex(
                name: "IX_historiacalDataItems_HystoriaclCryptoDataistListId",
                table: "historiacalDataItems",
                column: "HystoriaclCryptoDataistListId");

            migrationBuilder.AddForeignKey(
                name: "FK_historiacalDataItems_HystoricalCryptoDataList_HystoriaclCry~",
                table: "historiacalDataItems",
                column: "HystoriaclCryptoDataistListId",
                principalTable: "HystoricalCryptoDataList",
                principalColumn: "id");
        }
    }
}
