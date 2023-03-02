using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class Priceing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedTime",
                table: "News",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 27, 0, 58, 31, 857, DateTimeKind.Local).AddTicks(3253),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 2, 25, 0, 19, 27, 425, DateTimeKind.Local).AddTicks(6589));

            migrationBuilder.CreateTable(
                name: "Prices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MinKG = table.Column<double>(type: "float", nullable: false),
                    MaxKG = table.Column<double>(type: "float", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prices", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prices");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedTime",
                table: "News",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 25, 0, 19, 27, 425, DateTimeKind.Local).AddTicks(6589),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 2, 27, 0, 58, 31, 857, DateTimeKind.Local).AddTicks(3253));
        }
    }
}
