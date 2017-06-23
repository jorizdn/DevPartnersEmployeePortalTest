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
            throw new NotImplementedException();
        }

        public void RemoveUser(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(AspNetUser user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AddEmployeeModel> GetEmployees()
        {
            List<AddEmployeeModel> entities = new List<AddEmployeeModel>() { };

            foreach (var item in _context.AspNetUser)
            {
                var model = new AddEmployeeModel();
                 model.fname = item.FirstName;
                 model.lname = item.LastName;

                entities.Add(model);
            }

            return entities;
        }

    }
}
