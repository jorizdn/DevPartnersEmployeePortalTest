using System;
using System.Collections.Generic;

namespace DPEP.Common.DAL.Entities
{
    public partial class Type
    {
        public Type()
        {
            Leave = new HashSet<Leave>();
        }

        public int TypeId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Leave> Leave { get; set; }
    }
}
