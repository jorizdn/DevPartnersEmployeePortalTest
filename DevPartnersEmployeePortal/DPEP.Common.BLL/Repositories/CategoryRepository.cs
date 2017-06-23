using DPEP.Common.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using DPEP.Common.DAL.Entities;

namespace DPEP.Common.BLL.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DevPartnersEmployeeContext _context;

        public CategoryRepository(DevPartnersEmployeeContext context)
        {
            _context = context;
        }

        public void AddCategory(Category Category)
        {
            _context.Category.Add(Category);
            _context.SaveChanges();
        }

        public IEnumerable<Category> GetAllCategory()
        {
            return _context.Category;
        }

        public Category GetCategory(int id)
        {
            return _context.Category.Find(id);
        }

        public void RemoveCategory(int id)
        {
            _context.Category.Remove(_context.Category.Find(id));
            _context.SaveChanges();
        }

        public void UpdateCategory(Category Category)
        {
            _context.Entry(Category).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
