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
    [Migration("20230521141852_Database3")]
    partial class Database3
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
                        .HasColumnType("integer")
                        .HasColumnName("listId");

                    b.Property<decimal>("Low")
                        .HasColumnType("numeric")
                        .HasColumnName("low");

                    b.Property<decimal>("Open")
                        .HasColumnType("numeric")
                        .HasColumnName("open");

                    b.Property<int>("TimeStamp")
                        .HasColumnType("integer")
                        .HasColumnName("timeStamp");

                    b.Property<int>("TradingPairId")
                        .HasColumnType("integer")
                        .HasColumnName("tradingPairId");

                    b.Property<decimal>("Volume")
                        .HasColumnType("numeric")
                        .HasColumnName("volume");

                    b.HasKey("ItemId");

                    b.HasIndex("ListId");

                    b.HasIndex("TradingPairId");

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

            modelBuilder.Entity("DataBase.DataContext.Tables.TradingPair", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.HasKey("Id");

                    b.ToTable("tradingPair");
                });

            modelBuilder.Entity("DataBase.DataContext.Tables.HistoricalDataItems", b =>
                {
                    b.HasOne("DataBase.DataContext.Tables.HistoricalDataList", "List")
                        .WithMany("DataSets")
                        .HasForeignKey("ListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataBase.DataContext.Tables.TradingPair", "TradingPair")
                        .WithMany()
                        .HasForeignKey("TradingPairId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("List");

                    b.Navigation("TradingPair");
                });

            modelBuilder.Entity("DataBase.DataContext.Tables.HistoricalDataList", b =>
                {
                    b.Navigation("DataSets");
                });
#pragma warning restore 612, 618
        }
    }
}