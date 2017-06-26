using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DPEP.Common.BLL.Interfaces;
using DPEP.Common.DAL.Model;
using DPEP.Common.DAL.Entities;

namespace DPEP.Admin.UI.Controllers
{
    [Produces("application/json")]
    [Route("/User")]
    public class UserController : Controller
    {
        private readonly IUserRepository _context;
        public UserController(IUserRepository context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<AspNetUser> GetAllUsers()
        {
            return _context.GetAllUsers();
        }


        [HttpGet("{id}")]
        public AspNetUser GetUser([FromRoute] int id)
        {
            return _context.GetUser(id);
        }

        [HttpPost]
        public IActionResult PostUser([FromBody] AddEmployeeModel user)
        {
            _context.AddUser(user);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser([FromRoute] int id)
        {
            if (_context.GetUser(id) != null)
            {
                _context.RemoveUser(id);
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }


    }

    
}