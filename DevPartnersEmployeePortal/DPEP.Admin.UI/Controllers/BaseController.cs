using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Principal;

namespace DPEP.Admin.UI.Controllers
{
    public class BaseController : Microsoft.AspNetCore.Mvc.Controller
    {
        private const string Urlhelper = "UrlHelper";
        protected string UserName;
        protected IIdentity UserIdentity;
        public override void OnActionExecuting(ActionExecutingContext context)
        {

            UserName = HttpContext.User.Identity.Name;

            UserIdentity = HttpContext.User.Identity;

            context.HttpContext.Items[Urlhelper] = Url;
        }
    }
}