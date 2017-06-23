using System;
using System.Collections.Generic;

namespace DPEP.Common.DAL.Entities
{
    public partial class Company
    {
        public int CompanyId { get; set; }
        public string CompanyCode { get; set; }
        public string EmailAddress { get; set; }
    }
}
