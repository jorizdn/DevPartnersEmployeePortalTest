using Microsoft.AspNetCore.Hosting;

namespace DPEP.Common.BLL.Helpers {
    public static class PathHelper {
        public static string GetParentFolder(IHostingEnvironment env) {

            var parentfolder = env.ContentRootPath.Replace(env.ApplicationName, "DPEP.Common.DAL");

            return parentfolder;
        }
    }
}