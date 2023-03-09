using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Exon.Inferastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateLogModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Messages",
                table: "Logs");

            migrationBuilder.AddColumn<int>(
                name: "LogStatus",
                table: "Logs",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LogStatus",
                table: "Logs");

            migrationBuilder.AddColumn<string>(
                name: "Messages",
                table: "Logs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
