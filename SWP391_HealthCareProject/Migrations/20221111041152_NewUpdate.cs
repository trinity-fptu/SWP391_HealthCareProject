using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SWP391_HealthCareProject.Migrations
{
    public partial class NewUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsRegistable",
                table: "Campaign",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsRegistable",
                table: "Campaign");
        }
    }
}
