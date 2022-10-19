using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SWP391_HealthCareProject.Models
{
    public partial class BloodDonorContext : DbContext
    {
        public BloodDonorContext()
        {
        }

        public BloodDonorContext(DbContextOptions<BloodDonorContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Campaign> Campaigns { get; set; } = null!;
        public virtual DbSet<CampaignLocation> CampaignLocations { get; set; } = null!;
        public virtual DbSet<HospitalRedCross> HospitalRedCrosses { get; set; } = null!;
        public virtual DbSet<HospitalRedCrossAdmin> HospitalRedCrossAdmins { get; set; } = null!;
        public virtual DbSet<Participate> Participates { get; set; } = null!;
        public virtual DbSet<Plan> Plans { get; set; } = null!;
        public virtual DbSet<Post> Posts { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<Volunteer> Volunteers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(local);Database=BloodDonor;user=sa;pwd=12345");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Campaign>(entity =>
            {
                entity.ToTable("Campaign");

                entity.Property(e => e.CampaignId).HasColumnName("CampaignID");

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.PlanId).HasColumnName("PlanID");

                entity.Property(e => e.Province).HasMaxLength(255);

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.HasOne(d => d.Plan)
                    .WithMany(p => p.Campaigns)
                    .HasForeignKey(d => d.PlanId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CampaignPlan");
            });

            modelBuilder.Entity<CampaignLocation>(entity =>
            {
                entity.ToTable("CampaignLocation");

                entity.Property(e => e.CampaignLocationId).HasColumnName("CampaignLocationID");

                entity.Property(e => e.CampaignId).HasColumnName("CampaignID");

                entity.Property(e => e.Location).HasMaxLength(255);

                entity.HasOne(d => d.Campaign)
                    .WithMany(p => p.CampaignLocations)
                    .HasForeignKey(d => d.CampaignId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CLCampaign");
            });

            modelBuilder.Entity<HospitalRedCross>(entity =>
            {
                entity.HasKey(e => e.Rhid)
                    .HasName("PK__Hospital__5A84283B73FA5B75");

                entity.ToTable("Hospital_RedCross");

                entity.Property(e => e.Rhid).HasColumnName("RHID");

                entity.Property(e => e.Address).HasMaxLength(255);

                entity.Property(e => e.Email).HasMaxLength(255);

                entity.Property(e => e.Name).HasMaxLength(255);
            });

            modelBuilder.Entity<HospitalRedCrossAdmin>(entity =>
            {
                entity.HasKey(e => e.Rhaid)
                    .HasName("PK__Hospital__D0F38005D97EBBBF");

                entity.ToTable("HospitalRedCrossAdmin");

                entity.Property(e => e.Rhaid).HasColumnName("RHAID");

                entity.Property(e => e.FirstName).HasMaxLength(255);

                entity.Property(e => e.LastName).HasMaxLength(255);

                entity.Property(e => e.License).HasMaxLength(255);

                entity.Property(e => e.Rhid).HasColumnName("RHID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Rh)
                    .WithMany(p => p.HospitalRedCrossAdmins)
                    .HasForeignKey(d => d.Rhid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RHA_RH");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.HospitalRedCrossAdmins)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RHAUser");
            });

            modelBuilder.Entity<Participate>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.CampaignId).HasColumnName("CampaignID");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Location).HasMaxLength(255);

                entity.Property(e => e.RegisteredDate).HasColumnType("date");

                entity.Property(e => e.VolunteerId).HasColumnName("VolunteerID");

                entity.HasOne(d => d.Campaign)
                    .WithMany()
                    .HasForeignKey(d => d.CampaignId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Parti_Campaign");

                entity.HasOne(d => d.Volunteer)
                    .WithMany()
                    .HasForeignKey(d => d.VolunteerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Parti_Vol");
            });

            modelBuilder.Entity<Plan>(entity =>
            {
                entity.ToTable("Plan");

                entity.Property(e => e.PlanId).HasColumnName("PlanID");

                entity.Property(e => e.Description).HasMaxLength(255);

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.Rhid).HasColumnName("RHID");

                entity.HasOne(d => d.Rh)
                    .WithMany(p => p.Plans)
                    .HasForeignKey(d => d.Rhid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PlanRH");
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.ToTable("Post");

                entity.Property(e => e.PostId).HasColumnName("PostID");

                entity.Property(e => e.CampaignId).HasColumnName("CampaignID");

                entity.Property(e => e.Img).HasMaxLength(255);

                entity.Property(e => e.Rhaid).HasColumnName("RHAID");

                entity.Property(e => e.Title).HasMaxLength(1000);

                entity.HasOne(d => d.Campaign)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.CampaignId)
                    .HasConstraintName("FK_PostCampaign");

                entity.HasOne(d => d.Rha)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.Rhaid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PostRHA");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.HasIndex(e => e.UserName, "UQ__User__C9F284567CE8C0A8")
                    .IsUnique();

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.Avatar).HasMaxLength(255);

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.Email).HasMaxLength(255);

                entity.Property(e => e.Password).HasMaxLength(255);

                entity.Property(e => e.UserName).HasMaxLength(255);
            });

            modelBuilder.Entity<Volunteer>(entity =>
            {
                entity.ToTable("Volunteer");

                entity.Property(e => e.VolunteerId).HasColumnName("VolunteerID");

                entity.Property(e => e.Address).HasMaxLength(255);

                entity.Property(e => e.BloodType).HasMaxLength(50);

                entity.Property(e => e.City).HasMaxLength(255);

                entity.Property(e => e.Dob)
                    .HasColumnType("date")
                    .HasColumnName("DOB");

                entity.Property(e => e.FirstName).HasMaxLength(255);

                entity.Property(e => e.IdCardNumber)
                    .HasMaxLength(255)
                    .HasColumnName("ID_CardNumber");

                entity.Property(e => e.LastName).HasMaxLength(255);

                entity.Property(e => e.Phone).HasMaxLength(255);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Volunteers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VolunteerUser");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
