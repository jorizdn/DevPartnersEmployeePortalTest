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
    [Route("/Status")]
    public class StatusController : Controller
    {
        private readonly IStatusRepository _context;
        public StatusController(IStatusRepository context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Status> GetAllStatus()
        {
            return _context.GetAllStatus();
        }

        [HttpGet("{id}")]
        public Status GetStatus([FromRoute]int id)
        {
            return _context.GetStatus(id);
        }

        [HttpPost]
        public IActionResult PostStatus([FromBody] Status Status)
        {
            _context.AddStatus(Status);
            return Ok();
        }

        [HttpDelete("{id}")]
        public void DeleteStatus(int id)
        {
            _context.RemoveStatus(id);
        }

        [HttpPut("{id}")]
        public void PutStatus([FromRoute]int id, [FromBody] Status Status)
        {
            _context.UpdateStatus(Status);
        }
    }
}