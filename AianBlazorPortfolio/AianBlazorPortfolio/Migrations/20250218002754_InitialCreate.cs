using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AianBlazorPortfolio.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SiteContents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AboutTextEnglish = table.Column<string>(type: "text", nullable: true),
                    AboutTextFrench = table.Column<string>(type: "text", nullable: true),
                    AboutImageUrl = table.Column<string>(type: "text", nullable: true),
                    WorksContentEnglish = table.Column<string>(type: "text", nullable: true),
                    WorksContentFrench = table.Column<string>(type: "text", nullable: true),
                    SkillsContentEnglish = table.Column<string>(type: "text", nullable: true),
                    SkillsContentFrench = table.Column<string>(type: "text", nullable: true),
                    ContactEmail = table.Column<string>(type: "text", nullable: true),
                    ContactPhone = table.Column<string>(type: "text", nullable: true),
                    GithubUrl = table.Column<string>(type: "text", nullable: true),
                    LinkedInUrl = table.Column<string>(type: "text", nullable: true),
                    CVFileFrenchUrl = table.Column<string>(type: "text", nullable: true),
                    CVFileEnglishUrl = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiteContents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Testimonials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Comment = table.Column<string>(type: "text", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Approved = table.Column<bool>(type: "boolean", nullable: false),
                    Featured = table.Column<bool>(type: "boolean", nullable: false),
                    Rating = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Testimonials", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "SiteContents",
                columns: new[] { "Id", "AboutImageUrl", "AboutTextEnglish", "AboutTextFrench", "CVFileEnglishUrl", "CVFileFrenchUrl", "ContactEmail", "ContactPhone", "GithubUrl", "LinkedInUrl", "SkillsContentEnglish", "SkillsContentFrench", "WorksContentEnglish", "WorksContentFrench" },
                values: new object[] { 1, null, "Hello! I'm Aian Batoochirov, <br><br> a passionate Computer Science student at Champlain College. <br> I've worked on projects full stack webapp projects like a veterinary management system and a billing automation platform. <br><br>I'm eager to learn new technologies and am looking for an internship where I can contribute and grow. Let's connect and create something great together!", "Bonjour ! Je suis Aian Batoochirov, <br><br>\r\nun étudiant passionné en informatique au Collège Champlain. <br>\r\nJ'ai travaillé sur des projets full-stack, tels qu'un système de gestion vétérinaire et une plateforme d'automatisation de la facturation. <br><br>\r\nJe suis avide d'apprendre de nouvelles technologies et je recherche un stage où je pourrais contribuer et évoluer. Connectons-nous et créons ensemble quelque chose de grand !", "/files/CV Aian Batoochirov EN.pdf", "/files/CV Aian Batoochirov FR.pdf", "aianbat50@gmail.com", "+1 (438) 528-3019", "https://github.com/orell2j", "http://www.linkedin.com/in/aian-batoochirov-50521318b", "<p>Skills:<br>Java / Springboot, Agile / Scrum, Github / Git, Jira, Rest API, JavaScript / React, Micro Services, Linux, HTML / CSS, SQL / Databases, Teamwork, Problem Solver</p>", "<p>Compétences:<br>Java / Springboot, Agile / Scrum, Github / Git, Jira, Rest API, JavaScript / React, Micro Services, HTML / CSS, SQL / Databases, Travail d'équipe, Résolution de problèmes</p>", "<p>\r\n  Projects:<br>\r\n  • Veterinary Management System – <a href=\"https://github.com/cgerard321/champlain_petclinic\" target=\"_blank\">GitHub Repo</a><br>\r\n  • Billing Automation Platform – <a href=\"https://github.com/Carlos-123321/CompteExpress\" target=\"_blank\">GitHub Repo</a>\r\n</p>", "<p>\r\n  Projets :<br>\r\n  • Système de gestion vétérinaire – <a href=\"https://github.com/cgerard321/champlain_petclinic\" target=\"_blank\">Dépôt GitHub</a><br>\r\n  • Plateforme d'automatisation de la facturation – <a href=\"https://github.com/Carlos-123321/CompteExpress\" target=\"_blank\">Dépôt GitHub</a>\r\n</p>" });

            migrationBuilder.InsertData(
                table: "Testimonials",
                columns: new[] { "Id", "Approved", "Comment", "CreatedOn", "Featured", "Name", "Rating" },
                values: new object[,]
                {
                    { 1, true, "Great portfolio!", new DateTime(2025, 1, 20, 0, 0, 0, 0, DateTimeKind.Utc), true, "John Doe", 5.0 },
                    { 2, true, "Very professional work.", new DateTime(2025, 1, 21, 0, 0, 0, 0, DateTimeKind.Utc), false, "Jane Smith", 4.5 },
                    { 3, true, "Excellent design!", new DateTime(2025, 1, 22, 0, 0, 0, 0, DateTimeKind.Utc), false, "Alex Johnson", 4.0 },
                    { 4, true, "Impressive work.", new DateTime(2025, 1, 23, 0, 0, 0, 0, DateTimeKind.Utc), false, "Emily Davis", 4.5 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SiteContents");

            migrationBuilder.DropTable(
                name: "Testimonials");
        }
    }
}
