using System;
using Microsoft.EntityFrameworkCore.Migrations;

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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AboutTextEnglish = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AboutTextFrench = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AboutImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorksContentEnglish = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorksContentFrench = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SkillsContentEnglish = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SkillsContentFrench = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GithubUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LinkedInUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CVFileFrenchUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CVFileEnglishUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiteContents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Testimonials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubmittedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Approved = table.Column<bool>(type: "bit", nullable: false),
                    Featured = table.Column<bool>(type: "bit", nullable: false),
                    Rating = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Testimonials", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "SiteContents",
                columns: new[] { "Id", "AboutImageUrl", "AboutTextEnglish", "AboutTextFrench", "CVFileEnglishUrl", "CVFileFrenchUrl", "ContactEmail", "ContactPhone", "GithubUrl", "LinkedInUrl", "SkillsContentEnglish", "SkillsContentFrench", "WorksContentEnglish", "WorksContentFrench" },
                values: new object[] { 1, null, "Passionate Computer Science student proficient in multiple programming languages and cloud services. Experienced in developing IoT solutions, microservices and full-stack web applications. Seeking an internship to leverage my skills in software development and cloud computing.", "Étudiant passionné d'informatique maîtrisant plusieurs langages de programmation et services cloud. Expérimenté dans le développement de solutions IoT, de microservices et d'applications web full-stack. À la recherche d'un stage pour mettre à profit mes compétences en développement de logiciels et en cloud computing.", "/files/CV Aian Batoochirov EN.pdf", "/files/CV Aian Batoochirov FR.pdf", "aianbat50@gmail.com", "+1 (438) 528-3019", "https://github.com/orell2j", "http://www.linkedin.com/in/aian-batoochirov-50521318b", "<p>Skills:<br>Java / Springboot, Agile / Scrum, Github / Git, Jira, Rest API, JavaScript / React, Micro Services, Linux, HTML / CSS, SQL / Databases, Teamwork, Problem Solver</p>", "<p>Compétences:<br>Java / Springboot, Agile / Scrum, Github / Git, Jira, Rest API, JavaScript / React, Micro Services, HTML / CSS, SQL / Databases, Travail d'équipe, Résolution de problèmes</p>", "<p>Projects:<br>• WEB DEV - Pet Clinic Project<br>• WEB DEV - Billing Project Automation</p>", "<p>Projets:<br>• WEB DEV - Pet Clinic Project<br>• WEB DEV - CompteExpress</p>" });

            migrationBuilder.InsertData(
                table: "Testimonials",
                columns: new[] { "Id", "Approved", "Comment", "Featured", "Name", "Rating", "SubmittedOn" },
                values: new object[,]
                {
                    { 1, true, "Great portfolio!", true, "John Doe", 5.0, new DateTime(2025, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, true, "Very professional work.", false, "Jane Smith", 4.5, new DateTime(2025, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, true, "Excellent design!", false, "Alex Johnson", 4.0, new DateTime(2025, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, true, "Impressive work.", false, "Emily Davis", 4.5, new DateTime(2025, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, true, "Really liked it!", false, "Michael Brown", 5.0, new DateTime(2025, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, true, "Could be better.", false, "Sarah Wilson", 3.5, new DateTime(2025, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, true, "Outstanding effort!", true, "David Lee", 5.0, new DateTime(2025, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, true, "Very creative!", false, "Laura Martinez", 4.0, new DateTime(2025, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, true, "Amazing results!", true, "Chris Taylor", 5.0, new DateTime(2025, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, true, "Satisfying work.", false, "Olivia Harris", 4.5, new DateTime(2025, 1, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) }
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
