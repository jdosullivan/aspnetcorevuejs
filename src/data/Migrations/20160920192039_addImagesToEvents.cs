using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace data2.Migrations
{
    public partial class addImagesToEvents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EventImage",
                columns: table => new
                {
                    EventId = table.Column<long>(nullable: false),
                    ImageId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventImage", x => new { x.EventId, x.ImageId });
                    table.ForeignKey(
                        name: "FK_EventImage_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.AddColumn<long>(
                name: "MainImageId",
                table: "Events",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Events_MainImageId",
                table: "Events",
                column: "MainImageId");

            migrationBuilder.CreateIndex(
                name: "IX_EventImage_EventId",
                table: "EventImage",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Images_MainImageId",
                table: "Events",
                column: "MainImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Images_MainImageId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_MainImageId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "MainImageId",
                table: "Events");

            migrationBuilder.DropTable(
                name: "EventImage");
        }
    }
}
