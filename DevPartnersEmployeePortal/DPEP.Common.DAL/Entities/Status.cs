using System;
using System.Collections.Generic;

namespace DPEP.Common.DAL.Entities
{
    public partial class Status
    {
        public Status()
        {
            Response = new HashSet<Response>();
        }

        public int StatusId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Response> Response { get; set; }
    }
}
