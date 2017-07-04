using DPEP.Common.BLL.Helpers;
using DPEP.Common.BLL.Interfaces;
using DPEP.Common.DAL.Entities;
using DPEP.Common.DAL.Model;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DPEP.Admin.UI.Controllers
{
    [Produces("application/json")]
    [Route("/User")]
    public class UserController : BaseController //: BaseController
    {
        private readonly IUserRepository _user;
        private readonly DevPartnersEmployeeContext _context;
        private readonly ResponseBadRequest _badRequest;
        public UserController(
            DevPartnersEmployeeContext context,
            IUserRepository user,
            ResponseBadRequest badRequest)
        {
            _user = user;
            _context = context;
            _badRequest = badRequest;
        }

        [HttpPost]
        public async Task<IActionResult> NewUserAsync([FromBody] AddUpModel model)
        {
            var uri = HttpContext.Request.Host.Value;
            var user = await _user.NewAccountAsync(model, "");
            if (user == null)
            {
                return BadRequest(new
                {
                    error = _badRequest.ShowError(
                             _badRequest.ErrAccountDuplication
                            )
                });
            }
            //Send Verification Email to User
            //try
            //{
            //    var code = await _user.GenerateEmailConfirmation(model.Email, "", "");
            //}
            //catch (System.Exception ex)
            //{
            //    return BadRequest(new
            //    {
            //        error = ex.Message,
            //        errorstack = ex.StackTrace
            //    });
            //}

            //return CreatedAtAction("Index", "Home", new
            //{
            //    username = user.Username
            //}, new
            //{
            //    data = user,
            //    link = new
            //    {
            //        self = Url.Action("Index", "Home", new
            //        {
            //            username = user.Username
            //        }, Request.Scheme)
            //    }
            //});

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser([FromRoute] int id, [FromBody] UpdateInfoModel model)
        {
            _user.UpdateUser(model, id);
            return Ok();
        }

    }
}