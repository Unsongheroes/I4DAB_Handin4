using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ProsumerInfo.Migrations
{
    public partial class UpdatedModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GeneratedPower",
                table: "SmartMeters");

            migrationBuilder.DropColumn(
                name: "UsedPower",
                table: "SmartMeters");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GeneratedPower",
                table: "SmartMeters",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UsedPower",
                table: "SmartMeters",
                nullable: false,
                defaultValue: 0);
        }
    }
}
