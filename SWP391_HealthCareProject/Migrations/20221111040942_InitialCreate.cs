using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SWP391_HealthCareProject.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hospital_RedCross",
                columns: table => new
                {
                    RHID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Hospital__5A84283B73FA5B75", x => x.RHID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    Avatar = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "Plan",
                columns: table => new
                {
                    PlanID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: true),
                    ExpectedTotalCost = table.Column<double>(type: "float", nullable: true),
                    ExpectedAmount = table.Column<int>(type: "int", nullable: true),
                    RHID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plan", x => x.PlanID);
                    table.ForeignKey(
                        name: "FK_PlanRH",
                        column: x => x.RHID,
                        principalTable: "Hospital_RedCross",
                        principalColumn: "RHID");
                });

            migrationBuilder.CreateTable(
                name: "HospitalRedCrossAdmin",
                columns: table => new
                {
                    RHAID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    RHID = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    License = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Hospital__D0F38005D97EBBBF", x => x.RHAID);
                    table.ForeignKey(
                        name: "FK_RHA_RH",
                        column: x => x.RHID,
                        principalTable: "Hospital_RedCross",
                        principalColumn: "RHID");
                    table.ForeignKey(
                        name: "FK_RHAUser",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "Volunteer",
                columns: table => new
                {
                    VolunteerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    City = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DOB = table.Column<DateTime>(type: "date", nullable: false),
                    Gender = table.Column<bool>(type: "bit", nullable: false),
                    BloodType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Attended = table.Column<int>(type: "int", nullable: false),
                    ID_CardNumber = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Volunteer", x => x.VolunteerID);
                    table.ForeignKey(
                        name: "FK_VolunteerUser",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "Campaign",
                columns: table => new
                {
                    CampaignID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    NumOfVolunteer = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "date", nullable: false),
                    EndDate = table.Column<DateTime>(type: "date", nullable: false),
                    Province = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Cost = table.Column<double>(type: "float", nullable: true),
                    PlanID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campaign", x => x.CampaignID);
                    table.ForeignKey(
                        name: "FK_CampaignPlan",
                        column: x => x.PlanID,
                        principalTable: "Plan",
                        principalColumn: "PlanID");
                });

            migrationBuilder.CreateTable(
                name: "CampaignLocation",
                columns: table => new
                {
                    CampaignLocationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CampaignID = table.Column<int>(type: "int", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampaignLocation", x => x.CampaignLocationID);
                    table.ForeignKey(
                        name: "FK_CLCampaign",
                        column: x => x.CampaignID,
                        principalTable: "Campaign",
                        principalColumn: "CampaignID");
                });

            migrationBuilder.CreateTable(
                name: "Participates",
                columns: table => new
                {
                    VolunteerID = table.Column<int>(type: "int", nullable: false),
                    CampaignID = table.Column<int>(type: "int", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    RegisteredDate = table.Column<DateTime>(type: "date", nullable: false),
                    BloodAmount = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_Parti_Campaign",
                        column: x => x.CampaignID,
                        principalTable: "Campaign",
                        principalColumn: "CampaignID");
                    table.ForeignKey(
                        name: "FK_Parti_Vol",
                        column: x => x.VolunteerID,
                        principalTable: "Volunteer",
                        principalColumn: "VolunteerID");
                });

            migrationBuilder.CreateTable(
                name: "Post",
                columns: table => new
                {
                    PostID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Img = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CampaignID = table.Column<int>(type: "int", nullable: true),
                    RHAID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.PostID);
                    table.ForeignKey(
                        name: "FK_PostCampaign",
                        column: x => x.CampaignID,
                        principalTable: "Campaign",
                        principalColumn: "CampaignID");
                    table.ForeignKey(
                        name: "FK_PostRHA",
                        column: x => x.RHAID,
                        principalTable: "HospitalRedCrossAdmin",
                        principalColumn: "RHAID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Campaign_PlanID",
                table: "Campaign",
                column: "PlanID");

            migrationBuilder.CreateIndex(
                name: "IX_CampaignLocation_CampaignID",
                table: "CampaignLocation",
                column: "CampaignID");

            migrationBuilder.CreateIndex(
                name: "IX_HospitalRedCrossAdmin_RHID",
                table: "HospitalRedCrossAdmin",
                column: "RHID");

            migrationBuilder.CreateIndex(
                name: "IX_HospitalRedCrossAdmin_UserID",
                table: "HospitalRedCrossAdmin",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Participates_CampaignID",
                table: "Participates",
                column: "CampaignID");

            migrationBuilder.CreateIndex(
                name: "IX_Participates_VolunteerID",
                table: "Participates",
                column: "VolunteerID");

            migrationBuilder.CreateIndex(
                name: "IX_Plan_RHID",
                table: "Plan",
                column: "RHID");

            migrationBuilder.CreateIndex(
                name: "IX_Post_CampaignID",
                table: "Post",
                column: "CampaignID");

            migrationBuilder.CreateIndex(
                name: "IX_Post_RHAID",
                table: "Post",
                column: "RHAID");

            migrationBuilder.CreateIndex(
                name: "UQ__User__C9F284567CE8C0A8",
                table: "User",
                column: "UserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Volunteer_UserID",
                table: "Volunteer",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CampaignLocation");

            migrationBuilder.DropTable(
                name: "Participates");

            migrationBuilder.DropTable(
                name: "Post");

            migrationBuilder.DropTable(
                name: "Volunteer");

            migrationBuilder.DropTable(
                name: "Campaign");

            migrationBuilder.DropTable(
                name: "HospitalRedCrossAdmin");

            migrationBuilder.DropTable(
                name: "Plan");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Hospital_RedCross");
        }
    }
}
