using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DPEP.Common.BLL.Helpers
{
    public class CheckForgery : Controller
    {
        private readonly IHttpContextAccessor _accessor;
        private readonly IAntiforgery _antiforgery;
        private readonly ResponseBadRequest _badRequest;
        public CheckForgery(IAntiforgery antiforgery, ResponseBadRequest badRequest, IHttpContextAccessor accessor)
        {
            _antiforgery = antiforgery;
            _badRequest = badRequest;
            _accessor = accessor;

        }
        public async Task<string> CheckForgeryToken()
        {

            try
            {
                await _antiforgery.ValidateRequestAsync(_accessor.HttpContext);

                return null;
            }
            catch (Exception ex)
            {

                return ex.ToString().Contains("X-XSRF-TOKEN") ? "TokenNotFound" : "TokenHadExpired";
            }
        }

        public async Task<BadRequestObjectResult> CheckToken()
        {

            var token = await CheckForgeryToken();

            if (token != null)
            {

                switch (token)
                {
                    case "TokenNotFound":
                        return BadRequest(new
                        {
                            error = _badRequest.ShowError(_badRequest.ErrTokenMissing)
                        });
                    case "TokenHadExpired":
                        return BadRequest(new
                        {
                            error = _badRequest.ShowError(_badRequest.ErrAntiForgeryTokenExpiry)
                        });
                }

                return BadRequest(_badRequest.ShowError(_badRequest.ErrAntiForgeryRelated));
            }

            return null;
        }
    }
}
