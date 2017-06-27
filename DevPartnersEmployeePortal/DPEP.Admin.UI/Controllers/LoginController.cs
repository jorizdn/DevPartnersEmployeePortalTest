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
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {

            try
            {
                //var token = await _checkForgery.CheckToken();

                //if (token != null)
                //{
                //    return token;
                //}

                var user = await _authenticate.LoginThenReturnUser(model);

                if (user != null)
                {
                    if (!user.EmailConfirmed)
                    {
                        return BadRequest(new
                        {
                            error = _badRequest.ShowError(_badRequest.ErrUserUnverified)
                        });
                    }

                    return AcceptedAtAction("someAction", "someController", new
                    {
                        username = user.UserName
                    }, new
                    {
                        data = user,
                        link = new
                        {
                            self = Url.Action("someAction", "someController", new
                            {
                                username = user.UserName
                            }, Request.Scheme)
                        }
                    });
                }

                return BadRequest(_badRequest.ShowError(_badRequest.ErrAuthenticationFailed));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.StackTrace);
            }
        }
    }
}