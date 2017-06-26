using DPEP.Common.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using DPEP.Common.DAL.Entities;
using DPEP.Common.DAL.Model;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DPEP.Common.BLL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DevPartnersEmployeeContext _context;
        public UserRepository(DevPartnersEmployeeContext context)
        {
            _context = context;
        }

        public void AddUser(AddEmployeeModel user)
        {
            var company = new Company()
            {
                CompanyCode = user.employeeID,
                EmailAddress = user.emailAddress
            };
            _context.Company.Add(company);
            _context.SaveChanges();

            var model = new AspNetUser()
            {
                FirstName = user.fname,
                LastName = user.lname,
                CompanyId = company.CompanyId
            };
            _context.AspNetUser.Add(model);
            _context.SaveChanges();
        }

        public IEnumerable<AspNetUser> GetAllUsers()
        {
            return _context.AspNetUser;
        }

        public AspNetUser GetUser(int id)
        {
            return _context.AspNetUser.FirstOrDefault(a => a.AspNetUserId == id);
        }

        public void RemoveUser(int id)
        {
            _context.AspNetUser.Remove(_context.AspNetUser.Find(id));
            _context.Company.Remove(_context.Company.Find(id));
            _context.SaveChanges();
        }

    }
}
