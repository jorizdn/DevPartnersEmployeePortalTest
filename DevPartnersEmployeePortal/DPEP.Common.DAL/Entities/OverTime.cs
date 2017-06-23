using System;
using System.Collections.Generic;

namespace DPEP.Common.DAL.Entities
{
    public partial class OverTime
    {
        public OverTime()
        {
            Report = new HashSet<Report>();
        }

        public int OverTimeId { get; set; }
        public int? UserId { get; set; }
        public int? ResponseId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Reason { get; set; }
        public DateTime? DateCreated { get; set; }

        public virtual ICollection<Report> Report { get; set; }
        public virtual Response Response { get; set; }
        public virtual AspNetUser User { get; set; }
    }
}
