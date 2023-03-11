using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Exon.Inferastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateLogTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "orderId",
                table: "Logs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "orderId",
                table: "Logs");
        }
    }
}
