using System;
using System.Collections.Generic;

namespace DPEP.Common.DAL.Entities
{
    public partial class AspNetUserClaim
    {
        public int AspNetUserClaimId { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }
        public int? AspNetUserId { get; set; }

        public virtual AspNetUser AspNetUserClaimNavigation { get; set; }
    }
}
