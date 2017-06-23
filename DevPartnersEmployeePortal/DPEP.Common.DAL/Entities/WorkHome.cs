using System;
using System.Collections.Generic;

namespace DPEP.Common.DAL.Entities
{
    public partial class WorkHome
    {
        public int HomeId { get; set; }
        public int? UserId { get; set; }
        public int? ResponseId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Reason { get; set; }
        public DateTime? DateCreated { get; set; }

        public virtual Response Response { get; set; }
        public virtual AspNetUser User { get; set; }
    }
}
