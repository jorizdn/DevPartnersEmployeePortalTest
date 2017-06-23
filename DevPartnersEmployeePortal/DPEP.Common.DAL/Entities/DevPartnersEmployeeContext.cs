using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DPEP.Common.DAL.Entities
{
    public partial class DevPartnersEmployeeContext : DbContext
    {
        public virtual DbSet<AspNetRole> AspNetRole { get; set; }
        public virtual DbSet<AspNetRoleClaim> AspNetRoleClaim { get; set; }
        public virtual DbSet<AspNetUser> AspNetUser { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaim { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogin { get; set; }
        public virtual DbSet<AspNetUserRole> AspNetUserRole { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<ErrorLogs> ErrorLogs { get; set; }
        public virtual DbSet<FeedBack> FeedBack { get; set; }
        public virtual DbSet<FlagActions> FlagActions { get; set; }
        public virtual DbSet<JobType> JobType { get; set; }
        public virtual DbSet<Leave> Leave { get; set; }
        public virtual DbSet<OverTime> OverTime { get; set; }
        public virtual DbSet<Position> Position { get; set; }
        public virtual DbSet<Report> Report { get; set; }
        public virtual DbSet<RequestType> RequestType { get; set; }
        public virtual DbSet<Response> Response { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<Type> Type { get; set; }
        public virtual DbSet<UserStatus> UserStatus { get; set; }
        public virtual DbSet<UserType> UserType { get; set; }
        public virtual DbSet<WorkHome> WorkHome { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
        //    optionsBuilder.UseSqlServer(@"Data Source=devpartnersapi.cx49u7twr7h1.ap-northeast-2.rds.amazonaws.com;Integrated Security=False;User ID=sa;Password=1C1RLNS_enPH730PH730;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False; Database = DevPartnersEmployee;");
        //}

        public DevPartnersEmployeeContext(DbContextOptions<DevPartnersEmployeeContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRole>(entity =>
            {
                entity.Property(e => e.ConcurrencyStamp).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.NormalizedName).HasMaxLength(50);
            });

            modelBuilder.Entity<AspNetRoleClaim>(entity =>
            {
                entity.Property(e => e.AspNetRoleClaimId).ValueGeneratedNever();

                entity.Property(e => e.ClaimType).HasMaxLength(50);

                entity.Property(e => e.ClaimValue).HasMaxLength(50);

                entity.HasOne(d => d.AspNetRole)
                    .WithMany(p => p.AspNetRoleClaim)
                    .HasForeignKey(d => d.AspNetRoleId)
                    .HasConstraintName("FK_AspNetRoleClaim_AspNetRole");
            });

            modelBuilder.Entity<AspNetUser>(entity =>
            {
                entity.Property(e => e.AspNetUserId).HasColumnName("AspNetUserID");

                entity.Property(e => e.BirthDate).HasColumnType("date");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.JobTypeId).HasColumnName("JobTypeID");

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.PositionId).HasColumnName("PositionID");

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.UserName).HasMaxLength(50);

                entity.Property(e => e.UserStatusId).HasColumnName("UserStatusID");
            });

            modelBuilder.Entity<AspNetUserClaim>(entity =>
            {
                entity.Property(e => e.AspNetUserClaimId).ValueGeneratedNever();

                entity.Property(e => e.ClaimType).HasMaxLength(50);

                entity.Property(e => e.ClaimValue).HasMaxLength(50);

                entity.HasOne(d => d.AspNetUserClaimNavigation)
                    .WithOne(p => p.AspNetUserClaim)
                    .HasForeignKey<AspNetUserClaim>(d => d.AspNetUserClaimId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_AspNetUserClaim_AspNetUser");
            });

            modelBuilder.Entity<AspNetUserLogin>(entity =>
            {
                entity.HasKey(e => e.AspNetUserId)
                    .HasName("PK_AspNetUserLogin");

                entity.Property(e => e.AspNetUserId).ValueGeneratedOnAdd();

                entity.Property(e => e.LoginProvider).HasMaxLength(50);

                entity.Property(e => e.ProvideKey).HasMaxLength(50);

                entity.Property(e => e.ProviderDisplayName).HasMaxLength(50);

                entity.HasOne(d => d.AspNetUser)
                    .WithOne(p => p.AspNetUserLogin)
                    .HasForeignKey<AspNetUserLogin>(d => d.AspNetUserId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_AspNetUserLogin_AspNetUser");
            });

            modelBuilder.Entity<AspNetUserRole>(entity =>
            {
                entity.HasOne(d => d.AspNetRole)
                    .WithMany(p => p.AspNetUserRole)
                    .HasForeignKey(d => d.AspNetRoleId)
                    .HasConstraintName("FK_AspNetUserRole_AspNetRole");

                entity.HasOne(d => d.AspNetUser)
                    .WithMany(p => p.AspNetUserRole)
                    .HasForeignKey(d => d.AspNetUserId)
                    .HasConstraintName("FK_AspNetUserRole_AspNetUser");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

                entity.Property(e => e.CompanyCode).HasMaxLength(50);

                entity.Property(e => e.EmailAddress).HasMaxLength(50);
            });

            modelBuilder.Entity<ErrorLogs>(entity =>
            {
                entity.HasKey(e => e.ErrorId)
                    .HasName("PK_ErrorLogs");

                entity.Property(e => e.ErrorId).ValueGeneratedNever();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ErrorMessage).HasMaxLength(50);

                entity.Property(e => e.ErrorStack).HasMaxLength(50);
            });

            modelBuilder.Entity<FeedBack>(entity =>
            {
                entity.Property(e => e.FeedBackId).HasColumnName("FeedBackID");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.FlagId).HasColumnName("FlagID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.UserTypeId).HasColumnName("UserTypeID");

                entity.HasOne(d => d.Flag)
                    .WithMany(p => p.FeedBack)
                    .HasForeignKey(d => d.FlagId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_FeedBack_FlagActions");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.FeedBack)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_FeedBack_User");

                entity.HasOne(d => d.UserType)
                    .WithMany(p => p.FeedBack)
                    .HasForeignKey(d => d.UserTypeId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_FeedBack_UserType");
            });

            modelBuilder.Entity<FlagActions>(entity =>
            {
                entity.HasKey(e => e.FlagId)
                    .HasName("PK_FlagActions");

                entity.Property(e => e.FlagId).HasColumnName("FlagID");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<JobType>(entity =>
            {
                entity.Property(e => e.JobTypeId).HasColumnName("JobTypeID");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Leave>(entity =>
            {
                entity.Property(e => e.LeaveId).HasColumnName("LeaveID");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.ResponseId).HasColumnName("ResponseID");

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.Property(e => e.TypeId).HasColumnName("TypeID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Response)
                    .WithMany(p => p.Leave)
                    .HasForeignKey(d => d.ResponseId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Leave_Response");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Leave)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Leave_Type");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Leave)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Leave_User");
            });

            modelBuilder.Entity<OverTime>(entity =>
            {
                entity.Property(e => e.OverTimeId).HasColumnName("OverTimeID");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.ResponseId).HasColumnName("ResponseID");

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Response)
                    .WithMany(p => p.OverTime)
                    .HasForeignKey(d => d.ResponseId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_OverTime_Response");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.OverTime)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_OverTime_User");
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity.Property(e => e.PositionId).HasColumnName("PositionID");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Report>(entity =>
            {
                entity.Property(e => e.ReportId).HasColumnName("ReportID");

                entity.Property(e => e.CurrrentDate).HasColumnType("date");

                entity.Property(e => e.EndHour).HasColumnType("datetime");

                entity.Property(e => e.OverTimeId).HasColumnName("OverTimeID");

                entity.Property(e => e.StartHour).HasColumnType("datetime");

                entity.HasOne(d => d.OverTime)
                    .WithMany(p => p.Report)
                    .HasForeignKey(d => d.OverTimeId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Report_OverTime");
            });

            modelBuilder.Entity<RequestType>(entity =>
            {
                entity.Property(e => e.RequestTypeId).HasColumnName("RequestTypeID");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Response>(entity =>
            {
                entity.Property(e => e.ResponseId).HasColumnName("ResponseID");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.Message).HasMaxLength(50);

                entity.Property(e => e.RequestTypeId).HasColumnName("RequestTypeID");

                entity.Property(e => e.StatusId).HasColumnName("StatusID");

                entity.HasOne(d => d.RequestType)
                    .WithMany(p => p.Response)
                    .HasForeignKey(d => d.RequestTypeId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Response_RequestType");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Response)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Response_Status");
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.Property(e => e.StatusId).HasColumnName("StatusID");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Type>(entity =>
            {
                entity.Property(e => e.TypeId).HasColumnName("TypeID");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<UserStatus>(entity =>
            {
                entity.Property(e => e.UserStatusId).HasColumnName("UserStatusID");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<UserType>(entity =>
            {
                entity.Property(e => e.UserTypeId).HasColumnName("UserTypeID");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<WorkHome>(entity =>
            {
                entity.HasKey(e => e.HomeId)
                    .HasName("PK_WorkHome");

                entity.Property(e => e.HomeId).HasColumnName("HomeID");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.ResponseId).HasColumnName("ResponseID");

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Response)
                    .WithMany(p => p.WorkHome)
                    .HasForeignKey(d => d.ResponseId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_WorkHome_Response");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.WorkHome)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_WorkHome_User");
            });
        }
    }
}