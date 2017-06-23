using System;
using System.Collections.Generic;

namespace DPEP.Common.DAL.Entities
{
    public partial class AspNetRole
    {
        public AspNetRole()
        {
            AspNetRoleClaim = new HashSet<AspNetRoleClaim>();
            AspNetUserRole = new HashSet<AspNetUserRole>();
        }

        public int AspNetRoleId { get; set; }
        public string Name { get; set; }
        public string ConcurrencyStamp { get; set; }
        public string NormalizedName { get; set; }
        public Guid? Guid { get; set; }

        public virtual ICollection<AspNetRoleClaim> AspNetRoleClaim { get; set; }
        public virtual ICollection<AspNetUserRole> AspNetUserRole { get; set; }
    }
}
