using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SkillSwap.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContactInformations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PublicId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactInformations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PublicId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClerkId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bio = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    RecentActivity = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactInformationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Profiles_ContactInformations_ContactInformationId",
                        column: x => x.ContactInformationId,
                        principalTable: "ContactInformations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Connections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PublicId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProfileMatchId = table.Column<int>(type: "int", nullable: false),
                    ProfileMatchPublicId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsAccepted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Connections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Connections_Profiles_ProfileMatchId",
                        column: x => x.ProfileMatchId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Needs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PublicId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProfileId = table.Column<int>(type: "int", nullable: false),
                    TagName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Needs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Needs_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PublicId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProfileId = table.Column<int>(type: "int", nullable: false),
                    TagName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Skills_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ContactInformations",
                columns: new[] { "Id", "Email", "PublicId" },
                values: new object[,]
                {
                    { 1, "emma.watson@email.com", new Guid("46b5cf5d-1bd0-4aab-954e-3baf52ec4d9b") },
                    { 2, "jimmy.john@email.com", new Guid("6a4507d1-7f52-4812-96b4-d09f8d8442bd") },
                    { 3, "sarah.johnson@email.com", new Guid("3e489376-0130-4132-bc55-ff413468092f") },
                    { 4, "ethan.patel@email.com", new Guid("b77c5475-4059-4fb9-8837-4839246592b9") }
                });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "Id", "Bio", "ClerkId", "ContactInformationId", "ImageUrl", "Name", "PublicId", "RecentActivity" },
                values: new object[,]
                {
                    { 1, "Backend developer focused on building scalable and efficient server-side applications", "emma_w_303", 1, "https://images.pexels.com/photos/7020543/pexels-photo-7020543.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1", "Emma Watson", new Guid("5c7b326b-fb8d-4917-ad24-11fdb1c5d730"), new DateTime(2024, 9, 11, 23, 18, 39, 425, DateTimeKind.Local).AddTicks(3514) },
                    { 2, "Graphic designer with a keen eye for branding and marketing materials", "jimmy_j_303", 2, "https://images.pexels.com/photos/8159657/pexels-photo-8159657.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1", "Jimmy John", new Guid("2437d167-3354-4416-a948-31942558ef88"), new DateTime(2024, 9, 11, 23, 18, 39, 425, DateTimeKind.Local).AddTicks(3587) },
                    { 3, "Data scientist with expertise in machine learning and statistical analysis", "sarah_j_303", 3, "https://images.pexels.com/photos/4350178/pexels-photo-4350178.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1", "Sarah Johnson", new Guid("637eabf6-42ce-4d07-ae0d-7f7c267e6a49"), new DateTime(2024, 9, 11, 23, 18, 39, 425, DateTimeKind.Local).AddTicks(3594) },
                    { 4, "UI developer specializing in responsive design and accessibility", "ethan_p_303", 4, "https://images.pexels.com/photos/6652928/pexels-photo-6652928.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1", "Ethan Patel", new Guid("c16ea9ee-7fa0-434c-8e84-430e733f8df0"), new DateTime(2024, 9, 11, 23, 18, 39, 425, DateTimeKind.Local).AddTicks(3599) }
                });

            migrationBuilder.InsertData(
                table: "Needs",
                columns: new[] { "Id", "ProfileId", "PublicId", "TagName" },
                values: new object[,]
                {
                    { 1, 1, new Guid("98e6b778-4185-4064-b6f0-5a1b3e2131e5"), "JavaScript" },
                    { 2, 1, new Guid("4656b6d1-4621-4fb7-990f-785f216e5e59"), "CSS" },
                    { 3, 2, new Guid("a9238e5c-04ab-429a-b0e9-a3668ff79696"), "JavaScript" },
                    { 4, 2, new Guid("508ab9f3-8802-4328-9440-98c7e43529db"), "HTML" },
                    { 5, 3, new Guid("1b95b136-4fb6-4835-8bbb-c368915fd4a6"), "JavaScript" },
                    { 6, 3, new Guid("d32cff69-99ec-43fa-8e8a-163c7279958f"), "CSS" },
                    { 7, 4, new Guid("e128a1ac-de9d-4aca-bdfb-43d1df922c24"), "Python" },
                    { 8, 4, new Guid("7a4eac1c-7507-4bfd-abb6-8d2d37682f0c"), "PostgreSQL" }
                });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "ProfileId", "PublicId", "TagName" },
                values: new object[,]
                {
                    { 1, 1, new Guid("0e902b3c-c74f-438d-bf15-23eace7af035"), "Python" },
                    { 2, 1, new Guid("caa1e1eb-a593-4534-98f0-1e30122c15f1"), "CSS" },
                    { 3, 2, new Guid("55b6fc50-1bc7-4b34-ab6c-6f877bc7f5fa"), "Python" },
                    { 4, 2, new Guid("106047f6-d319-4688-a9da-5c2b2945efb4"), "HTML" },
                    { 5, 3, new Guid("cf716ab2-058c-4c60-9d9a-8ba2ba0eae1f"), "Python" },
                    { 6, 3, new Guid("bfa043f8-3852-4c68-a1f7-76bf1db00577"), "CSS" },
                    { 7, 4, new Guid("0333234b-72ca-4bd8-8db4-0c0b7cef612a"), "JavaScript" },
                    { 8, 4, new Guid("631a5ee4-0bd6-4f0e-b529-6b6d3ab83c40"), "CSS" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Connections_ProfileMatchId",
                table: "Connections",
                column: "ProfileMatchId");

            migrationBuilder.CreateIndex(
                name: "IX_Needs_ProfileId",
                table: "Needs",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_ContactInformationId",
                table: "Profiles",
                column: "ContactInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_ProfileId",
                table: "Skills",
                column: "ProfileId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Connections");

            migrationBuilder.DropTable(
                name: "Needs");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "Profiles");

            migrationBuilder.DropTable(
                name: "ContactInformations");
        }
    }
}
