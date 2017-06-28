using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DPEP.Common.BLL.Interfaces;
using DPEP.Common.DAL.Model;
using DPEP.Common.DAL.Entities;
using DPEP.Common.BLL.Helpers;

namespace DPEP.Admin.UI.Controllers
{
    [Produces("application/json")]
    [Route("/User")]
    public class UserController : Controller
    {
        private readonly IUserRepository _user;
        private readonly DevPartnersEmployeeContext _context;
        private readonly ResponseBadRequest _badRequest;
        public UserController(IUserRepository user, DevPartnersEmployeeContext context, ResponseBadRequest badRequest)
        {
            _user = user;
            _context = context;
            _badRequest = badRequest;
        }

        [HttpGet]
        public IEnumerable<AspNetUser> GetAllUsers()
        {
            return _user.GetAllUsers();
        }
         

        [HttpGet("{id}")]
        public AspNetUser GetUser([FromRoute] int id)
        {
            return _user.GetUser(id);
        }

        [HttpPost]
        public IActionResult PostUser([FromBody] AddUpModel user)
        {
            var uri = HttpContext.Request.Host.Value;

            _user.AddUser(user);
            _user.GenerateEmail(user.emailAddress, uri);

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser([FromRoute] int id)
        {
            if (_user.GetUser(id) != null)
            {
                _user.RemoveUser(id);
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }


    }

    
}