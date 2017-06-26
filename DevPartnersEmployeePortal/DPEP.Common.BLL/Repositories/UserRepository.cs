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
        private readonly IMapper _mapper;

        public UserRepository(DevPartnersEmployeeContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void AddUser(AddEmployeeModel user)
        {
            var company = Mapper.Map<Company>(user);
            _context.Company.Add(company);
            _context.SaveChanges();

            var aspNetUser = Mapper.Map<AspNetUser>(user);
            _context.AspNetUser.Add(aspNetUser);
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
