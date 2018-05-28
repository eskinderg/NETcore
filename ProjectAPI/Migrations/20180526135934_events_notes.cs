using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ProjectAPI.Migrations
{
    public partial class events_notes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "event_tbl",
                columns: table => new
                {
                    event_id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    complete = table.Column<bool>(nullable: false),
                    title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_event_tbl", x => x.event_id);
                });

            migrationBuilder.CreateTable(
                name: "note_tbl",
                columns: table => new
                {
                    note_id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    colour = table.Column<string>(nullable: true),
                    height = table.Column<int>(nullable: false),
                    left = table.Column<int>(nullable: false),
                    text = table.Column<string>(nullable: true),
                    top = table.Column<int>(nullable: false),
                    width = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_note_tbl", x => x.note_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "event_tbl");

            migrationBuilder.DropTable(
                name: "note_tbl");
        }
    }
}
