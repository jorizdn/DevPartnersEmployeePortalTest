using System;
using System.Collections.Generic;
using System.Text;

namespace DPEP.Common.DAL.Model
{
    public class AppSettingModel
    {
        public string DirectoryPath { get; set; }
        public string ApiKey { get; set; }


        public string SenderEmail { get; set; }
        public string Password { get; set; }
        public string CaptchaSecretKey { get; set; }
        public string CaptchaUri { get; set; }
        public string PipeDriveToken { get; set; }
        public string PipeDriveUri { get; set; }
        public int PipeDriveDealPrivacy { get; set; }
    }
}
