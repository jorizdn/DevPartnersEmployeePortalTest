using System;
using System.Collections.Generic;

namespace DPEP.Common.DAL.Entities
{
    public partial class AspNetUserLogin
    {
        public int AspNetUserId { get; set; }
        public string LoginProvider { get; set; }
        public string ProvideKey { get; set; }
        public string ProviderDisplayName { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }
    }
}
