using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SWP391_HealthCareProject.Migrations
{
    public partial class AddPK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Participates_VolunteerID",
                table: "Participates");

            migrationBuilder.RenameColumn(
                name: "IsRegistable",
                table: "Campaign",
                newName: "Status");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Participates",
                table: "Participates",
                columns: new[] { "VolunteerID", "CampaignID" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Participates",
                table: "Participates");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Campaign",
                newName: "IsRegistable");

            migrationBuilder.CreateIndex(
                name: "IX_Participates_VolunteerID",
                table: "Participates",
                column: "VolunteerID");
        }
    }
}
