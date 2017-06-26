using System;
using System.Collections.Generic;
using System.Text;

namespace DPEP.Common.DAL.Model
{
    public class AddEmployeeModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string employeeID { get; set; }
        public string emailAddress { get; set; }
    }
}
