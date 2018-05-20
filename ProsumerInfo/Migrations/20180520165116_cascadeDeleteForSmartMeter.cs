using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ProsumerInfo.Migrations
{
    public partial class cascadeDeleteForSmartMeter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Prosumers_SmartMeterId",
                table: "Prosumers");

            migrationBuilder.CreateIndex(
                name: "IX_Prosumers_SmartMeterId",
                table: "Prosumers",
                column: "SmartMeterId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Prosumers_SmartMeterId",
                table: "Prosumers");

            migrationBuilder.CreateIndex(
                name: "IX_Prosumers_SmartMeterId",
                table: "Prosumers",
                column: "SmartMeterId");
        }
    }
}
