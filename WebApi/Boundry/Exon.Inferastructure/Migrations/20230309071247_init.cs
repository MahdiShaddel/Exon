using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Exon.Inferastructure.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LogType = table.Column<int>(type: "int", nullable: false),
                    LogStatus = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderLoadingReport",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    orderId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    companyInternalContractCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    orderGoodDescreption = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    orderIssueDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    orderIssueTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    receiverCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ctName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    receiverName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    truckLicensePlate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    driverFullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    orderGoodCount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    orderWeight = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    billOfLadingID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    billOfLadingDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    billOfLadingTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    billOfLadingGoodCount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    billOfLadingWeight = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    driverTelephne = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isArrived = table.Column<bool>(type: "bit", nullable: false),
                    driverArrivedTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderLoadingReport", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Logs");

            migrationBuilder.DropTable(
                name: "OrderLoadingReport");
        }
    }
}
