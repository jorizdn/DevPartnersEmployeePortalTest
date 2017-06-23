using System;
using System.Collections.Generic;

namespace DPEP.Common.DAL.Entities
{
    public partial class FlagActions
    {
        public FlagActions()
        {
            FeedBack = new HashSet<FeedBack>();
        }

        public int FlagId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<FeedBack> FeedBack { get; set; }
    }
}
