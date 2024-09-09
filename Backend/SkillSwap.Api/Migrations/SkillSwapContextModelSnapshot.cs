﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace SkillSwap.Api.Migrations
{
    [DbContext(typeof(SkillSwapContext))]
    partial class SkillSwapContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SkillSwap.Api.Models.Connection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsAccepted")
                        .HasColumnType("bit");

                    b.Property<int>("ProfileMatchId")
                        .HasColumnType("int");

                    b.Property<Guid>("PublicId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ProfileMatchId");

                    b.ToTable("Connections");
                });

            modelBuilder.Entity("SkillSwap.Api.Models.ContactInformation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("PublicId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("ContactInformations");
                });

            modelBuilder.Entity("SkillSwap.Api.Models.Need", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ProfileId")
                        .HasColumnType("int");

                    b.Property<Guid>("PublicId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TagName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("ProfileId");

                    b.ToTable("Needs");
                });

            modelBuilder.Entity("SkillSwap.Api.Models.Profile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Bio")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("ClerkId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ContactInformationId")
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("PublicId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("RecentActivity")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ContactInformationId");

                    b.ToTable("Profiles");
                });

            modelBuilder.Entity("SkillSwap.Api.Models.Skill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ProfileId")
                        .HasColumnType("int");

                    b.Property<Guid>("PublicId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TagName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("ProfileId");

                    b.ToTable("Skills");
                });

            modelBuilder.Entity("SkillSwap.Api.Models.Connection", b =>
                {
                    b.HasOne("SkillSwap.Api.Models.Profile", "ProfileMatch")
                        .WithMany("Connections")
                        .HasForeignKey("ProfileMatchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProfileMatch");
                });

            modelBuilder.Entity("SkillSwap.Api.Models.Need", b =>
                {
                    b.HasOne("SkillSwap.Api.Models.Profile", null)
                        .WithMany("Needs")
                        .HasForeignKey("ProfileId");
                });

            modelBuilder.Entity("SkillSwap.Api.Models.Profile", b =>
                {
                    b.HasOne("SkillSwap.Api.Models.ContactInformation", "ContactInformation")
                        .WithMany()
                        .HasForeignKey("ContactInformationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ContactInformation");
                });

            modelBuilder.Entity("SkillSwap.Api.Models.Skill", b =>
                {
                    b.HasOne("SkillSwap.Api.Models.Profile", null)
                        .WithMany("Skills")
                        .HasForeignKey("ProfileId");
                });

            modelBuilder.Entity("SkillSwap.Api.Models.Profile", b =>
                {
                    b.Navigation("Connections");

                    b.Navigation("Needs");

                    b.Navigation("Skills");
                });
#pragma warning restore 612, 618
        }
    }
}
