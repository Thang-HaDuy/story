using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace back_end.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMovie : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryMovie_movies_MovieId",
                table: "CategoryMovie");

            migrationBuilder.DropForeignKey(
                name: "FK_episodes_movies_MovieId",
                table: "episodes");

            migrationBuilder.DropForeignKey(
                name: "FK_Follows_movies_MovieId",
                table: "Follows");

            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_movies_MovieId",
                table: "Ratings");

            migrationBuilder.DropForeignKey(
                name: "FK_View_movies_MovieId",
                table: "View");

            migrationBuilder.DropPrimaryKey(
                name: "PK_movies",
                table: "movies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_episodes",
                table: "episodes");

            migrationBuilder.RenameTable(
                name: "movies",
                newName: "Movies");

            migrationBuilder.RenameTable(
                name: "episodes",
                newName: "Episodes");

            migrationBuilder.RenameColumn(
                name: "FileName",
                table: "Movies",
                newName: "Background");

            migrationBuilder.RenameIndex(
                name: "IX_episodes_MovieId",
                table: "Episodes",
                newName: "IX_Episodes_MovieId");

            migrationBuilder.AddColumn<string>(
                name: "Avatar",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Movies",
                table: "Movies",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Episodes",
                table: "Episodes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryMovie_Movies_MovieId",
                table: "CategoryMovie",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Episodes_Movies_MovieId",
                table: "Episodes",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Follows_Movies_MovieId",
                table: "Follows",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Movies_MovieId",
                table: "Ratings",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_View_Movies_MovieId",
                table: "View",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryMovie_Movies_MovieId",
                table: "CategoryMovie");

            migrationBuilder.DropForeignKey(
                name: "FK_Episodes_Movies_MovieId",
                table: "Episodes");

            migrationBuilder.DropForeignKey(
                name: "FK_Follows_Movies_MovieId",
                table: "Follows");

            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Movies_MovieId",
                table: "Ratings");

            migrationBuilder.DropForeignKey(
                name: "FK_View_Movies_MovieId",
                table: "View");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Movies",
                table: "Movies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Episodes",
                table: "Episodes");

            migrationBuilder.DropColumn(
                name: "Avatar",
                table: "Movies");

            migrationBuilder.RenameTable(
                name: "Movies",
                newName: "movies");

            migrationBuilder.RenameTable(
                name: "Episodes",
                newName: "episodes");

            migrationBuilder.RenameColumn(
                name: "Background",
                table: "movies",
                newName: "FileName");

            migrationBuilder.RenameIndex(
                name: "IX_Episodes_MovieId",
                table: "episodes",
                newName: "IX_episodes_MovieId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_movies",
                table: "movies",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_episodes",
                table: "episodes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryMovie_movies_MovieId",
                table: "CategoryMovie",
                column: "MovieId",
                principalTable: "movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_episodes_movies_MovieId",
                table: "episodes",
                column: "MovieId",
                principalTable: "movies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Follows_movies_MovieId",
                table: "Follows",
                column: "MovieId",
                principalTable: "movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_movies_MovieId",
                table: "Ratings",
                column: "MovieId",
                principalTable: "movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_View_movies_MovieId",
                table: "View",
                column: "MovieId",
                principalTable: "movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
