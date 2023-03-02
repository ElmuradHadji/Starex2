using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class relation1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedTime",
                table: "News",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 28, 0, 28, 43, 11, DateTimeKind.Local).AddTicks(2037),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 2, 27, 1, 28, 44, 147, DateTimeKind.Local).AddTicks(6595));

            migrationBuilder.AddColumn<int>(
                name: "WareHouseId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_WareHouseId",
                table: "AspNetUsers",
                column: "WareHouseId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_WareHouses_WareHouseId",
                table: "AspNetUsers",
                column: "WareHouseId",
                principalTable: "WareHouses",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_WareHouses_WareHouseId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_WareHouseId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "WareHouseId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedTime",
                table: "News",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 27, 1, 28, 44, 147, DateTimeKind.Local).AddTicks(6595),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 2, 28, 0, 28, 43, 11, DateTimeKind.Local).AddTicks(2037));
        }
    }
}
