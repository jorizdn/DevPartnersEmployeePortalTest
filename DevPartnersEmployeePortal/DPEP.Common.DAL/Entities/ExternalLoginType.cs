using System;
using System.Collections.Generic;

namespace DPEP.Common.DAL.Entities
{
    public partial class ExternalLoginType
    {
        public ExternalLoginType()
        {
            AspNetUser = new HashSet<AspNetUser>();
        }

        public int ExternalLoginTypeId { get; set; }
        public string Name { get; set; }
        public string IsSupported { get; set; }
        public Guid? Guid { get; set; }

        public virtual ICollection<AspNetUser> AspNetUser { get; set; }
    }
}
