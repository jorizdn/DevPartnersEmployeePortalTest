using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DPEP.Common.DAL.Identity
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>(entity => {
                entity.ToTable("AspNetUser");
                entity.Property(e => e.Id).HasColumnName("AspNetUserId");
            });

            builder.Entity<ApplicationUser>(entity => {
                entity.ToTable("AspNetUser");
                entity.Property(e => e.Id).HasColumnName("AspNetUserId");
            });

            builder.Entity<IdentityRole<int>>(entity => {
                entity.ToTable("AspNetRole");
                entity.Property(e => e.Id).HasColumnName("AspNetRoleId");

            });

            builder.Entity<IdentityUserClaim<int>>(entity => {
                entity.ToTable("AspNetUserClaim");
                entity.Property(e => e.UserId).HasColumnName("AspNetUserId");
                entity.Property(e => e.Id).HasColumnName("AspNetUserClaimId");

            });

            builder.Entity<IdentityUserLogin<int>>(entity => {
                entity.ToTable("AspNetUserLogin");
                entity.Property(e => e.UserId).HasColumnName("AspNetUserId");

            });

            builder.Entity<IdentityRoleClaim<int>>(entity => {
                entity.ToTable("AspNetRoleClaim");
                entity.Property(e => e.Id).HasColumnName("AspNetRoleClaimId");
                entity.Property(e => e.RoleId).HasColumnName("AspNetRoleId");
            });

            builder.Entity<IdentityUserRole<int>>(entity => {
                entity.ToTable("AspNetUserRole");
                entity.Property(e => e.UserId).HasColumnName("AspNetUserId");
                entity.Property(e => e.RoleId).HasColumnName("AspNetRoleId");

            });

            builder.Entity<IdentityUserToken<int>>(entity => {
                entity.ToTable("AspNetUserToken");
                entity.Property(e => e.UserId).HasColumnName("AspNetUserId");

            });
        }
    }
}