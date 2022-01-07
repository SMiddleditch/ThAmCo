using Microsoft.EntityFrameworkCore.Migrations;

namespace ThAmCo.Events.Migrations
{
    public partial class IntialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    CustomerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    EventId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventType = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.EventId);
                });

            migrationBuilder.CreateTable(
                name: "Staff",
                columns: table => new
                {
                    StaffId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    JobType = table.Column<string>(nullable: false),
                    FirstAid = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staff", x => x.StaffId);
                });

            migrationBuilder.CreateTable(
                name: "GuestBooking",
                columns: table => new
                {
                    CustomerId = table.Column<int>(nullable: false),
                    EventId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuestBooking", x => new { x.CustomerId, x.EventId });
                    table.ForeignKey(
                        name: "FK_GuestBooking_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GuestBooking_Event_EventId",
                        column: x => x.EventId,
                        principalTable: "Event",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Staffing",
                columns: table => new
                {
                    EventId = table.Column<int>(nullable: false),
                    StaffId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staffing", x => new { x.EventId, x.StaffId });
                    table.ForeignKey(
                        name: "FK_Staffing_Event_EventId",
                        column: x => x.EventId,
                        principalTable: "Event",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Staffing_Staff_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Staff",
                        principalColumn: "StaffId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "CustomerId", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "Stephen", "Hawking" },
                    { 2, "Albert", "Einstein" },
                    { 3, "Carl", "Sagan" }
                });

            migrationBuilder.InsertData(
                table: "Event",
                columns: new[] { "EventId", "EventType" },
                values: new object[,]
                {
                    { 1, "Wedding" },
                    { 2, "Birthday" },
                    { 3, "Funeral" }
                });

            migrationBuilder.InsertData(
                table: "Staff",
                columns: new[] { "StaffId", "FirstAid", "FirstName", "JobType", "LastName" },
                values: new object[,]
                {
                    { 1, true, "Jack", "Chef", "Johnson" },
                    { 2, false, "Sarah", "Server", "Hawking" },
                    { 3, false, "Paul", "Cleaner", "Walker" }
                });

            migrationBuilder.InsertData(
                table: "GuestBooking",
                columns: new[] { "CustomerId", "EventId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "Staffing",
                columns: new[] { "EventId", "StaffId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_GuestBooking_EventId",
                table: "GuestBooking",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Staffing_StaffId",
                table: "Staffing",
                column: "StaffId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GuestBooking");

            migrationBuilder.DropTable(
                name: "Staffing");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Event");

            migrationBuilder.DropTable(
                name: "Staff");
        }
    }
}
