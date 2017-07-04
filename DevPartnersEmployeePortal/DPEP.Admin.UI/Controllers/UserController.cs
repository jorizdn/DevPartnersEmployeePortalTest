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
            _user.UpdateUser(model, id);
            return Ok();
        }

        [HttpGet]
        public IEnumerable<UserDetails> GetAll()
        {
            var asps = _user.GetUsers();
            List<UserDetails> userdetail = new List<UserDetails>() { };
            foreach (var item in asps)
            {
                var com = _context.Company.SingleOrDefault(a => a.CompanyId == item.CompanyId);
                var pos = _context.Position.SingleOrDefault(a => a.PositionId == item.PositionId);
                var cat = _context.Category.SingleOrDefault(a => a.CategoryId == item.CategoryId);
                var user = new UserDetails()
                {
                    FirstName = item.FirstName,
                    MiddleName = item.MiddleName,
                    LastName = item.LastName,
                    Address = item.Address,
                    CompanyCode = com.CompanyCode,
                    BirthDate = item.BirthDate,
                    Position = pos.Name,
                    Category = cat.Name,
                    Gender = (item.Gender == true) ? "Male" : "Female",
                DateCreated = item.DateCreated
                };
                userdetail.Add(user);
            }

            //return userdetail;

            //return (from a in _context.AspNetUser
            //        join p in _context.Company on a.CompanyId equals p.CompanyId
            //        join s in _context.Position on a.PositionId equals s.PositionId
            //        join d in 
            //        select new UserDetails
            //        {
            //              FirstName = a.FirstName,
            //              MiddleName = a.MiddleName,
            //              LastName = a.LastName,
            //              Address = a.Address,
            //              BirthDate = a.BirthDate,
            //              CompanyCode = p.CompanyCode,
            //              Position = 
            //              Category 
            //              JobType 
            //              Gender 
            //              DateCreated 
            //        }).FirstOrDefault();

            return userdetail;
        }
    }
}