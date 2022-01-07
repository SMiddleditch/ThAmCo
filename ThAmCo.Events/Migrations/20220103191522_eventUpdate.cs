using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ThAmCo.Events.Migrations
{
    public partial class eventUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "EventType",
                table: "Event",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTime",
                table: "Event",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "EventTitle",
                table: "Event",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "EventId",
                keyValue: 1,
                columns: new[] { "DateTime", "EventTitle", "EventType" },
                values: new object[] { new DateTime(2021, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wedding", "Party" });

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "EventId",
                keyValue: 2,
                columns: new[] { "DateTime", "EventTitle", "EventType" },
                values: new object[] { new DateTime(2019, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Birthday", "Party" });

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "EventId",
                keyValue: 3,
                columns: new[] { "DateTime", "EventTitle", "EventType" },
                values: new object[] { new DateTime(2018, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Funeral", "Party" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateTime",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "EventTitle",
                table: "Event");

            migrationBuilder.AlterColumn<string>(
                name: "EventType",
                table: "Event",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "EventId",
                keyValue: 1,
                column: "EventType",
                value: "Wedding");

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "EventId",
                keyValue: 2,
                column: "EventType",
                value: "Birthday");

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "EventId",
                keyValue: 3,
                column: "EventType",
                value: "Funeral");
        }
    }
}
