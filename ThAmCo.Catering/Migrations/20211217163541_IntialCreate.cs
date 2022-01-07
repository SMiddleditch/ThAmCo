using Microsoft.EntityFrameworkCore.Migrations;

namespace ThAmCo.Catering.Migrations
{
    public partial class IntialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "foodItems",
                columns: table => new
                {
                    FoodItemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: false),
                    UnitPrice = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_foodItems", x => x.FoodItemId);
                });

            migrationBuilder.CreateTable(
                name: "Menu",
                columns: table => new
                {
                    MenuId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MenuName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu", x => x.MenuId);
                });

            migrationBuilder.CreateTable(
                name: "foodBooking",
                columns: table => new
                {
                    FoodBookingId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MenuId = table.Column<int>(nullable: false),
                    ClientReference = table.Column<int>(nullable: false),
                    NumberOfGuest = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_foodBooking", x => x.FoodBookingId);
                    table.ForeignKey(
                        name: "FK_foodBooking_Menu_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menu",
                        principalColumn: "MenuId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "menuFoodItem",
                columns: table => new
                {
                    MenuId = table.Column<int>(nullable: false),
                    FoodItemId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_menuFoodItem", x => new { x.MenuId, x.FoodItemId });
                    table.ForeignKey(
                        name: "FK_menuFoodItem_foodItems_FoodItemId",
                        column: x => x.FoodItemId,
                        principalTable: "foodItems",
                        principalColumn: "FoodItemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_menuFoodItem_Menu_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menu",
                        principalColumn: "MenuId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Menu",
                columns: new[] { "MenuId", "MenuName" },
                values: new object[,]
                {
                    { 1, "BBQ" },
                    { 2, "Roast" },
                    { 3, "Cakes" }
                });

            migrationBuilder.InsertData(
                table: "foodItems",
                columns: new[] { "FoodItemId", "Description", "UnitPrice" },
                values: new object[,]
                {
                    { 1, "Sausages", 100f },
                    { 2, "Chicken", 200f },
                    { 3, "RedVelvet", 300f }
                });

            migrationBuilder.InsertData(
                table: "foodBooking",
                columns: new[] { "FoodBookingId", "ClientReference", "MenuId", "NumberOfGuest" },
                values: new object[,]
                {
                    { 1, 1, 1, 10 },
                    { 2, 2, 2, 20 },
                    { 3, 3, 3, 30 }
                });

            migrationBuilder.InsertData(
                table: "menuFoodItem",
                columns: new[] { "MenuId", "FoodItemId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_foodBooking_MenuId",
                table: "foodBooking",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_menuFoodItem_FoodItemId",
                table: "menuFoodItem",
                column: "FoodItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "foodBooking");

            migrationBuilder.DropTable(
                name: "menuFoodItem");

            migrationBuilder.DropTable(
                name: "foodItems");

            migrationBuilder.DropTable(
                name: "Menu");
        }
    }
}
