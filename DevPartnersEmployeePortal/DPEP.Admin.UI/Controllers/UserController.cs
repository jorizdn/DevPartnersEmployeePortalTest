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

        //[HttpGet]
        //public IEnumerable<AspNetUser> GetAllUsers()
        //{
        //    return _context.GetAllUsers();
        //}

        [HttpPost]
        public IActionResult PostUser([FromBody] AddEmployeeModel user)
        {
            _context.AddUser(user);
            return Ok();
        }

        [HttpGet]
        public IEnumerable<AddEmployeeModel> GetEmployees()
        {
            return _context.GetEmployees();
        }

    }

    
}