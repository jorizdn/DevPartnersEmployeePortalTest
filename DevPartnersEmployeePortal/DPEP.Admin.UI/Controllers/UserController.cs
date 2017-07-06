using AutoMapper;
using DPEP.Common.BLL.Helpers;
using DPEP.Common.BLL.Interfaces;
using DPEP.Common.DAL.Entities;
using DPEP.Common.DAL.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
        private readonly IMapper _mapper;
        public UserController(
            DevPartnersEmployeeContext context,
            IUserRepository user,
            ResponseBadRequest badRequest,
            IMapper mapper)
        {
            _user = user;
            _context = context;
            _badRequest = badRequest;
            _mapper = mapper;
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
            _user.UpdateUserAsync(model, id);
            return Ok();
        }

        [HttpGet]
        public IEnumerable<UserDetails> GetAll()
        {
            var asps = _user.GetUsers();
            List<UserDetails> userdetail = new List<UserDetails>() { };
            foreach (var item in _user.GetUsers())
            {
                var user = (from a in _context.AspNetUser
                            join p in _context.Company on a.CompanyId equals p.CompanyId
                            join s in _context.Position on a.PositionId equals s.PositionId
                            join b in _context.Category on a.CategoryId equals b.CategoryId
                            join m in _context.JobType on a.JobTypeId equals m.JobId
                           where a.AspNetUserId == item.AspNetUserId
                            select new UserDetails
                            {
                                FirstName = a.FirstName,
                                MiddleName = a.MiddleName,
                                LastName = a.LastName,
                                Address = a.Address,
                                BirthDate = a.BirthDate,
                                CompanyCode = p.CompanyCode,
                                Position = s.Name,
                                Category = b.Name,
                                EmailAddress = p.EmailAddress,
                                JobType = m.Name,
                                Gender = (a.Gender == true) ? "Male" : "Female",
                                DateCreated = a.DateCreated
                            }).FirstOrDefault();
                userdetail.Add(user);
            }
            return userdetail;
        }
    }
}