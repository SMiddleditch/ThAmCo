using Microsoft.EntityFrameworkCore.Migrations;

namespace ThAmCo.Events.Migrations
{
    public partial class updateEvent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Staff",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "Attendance",
                table: "Customer",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Customer",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "CustomerId",
                keyValue: 1,
                columns: new[] { "Attendance", "Email" },
                values: new object[] { true, "steHawk@gmail.com" });

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "CustomerId",
                keyValue: 2,
                column: "Email",
                value: "alEinstein@gmail.com");

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "CustomerId",
                keyValue: 3,
                columns: new[] { "Attendance", "Email" },
                values: new object[] { true, "carlSa@gmail.com" });

            migrationBuilder.UpdateData(
                table: "Staff",
                keyColumn: "StaffId",
                keyValue: 1,
                column: "Email",
                value: "JJ@gmail.com");

            migrationBuilder.UpdateData(
                table: "Staff",
                keyColumn: "StaffId",
                keyValue: 2,
                column: "Email",
                value: "SH@gmail.com");

            migrationBuilder.UpdateData(
                table: "Staff",
                keyColumn: "StaffId",
                keyValue: 3,
                column: "Email",
                value: "PW@gmail.com");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Staff");

            migrationBuilder.DropColumn(
                name: "Attendance",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Customer");
        }
    }
}
