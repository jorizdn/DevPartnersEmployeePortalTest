using DPEP.Common.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using DPEP.Common.DAL.Entities;
using DPEP.Common.DAL.Model;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using DPEP.Common.DAL.Identity;
using DPEP.Common.BLL.Methods;

namespace DPEP.Common.BLL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DevPartnersEmployeeContext _context;
        private readonly SendEmail _sendEmail;

        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserRepository(DevPartnersEmployeeContext context,IMapper mapper, SendEmail sendEmail, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _mapper = mapper;
            _sendEmail = sendEmail;
            _userManager = userManager;
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

        public async Task<string> GenerateEmail(string userEmail, string uri)
        {

            var user = await _userManager.FindByEmailAsync(userEmail);
            if (user != null)
            {

                var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);

                var company = _context.Company.Find(userEmail);
                var userGuid = (from cn in _context.AspNetUser
                                where company.EmailAddress == userEmail
                                select cn.Guid.Value.ToString()).FirstOrDefault();

                var fullName = (from cn in _context.AspNetUser
                                where company.EmailAddress == userEmail
                                select cn.FirstName + " " + cn.LastName).FirstOrDefault();

                var confirmUrl = "http://" + uri + $"/user/verification?guid={userGuid}&token={token}";
                await _sendEmail.SendNow("Verify your account", "VerificationEmail-Template", userEmail, true, fullName, confirmUrl.Replace("api/", ""), uri, "", "", "");
            }

            return null;
        }

    }
}
