using System;
using System.Collections.Generic;

namespace DPEP.Common.DAL.Entities
{
    public partial class AspNetUser
    {
        public AspNetUser()
        {
            AspNetUserRole = new HashSet<AspNetUserRole>();
            FeedBack = new HashSet<FeedBack>();
            Leave = new HashSet<Leave>();
            OverTime = new HashSet<OverTime>();
            WorkHome = new HashSet<WorkHome>();
        }

        public int AspNetUserId { get; set; }
        public int? PositionId { get; set; }
        public int? RoleId { get; set; }
        public int? CompanyId { get; set; }
        public int? JobTypeId { get; set; }
        public int? CategoryId { get; set; }
        public int? UserStatusId { get; set; }
        public string ProfilePicture { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public DateTime? BirthDate { get; set; }
        public bool? Gender { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime? DateCreated { get; set; }
        public Guid? Guid { get; set; }
        public bool? IsVerified { get; set; }
        public Guid? Passcode { get; set; }

        public virtual AspNetUserClaim AspNetUserClaim { get; set; }
        public virtual AspNetUserLogin AspNetUserLogin { get; set; }
        public virtual ICollection<AspNetUserRole> AspNetUserRole { get; set; }
        public virtual ICollection<FeedBack> FeedBack { get; set; }
        public virtual ICollection<Leave> Leave { get; set; }
        public virtual ICollection<OverTime> OverTime { get; set; }
        public virtual ICollection<WorkHome> WorkHome { get; set; }
    }
}
