using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Job.Models;

public partial class JobDbContext : DbContext
{
    public JobDbContext()
    {
    }

    public JobDbContext(DbContextOptions<JobDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TApplication> TApplications { get; set; }

    public virtual DbSet<TCompanyProfile> TCompanyProfiles { get; set; }

    public virtual DbSet<TCompanyVerification> TCompanyVerifications { get; set; }

    public virtual DbSet<TJobPosting> TJobPostings { get; set; }

    public virtual DbSet<TJobPostingDetail> TJobPostingDetails { get; set; }

    public virtual DbSet<TJobPostingStatus> TJobPostingStatuses { get; set; }

    public virtual DbSet<TManager> TManagers { get; set; }

    public virtual DbSet<TMember> TMembers { get; set; }

    public virtual DbSet<TMemberComment> TMemberComments { get; set; }

    public virtual DbSet<TMemberProfile> TMemberProfiles { get; set; }

    public virtual DbSet<TOwnerAdmission> TOwnerAdmissions { get; set; }

    public virtual DbSet<TPermission> TPermissions { get; set; }

    public virtual DbSet<TPreferredLocation> TPreferredLocations { get; set; }

    public virtual DbSet<TResumeTemplate> TResumeTemplates { get; set; }

    public virtual DbSet<TUserManagerMent> TUserManagerMents { get; set; }

    public virtual DbSet<TUserRecord> TUserRecords { get; set; }

    public virtual DbSet<TWorkerApply> TWorkerApplies { get; set; }

    public virtual DbSet<TWorkerProfile> TWorkerProfiles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=JobDB;Integrated Security=True;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TApplication>(entity =>
        {
            entity.HasKey(e => e.ApplicationId).HasName("PK__tApplica__C93A4C99160CD11D");

            entity.ToTable("tApplications");

            entity.Property(e => e.AppliedAt).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.CoverLetter).HasMaxLength(500);
            entity.Property(e => e.SpecialRequirements).HasMaxLength(500);
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasDefaultValue("pending");
        });

