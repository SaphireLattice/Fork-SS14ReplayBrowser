﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using NpgsqlTypes;
using ReplayBrowser.Data;

#nullable disable

namespace Server.Migrations
{
    [DbContext(typeof(ReplayDbContext))]
    [Migration("20240531155017_FavoriteReplays")]
    partial class FavoriteReplays
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ReplayBrowser.Data.Models.Account.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<List<int>>("FavoriteReplays")
                        .IsRequired()
                        .HasColumnType("integer[]");

                    b.Property<Guid>("Guid")
                        .HasColumnType("uuid");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("boolean");

                    b.Property<int>("SettingsId")
                        .HasColumnType("integer");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Guid")
                        .IsUnique();

                    b.HasIndex("SettingsId");

                    b.HasIndex("Username");

                    b.ToTable("Accounts", (string)null);
                });

            modelBuilder.Entity("ReplayBrowser.Data.Models.Account.AccountSettings", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<List<Guid>>("Friends")
                        .IsRequired()
                        .HasColumnType("uuid[]");

                    b.Property<bool>("RedactInformation")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.ToTable("AccountSettings");
                });

            modelBuilder.Entity("ReplayBrowser.Data.Models.Account.HistoryEntry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("AccountId")
                        .HasColumnType("integer");

                    b.Property<string>("Action")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Details")
                        .HasColumnType("text");

                    b.Property<DateTime>("Time")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("HistoryEntry");
                });

            modelBuilder.Entity("ReplayBrowser.Data.Models.ParsedReplay", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Name");

                    b.ToTable("ParsedReplays", (string)null);
                });

            modelBuilder.Entity("ReplayBrowser.Data.Models.Player", b =>
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

                    b.HasIndex("PlayerGuid");

                    b.HasIndex("PlayerIcName");

                    b.HasIndex("PlayerOocName");

                    b.HasIndex("ReplayId");

                    b.ToTable("Players", (string)null);
                });

            modelBuilder.Entity("ReplayBrowser.Data.Models.Replay", b =>
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

                    b.Property<NpgsqlTsVector>("RoundEndTextSearchVector")
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("tsvector")
                        .HasAnnotation("Npgsql:TsVectorConfig", "english")
                        .HasAnnotation("Npgsql:TsVectorProperties", new[] { "RoundEndText" });

                    b.Property<int?>("RoundId")
                        .HasColumnType("integer");

                    b.Property<string>("ServerId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ServerName")
                        .HasColumnType("text");

                    b.Property<int>("Size")
                        .HasColumnType("integer");

                    b.Property<int>("UncompressedSize")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("Gamemode");

                    b.HasIndex("Map");

                    b.HasIndex("RoundEndTextSearchVector");

                    NpgsqlIndexBuilderExtensions.HasMethod(b.HasIndex("RoundEndTextSearchVector"), "GIN");

                    b.HasIndex("ServerId");

                    b.HasIndex("ServerName");

                    b.ToTable("Replays", (string)null);
                });

            modelBuilder.Entity("ReplayBrowser.Data.Models.Account.Account", b =>
                {
                    b.HasOne("ReplayBrowser.Data.Models.Account.AccountSettings", "Settings")
                        .WithMany()
                        .HasForeignKey("SettingsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Settings");
                });

            modelBuilder.Entity("ReplayBrowser.Data.Models.Account.HistoryEntry", b =>
                {
                    b.HasOne("ReplayBrowser.Data.Models.Account.Account", null)
                        .WithMany("History")
                        .HasForeignKey("AccountId");
                });

            modelBuilder.Entity("ReplayBrowser.Data.Models.Player", b =>
                {
                    b.HasOne("ReplayBrowser.Data.Models.Replay", "Replay")
                        .WithMany("RoundEndPlayers")
                        .HasForeignKey("ReplayId");

                    b.Navigation("Replay");
                });

            modelBuilder.Entity("ReplayBrowser.Data.Models.Account.Account", b =>
                {
                    b.Navigation("History");
                });

            modelBuilder.Entity("ReplayBrowser.Data.Models.Replay", b =>
                {
                    b.Navigation("RoundEndPlayers");
                });
#pragma warning restore 612, 618
        }
    }
}
