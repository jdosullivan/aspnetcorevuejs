using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace data2.Migrations
{
    public partial class oneToManyEventGroups : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "GroupId",
                table: "Events",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Events_GroupId",
                table: "Events",
                column: "GroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Groups_GroupId",
                table: "Events",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Groups_GroupId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_GroupId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "Events");
        }
    }
}
