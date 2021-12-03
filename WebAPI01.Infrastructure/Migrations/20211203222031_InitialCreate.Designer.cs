﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WebAPI01.Infrastructure;

namespace WebAPI01.Infrastructure.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20211203222031_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("WebAPI01.Domain.Model.AudioFile", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("Bitrate")
                        .HasColumnType("integer");

                    b.Property<Guid>("FileId")
                        .HasColumnType("uuid");

                    b.Property<int>("Length")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("FileId")
                        .IsUnique();

                    b.ToTable("AudioFiles");
                });

            modelBuilder.Entity("WebAPI01.Domain.Model.File", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Format")
                        .HasColumnType("text");

                    b.Property<string>("Path")
                        .HasColumnType("text");

                    b.Property<float>("Size")
                        .HasColumnType("real");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("UserForeignKey")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserForeignKey");

                    b.ToTable("Files");
                });

            modelBuilder.Entity("WebAPI01.Domain.Model.ImageFile", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("ColorPalette")
                        .HasColumnType("text");

                    b.Property<Guid>("FileId")
                        .HasColumnType("uuid");

                    b.Property<string>("Resolution")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("FileId")
                        .IsUnique();

                    b.ToTable("ImageFiles");
                });

            modelBuilder.Entity("WebAPI01.Domain.Model.TextFile", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Encoding")
                        .HasColumnType("text");

                    b.Property<Guid>("FileId")
                        .HasColumnType("uuid");

                    b.Property<int>("SymbolCount")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("FileId")
                        .IsUnique();

                    b.ToTable("TextFiles");
                });

            modelBuilder.Entity("WebAPI01.Domain.Model.VideoFile", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("Bitrate")
                        .HasColumnType("integer");

                    b.Property<string>("Encoding")
                        .HasColumnType("text");

                    b.Property<Guid>("FileId")
                        .HasColumnType("uuid");

                    b.Property<int>("Length")
                        .HasColumnType("integer");

                    b.Property<string>("Resolution")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("FileId")
                        .IsUnique();

                    b.ToTable("VideoFiles");
                });

            modelBuilder.Entity("WebAPI01.Domain.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("WebAPI01.Domain.Model.AudioFile", b =>
                {
                    b.HasOne("WebAPI01.Domain.Model.File", "File")
                        .WithOne("AudioFile")
                        .HasForeignKey("WebAPI01.Domain.Model.AudioFile", "FileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("File");
                });

            modelBuilder.Entity("WebAPI01.Domain.Model.File", b =>
                {
                    b.HasOne("WebAPI01.Domain.User", "User")
                        .WithMany("Files")
                        .HasForeignKey("UserForeignKey")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("WebAPI01.Domain.Model.ImageFile", b =>
                {
                    b.HasOne("WebAPI01.Domain.Model.File", "File")
                        .WithOne("ImageFile")
                        .HasForeignKey("WebAPI01.Domain.Model.ImageFile", "FileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("File");
                });

            modelBuilder.Entity("WebAPI01.Domain.Model.TextFile", b =>
                {
                    b.HasOne("WebAPI01.Domain.Model.File", "File")
                        .WithOne("TextFile")
                        .HasForeignKey("WebAPI01.Domain.Model.TextFile", "FileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("File");
                });

            modelBuilder.Entity("WebAPI01.Domain.Model.VideoFile", b =>
                {
                    b.HasOne("WebAPI01.Domain.Model.File", "File")
                        .WithOne("VideoFile")
                        .HasForeignKey("WebAPI01.Domain.Model.VideoFile", "FileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("File");
                });

            modelBuilder.Entity("WebAPI01.Domain.Model.File", b =>
                {
                    b.Navigation("AudioFile");

                    b.Navigation("ImageFile");

                    b.Navigation("TextFile");

                    b.Navigation("VideoFile");
                });

            modelBuilder.Entity("WebAPI01.Domain.User", b =>
                {
                    b.Navigation("Files");
                });
#pragma warning restore 612, 618
        }
    }
}
