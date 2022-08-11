using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FriendMusic.Migrations
{
    public partial class PrepForApiDeployment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Songs",
                newName: "Title");

            migrationBuilder.AddColumn<string>(
                name: "AlbumTitle",
                table: "Songs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AlbumTitle",
                table: "Songs");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Songs",
                newName: "Name");
        }
    }
}
