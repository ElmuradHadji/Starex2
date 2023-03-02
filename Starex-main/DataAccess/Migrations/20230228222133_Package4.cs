using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class Package4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedTime",
                table: "News",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 1, 2, 21, 32, 626, DateTimeKind.Local).AddTicks(511),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 1, 1, 23, 17, 897, DateTimeKind.Local).AddTicks(5779));

            migrationBuilder.CreateIndex(
                name: "IX_Package_InternalTrackingId",
                table: "Package",
                column: "InternalTrackingId",
                unique: true,
                filter: "[InternalTrackingId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Package_InternalTrackingId",
                table: "Package");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedTime",
                table: "News",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 1, 1, 23, 17, 897, DateTimeKind.Local).AddTicks(5779),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 1, 2, 21, 32, 626, DateTimeKind.Local).AddTicks(511));
        }
    }
}
