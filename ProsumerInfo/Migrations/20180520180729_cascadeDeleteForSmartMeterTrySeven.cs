using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ProsumerInfo.Migrations
{
    public partial class cascadeDeleteForSmartMeterTrySeven : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prosumers_SmartMeters_SmartMeterId",
                table: "Prosumers");

            migrationBuilder.DropIndex(
                name: "IX_Prosumers_SmartMeterId",
                table: "Prosumers");

            migrationBuilder.CreateIndex(
                name: "IX_Prosumers_SmartMeterId",
                table: "Prosumers",
                column: "SmartMeterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Prosumers_SmartMeters_SmartMeterId",
                table: "Prosumers",
                column: "SmartMeterId",
                principalTable: "SmartMeters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prosumers_SmartMeters_SmartMeterId",
                table: "Prosumers");

            migrationBuilder.DropIndex(
                name: "IX_Prosumers_SmartMeterId",
                table: "Prosumers");

            migrationBuilder.CreateIndex(
                name: "IX_Prosumers_SmartMeterId",
                table: "Prosumers",
                column: "SmartMeterId",
                unique: true,
                filter: "[SmartMeterId] IS NOT NULL");

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
