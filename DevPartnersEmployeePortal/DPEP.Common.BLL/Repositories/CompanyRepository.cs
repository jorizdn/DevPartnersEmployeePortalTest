using DPEP.Common.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using DPEP.Common.DAL.Entities;
using System.Linq;

namespace DPEP.Common.BLL.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly DevPartnersEmployeeContext _context;

        public CompanyRepository(DevPartnersEmployeeContext context)
        {
            _context = context;
        }

        public void AddCompany(Company Company)
        {
            _context.Company.Add(Company);
            _context.SaveChanges();
        }

        public IEnumerable<Company> GetAllCompany()
        {
            return _context.Company;
        }

        public Company GetCompany(int id)
        {
            return _context.Company.FirstOrDefault(a => a.CompanyId == id);
        }
    }
}
