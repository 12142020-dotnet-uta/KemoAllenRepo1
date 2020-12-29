using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace P0_KemoAllen.Migrations
{
    public partial class P0_Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "customers",
                columns: table => new
                {
                    userId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    firstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customers", x => x.userId);
                });

            migrationBuilder.CreateTable(
                name: "inventory",
                columns: table => new
                {
                    inventoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_inventory", x => x.inventoryId);
                });

            migrationBuilder.CreateTable(
                name: "locations",
                columns: table => new
                {
                    locationGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    locationName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    locationInventoryinventoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_locations", x => x.locationGuid);
                    table.ForeignKey(
                        name: "FK_locations_inventory_locationInventoryinventoryId",
                        column: x => x.locationInventoryinventoryId,
                        principalTable: "inventory",
                        principalColumn: "inventoryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    orderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                });

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
                name: "inventory");
        }
    }
}
