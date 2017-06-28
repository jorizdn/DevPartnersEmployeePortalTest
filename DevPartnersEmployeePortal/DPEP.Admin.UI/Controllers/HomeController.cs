using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DPEP.Common.DAL.Entities;
using DPEP.Common.BLL.Interfaces;

namespace DPEP.Admin.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly DevPartnersEmployeeContext _context;
        private readonly IUserRepository _user;

        public HomeController(DevPartnersEmployeeContext context, IUserRepository user)
        {
            _context = context;
            _user = user;
        }
        public IActionResult Index()
        {
            return View(_user.GetAllUsers());
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
