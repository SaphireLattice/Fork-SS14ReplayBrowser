﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ReplayBrowser.Data;

#nullable disable

namespace Server.Migrations
{
    [DbContext(typeof(ReplayDbContext))]
    [Migration("20240219152928_Date")]
    partial class Date
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Server.Models.ParsedReplay", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Name");

                    b.ToTable("ParsedReplays", (string)null);
                });

            modelBuilder.Entity("Server.Models.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("Antag")
                        .HasColumnType("boolean");

                    b.Property<List<string>>("AntagPrototypes")
                        .IsRequired()
                        .HasColumnType("text[]");

                    b.Property<List<string>>("JobPrototypes")
                        .IsRequired()
                        .HasColumnType("text[]");

                    b.Property<Guid>("PlayerGuid")
                        .HasColumnType("uuid");

                    b.Property<string>("PlayerIcName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PlayerOocName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("ReplayId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ReplayId");

                    b.ToTable("Players", (string)null);
                });

            modelBuilder.Entity("Server.Models.Replay", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Duration")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("EndTick")
                        .HasColumnType("integer");

                    b.Property<string>("EndTime")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("FileCount")
                        .HasColumnType("integer");

                    b.Property<string>("Gamemode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Link")
                        .HasColumnType("text");

                    b.Property<string>("Map")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("RoundEndText")
                        .HasColumnType("text");

                    b.Property<string>("ServerId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Size")
                        .HasColumnType("integer");

                    b.Property<int>("UncompressedSize")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Replays", (string)null);
                });

            modelBuilder.Entity("Server.Models.Player", b =>
                {
                    b.HasOne("Server.Models.Replay", null)
                        .WithMany("RoundEndPlayers")
                        .HasForeignKey("ReplayId");
                });

            modelBuilder.Entity("Server.Models.Replay", b =>
                {
                    b.Navigation("RoundEndPlayers");
                });
#pragma warning restore 612, 618
        }
    }
}
