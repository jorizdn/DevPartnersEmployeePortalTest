using System;
using System.Collections.Generic;

namespace DPEP.Common.DAL.Entities
{
    public partial class AspNetRoleClaim
    {
        public int AspNetRoleClaimId { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }
        public int? AspNetRoleId { get; set; }

        public virtual AspNetRole AspNetRole { get; set; }
    }
}
