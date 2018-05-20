using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ProsumerInfo.Migrations
{
    public partial class addedNewForeignKeySmartMeter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prosumers_SmartMeters_SmartMeterId",
                table: "Prosumers");

            migrationBuilder.AlterColumn<int>(
                name: "SmartMeterId",
                table: "Prosumers",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Prosumers_SmartMeters_SmartMeterId",
                table: "Prosumers",
                column: "SmartMeterId",
                principalTable: "SmartMeters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prosumers_SmartMeters_SmartMeterId",
                table: "Prosumers");

            migrationBuilder.AlterColumn<int>(
                name: "SmartMeterId",
                table: "Prosumers",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Prosumers_SmartMeters_SmartMeterId",
                table: "Prosumers",
                column: "SmartMeterId",
                principalTable: "SmartMeters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
