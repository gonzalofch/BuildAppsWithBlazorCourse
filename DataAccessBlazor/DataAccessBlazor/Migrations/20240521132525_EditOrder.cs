using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessBlazor.Migrations
{
    /// <inheritdoc />
    public partial class EditOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DeliveryLocationId",
                table: "Orders",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "LatLong",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Latitude = table.Column<double>(type: "REAL", nullable: false),
                    Longitude = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LatLong", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DeliveryLocationId",
                table: "Orders",
                column: "DeliveryLocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_LatLong_DeliveryLocationId",
                table: "Orders",
                column: "DeliveryLocationId",
                principalTable: "LatLong",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_LatLong_DeliveryLocationId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "LatLong");

            migrationBuilder.DropIndex(
                name: "IX_Orders_DeliveryLocationId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DeliveryLocationId",
                table: "Orders");
        }
    }
}
