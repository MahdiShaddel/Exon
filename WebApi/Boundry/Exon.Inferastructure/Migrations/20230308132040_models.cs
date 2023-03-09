using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Exon.Inferastructure.Migrations
{
    /// <inheritdoc />
    public partial class models : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FlowReport",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlowReport", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReportLoaded",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    billOfLadingID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    companyInternalContractCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    billOfLadingGoodDescreption = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    billOfLadingDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    billOfLadingTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    receiverCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ctName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    receiverName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    truckLicensePlate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    driverFullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    billOfLadingGoodCount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    billOfLadingWeight = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    driverTelephne = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    billOfLadingOrderId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    orderIssueDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    orderIssueTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportLoaded", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FlowReport");

            migrationBuilder.DropTable(
                name: "ReportLoaded");
        }
    }
}
