using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ProsumerInfo.Migrations
{
    public partial class cascadeDeleteForSmartMeterTryFive : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prosumers_SmartMeters_SmartMeterId",
                table: "Prosumers");

            migrationBuilder.DropIndex(
                name: "IX_Prosumers_SmartMeterId",
                table: "Prosumers");

            migrationBuilder.DropColumn(
                name: "SmartMeterId",
                table: "Prosumers");

            migrationBuilder.AddColumn<int>(
                name: "ProsumerForeignKey",
                table: "SmartMeters",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SmartMeters_ProsumerForeignKey",
                table: "SmartMeters",
                column: "ProsumerForeignKey",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SmartMeters_Prosumers_ProsumerForeignKey",
                table: "SmartMeters",
                column: "ProsumerForeignKey",
                principalTable: "Prosumers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SmartMeters_Prosumers_ProsumerForeignKey",
                table: "SmartMeters");

            migrationBuilder.DropIndex(
                name: "IX_SmartMeters_ProsumerForeignKey",
                table: "SmartMeters");

            migrationBuilder.DropColumn(
                name: "ProsumerForeignKey",
                table: "SmartMeters");

            migrationBuilder.AddColumn<int>(
                name: "SmartMeterId",
                table: "Prosumers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Prosumers_SmartMeterId",
                table: "Prosumers",
                column: "SmartMeterId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Prosumers_SmartMeters_SmartMeterId",
                table: "Prosumers",
                column: "SmartMeterId",
                principalTable: "SmartMeters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
