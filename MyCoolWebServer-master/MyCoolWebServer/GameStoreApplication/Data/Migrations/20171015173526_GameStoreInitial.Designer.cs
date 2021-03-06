﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using MyCoolWebServer.GameStoreApplication.Data;
using System;

namespace MyCoolWebServer.GameStoreApplication.Data.Migrations
{
    [DbContext(typeof(GameStoreDbContext))]
    [Migration("20171015173526_GameStoreInitial")]
    partial class GameStoreInitial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MyCoolWebServer.GameStoreApplication.Data.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .HasMaxLength(200);

                    b.Property<int>("Image");

                    b.Property<decimal>("Price");

                    b.Property<DateTime>("ReleaseDate");

                    b.Property<double>("Size");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("TrailerId")
                        .IsRequired()
                        .HasMaxLength(11);

                    b.HasKey("Id");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("MyCoolWebServer.GameStoreApplication.Data.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("FullName");

                    b.Property<bool>("IsAdmin");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MyCoolWebServer.GameStoreApplication.Data.UserGame", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<int>("GameId");

                    b.HasKey("UserId", "GameId");

                    b.HasIndex("GameId");

                    b.ToTable("UserGames");
                });

            modelBuilder.Entity("MyCoolWebServer.GameStoreApplication.Data.UserGame", b =>
                {
                    b.HasOne("MyCoolWebServer.GameStoreApplication.Data.Game", "Game")
                        .WithMany("Users")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("MyCoolWebServer.GameStoreApplication.Data.User", "User")
                        .WithMany("Games")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
