﻿// <auto-generated />
using System;
using DataBase.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataBase.Migrations
{
    [DbContext(typeof(DataBaseContext))]
    [Migration("20230523095750_NewDatabase4")]
    partial class NewDatabase4
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("DataBase.DataContext.Tables.DBUser", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int?>("Id"));

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("bytea")
                        .HasColumnName("passwordhash");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("bytea")
                        .HasColumnName("passwordsalt");

                    b.Property<string>("UserName")
                        .HasColumnType("text")
                        .HasColumnName("username");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DataBase.DataContext.Tables.HistoricalDataItems", b =>
                {
                    b.Property<int>("ItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ItemId"));

                    b.Property<decimal>("Close")
                        .HasColumnType("numeric")
                        .HasColumnName("close");

                    b.Property<decimal>("High")
                        .HasColumnType("numeric")
                        .HasColumnName("high");

                    b.Property<int>("ListId")
                        .HasColumnType("integer");

                    b.Property<decimal>("Low")
                        .HasColumnType("numeric")
                        .HasColumnName("low");

                    b.Property<decimal>("Open")
                        .HasColumnType("numeric")
                        .HasColumnName("open");

                    b.Property<int>("TimeStamp")
                        .HasColumnType("integer")
                        .HasColumnName("timeStamp");

                    b.Property<decimal>("Volume")
                        .HasColumnType("numeric")
                        .HasColumnName("volume");

                    b.HasKey("ItemId");

                    b.HasIndex("ListId");

                    b.ToTable("historiacalDataItems");
                });

            modelBuilder.Entity("DataBase.DataContext.Tables.HistoricalDataList", b =>
                {
                    b.Property<int>("ListId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ListId"));

                    b.Property<long>("Datasize")
                        .HasColumnType("bigint")
                        .HasColumnName("datasize");

                    b.Property<DateTime>("TimeStampEnd")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("timestampend");

                    b.Property<DateTime>("TimeStampStart")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("timestampstart");

                    b.HasKey("ListId");

                    b.ToTable("Historicaldatalist");
                });

            modelBuilder.Entity("DataBase.DataContext.Tables.TickerDataItems", b =>
                {
                    b.Property<int>("ItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ItemId"));

                    b.Property<decimal>("Ask")
                        .HasColumnType("numeric")
                        .HasColumnName("lowest_sell_order");

                    b.Property<decimal>("Bid")
                        .HasColumnType("numeric")
                        .HasColumnName("highest_buy_order");

                    b.Property<decimal>("HighestPrice")
                        .HasColumnType("numeric")
                        .HasColumnName("highestPrice");

                    b.Property<decimal>("LastPrice")
                        .HasColumnType("numeric")
                        .HasColumnName("lastprice");

                    b.Property<int>("ListId")
                        .HasColumnType("integer");

                    b.Property<decimal>("LowestPrice")
                        .HasColumnType("numeric")
                        .HasColumnName("lowestPrice");

                    b.Property<decimal>("Open")
                        .HasColumnType("numeric")
                        .HasColumnName("first_price_of_day");

                    b.Property<decimal>("Open24")
                        .HasColumnType("numeric")
                        .HasColumnName("open_24");

                    b.Property<decimal>("PercentChange24")
                        .HasColumnType("numeric")
                        .HasColumnName("percent_change_24");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("timestamp");

                    b.Property<decimal>("VWap")
                        .HasColumnType("numeric")
                        .HasColumnName("volume_weighted_average_price");

                    b.Property<decimal>("Volume")
                        .HasColumnType("numeric")
                        .HasColumnName("volume");

                    b.HasKey("ItemId");

                    b.HasIndex("ListId");

                    b.ToTable("tickerDataItems");
                });

            modelBuilder.Entity("DataBase.DataContext.Tables.TickerDataList", b =>
                {
                    b.Property<int>("ListId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ListId"));

                    b.Property<long>("DataSize")
                        .HasColumnType("bigint")
                        .HasColumnName("datasize");

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<DateTime>("Timestampend")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("timestampend");

                    b.Property<DateTime>("Timestampstart")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("timestampstart");

                    b.HasKey("ListId");

                    b.ToTable("tickerDataList");
                });

            modelBuilder.Entity("DataBase.DataContext.Tables.HistoricalDataItems", b =>
                {
                    b.HasOne("DataBase.DataContext.Tables.HistoricalDataList", "List")
                        .WithMany("DataSets")
                        .HasForeignKey("ListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("List");
                });

            modelBuilder.Entity("DataBase.DataContext.Tables.TickerDataItems", b =>
                {
                    b.HasOne("DataBase.DataContext.Tables.TickerDataList", "List")
                        .WithMany("TickerDataItems")
                        .HasForeignKey("ListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("List");
                });

            modelBuilder.Entity("DataBase.DataContext.Tables.HistoricalDataList", b =>
                {
                    b.Navigation("DataSets");
                });

            modelBuilder.Entity("DataBase.DataContext.Tables.TickerDataList", b =>
                {
                    b.Navigation("TickerDataItems");
                });
#pragma warning restore 612, 618
        }
    }
}
