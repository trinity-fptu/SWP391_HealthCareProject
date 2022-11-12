﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SWP391_HealthCareProject.Models;

#nullable disable

namespace SWP391_HealthCareProject.Migrations
{
    [DbContext(typeof(BloodDonorContext))]
    [Migration("20221112154046_AddPK")]
    partial class AddPK
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("SWP391_HealthCareProject.Models.Campaign", b =>
                {
                    b.Property<int>("CampaignId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CampaignID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CampaignId"), 1L, 1);

                    b.Property<double?>("Cost")
                        .HasColumnType("float");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("NumOfVolunteer")
                        .HasColumnType("int");

                    b.Property<int>("PlanId")
                        .HasColumnType("int")
                        .HasColumnName("PlanID");

                    b.Property<string>("Province")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("date");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("CampaignId");

                    b.HasIndex("PlanId");

                    b.ToTable("Campaign", (string)null);
                });

            modelBuilder.Entity("SWP391_HealthCareProject.Models.CampaignLocation", b =>
                {
                    b.Property<int>("CampaignLocationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CampaignLocationID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CampaignLocationId"), 1L, 1);

                    b.Property<int>("CampaignId")
                        .HasColumnType("int")
                        .HasColumnName("CampaignID");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("CampaignLocationId");

                    b.HasIndex("CampaignId");

                    b.ToTable("CampaignLocation", (string)null);
                });

            modelBuilder.Entity("SWP391_HealthCareProject.Models.HospitalRedCross", b =>
                {
                    b.Property<int>("Rhid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("RHID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Rhid"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Rhid")
                        .HasName("PK__Hospital__5A84283B73FA5B75");

                    b.ToTable("Hospital_RedCross", (string)null);
                });

            modelBuilder.Entity("SWP391_HealthCareProject.Models.HospitalRedCrossAdmin", b =>
                {
                    b.Property<int>("Rhaid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("RHAID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Rhaid"), 1L, 1);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("License")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("Rhid")
                        .HasColumnType("int")
                        .HasColumnName("RHID");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("UserID");

                    b.HasKey("Rhaid")
                        .HasName("PK__Hospital__D0F38005D97EBBBF");

                    b.HasIndex("Rhid");

                    b.HasIndex("UserId");

                    b.ToTable("HospitalRedCrossAdmin", (string)null);
                });

            modelBuilder.Entity("SWP391_HealthCareProject.Models.Participate", b =>
                {
                    b.Property<int>("VolunteerId")
                        .HasColumnType("int")
                        .HasColumnName("VolunteerID");

                    b.Property<int>("CampaignId")
                        .HasColumnType("int")
                        .HasColumnName("CampaignID");

                    b.Property<int?>("BloodAmount")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("date");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime>("RegisteredDate")
                        .HasColumnType("date");

                    b.HasKey("VolunteerId", "CampaignId");

                    b.HasIndex("CampaignId");

                    b.ToTable("Participates");
                });

            modelBuilder.Entity("SWP391_HealthCareProject.Models.Plan", b =>
                {
                    b.Property<int>("PlanId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PlanID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PlanId"), 1L, 1);

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int?>("ExpectedAmount")
                        .HasColumnType("int");

                    b.Property<double?>("ExpectedTotalCost")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("Rhid")
                        .HasColumnType("int")
                        .HasColumnName("RHID");

                    b.Property<bool?>("Status")
                        .HasColumnType("bit");

                    b.HasKey("PlanId");

                    b.HasIndex("Rhid");

                    b.ToTable("Plan", (string)null);
                });

            modelBuilder.Entity("SWP391_HealthCareProject.Models.Post", b =>
                {
                    b.Property<int>("PostId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PostID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PostId"), 1L, 1);

                    b.Property<int?>("CampaignId")
                        .HasColumnType("int")
                        .HasColumnName("CampaignID");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Img")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("Rhaid")
                        .HasColumnType("int")
                        .HasColumnName("RHAID");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.HasKey("PostId");

                    b.HasIndex("CampaignId");

                    b.HasIndex("Rhaid");

                    b.ToTable("Post", (string)null);
                });

            modelBuilder.Entity("SWP391_HealthCareProject.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("UserID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<string>("Avatar")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("UserId");

                    b.HasIndex(new[] { "UserName" }, "UQ__User__C9F284567CE8C0A8")
                        .IsUnique();

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("SWP391_HealthCareProject.Models.Volunteer", b =>
                {
                    b.Property<int>("VolunteerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("VolunteerID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VolunteerId"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("Attended")
                        .HasColumnType("int");

                    b.Property<string>("BloodType")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime>("Dob")
                        .HasColumnType("date")
                        .HasColumnName("DOB");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<bool>("Gender")
                        .HasColumnType("bit");

                    b.Property<string>("IdCardNumber")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("ID_CardNumber");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("UserID");

                    b.HasKey("VolunteerId");

                    b.HasIndex("UserId");

                    b.ToTable("Volunteer", (string)null);
                });

            modelBuilder.Entity("SWP391_HealthCareProject.Models.Campaign", b =>
                {
                    b.HasOne("SWP391_HealthCareProject.Models.Plan", "Plan")
                        .WithMany("Campaigns")
                        .HasForeignKey("PlanId")
                        .IsRequired()
                        .HasConstraintName("FK_CampaignPlan");

                    b.Navigation("Plan");
                });

            modelBuilder.Entity("SWP391_HealthCareProject.Models.CampaignLocation", b =>
                {
                    b.HasOne("SWP391_HealthCareProject.Models.Campaign", "Campaign")
                        .WithMany("CampaignLocations")
                        .HasForeignKey("CampaignId")
                        .IsRequired()
                        .HasConstraintName("FK_CLCampaign");

                    b.Navigation("Campaign");
                });

            modelBuilder.Entity("SWP391_HealthCareProject.Models.HospitalRedCrossAdmin", b =>
                {
                    b.HasOne("SWP391_HealthCareProject.Models.HospitalRedCross", "Rh")
                        .WithMany("HospitalRedCrossAdmins")
                        .HasForeignKey("Rhid")
                        .IsRequired()
                        .HasConstraintName("FK_RHA_RH");

                    b.HasOne("SWP391_HealthCareProject.Models.User", "User")
                        .WithMany("HospitalRedCrossAdmins")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK_RHAUser");

                    b.Navigation("Rh");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SWP391_HealthCareProject.Models.Participate", b =>
                {
                    b.HasOne("SWP391_HealthCareProject.Models.Campaign", "Campaign")
                        .WithMany()
                        .HasForeignKey("CampaignId")
                        .IsRequired()
                        .HasConstraintName("FK_Parti_Campaign");

                    b.HasOne("SWP391_HealthCareProject.Models.Volunteer", "Volunteer")
                        .WithMany()
                        .HasForeignKey("VolunteerId")
                        .IsRequired()
                        .HasConstraintName("FK_Parti_Vol");

                    b.Navigation("Campaign");

                    b.Navigation("Volunteer");
                });

            modelBuilder.Entity("SWP391_HealthCareProject.Models.Plan", b =>
                {
                    b.HasOne("SWP391_HealthCareProject.Models.HospitalRedCross", "Rh")
                        .WithMany("Plans")
                        .HasForeignKey("Rhid")
                        .IsRequired()
                        .HasConstraintName("FK_PlanRH");

                    b.Navigation("Rh");
                });

            modelBuilder.Entity("SWP391_HealthCareProject.Models.Post", b =>
                {
                    b.HasOne("SWP391_HealthCareProject.Models.Campaign", "Campaign")
                        .WithMany("Posts")
                        .HasForeignKey("CampaignId")
                        .HasConstraintName("FK_PostCampaign");

                    b.HasOne("SWP391_HealthCareProject.Models.HospitalRedCrossAdmin", "Rha")
                        .WithMany("Posts")
                        .HasForeignKey("Rhaid")
                        .IsRequired()
                        .HasConstraintName("FK_PostRHA");

                    b.Navigation("Campaign");

                    b.Navigation("Rha");
                });

            modelBuilder.Entity("SWP391_HealthCareProject.Models.Volunteer", b =>
                {
                    b.HasOne("SWP391_HealthCareProject.Models.User", "User")
                        .WithMany("Volunteers")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK_VolunteerUser");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SWP391_HealthCareProject.Models.Campaign", b =>
                {
                    b.Navigation("CampaignLocations");

                    b.Navigation("Posts");
                });

            modelBuilder.Entity("SWP391_HealthCareProject.Models.HospitalRedCross", b =>
                {
                    b.Navigation("HospitalRedCrossAdmins");

                    b.Navigation("Plans");
                });

            modelBuilder.Entity("SWP391_HealthCareProject.Models.HospitalRedCrossAdmin", b =>
                {
                    b.Navigation("Posts");
                });

            modelBuilder.Entity("SWP391_HealthCareProject.Models.Plan", b =>
                {
                    b.Navigation("Campaigns");
                });

            modelBuilder.Entity("SWP391_HealthCareProject.Models.User", b =>
                {
                    b.Navigation("HospitalRedCrossAdmins");

                    b.Navigation("Volunteers");
                });
#pragma warning restore 612, 618
        }
    }
}
