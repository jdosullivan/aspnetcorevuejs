using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace data2.Migrations
{
    public partial class AddMainImageToGroups : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "MainImageId",
                table: "Groups",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Images_MainImageId",
                table: "Groups",
                column: "MainImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Images_MainImageId",
                table: "Groups");			

            migrationBuilder.DropColumn(
                name: "MainImageId",
                table: "Groups");
        }
    }
}
