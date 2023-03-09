using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Exon.Inferastructure.Migrations
{
    /// <inheritdoc />
    public partial class updateflowreport : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "companyInternalContractCode",
                table: "FlowReport",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ctName",
                table: "FlowReport",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "driverFullName",
                table: "FlowReport",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "orderGoodCount",
                table: "FlowReport",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "orderId",
                table: "FlowReport",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "orderIssueDate",
                table: "FlowReport",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "orderIssueTime",
                table: "FlowReport",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "orderWeight",
                table: "FlowReport",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "receiverCode",
                table: "FlowReport",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "receiverName",
                table: "FlowReport",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "truckLicensePlate",
                table: "FlowReport",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "companyInternalContractCode",
                table: "FlowReport");

            migrationBuilder.DropColumn(
                name: "ctName",
                table: "FlowReport");

            migrationBuilder.DropColumn(
                name: "driverFullName",
                table: "FlowReport");

            migrationBuilder.DropColumn(
                name: "orderGoodCount",
                table: "FlowReport");

            migrationBuilder.DropColumn(
                name: "orderId",
                table: "FlowReport");

            migrationBuilder.DropColumn(
                name: "orderIssueDate",
                table: "FlowReport");

            migrationBuilder.DropColumn(
                name: "orderIssueTime",
                table: "FlowReport");

            migrationBuilder.DropColumn(
                name: "orderWeight",
                table: "FlowReport");

            migrationBuilder.DropColumn(
                name: "receiverCode",
                table: "FlowReport");

            migrationBuilder.DropColumn(
                name: "receiverName",
                table: "FlowReport");

            migrationBuilder.DropColumn(
                name: "truckLicensePlate",
                table: "FlowReport");
        }
    }
}
