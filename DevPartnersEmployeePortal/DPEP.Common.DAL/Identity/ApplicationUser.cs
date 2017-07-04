using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DPEP.Common.DAL.Identity
{
    public class ApplicationUser : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
        public int CountryId { get; set; }
        public string State { get; set; }
        public string OrganizationName { get; set; }
        public string AppId { get; set; }
        public int? ExternalLoginTypeId { get; set; }
        public int? CategoryId { get; set; }
        public int? PositionId { get; set; }
        public int? JobTypeId { get; set; }
        public string CompanyId { get; set; }
    }
}
