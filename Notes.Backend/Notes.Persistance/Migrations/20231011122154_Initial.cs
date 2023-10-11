using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Notes.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Notes",
                columns: table => new
                {
                    NoteId = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    Details = table.Column<string>(type: "text", nullable: true),
                    DateNote = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DateCreation = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateEdit = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notes", x => x.NoteId);
                });

            migrationBuilder.CreateTable(
                name: "Notices",
                columns: table => new
                {
                    NoticeId = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    DateCreation = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateEdit = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Deadline = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notices", x => x.NoticeId);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    TagId = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.TagId);
                });

            migrationBuilder.CreateTable(
                name: "NoteTag",
                columns: table => new
                {
                    NotesNoteId = table.Column<Guid>(type: "uuid", nullable: false),
                    TagsTagId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoteTag", x => new { x.NotesNoteId, x.TagsTagId });
                    table.ForeignKey(
                        name: "FK_NoteTag_Notes_NotesNoteId",
                        column: x => x.NotesNoteId,
                        principalTable: "Notes",
                        principalColumn: "NoteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NoteTag_Tags_TagsTagId",
                        column: x => x.TagsTagId,
                        principalTable: "Tags",
                        principalColumn: "TagId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NoticeTag",
                columns: table => new
                {
                    NoticesNoticeId = table.Column<Guid>(type: "uuid", nullable: false),
                    TagsTagId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoticeTag", x => new { x.NoticesNoticeId, x.TagsTagId });
                    table.ForeignKey(
                        name: "FK_NoticeTag_Notices_NoticesNoticeId",
                        column: x => x.NoticesNoticeId,
                        principalTable: "Notices",
                        principalColumn: "NoticeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NoticeTag_Tags_TagsTagId",
                        column: x => x.TagsTagId,
                        principalTable: "Tags",
                        principalColumn: "TagId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Notes_NoteId",
                table: "Notes",
                column: "NoteId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NoteTag_TagsTagId",
                table: "NoteTag",
                column: "TagsTagId");

            migrationBuilder.CreateIndex(
                name: "IX_NoticeTag_TagsTagId",
                table: "NoticeTag",
                column: "TagsTagId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NoteTag");

            migrationBuilder.DropTable(
                name: "NoticeTag");

            migrationBuilder.DropTable(
                name: "Notes");

            migrationBuilder.DropTable(
                name: "Notices");

            migrationBuilder.DropTable(
                name: "Tags");
        }
    }
}
