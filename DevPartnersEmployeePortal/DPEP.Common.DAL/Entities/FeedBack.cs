using System;
using System.Collections.Generic;

namespace DPEP.Common.DAL.Entities
{
    public partial class FeedBack
    {
        public int FeedBackId { get; set; }
        public int? UserId { get; set; }
        public int? UserTypeId { get; set; }
        public int? FlagId { get; set; }
        public string Comment { get; set; }
        public DateTime? DateCreated { get; set; }

        public virtual FlagActions Flag { get; set; }
        public virtual AspNetUser User { get; set; }
        public virtual UserType UserType { get; set; }
    }
}
