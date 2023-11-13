using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cryptolus.Persistant.Migrations
{
    /// <inheritdoc />
    public partial class addPhotoForUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Image",
                table: "Authors",
                newName: "Photo");

            migrationBuilder.AddColumn<string>(
                name: "Photo",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Photo",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "Photo",
                table: "Authors",
                newName: "Image");
        }
    }
}
