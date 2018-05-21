using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ProsumerInfo.Migrations
{
    public partial class PublicKeyIsUnique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PublicKey",
                table: "Prosumers",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Prosumers_PublicKey",
                table: "Prosumers",
                column: "PublicKey",
                unique: true,
                filter: "[PublicKey] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Prosumers_PublicKey",
                table: "Prosumers");

            migrationBuilder.AlterColumn<string>(
                name: "PublicKey",
                table: "Prosumers",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