        modelBuilder.Entity<TCompanyProfile>(entity =>
        {
            entity.HasKey(e => e.ProfileId);

            entity.ToTable("tCompanyProfiles");

            entity.Property(e => e.ProfileId).HasColumnName("profileId");
            entity.Property(e => e.Address).HasColumnName("address");
            entity.Property(e => e.Fb).HasColumnName("FB");
            entity.Property(e => e.Ig).HasColumnName("IG");
            entity.Property(e => e.Intro).HasColumnName("intro");
            entity.Property(e => e.MemberId).HasColumnName("memberId");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Phone)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("phone");
            entity.Property(e => e.ProfilePicture).HasColumnName("profilePicture");
            entity.Property(e => e.Type)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("type");
            entity.Property(e => e.Website).HasColumnName("website");
        });

        modelBuilder.Entity<TCompanyVerification>(entity =>
        {
            entity.HasKey(e => e.VerificationId);

            entity.ToTable("tCompanyVerifications");

            entity.Property(e => e.VerificationId).HasColumnName("verificationId");
            entity.Property(e => e.ApprovedAt)
                .HasColumnType("datetime")
                .HasColumnName("approvedAt");
            entity.Property(e => e.BusinessRegNo)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("businessRegNo");
            entity.Property(e => e.CompanyLicenseImage)
                .HasMaxLength(300)
                .HasColumnName("companyLicenseImage");
            entity.Property(e => e.EstablishedDate).HasColumnName("establishedDate");
            entity.Property(e => e.MemberId).HasColumnName("memberId");
            entity.Property(e => e.OwnerName)
                .HasMaxLength(80)
                .HasColumnName("ownerName");
            entity.Property(e => e.RegisteredAddress)
                .HasMaxLength(250)
                .HasColumnName("registeredAddress");
            entity.Property(e => e.RegisteredName)
                .HasMaxLength(150)
                .HasColumnName("registeredName");
            entity.Property(e => e.SubmittedAt)
                .HasColumnType("datetime")
                .HasColumnName("submittedAt");
        });

        modelBuilder.Entity<TJobPosting>(entity =>
        {
            entity.HasKey(e => e.PostingId).HasName("PK_JobPostings");

            entity.ToTable("tJobPostings");

            entity.Property(e => e.PostingId).HasColumnName("postingId");
            entity.Property(e => e.ApplicationDeadline)
                .HasColumnType("datetime")
                .HasColumnName("applicationDeadline");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.PostTitle)
                .HasMaxLength(20)
                .HasColumnName("postTitle");
            entity.Property(e => e.PublishEndDate)
                .HasColumnType("datetime")
                .HasColumnName("publishEndDate");
            entity.Property(e => e.PublishStartDate)
                .HasColumnType("datetime")
                .HasColumnName("publishStartDate");
            entity.Property(e => e.StatusId).HasColumnName("statusId");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updatedAt");
            entity.Property(e => e.UserId).HasColumnName("userId");
        });

        modelBuilder.Entity<TJobPostingDetail>(entity =>
        {
            entity.HasKey(e => e.DetailId).HasName("PK_JobPostingDetails");

            entity.ToTable("tJobPostingDetails");

            entity.Property(e => e.DetailId).HasColumnName("detailId");
            entity.Property(e => e.BenefitsTags).HasColumnName("benefitsTags");
            entity.Property(e => e.BenefitsText).HasColumnName("benefitsText");
            entity.Property(e => e.CoverImage)
                .HasMaxLength(255)
                .HasColumnName("coverImage");
            entity.Property(e => e.DayOff)
                .HasMaxLength(100)
                .HasColumnName("dayOff");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.EndDate)
                .HasColumnType("datetime")
                .HasColumnName("endDate");
            entity.Property(e => e.EnvironmentImage).HasColumnName("environmentImage");
            entity.Property(e => e.Notice).HasColumnName("notice");
            entity.Property(e => e.PeopleRequired).HasColumnName("peopleRequired");
            entity.Property(e => e.PostingId).HasColumnName("postingId");
            entity.Property(e => e.RequiredExperience).HasColumnName("requiredExperience");
            entity.Property(e => e.RequiredLincenses).HasColumnName("requiredLincenses");
            entity.Property(e => e.RequiredSkills).HasColumnName("requiredSkills");
            entity.Property(e => e.StartDate)
                .HasColumnType("datetime")
                .HasColumnName("startDate");
            entity.Property(e => e.WorkingHours)
                .HasMaxLength(100)
                .HasColumnName("workingHours");
        });

        modelBuilder.Entity<TJobPostingStatus>(entity =>
        {
            entity.HasKey(e => e.StatusId).HasName("PK_JobPostingStatus");

            entity.ToTable("tJobPostingStatus");

            entity.Property(e => e.StatusId)
                .ValueGeneratedNever()
                .HasColumnName("statusId");
            entity.Property(e => e.StatusName)
                .HasMaxLength(50)
                .HasColumnName("statusName");
        });

        modelBuilder.Entity<TManager>(entity =>
        {
            entity.HasKey(e => e.ManagerId).HasName("PK_Manager");

            entity.ToTable("tManager");

            entity.Property(e => e.ManagerId).HasColumnName("ManagerID");
            entity.Property(e => e.Account).HasMaxLength(50);
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.EmailConfirmed).HasDefaultValue(false);
            entity.Property(e => e.ManagerName).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.PermissionId).HasColumnName("PermissionID");
            entity.Property(e => e.PermissionName).HasMaxLength(50);
        });

        modelBuilder.Entity<TMember>(entity =>
        {
            entity.HasKey(e => e.MemberId).HasName("PK_Members");

            entity.ToTable("tMembers");

            entity.Property(e => e.MemberId).HasColumnName("MemberID");
            entity.Property(e => e.Account)
                .HasMaxLength(10)
                .HasColumnName("account");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Password)
                .HasMaxLength(20)
                .HasColumnName("password");
            entity.Property(e => e.PermissionId).HasColumnName("PermissionID");
            entity.Property(e => e.PermissionName).HasMaxLength(50);
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("phone");
        });

        modelBuilder.Entity<TMemberComment>(entity =>
        {
            entity.HasKey(e => e.CommentId).HasName("PK_MemberComments");

            entity.ToTable("tMemberComments");

            entity.Property(e => e.MemberName).HasMaxLength(50);
            entity.Property(e => e.UserName).HasMaxLength(50);
        });

        modelBuilder.Entity<TMemberProfile>(entity =>
        {
            entity.HasKey(e => e.ProfileId).HasName("PK__tMemberP__290C88E4175B8850");

            entity.ToTable("tMemberProfiles");

            entity.Property(e => e.ContactIg)
                .HasMaxLength(100)
                .HasColumnName("ContactIG");
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.Education).HasMaxLength(200);
            entity.Property(e => e.ExpectedBenefits).HasMaxLength(200);
            entity.Property(e => e.Languages).HasMaxLength(200);
            entity.Property(e => e.Licenses).HasMaxLength(200);
            entity.Property(e => e.Motivation).HasMaxLength(1000);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.PreferredCategories).HasMaxLength(200);
            entity.Property(e => e.ProfilePicture).HasMaxLength(255);
            entity.Property(e => e.Sex).HasMaxLength(30);
            entity.Property(e => e.WorkExperience).HasMaxLength(400);
        });

        modelBuilder.Entity<TOwnerAdmission>(entity =>
        {
            entity.HasKey(e => e.OwnerAdmissionId).HasName("PK__OwnerAdm__8F9E6A73349F520B");

            entity.ToTable("tOwnerAdmission");

            entity.Property(e => e.OwnerAdmissionId).HasColumnName("ownerAdmissionId");
            entity.Property(e => e.AdmissionDate)
                .HasColumnType("datetime")
                .HasColumnName("admissionDate");
            entity.Property(e => e.AdmissionPosition)
                .HasMaxLength(50)
                .HasColumnName("admissionPosition");
            entity.Property(e => e.ApplyOwner)
                .HasMaxLength(50)
                .HasColumnName("applyOwner");
            entity.Property(e => e.MemberId).HasColumnName("memberId");
            entity.Property(e => e.ReplySituation)
                .HasMaxLength(50)
                .HasColumnName("replySituation");
            entity.Property(e => e.WorkEndDate)
                .HasColumnType("datetime")
                .HasColumnName("workEndDate");
            entity.Property(e => e.WorkStartDate)
                .HasColumnType("datetime")
                .HasColumnName("workStartDate");
            entity.Property(e => e.WorkerName)
                .HasMaxLength(50)
                .HasColumnName("workerName");
        });

        modelBuilder.Entity<TPermission>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tPermission");

            entity.Property(e => e.MemberId).HasColumnName("MemberID");
            entity.Property(e => e.PermissionId).HasColumnName("PermissionID");
            entity.Property(e => e.PermissionName).HasMaxLength(50);
        });

        modelBuilder.Entity<TPreferredLocation>(entity =>
        {
            entity.HasKey(e => e.LocationId).HasName("PK__tPreferr__E7FEA497C0ACBEE9");

            entity.ToTable("tPreferredLocations");
        });

        modelBuilder.Entity<TResumeTemplate>(entity =>
        {
            entity.HasKey(e => e.TemplateId).HasName("PK__tResume___F87ADD27B198DDE0");

            entity.ToTable("tResume_Templates");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.TemplateName).HasMaxLength(100);
            entity.Property(e => e.TemplateTitle).HasMaxLength(100);
        });

        modelBuilder.Entity<TUserManagerMent>(entity =>
        {
            entity.HasKey(e => e.ManagerMentId).HasName("PK_UserManagerMents");

            entity.ToTable("tUserManagerMents");

            entity.Property(e => e.ManagerMentId).HasColumnName("ManagerMentID");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.HonorTitle).HasMaxLength(50);
            entity.Property(e => e.MemberId).HasColumnName("MemberID");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.PermissionId).HasColumnName("PermissionID");
            entity.Property(e => e.Points).HasColumnName("points");
            entity.Property(e => e.UserRecordId).HasColumnName("UserRecordID");
        });

        modelBuilder.Entity<TUserRecord>(entity =>
        {
            entity.HasKey(e => e.UserRecordId).HasName("PK_UserRecords");

            entity.ToTable("tUserRecords");

            entity.Property(e => e.UserRecordId).HasColumnName("UserRecordID");
            entity.Property(e => e.ApplicationRecord).HasMaxLength(50);
            entity.Property(e => e.LoginIprecord)
                .HasMaxLength(50)
                .HasColumnName("LoginIPRecord");
            entity.Property(e => e.MemberId).HasColumnName("MemberID");
        });

        modelBuilder.Entity<TWorkerApply>(entity =>
        {
            entity.HasKey(e => e.WorkerApplyId).HasName("PK__WorkerAp__455F82BD6B4515D0");

            entity.ToTable("tWorkerApply");

            entity.Property(e => e.WorkerApplyId).HasColumnName("workerApplyId");
            entity.Property(e => e.ApplyDate)
                .HasColumnType("datetime")
                .HasColumnName("applyDate");
            entity.Property(e => e.ApplyOwner)
                .HasMaxLength(50)
                .HasColumnName("applyOwner");
            entity.Property(e => e.ApplyPosition)
                .HasMaxLength(50)
                .HasColumnName("applyPosition");
            entity.Property(e => e.ApplySituation)
                .HasMaxLength(50)
                .HasColumnName("applySituation");
            entity.Property(e => e.Introduction).HasMaxLength(500);
            entity.Property(e => e.MemberId).HasColumnName("memberId");
            entity.Property(e => e.SnapShotId).HasColumnName("snapShotId");
            entity.Property(e => e.WorkerName)
                .HasMaxLength(50)
                .HasColumnName("workerName");
        });

        modelBuilder.Entity<TWorkerProfile>(entity =>
        {
            entity.HasKey(e => e.ProfileId);

            entity.ToTable("tWorkerProfiles");

            entity.Property(e => e.ProfileId).HasColumnName("profileId");
            entity.Property(e => e.BirthDate).HasColumnName("birthDate");
            entity.Property(e => e.GenderCode)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("genderCode");
            entity.Property(e => e.MemberId).HasColumnName("memberId");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Phone)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("phone");
            entity.Property(e => e.ProfilePicture)
                .HasMaxLength(255)
                .HasColumnName("profilePicture");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
