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
                    { 1, "emma.watson@email.com", new Guid("967f7687-80cd-4c49-af72-30f1bded6210") },
                    { 2, "jimmy.john@email.com", new Guid("620aac10-d6b4-48a4-89ef-52ea8ccfc78b") },
                    { 3, "sarah.johnson@email.com", new Guid("cc7b951b-1cd8-47ee-9346-0c97c63afa1a") },
                    { 4, "ethan.patel@email.com", new Guid("67b5f9b9-d7c9-4fad-8951-e87fed1202ee") }
                });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "Id", "Bio", "ClerkId", "ContactInformationId", "ImageUrl", "Name", "PublicId", "RecentActivity" },
                values: new object[,]
                {
                    { 1, "Backend developer focused on scalable and efficient server-side applications", "emma_w_303", 1, "https://images.pexels.com/photos/7020543/pexels-photo-7020543.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1", "Emma Watson", new Guid("456c1b74-1ded-4497-b82b-b9bcd052c085"), new DateTime(2024, 9, 12, 19, 33, 4, 609, DateTimeKind.Local).AddTicks(7198) },
                    { 2, "Graphic designer with a keen eye for branding and marketing materials", "jimmy_j_303", 2, "https://images.pexels.com/photos/8159657/pexels-photo-8159657.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1", "Jimmy John", new Guid("70a67287-35b9-4dae-a351-7ebb37d68ebe"), new DateTime(2024, 9, 12, 19, 33, 4, 609, DateTimeKind.Local).AddTicks(7266) },
                    { 3, "Data scientist with expertise in machine learning and statistical analysis", "sarah_j_303", 3, "https://images.pexels.com/photos/4350178/pexels-photo-4350178.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1", "Sarah Johnson", new Guid("2463a3fd-84e3-477f-9200-c745635da5e1"), new DateTime(2024, 9, 12, 19, 33, 4, 609, DateTimeKind.Local).AddTicks(7272) },
                    { 4, "UI developer specializing in responsive design and accessibility", "ethan_p_303", 4, "https://images.pexels.com/photos/6652928/pexels-photo-6652928.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1", "Ethan Patel", new Guid("427d0276-bb92-45fd-9188-8075a0e86417"), new DateTime(2024, 9, 12, 19, 33, 4, 609, DateTimeKind.Local).AddTicks(7278) }
                });

            migrationBuilder.InsertData(
                table: "Needs",
                columns: new[] { "Id", "ProfileId", "PublicId", "TagName" },
                values: new object[,]
                {
                    { 1, 1, new Guid("fc82590b-6b9b-4d83-b703-dc216773832f"), "JavaScript" },
                    { 2, 1, new Guid("dc336f9a-a5df-4e7f-9416-c1fc7e8f4819"), "CSS" },
                    { 3, 2, new Guid("6286c5d7-60fa-4995-ad94-ae80c053731e"), "JavaScript" },
                    { 4, 2, new Guid("349feb79-54c7-4fd1-bd56-43268d931bf8"), "CSS" },
                    { 5, 3, new Guid("09cbf2a8-d87e-45d8-b0ae-f34229df1117"), "JavaScript" },
                    { 6, 3, new Guid("18ad7f68-92d0-48fb-a3bf-17fcf3822411"), "CSS" },
                    { 7, 4, new Guid("14e8e104-f010-4bae-8a10-bf9508c12b9b"), "Python" },
                    { 8, 4, new Guid("d0edfa3f-98e6-4c04-b964-a1b2e32bdaba"), "PostgreSQL" }
                });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "ProfileId", "PublicId", "TagName" },
                values: new object[,]
                {
                    { 1, 1, new Guid("ee98b38e-8a3c-46ea-8bcf-6ebf0d07427b"), "Python" },
                    { 2, 1, new Guid("ead07590-4312-4b9c-9d77-4daef1ae1011"), "C#" },
                    { 3, 2, new Guid("968a9fff-6717-406c-8a8a-d38a57ba432a"), "Python" },
                    { 4, 2, new Guid("7ea3dc0f-892b-4402-85e8-0184ace48ac5"), "C++" },
                    { 5, 3, new Guid("8ffc81e3-ee19-42c9-b633-b83d8e575ce2"), "Python" },
                    { 6, 3, new Guid("0cd99301-323a-4b8a-8c06-e72b46334b80"), "Rust" },
                    { 7, 4, new Guid("bfa6e9c2-fb04-48e7-8739-22f0aec02082"), "JavaScript" },
                    { 8, 4, new Guid("5896427f-4289-4daf-8980-191da950df17"), "CSS" }
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
