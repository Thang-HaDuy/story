using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace back_end.Migrations
{
    /// <inheritdoc />
    public partial class updatemodelepisode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Views_Movies_MovieId",
                table: "Views");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Views",
                table: "Views");

            migrationBuilder.RenameColumn(
                name: "MovieId",
                table: "Views",
                newName: "EpisodeId");

            migrationBuilder.RenameIndex(
                name: "IX_Views_MovieId",
                table: "Views",
                newName: "IX_Views_EpisodeId");

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "Views",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Views",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Views",
                table: "Views",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Views_UserId",
                table: "Views",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Views_Episodes_EpisodeId",
                table: "Views",
                column: "EpisodeId",
                principalTable: "Episodes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Views_Episodes_EpisodeId",
                table: "Views");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Views",
                table: "Views");

            migrationBuilder.DropIndex(
                name: "IX_Views_UserId",
                table: "Views");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Views");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Views");

            migrationBuilder.RenameColumn(
                name: "EpisodeId",
                table: "Views",
                newName: "MovieId");

            migrationBuilder.RenameIndex(
                name: "IX_Views_EpisodeId",
                table: "Views",
                newName: "IX_Views_MovieId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Views",
                table: "Views",
                columns: new[] { "UserId", "MovieId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Views_Movies_MovieId",
                table: "Views",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
