using System;
using System.Collections.Generic;

namespace DPEP.Common.DAL.Entities
{
    public partial class ErrorLogs
    {
        public int ErrorId { get; set; }
        public string ErrorMessage { get; set; }
        public string ErrorStack { get; set; }
        public DateTime? CreatedDate { get; set; }
        public Guid? Guid { get; set; }
    }
}
