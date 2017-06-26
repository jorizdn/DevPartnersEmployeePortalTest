using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DPEP.Common.BLL.Interfaces;
using DPEP.Common.DAL.Entities;

namespace DPEP.Admin.UI.Controllers
{
    [Produces("application/json")]
    [Route("/Company")]
    public class CompanyController : Controller
    {
        private readonly ICompanyRepository _context;

        public CompanyController(ICompanyRepository context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Company> GetAllCompany()
        {
            return _context.GetAllCompany();
        }

        [HttpGet("{id}")]
        public Company GetCompany([FromRoute] int id)
        {
            return _context.GetCompany(id);
        }
    }
}