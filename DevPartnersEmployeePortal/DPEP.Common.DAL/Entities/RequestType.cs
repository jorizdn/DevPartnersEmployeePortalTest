using System;
using System.Collections.Generic;

namespace DPEP.Common.DAL.Entities
{
    public partial class RequestType
    {
        public RequestType()
        {
            Response = new HashSet<Response>();
        }

        public int RequestTypeId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Response> Response { get; set; }
    }
}
