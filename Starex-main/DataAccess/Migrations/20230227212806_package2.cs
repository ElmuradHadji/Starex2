using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class package2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Package_Branches_BranchId",
                table: "Package");

            migrationBuilder.DropForeignKey(
                name: "FK_Package_WareHouses_WareHouseId",
                table: "Package");

            migrationBuilder.RenameColumn(
                name: "WareHouseId",
                table: "Package",
                newName: "wareHouseId");

            migrationBuilder.RenameColumn(
                name: "BranchId",
                table: "Package",
                newName: "branchId");

            migrationBuilder.RenameIndex(
                name: "IX_Package_WareHouseId",
                table: "Package",
                newName: "IX_Package_wareHouseId");

            migrationBuilder.RenameIndex(
                name: "IX_Package_BranchId",
                table: "Package",
                newName: "IX_Package_branchId");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Package",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedTime",
                table: "News",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 28, 1, 28, 6, 141, DateTimeKind.Local).AddTicks(2228),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 2, 28, 0, 46, 20, 631, DateTimeKind.Local).AddTicks(9732));

            migrationBuilder.AddForeignKey(
                name: "FK_Package_Branches_branchId",
                table: "Package",
                column: "branchId",
                principalTable: "Branches",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Package_WareHouses_wareHouseId",
                table: "Package",
                column: "wareHouseId",
                principalTable: "WareHouses",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Package_Branches_branchId",
                table: "Package");

            migrationBuilder.DropForeignKey(
                name: "FK_Package_WareHouses_wareHouseId",
                table: "Package");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Package");

            migrationBuilder.RenameColumn(
                name: "wareHouseId",
                table: "Package",
                newName: "WareHouseId");

            migrationBuilder.RenameColumn(
                name: "branchId",
                table: "Package",
                newName: "BranchId");

            migrationBuilder.RenameIndex(
                name: "IX_Package_wareHouseId",
                table: "Package",
                newName: "IX_Package_WareHouseId");

            migrationBuilder.RenameIndex(
                name: "IX_Package_branchId",
                table: "Package",
                newName: "IX_Package_BranchId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedTime",
                table: "News",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 28, 0, 46, 20, 631, DateTimeKind.Local).AddTicks(9732),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 2, 28, 1, 28, 6, 141, DateTimeKind.Local).AddTicks(2228));

            migrationBuilder.AddForeignKey(
                name: "FK_Package_Branches_BranchId",
                table: "Package",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Package_WareHouses_WareHouseId",
                table: "Package",
                column: "WareHouseId",
                principalTable: "WareHouses",
                principalColumn: "Id");
        }
    }
}
