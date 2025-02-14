using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AianBlazorPortfolio.Migrations
{
    /// <inheritdoc />
    public partial class SeedTestimonials : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "Testimonials");
        }
    }
}
