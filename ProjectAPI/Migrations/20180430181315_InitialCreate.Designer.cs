﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Project.Data;
using System;

namespace ProjectAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20180430181315_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011");

            modelBuilder.Entity("Project.Model.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("Name")
                        .HasMaxLength(50);

                    b.Property<int>("SubCategoryId")
                        .HasColumnName("SubCategory_Id");

                    b.HasKey("Id");

                    b.HasIndex("SubCategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Project.Model.Models.Content", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("content_id");

                    b.Property<int>("FolderId")
                        .HasColumnName("folder_id");

                    b.Property<string>("Html")
                        .HasColumnName("content_html");

                    b.Property<string>("Summary")
                        .HasColumnName("content_teaser");

                    b.Property<string>("Title")
                        .HasColumnName("content_title");

                    b.Property<int>("XmlConfigId")
                        .HasColumnName("xml_config_id");

                    b.HasKey("Id");

                    b.HasIndex("FolderId");

                    b.ToTable("content");
                });

            modelBuilder.Entity("Project.Model.Models.Folder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("folder_id");

                    b.Property<string>("Name")
                        .HasColumnName("folder_name");

                    b.Property<int?>("ParentId")
                        .HasColumnName("parent_id");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("content_folder_tbl");
                });

            modelBuilder.Entity("Project.Model.SubCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("SubCategory");
                });

            modelBuilder.Entity("Project.Model.Models.Category", b =>
                {
                    b.HasOne("Project.Model.SubCategory", "SubCategory")
                        .WithMany("Category")
                        .HasForeignKey("SubCategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Project.Model.Models.Content", b =>
                {
                    b.HasOne("Project.Model.Models.Folder", "Folder")
                        .WithMany()
                        .HasForeignKey("FolderId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Project.Model.Models.Folder", b =>
                {
                    b.HasOne("Project.Model.Models.Folder", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId");
                });
#pragma warning restore 612, 618
        }
    }
}
