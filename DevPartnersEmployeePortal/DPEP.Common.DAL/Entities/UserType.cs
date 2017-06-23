using System;
using System.Collections.Generic;

namespace DPEP.Common.DAL.Entities
{
    public partial class UserType
    {
        public UserType()
        {
            FeedBack = new HashSet<FeedBack>();
        }

        public int UserTypeId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<FeedBack> FeedBack { get; set; }
    }
}
