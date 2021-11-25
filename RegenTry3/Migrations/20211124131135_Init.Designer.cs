﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RegenTry3.Model;

namespace RegenTry3.Migrations
{
    [DbContext(typeof(CrmDbContext))]
    [Migration("20211124131135_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BackerProject", b =>
                {
                    b.Property<int>("BackersId")
                        .HasColumnType("int");

                    b.Property<int>("ProjectsId")
                        .HasColumnType("int");

                    b.HasKey("BackersId", "ProjectsId");

                    b.HasIndex("ProjectsId");

                    b.ToTable("BackerProject");
                });

            modelBuilder.Entity("BackerReward", b =>
                {
                    b.Property<int>("BackersId")
                        .HasColumnType("int");

                    b.Property<int>("RewardsId")
                        .HasColumnType("int");

                    b.HasKey("BackersId", "RewardsId");

                    b.HasIndex("RewardsId");

                    b.ToTable("BackerReward");
                });

            modelBuilder.Entity("RegenTry3.Model.Backer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Username")
                        .IsUnique()
                        .HasFilter("[Username] IS NOT NULL");

                    b.ToTable("Backers");
                });

            modelBuilder.Entity("RegenTry3.Model.BackerProject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BackerId")
                        .HasColumnType("int");

                    b.Property<int?>("ProjectId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BackerId");

                    b.HasIndex("ProjectId");

                    b.ToTable("BackerProjects");
                });

            modelBuilder.Entity("RegenTry3.Model.BackerReward", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BackerId")
                        .HasColumnType("int");

                    b.Property<int?>("RewardId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BackerId");

                    b.HasIndex("RewardId");

                    b.ToTable("BackerRewards");
                });

            modelBuilder.Entity("RegenTry3.Model.Creator", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Username")
                        .IsUnique()
                        .HasFilter("[Username] IS NOT NULL");

                    b.ToTable("Creators");
                });

            modelBuilder.Entity("RegenTry3.Model.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Photos")
                        .HasColumnType("int");

                    b.Property<int?>("ProjectId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Videos")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("RegenTry3.Model.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CreatorId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("MoneyEarned")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Photos")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Videos")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("RegenTry3.Model.Reward", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("ProjectId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("Rewards");
                });

            modelBuilder.Entity("BackerProject", b =>
                {
                    b.HasOne("RegenTry3.Model.Backer", null)
                        .WithMany()
                        .HasForeignKey("BackersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RegenTry3.Model.Project", null)
                        .WithMany()
                        .HasForeignKey("ProjectsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BackerReward", b =>
                {
                    b.HasOne("RegenTry3.Model.Backer", null)
                        .WithMany()
                        .HasForeignKey("BackersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RegenTry3.Model.Reward", null)
                        .WithMany()
                        .HasForeignKey("RewardsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RegenTry3.Model.BackerProject", b =>
                {
                    b.HasOne("RegenTry3.Model.Backer", "Backer")
                        .WithMany("BackerProjects")
                        .HasForeignKey("BackerId");

                    b.HasOne("RegenTry3.Model.Project", "Project")
                        .WithMany("BackerProjects")
                        .HasForeignKey("ProjectId");

                    b.Navigation("Backer");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("RegenTry3.Model.BackerReward", b =>
                {
                    b.HasOne("RegenTry3.Model.Backer", "Backer")
                        .WithMany("BackerRewards")
                        .HasForeignKey("BackerId");

                    b.HasOne("RegenTry3.Model.Reward", "Reward")
                        .WithMany("BackerRewards")
                        .HasForeignKey("RewardId");

                    b.Navigation("Backer");

                    b.Navigation("Reward");
                });

            modelBuilder.Entity("RegenTry3.Model.Post", b =>
                {
                    b.HasOne("RegenTry3.Model.Project", null)
                        .WithMany("Posts")
                        .HasForeignKey("ProjectId");
                });

            modelBuilder.Entity("RegenTry3.Model.Project", b =>
                {
                    b.HasOne("RegenTry3.Model.Creator", "Creator")
                        .WithMany("Projects")
                        .HasForeignKey("CreatorId");

                    b.Navigation("Creator");
                });

            modelBuilder.Entity("RegenTry3.Model.Reward", b =>
                {
                    b.HasOne("RegenTry3.Model.Project", "Project")
                        .WithMany("Rewards")
                        .HasForeignKey("ProjectId");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("RegenTry3.Model.Backer", b =>
                {
                    b.Navigation("BackerProjects");

                    b.Navigation("BackerRewards");
                });

            modelBuilder.Entity("RegenTry3.Model.Creator", b =>
                {
                    b.Navigation("Projects");
                });

            modelBuilder.Entity("RegenTry3.Model.Project", b =>
                {
                    b.Navigation("BackerProjects");

                    b.Navigation("Posts");

                    b.Navigation("Rewards");
                });

            modelBuilder.Entity("RegenTry3.Model.Reward", b =>
                {
                    b.Navigation("BackerRewards");
                });
#pragma warning restore 612, 618
        }
    }
}