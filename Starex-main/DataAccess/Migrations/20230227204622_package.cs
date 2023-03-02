using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class package : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "packageStatusId",
                table: "Package",
                type: "int",
                nullable: false,
                defaultValue: 2,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<double>(
                name: "Cost",
                table: "Package",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "CostCurrencyId",
                table: "Package",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "InternalTrackingId",
                table: "Package",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OriginalTrackingId",
                table: "Package",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Package",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PriceCurrencyId",
                table: "Package",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Weight",
                table: "Package",
                type: "float",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedTime",
                table: "News",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 28, 0, 46, 20, 631, DateTimeKind.Local).AddTicks(9732),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 2, 28, 0, 28, 43, 11, DateTimeKind.Local).AddTicks(2037));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cost",
                table: "Package");

            migrationBuilder.DropColumn(
                name: "CostCurrencyId",
                table: "Package");

            migrationBuilder.DropColumn(
                name: "InternalTrackingId",
                table: "Package");

            migrationBuilder.DropColumn(
                name: "OriginalTrackingId",
                table: "Package");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Package");

            migrationBuilder.DropColumn(
                name: "PriceCurrencyId",
                table: "Package");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "Package");

            migrationBuilder.AlterColumn<int>(
                name: "packageStatusId",
                table: "Package",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 2);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedTime",
                table: "News",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 28, 0, 28, 43, 11, DateTimeKind.Local).AddTicks(2037),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 2, 28, 0, 46, 20, 631, DateTimeKind.Local).AddTicks(9732));
        }
    }
}
