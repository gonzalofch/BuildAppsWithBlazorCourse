using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessBlazor.Migrations
{
    /// <inheritdoc />
    public partial class EditDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Addresses_DeliveryAddressId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_LatLong_DeliveryLocationId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_PizzaToppings_Pizzas_PizzaId",
                table: "PizzaToppings");

            migrationBuilder.DropForeignKey(
                name: "FK_PizzaToppings_Toppings_ToppingId",
                table: "PizzaToppings");

            migrationBuilder.DropTable(
                name: "LatLong");

            migrationBuilder.DropTable(
                name: "OrdersWithStatus");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Orders_DeliveryLocationId",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PizzaToppings",
                table: "PizzaToppings");

            migrationBuilder.DropIndex(
                name: "IX_PizzaToppings_PizzaId",
                table: "PizzaToppings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Addresses",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "PizzaToppings");

            migrationBuilder.RenameTable(
                name: "PizzaToppings",
                newName: "PizzaTopping");

            migrationBuilder.RenameTable(
                name: "Addresses",
                newName: "Address");

            migrationBuilder.RenameColumn(
                name: "DeliveryLocationId",
                table: "Orders",
                newName: "DeliveryLocation_Id");

            migrationBuilder.RenameIndex(
                name: "IX_PizzaToppings_ToppingId",
                table: "PizzaTopping",
                newName: "IX_PizzaTopping_ToppingId");

            migrationBuilder.AlterColumn<int>(
                name: "OrderId",
                table: "Orders",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<double>(
                name: "DeliveryLocation_Latitude",
                table: "Orders",
                type: "REAL",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "DeliveryLocation_Longitude",
                table: "Orders",
                type: "REAL",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PizzaTopping",
                table: "PizzaTopping",
                columns: new[] { "PizzaId", "ToppingId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Address",
                table: "Address",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Address_DeliveryAddressId",
                table: "Orders",
                column: "DeliveryAddressId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PizzaTopping_Pizzas_PizzaId",
                table: "PizzaTopping",
                column: "PizzaId",
                principalTable: "Pizzas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PizzaTopping_Toppings_ToppingId",
                table: "PizzaTopping",
                column: "ToppingId",
                principalTable: "Toppings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Address_DeliveryAddressId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_PizzaTopping_Pizzas_PizzaId",
                table: "PizzaTopping");

            migrationBuilder.DropForeignKey(
                name: "FK_PizzaTopping_Toppings_ToppingId",
                table: "PizzaTopping");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PizzaTopping",
                table: "PizzaTopping");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Address",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "DeliveryLocation_Latitude",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DeliveryLocation_Longitude",
                table: "Orders");

            migrationBuilder.RenameTable(
                name: "PizzaTopping",
                newName: "PizzaToppings");

            migrationBuilder.RenameTable(
                name: "Address",
                newName: "Addresses");

            migrationBuilder.RenameColumn(
                name: "DeliveryLocation_Id",
                table: "Orders",
                newName: "DeliveryLocationId");

            migrationBuilder.RenameIndex(
                name: "IX_PizzaTopping_ToppingId",
                table: "PizzaToppings",
                newName: "IX_PizzaToppings_ToppingId");

            migrationBuilder.AlterColumn<int>(
                name: "OrderId",
                table: "Orders",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "PizzaToppings",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0)
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PizzaToppings",
                table: "PizzaToppings",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Addresses",
                table: "Addresses",
                column: "Id");

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

            migrationBuilder.CreateTable(
                name: "OrdersWithStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrderId = table.Column<int>(type: "INTEGER", nullable: false),
                    StatusText = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdersWithStatus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrdersWithStatus_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IsAuthenticated = table.Column<bool>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DeliveryLocationId",
                table: "Orders",
                column: "DeliveryLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_PizzaToppings_PizzaId",
                table: "PizzaToppings",
                column: "PizzaId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdersWithStatus_OrderId",
                table: "OrdersWithStatus",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Addresses_DeliveryAddressId",
                table: "Orders",
                column: "DeliveryAddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_LatLong_DeliveryLocationId",
                table: "Orders",
                column: "DeliveryLocationId",
                principalTable: "LatLong",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PizzaToppings_Pizzas_PizzaId",
                table: "PizzaToppings",
                column: "PizzaId",
                principalTable: "Pizzas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PizzaToppings_Toppings_ToppingId",
                table: "PizzaToppings",
                column: "ToppingId",
                principalTable: "Toppings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
