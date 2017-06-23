using DPEP.Common.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DPEP.Common.BLL.Interfaces
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAllCategory();
        Category GetCategory(int id);
        void AddCategory(Category Category);
        void UpdateCategory(Category Category);
        void RemoveCategory(int id);
    }
}