using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DPEP.Common.DAL.Entities;
using DPEP.Common.BLL.Interfaces;

namespace DPEP.Admin.UI.Controllers
{
    [Produces("application/json")]
    [Route("/Category")]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _context;
        public CategoryController(ICategoryRepository context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Category> GetAllCategory()
        {
            return _context.GetAllCategory();
        }

        [HttpGet("{id}")]
        public Category GetCategory([FromRoute]int id)
        {
            return _context.GetCategory(id);
        }

        [HttpPost]
        public IActionResult PostCategory([FromBody] Category Category)
        {
            _context.AddCategory(Category);
            return Ok();
        }

        [HttpDelete("{id}")]
        public void DeleteCategory(int id)
        {
            _context.RemoveCategory(id);
        }

        [HttpPut("{id}")]
        public void PutCategory([FromRoute]int id, [FromBody] Category Category)
        {
            _context.UpdateCategory(Category);
        }
    }
}