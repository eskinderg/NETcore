using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ProjectAPI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "content_folder_tbl",
                columns: table => new
                {
                    folder_id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    folder_name = table.Column<string>(nullable: true),
                    parent_id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_content_folder_tbl", x => x.folder_id);
                    table.ForeignKey(
                        name: "FK_content_folder_tbl_content_folder_tbl_parent_id",
                        column: x => x.parent_id,
                        principalTable: "content_folder_tbl",
                        principalColumn: "folder_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SubCategory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "content",
                columns: table => new
                {
                    content_id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    folder_id = table.Column<int>(nullable: false),
                    content_html = table.Column<string>(nullable: true),
                    content_teaser = table.Column<string>(nullable: true),
                    content_title = table.Column<string>(nullable: true),
                    xml_config_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_content", x => x.content_id);
                    table.ForeignKey(
                        name: "FK_content_content_folder_tbl_folder_id",
                        column: x => x.folder_id,
                        principalTable: "content_folder_tbl",
                        principalColumn: "folder_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    SubCategory_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_SubCategory_SubCategory_Id",
                        column: x => x.SubCategory_Id,
                        principalTable: "SubCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_SubCategory_Id",
                table: "Categories",
                column: "SubCategory_Id");

            migrationBuilder.CreateIndex(
                name: "IX_content_folder_id",
                table: "content",
                column: "folder_id");

            migrationBuilder.CreateIndex(
                name: "IX_content_folder_tbl_parent_id",
                table: "content_folder_tbl",
                column: "parent_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "content");

            migrationBuilder.DropTable(
                name: "SubCategory");

            migrationBuilder.DropTable(
                name: "content_folder_tbl");
        }
    }
}
