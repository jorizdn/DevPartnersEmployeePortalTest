using System;
using System.Collections.Generic;

namespace DPEP.Common.DAL.Entities
{
    public partial class AspNetUserRole
    {
        public int? AspNetUserId { get; set; }
        public int? AspNetRoleId { get; set; }
        public int AspNetUserRoleId { get; set; }

        public virtual AspNetRole AspNetRole { get; set; }
        public virtual AspNetUser AspNetUser { get; set; }
    }
}
