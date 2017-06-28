using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DPEP.Common.BLL.Helpers;
using Microsoft.AspNetCore.Authorization;
using DPEP.Common.BLL.Interfaces;
using DPEP.Common.DAL.Model;

namespace DPEP.Admin.UI.Controllers
{
    [AllowAnonymous]
    [Route("[controller]")]
    public class LoginController : BaseController
    {
        private readonly IAuthenticate _authenticate;
        private readonly ResponseBadRequest _badRequest;
        private readonly CheckForgery _checkForgery;
        public LoginController(IAuthenticate authenticate, CheckForgery checkForgery, ResponseBadRequest badRequest)
        {
            _authenticate = authenticate;
            _checkForgery = checkForgery;
            _badRequest = badRequest;
        }

        [HttpPost]
        public IActionResult Login([FromBody] LoginModel model)
        {
            return Ok();
        }
    }
}