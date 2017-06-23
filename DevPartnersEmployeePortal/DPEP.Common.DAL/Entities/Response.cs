using System;
using System.Collections.Generic;

namespace DPEP.Common.DAL.Entities
{
    public partial class Response
    {
        public Response()
        {
            Leave = new HashSet<Leave>();
            OverTime = new HashSet<OverTime>();
            WorkHome = new HashSet<WorkHome>();
        }

        public int ResponseId { get; set; }
        public int? RequestTypeId { get; set; }
        public int? StatusId { get; set; }
        public string Message { get; set; }
        public DateTime? DateCreated { get; set; }

        public virtual ICollection<Leave> Leave { get; set; }
        public virtual ICollection<OverTime> OverTime { get; set; }
        public virtual ICollection<WorkHome> WorkHome { get; set; }
        public virtual RequestType RequestType { get; set; }
        public virtual Status Status { get; set; }
    }
}
