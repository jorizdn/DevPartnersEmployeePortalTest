using Newtonsoft.Json;
using System;

namespace DPEP.Common.DAL.Model
{
    public class UserModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        [JsonIgnore]
        public bool EmailConfirmed { get; set; }
    }

    public class UserDetails
    {
        public UserModel User { get; set; }
    }
}
