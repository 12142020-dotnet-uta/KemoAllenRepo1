using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace P0_KemoAllen.Migrations
{
    public partial class StoreMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "customers",
                columns: table => new
                {
                    userId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customers", x => x.userId);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    productId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UnitPrice = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.productId);
                });

            migrationBuilder.CreateTable(
                name: "inventories",
                columns: table => new
                {
                    inventoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    inventoryProductproductId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    inventoryQuantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_inventories", x => x.inventoryId);
                    table.ForeignKey(
                        name: "FK_inventories_products_inventoryProductproductId",
                        column: x => x.inventoryProductproductId,
                        principalTable: "products",
                        principalColumn: "productId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "locations",
                columns: table => new
                {
                    locationGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LocationName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    locationInventoryinventoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_locations", x => x.locationGuid);
                    table.ForeignKey(
                        name: "FK_locations_inventories_locationInventoryinventoryId",
                        column: x => x.locationInventoryinventoryId,
                        principalTable: "inventories",
                        principalColumn: "inventoryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    orderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    orderProductproductId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    orderQuantity = table.Column<int>(type: "int", nullable: false),
                    orderLocationlocationGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    orderCustomeruserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    timeCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orders", x => x.orderId);
                    table.ForeignKey(
                        name: "FK_orders_customers_orderCustomeruserId",
                        column: x => x.orderCustomeruserId,
                        principalTable: "customers",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_orders_locations_orderLocationlocationGuid",
                        column: x => x.orderLocationlocationGuid,
                        principalTable: "locations",
                        principalColumn: "locationGuid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_orders_products_orderProductproductId",
                        column: x => x.orderProductproductId,
                        principalTable: "products",
                        principalColumn: "productId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_inventories_inventoryProductproductId",
                table: "inventories",
                column: "inventoryProductproductId");

            migrationBuilder.CreateIndex(
                name: "IX_locations_locationInventoryinventoryId",
                table: "locations",
                column: "locationInventoryinventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_orders_orderCustomeruserId",
                table: "orders",
                column: "orderCustomeruserId");

            migrationBuilder.CreateIndex(
                name: "IX_orders_orderLocationlocationGuid",
                table: "orders",
                column: "orderLocationlocationGuid");

            migrationBuilder.CreateIndex(
                name: "IX_orders_orderProductproductId",
                table: "orders",
                column: "orderProductproductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.DropTable(
                name: "customers");

            migrationBuilder.DropTable(
                name: "locations");

            migrationBuilder.DropTable(
                name: "inventories");

            migrationBuilder.DropTable(
                name: "products");
        }
    }
}
