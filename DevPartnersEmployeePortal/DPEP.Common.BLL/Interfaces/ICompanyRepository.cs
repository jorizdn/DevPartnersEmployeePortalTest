using DPEP.Common.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DPEP.Common.BLL.Interfaces
{
    public interface ICompanyRepository
    {
        IEnumerable<Company> GetAllCompany();
        Company GetCompany(int id);
        void AddCompany(Company Company);
    }
}
