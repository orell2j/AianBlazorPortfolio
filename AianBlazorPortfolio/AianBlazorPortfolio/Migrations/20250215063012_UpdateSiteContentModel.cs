using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AianBlazorPortfolio.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSiteContentModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "WorksContent",
                table: "SiteContents",
                newName: "WorksContentFrench");

            migrationBuilder.RenameColumn(
                name: "SkillsContent",
                table: "SiteContents",
                newName: "WorksContentEnglish");

            migrationBuilder.RenameColumn(
                name: "AboutText",
                table: "SiteContents",
                newName: "SkillsContentFrench");

            migrationBuilder.AddColumn<string>(
                name: "AboutTextEnglish",
                table: "SiteContents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AboutTextFrench",
                table: "SiteContents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GithubUrl",
                table: "SiteContents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LinkedInUrl",
                table: "SiteContents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SkillsContentEnglish",
                table: "SiteContents",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AboutTextEnglish",
                table: "SiteContents");

            migrationBuilder.DropColumn(
                name: "AboutTextFrench",
                table: "SiteContents");

            migrationBuilder.DropColumn(
                name: "GithubUrl",
                table: "SiteContents");

            migrationBuilder.DropColumn(
                name: "LinkedInUrl",
                table: "SiteContents");

            migrationBuilder.DropColumn(
                name: "SkillsContentEnglish",
                table: "SiteContents");

            migrationBuilder.RenameColumn(
                name: "WorksContentFrench",
                table: "SiteContents",
                newName: "WorksContent");

            migrationBuilder.RenameColumn(
                name: "WorksContentEnglish",
                table: "SiteContents",
                newName: "SkillsContent");

            migrationBuilder.RenameColumn(
                name: "SkillsContentFrench",
                table: "SiteContents",
                newName: "AboutText");
        }
    }
}
