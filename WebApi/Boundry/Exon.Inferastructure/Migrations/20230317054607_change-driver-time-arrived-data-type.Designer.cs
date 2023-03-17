﻿// <auto-generated />
using System;
using Exon.Inferastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Exon.Inferastructure.Migrations
{
    [DbContext(typeof(ExonContext))]
    [Migration("20230317054607_change-driver-time-arrived-data-type")]
    partial class changedrivertimearriveddatatype
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Exon.Domain.Models.Logs", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("LogStatus")
                        .HasColumnType("int");

                    b.Property<int>("LogType")
                        .HasColumnType("int");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("OrderId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Logs");
                });

            modelBuilder.Entity("Exon.Domain.Models.OrderLoadingReport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ModifedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("billOfLadingDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("billOfLadingGoodCount")
                        .HasColumnType("int");

                    b.Property<string>("billOfLadingID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<TimeSpan?>("billOfLadingTime")
                        .HasColumnType("time");

                    b.Property<int?>("billOfLadingWeight")
                        .HasColumnType("int");

                    b.Property<int?>("companyInternalContractCode")
                        .HasColumnType("int");

                    b.Property<string>("ctName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<TimeSpan?>("driverArrivedTime")
                        .HasColumnType("time");

                    b.Property<string>("driverFullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("driverTelephne")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("isArrived")
                        .HasColumnType("bit");

                    b.Property<int?>("orderGoodCount")
                        .HasColumnType("int");

                    b.Property<string>("orderGoodDescreption")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("orderId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("orderIssueDate")
                        .HasColumnType("datetime2");

                    b.Property<TimeSpan?>("orderIssueTime")
                        .HasColumnType("time");

                    b.Property<int?>("orderWeight")
                        .HasColumnType("int");

                    b.Property<int?>("receiverCode")
                        .HasColumnType("int");

                    b.Property<string>("receiverName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("truckLicensePlate")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("OrderLoadingReport");
                });
#pragma warning restore 612, 618
        }
    }
}
