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
    [Migration("20230523082509_NewDatabase2")]
    partial class NewDatabase2
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

            modelBuilder.Entity("DataBase.DataContext.Tables.TradingPairDataItems", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("BaseDecimals")
                        .HasColumnType("integer")
                        .HasColumnName("base_decimals");

                    b.Property<int>("CounterDecimals")
                        .HasColumnType("integer")
                        .HasColumnName("counter_decimals");

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("InstantAndMarketOrders")
                        .HasColumnType("text")
                        .HasColumnName("instant_and_market_orders");

                    b.Property<int>("InstantorderCounterDecimals")
                        .HasColumnType("integer")
                        .HasColumnName("instant_order_counter_decimals");

                    b.Property<int>("ListId")
                        .HasColumnType("integer");

                    b.Property<string>("MinimumOrder")
                        .HasColumnType("text")
                        .HasColumnName("minimum_order");

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("Trading")
                        .HasColumnType("text")
                        .HasColumnName("trading");

                    b.Property<string>("UrlSymbol")
                        .HasColumnType("text")
                        .HasColumnName("url_symbol");

                    b.HasKey("Id");

                    b.HasIndex("ListId");

                    b.ToTable("TradingPairItems");
                });

            modelBuilder.Entity("DataBase.DataContext.Tables.TradingPairDataList", b =>
                {
                    b.Property<int>("ListId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ListId"));

                    b.Property<long>("Datasize")
                        .HasColumnType("bigint")
                        .HasColumnName("datasize");

                    b.HasKey("ListId");

                    b.ToTable("TradingPairList");
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

            modelBuilder.Entity("DataBase.DataContext.Tables.TradingPairDataItems", b =>
                {
                    b.HasOne("DataBase.DataContext.Tables.TradingPairDataList", "List")
                        .WithMany("Items")
                        .HasForeignKey("ListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("List");
                });

            modelBuilder.Entity("DataBase.DataContext.Tables.HistoricalDataList", b =>
                {
                    b.Navigation("DataSets");
                });

            modelBuilder.Entity("DataBase.DataContext.Tables.TradingPairDataList", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}