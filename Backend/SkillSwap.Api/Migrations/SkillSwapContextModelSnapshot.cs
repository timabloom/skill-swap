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
                            PublicId = new Guid("46b5cf5d-1bd0-4aab-954e-3baf52ec4d9b")
                        },
                        new
                        {
                            Id = 2,
                            Email = "jimmy.john@email.com",
                            PublicId = new Guid("6a4507d1-7f52-4812-96b4-d09f8d8442bd")
                        },
                        new
                        {
                            Id = 3,
                            Email = "sarah.johnson@email.com",
                            PublicId = new Guid("3e489376-0130-4132-bc55-ff413468092f")
                        },
                        new
                        {
                            Id = 4,
                            Email = "ethan.patel@email.com",
                            PublicId = new Guid("b77c5475-4059-4fb9-8837-4839246592b9")
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
                            PublicId = new Guid("98e6b778-4185-4064-b6f0-5a1b3e2131e5"),
                            TagName = "JavaScript"
                        },
                        new
                        {
                            Id = 2,
                            ProfileId = 1,
                            PublicId = new Guid("4656b6d1-4621-4fb7-990f-785f216e5e59"),
                            TagName = "CSS"
                        },
                        new
                        {
                            Id = 3,
                            ProfileId = 2,
                            PublicId = new Guid("a9238e5c-04ab-429a-b0e9-a3668ff79696"),
                            TagName = "JavaScript"
                        },
                        new
                        {
                            Id = 4,
                            ProfileId = 2,
                            PublicId = new Guid("508ab9f3-8802-4328-9440-98c7e43529db"),
                            TagName = "HTML"
                        },
                        new
                        {
                            Id = 5,
                            ProfileId = 3,
                            PublicId = new Guid("1b95b136-4fb6-4835-8bbb-c368915fd4a6"),
                            TagName = "JavaScript"
                        },
                        new
                        {
                            Id = 6,
                            ProfileId = 3,
                            PublicId = new Guid("d32cff69-99ec-43fa-8e8a-163c7279958f"),
                            TagName = "CSS"
                        },
                        new
                        {
                            Id = 7,
                            ProfileId = 4,
                            PublicId = new Guid("e128a1ac-de9d-4aca-bdfb-43d1df922c24"),
                            TagName = "Python"
                        },
                        new
                        {
                            Id = 8,
                            ProfileId = 4,
                            PublicId = new Guid("7a4eac1c-7507-4bfd-abb6-8d2d37682f0c"),
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
                            Bio = "Backend developer focused on building scalable and efficient server-side applications",
                            ClerkId = "emma_w_303",
                            ContactInformationId = 1,
                            ImageUrl = "https://images.pexels.com/photos/7020543/pexels-photo-7020543.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
                            Name = "Emma Watson",
                            PublicId = new Guid("5c7b326b-fb8d-4917-ad24-11fdb1c5d730"),
                            RecentActivity = new DateTime(2024, 9, 11, 23, 18, 39, 425, DateTimeKind.Local).AddTicks(3514)
                        },
                        new
                        {
                            Id = 2,
                            Bio = "Graphic designer with a keen eye for branding and marketing materials",
                            ClerkId = "jimmy_j_303",
                            ContactInformationId = 2,
                            ImageUrl = "https://images.pexels.com/photos/8159657/pexels-photo-8159657.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
                            Name = "Jimmy John",
                            PublicId = new Guid("2437d167-3354-4416-a948-31942558ef88"),
                            RecentActivity = new DateTime(2024, 9, 11, 23, 18, 39, 425, DateTimeKind.Local).AddTicks(3587)
                        },
                        new
                        {
                            Id = 3,
                            Bio = "Data scientist with expertise in machine learning and statistical analysis",
                            ClerkId = "sarah_j_303",
                            ContactInformationId = 3,
                            ImageUrl = "https://images.pexels.com/photos/4350178/pexels-photo-4350178.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
                            Name = "Sarah Johnson",
                            PublicId = new Guid("637eabf6-42ce-4d07-ae0d-7f7c267e6a49"),
                            RecentActivity = new DateTime(2024, 9, 11, 23, 18, 39, 425, DateTimeKind.Local).AddTicks(3594)
                        },
                        new
                        {
                            Id = 4,
                            Bio = "UI developer specializing in responsive design and accessibility",
                            ClerkId = "ethan_p_303",
                            ContactInformationId = 4,
                            ImageUrl = "https://images.pexels.com/photos/6652928/pexels-photo-6652928.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
                            Name = "Ethan Patel",
                            PublicId = new Guid("c16ea9ee-7fa0-434c-8e84-430e733f8df0"),
                            RecentActivity = new DateTime(2024, 9, 11, 23, 18, 39, 425, DateTimeKind.Local).AddTicks(3599)
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
                            PublicId = new Guid("0e902b3c-c74f-438d-bf15-23eace7af035"),
                            TagName = "Python"
                        },
                        new
                        {
                            Id = 2,
                            ProfileId = 1,
                            PublicId = new Guid("caa1e1eb-a593-4534-98f0-1e30122c15f1"),
                            TagName = "CSS"
                        },
                        new
                        {
                            Id = 3,
                            ProfileId = 2,
                            PublicId = new Guid("55b6fc50-1bc7-4b34-ab6c-6f877bc7f5fa"),
                            TagName = "Python"
                        },
                        new
                        {
                            Id = 4,
                            ProfileId = 2,
                            PublicId = new Guid("106047f6-d319-4688-a9da-5c2b2945efb4"),
                            TagName = "HTML"
                        },
                        new
                        {
                            Id = 5,
                            ProfileId = 3,
                            PublicId = new Guid("cf716ab2-058c-4c60-9d9a-8ba2ba0eae1f"),
                            TagName = "Python"
                        },
                        new
                        {
                            Id = 6,
                            ProfileId = 3,
                            PublicId = new Guid("bfa043f8-3852-4c68-a1f7-76bf1db00577"),
                            TagName = "CSS"
                        },
                        new
                        {
                            Id = 7,
                            ProfileId = 4,
                            PublicId = new Guid("0333234b-72ca-4bd8-8db4-0c0b7cef612a"),
                            TagName = "JavaScript"
                        },
                        new
                        {
                            Id = 8,
                            ProfileId = 4,
                            PublicId = new Guid("631a5ee4-0bd6-4f0e-b529-6b6d3ab83c40"),
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
