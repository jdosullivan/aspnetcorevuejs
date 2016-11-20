using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace data2.Migrations
{
    public partial class createGroupTags : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GroupTag",
                columns: table => new
                {
                    TagId = table.Column<long>(nullable: false),
                    GroupId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupTag", x => new { x.TagId, x.GroupId });
                    table.ForeignKey(
                        name: "FK_GroupTag_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GroupTag_TagId",
                table: "GroupTag",
                column: "TagId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroupTag");
        }
    }
}
