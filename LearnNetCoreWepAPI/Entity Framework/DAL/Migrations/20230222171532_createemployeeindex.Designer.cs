﻿// <auto-generated />
using System;
using LearnNetCoreWepAPI.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LearnNetCoreWepAPI.DAL.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20230222171532_createemployeeindex")]
    partial class createemployeeindex
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LearnNetCoreWepAPI.DAL.models.Media", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("EmpoId")
                        .HasColumnType("int");

                    b.Property<string>("FileURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EmpoId")
                        .IsUnique();

                    b.ToTable("Media");
                });

            modelBuilder.Entity("LearnNetCoreWepAPI.DAL.models.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Post");
                });

            modelBuilder.Entity("LearnNetCoreWepAPI.DAL.models.PostMedia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("MediaId")
                        .HasColumnType("int");

                    b.Property<int>("PostId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MediaId");

                    b.HasIndex("PostId");

                    b.ToTable("PostMedia");
                });

            modelBuilder.Entity("LearnNetCoreWepAPI.models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Age");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("MediaPost", b =>
                {
                    b.Property<int>("MediasId")
                        .HasColumnType("int");

                    b.Property<int>("PostsId")
                        .HasColumnType("int");

                    b.HasKey("MediasId", "PostsId");

                    b.HasIndex("PostsId");

                    b.ToTable("MediaPost");
                });

            modelBuilder.Entity("LearnNetCoreWepAPI.DAL.models.Media", b =>
                {
                    b.HasOne("LearnNetCoreWepAPI.models.Employee", "Employee")
                        .WithOne("Media")
                        .HasForeignKey("LearnNetCoreWepAPI.DAL.models.Media", "EmpoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("LearnNetCoreWepAPI.DAL.models.Post", b =>
                {
                    b.HasOne("LearnNetCoreWepAPI.models.Employee", null)
                        .WithMany("Posts")
                        .HasForeignKey("EmployeeId");
                });

            modelBuilder.Entity("LearnNetCoreWepAPI.DAL.models.PostMedia", b =>
                {
                    b.HasOne("LearnNetCoreWepAPI.DAL.models.Media", "Media")
                        .WithMany("PostMedias")
                        .HasForeignKey("MediaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LearnNetCoreWepAPI.DAL.models.Post", "Post")
                        .WithMany("PostMedias")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Media");

                    b.Navigation("Post");
                });

            modelBuilder.Entity("MediaPost", b =>
                {
                    b.HasOne("LearnNetCoreWepAPI.DAL.models.Media", null)
                        .WithMany()
                        .HasForeignKey("MediasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LearnNetCoreWepAPI.DAL.models.Post", null)
                        .WithMany()
                        .HasForeignKey("PostsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LearnNetCoreWepAPI.DAL.models.Media", b =>
                {
                    b.Navigation("PostMedias");
                });

            modelBuilder.Entity("LearnNetCoreWepAPI.DAL.models.Post", b =>
                {
                    b.Navigation("PostMedias");
                });

            modelBuilder.Entity("LearnNetCoreWepAPI.models.Employee", b =>
                {
                    b.Navigation("Media")
                        .IsRequired();

                    b.Navigation("Posts");
                });
#pragma warning restore 612, 618
        }
    }
}
