﻿// <auto-generated />
using System;
using Cryptolus.Persistant.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Cryptolus.Persistant.Migrations
{
    [DbContext(typeof(CryptolusContext))]
    [Migration("20231112172508_v2")]
    partial class v2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Cryptolus.Domain.Entities.Post.Author", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("Cryptolus.Domain.Entities.Post.Position.OpenPositionInfo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("EnterPrice")
                        .HasColumnType("float");

                    b.Property<double>("StopLose")
                        .HasColumnType("float");

                    b.Property<double>("TakeProffit")
                        .HasColumnType("float");

                    b.Property<double>("TpSl")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("OpenPositionInfo");
                });

            modelBuilder.Entity("Cryptolus.Domain.Entities.Post.Position.PositionInfo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Direction")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("InfoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Result")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("InfoId");

                    b.ToTable("PositionInfo");
                });

            modelBuilder.Entity("Cryptolus.Domain.Entities.Post.Post", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AuthorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ContentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsChanged")
                        .HasColumnType("bit");

                    b.Property<Guid>("PositionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ViewsCount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("ContentId");

                    b.HasIndex("PositionId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("Cryptolus.Domain.Entities.Post.PostContent", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Coin")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CoinSymbol")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Picture")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PostContent");
                });

            modelBuilder.Entity("Cryptolus.Domain.Entities.Post.PostThemes", b =>
                {
                    b.Property<Guid>("PostId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ThemeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("PostId", "ThemeId");

                    b.HasIndex("ThemeId");

                    b.ToTable("PostThemes");
                });

            modelBuilder.Entity("Cryptolus.Domain.Entities.Post.Themes", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Themes");
                });

            modelBuilder.Entity("Cryptolus.Domain.Entities.User.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAuthenticated")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Cryptolus.Domain.Entities.Post.Position.PositionInfo", b =>
                {
                    b.HasOne("Cryptolus.Domain.Entities.Post.Position.OpenPositionInfo", "Info")
                        .WithMany()
                        .HasForeignKey("InfoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Info");
                });

            modelBuilder.Entity("Cryptolus.Domain.Entities.Post.Post", b =>
                {
                    b.HasOne("Cryptolus.Domain.Entities.Post.Author", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cryptolus.Domain.Entities.Post.PostContent", "Content")
                        .WithMany()
                        .HasForeignKey("ContentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cryptolus.Domain.Entities.Post.Position.PositionInfo", "Position")
                        .WithMany()
                        .HasForeignKey("PositionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Content");

                    b.Navigation("Position");
                });

            modelBuilder.Entity("Cryptolus.Domain.Entities.Post.PostThemes", b =>
                {
                    b.HasOne("Cryptolus.Domain.Entities.Post.Post", "Post")
                        .WithMany("PostThemes")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cryptolus.Domain.Entities.Post.Themes", "Theme")
                        .WithMany("PostThemes")
                        .HasForeignKey("ThemeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Post");

                    b.Navigation("Theme");
                });

            modelBuilder.Entity("Cryptolus.Domain.Entities.Post.Post", b =>
                {
                    b.Navigation("PostThemes");
                });

            modelBuilder.Entity("Cryptolus.Domain.Entities.Post.Themes", b =>
                {
                    b.Navigation("PostThemes");
                });
#pragma warning restore 612, 618
        }
    }
}
