﻿using Newtonsoft.Json;
using System;

namespace DPEP.Common.DAL.Model
{
    public class UserDetails
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public DateTime? BirthDate { get; set; }
        [JsonProperty(PropertyName = "CompanyId")]
        public string CompanyCode { get; set; }
        public string Position { get; set; }
        public string Category { get; set; }
        public string Gender { get; set; }
        public DateTime? DateCreated { get; set; }
    }
}
