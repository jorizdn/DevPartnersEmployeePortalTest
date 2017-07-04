using System;
using System.Collections.Generic;
using System.Text;

namespace DPEP.Common.DAL.Model
{
    public class UpdateInfoModel
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }
        public bool Gender { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
