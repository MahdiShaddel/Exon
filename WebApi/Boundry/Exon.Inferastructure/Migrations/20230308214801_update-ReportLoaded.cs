using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Exon.Inferastructure.Migrations
{
    /// <inheritdoc />
    public partial class updateReportLoaded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "receiverName",
                table: "ReportLoaded");

            migrationBuilder.DropColumn(
                name: "truckLicensePlate",
                table: "ReportLoaded");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "receiverName",
                table: "ReportLoaded",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "truckLicensePlate",
                table: "ReportLoaded",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
