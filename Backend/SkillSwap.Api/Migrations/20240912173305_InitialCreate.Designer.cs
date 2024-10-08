﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace SkillSwap.Api.Migrations
{
    [DbContext(typeof(SkillSwapContext))]
    [Migration("20240912173305_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<Guid>("ProfileMatchPublicId")
                        .HasColumnType("uniqueidentifier");

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

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "emma.watson@email.com",
                            PublicId = new Guid("967f7687-80cd-4c49-af72-30f1bded6210")
                        },
                        new
                        {
                            Id = 2,
                            Email = "jimmy.john@email.com",
                            PublicId = new Guid("620aac10-d6b4-48a4-89ef-52ea8ccfc78b")
                        },
                        new
                        {
                            Id = 3,
                            Email = "sarah.johnson@email.com",
                            PublicId = new Guid("cc7b951b-1cd8-47ee-9346-0c97c63afa1a")
                        },
                        new
                        {
                            Id = 4,
                            Email = "ethan.patel@email.com",
                            PublicId = new Guid("67b5f9b9-d7c9-4fad-8951-e87fed1202ee")
                        });
                });

            modelBuilder.Entity("SkillSwap.Api.Models.Need", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ProfileId")
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

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ProfileId = 1,
                            PublicId = new Guid("fc82590b-6b9b-4d83-b703-dc216773832f"),
                            TagName = "JavaScript"
                        },
                        new
                        {
                            Id = 2,
                            ProfileId = 1,
                            PublicId = new Guid("dc336f9a-a5df-4e7f-9416-c1fc7e8f4819"),
                            TagName = "CSS"
                        },
                        new
                        {
                            Id = 3,
                            ProfileId = 2,
                            PublicId = new Guid("6286c5d7-60fa-4995-ad94-ae80c053731e"),
                            TagName = "JavaScript"
                        },
                        new
                        {
                            Id = 4,
                            ProfileId = 2,
                            PublicId = new Guid("349feb79-54c7-4fd1-bd56-43268d931bf8"),
                            TagName = "CSS"
                        },
                        new
                        {
                            Id = 5,
                            ProfileId = 3,
                            PublicId = new Guid("09cbf2a8-d87e-45d8-b0ae-f34229df1117"),
                            TagName = "JavaScript"
                        },
                        new
                        {
                            Id = 6,
                            ProfileId = 3,
                            PublicId = new Guid("18ad7f68-92d0-48fb-a3bf-17fcf3822411"),
                            TagName = "CSS"
                        },
                        new
                        {
                            Id = 7,
                            ProfileId = 4,
                            PublicId = new Guid("14e8e104-f010-4bae-8a10-bf9508c12b9b"),
                            TagName = "Python"
                        },
                        new
                        {
                            Id = 8,
                            ProfileId = 4,
                            PublicId = new Guid("d0edfa3f-98e6-4c04-b964-a1b2e32bdaba"),
                            TagName = "PostgreSQL"
                        });
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

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Bio = "Backend developer focused on scalable and efficient server-side applications",
                            ClerkId = "emma_w_303",
                            ContactInformationId = 1,
                            ImageUrl = "https://images.pexels.com/photos/7020543/pexels-photo-7020543.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
                            Name = "Emma Watson",
                            PublicId = new Guid("456c1b74-1ded-4497-b82b-b9bcd052c085"),
                            RecentActivity = new DateTime(2024, 9, 12, 19, 33, 4, 609, DateTimeKind.Local).AddTicks(7198)
                        },
                        new
                        {
                            Id = 2,
                            Bio = "Graphic designer with a keen eye for branding and marketing materials",
                            ClerkId = "jimmy_j_303",
                            ContactInformationId = 2,
                            ImageUrl = "https://images.pexels.com/photos/8159657/pexels-photo-8159657.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
                            Name = "Jimmy John",
                            PublicId = new Guid("70a67287-35b9-4dae-a351-7ebb37d68ebe"),
                            RecentActivity = new DateTime(2024, 9, 12, 19, 33, 4, 609, DateTimeKind.Local).AddTicks(7266)
                        },
                        new
                        {
                            Id = 3,
                            Bio = "Data scientist with expertise in machine learning and statistical analysis",
                            ClerkId = "sarah_j_303",
                            ContactInformationId = 3,
                            ImageUrl = "https://images.pexels.com/photos/4350178/pexels-photo-4350178.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
                            Name = "Sarah Johnson",
                            PublicId = new Guid("2463a3fd-84e3-477f-9200-c745635da5e1"),
                            RecentActivity = new DateTime(2024, 9, 12, 19, 33, 4, 609, DateTimeKind.Local).AddTicks(7272)
                        },
                        new
                        {
                            Id = 4,
                            Bio = "UI developer specializing in responsive design and accessibility",
                            ClerkId = "ethan_p_303",
                            ContactInformationId = 4,
                            ImageUrl = "https://images.pexels.com/photos/6652928/pexels-photo-6652928.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
                            Name = "Ethan Patel",
                            PublicId = new Guid("427d0276-bb92-45fd-9188-8075a0e86417"),
                            RecentActivity = new DateTime(2024, 9, 12, 19, 33, 4, 609, DateTimeKind.Local).AddTicks(7278)
                        });
                });

            modelBuilder.Entity("SkillSwap.Api.Models.Skill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ProfileId")
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

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ProfileId = 1,
                            PublicId = new Guid("ee98b38e-8a3c-46ea-8bcf-6ebf0d07427b"),
                            TagName = "Python"
                        },
                        new
                        {
                            Id = 2,
                            ProfileId = 1,
                            PublicId = new Guid("ead07590-4312-4b9c-9d77-4daef1ae1011"),
                            TagName = "C#"
                        },
                        new
                        {
                            Id = 3,
                            ProfileId = 2,
                            PublicId = new Guid("968a9fff-6717-406c-8a8a-d38a57ba432a"),
                            TagName = "Python"
                        },
                        new
                        {
                            Id = 4,
                            ProfileId = 2,
                            PublicId = new Guid("7ea3dc0f-892b-4402-85e8-0184ace48ac5"),
                            TagName = "C++"
                        },
                        new
                        {
                            Id = 5,
                            ProfileId = 3,
                            PublicId = new Guid("8ffc81e3-ee19-42c9-b633-b83d8e575ce2"),
                            TagName = "Python"
                        },
                        new
                        {
                            Id = 6,
                            ProfileId = 3,
                            PublicId = new Guid("0cd99301-323a-4b8a-8c06-e72b46334b80"),
                            TagName = "Rust"
                        },
                        new
                        {
                            Id = 7,
                            ProfileId = 4,
                            PublicId = new Guid("bfa6e9c2-fb04-48e7-8739-22f0aec02082"),
                            TagName = "JavaScript"
                        },
                        new
                        {
                            Id = 8,
                            ProfileId = 4,
                            PublicId = new Guid("5896427f-4289-4daf-8980-191da950df17"),
                            TagName = "CSS"
                        });
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
                    b.HasOne("SkillSwap.Api.Models.Profile", "Profile")
                        .WithMany("Needs")
                        .HasForeignKey("ProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Profile");
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
                    b.HasOne("SkillSwap.Api.Models.Profile", "Profile")
                        .WithMany("Skills")
                        .HasForeignKey("ProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Profile");
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
