using System;
using System.Collections.Generic;

namespace DPEP.Common.DAL.Entities
{
    public partial class Report
    {
        public int ReportId { get; set; }
        public int? OverTimeId { get; set; }
        public string WorkDone { get; set; }
        public DateTime? StartHour { get; set; }
        public DateTime? EndHour { get; set; }
        public DateTime? CurrrentDate { get; set; }

        public virtual OverTime OverTime { get; set; }
    }
}
