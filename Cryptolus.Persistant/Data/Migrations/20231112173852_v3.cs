using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cryptolus.Persistant.Migrations
{
    /// <inheritdoc />
    public partial class v3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Result",
                table: "PositionInfo",
                newName: "PositionResult");

            migrationBuilder.RenameColumn(
                name: "TakeProffit",
                table: "OpenPositionInfo",
                newName: "TakeProfit");

            migrationBuilder.RenameColumn(
                name: "StopLose",
                table: "OpenPositionInfo",
                newName: "StopLoss");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PositionResult",
                table: "PositionInfo",
                newName: "Result");

            migrationBuilder.RenameColumn(
                name: "TakeProfit",
                table: "OpenPositionInfo",
                newName: "TakeProffit");

            migrationBuilder.RenameColumn(
                name: "StopLoss",
                table: "OpenPositionInfo",
                newName: "StopLose");
        }
    }
}
