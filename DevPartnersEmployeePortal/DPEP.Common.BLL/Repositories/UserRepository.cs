using AutoMapper;
using DPEP.Common.BLL.Helpers;
using DPEP.Common.BLL.Interfaces;
using DPEP.Common.BLL.Methods;
using DPEP.Common.DAL.Entities;
using DPEP.Common.DAL.Identity;
using DPEP.Common.DAL.Model;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DPEP.Common.BLL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private const string Role = "Client";
        private const string Claim = "IsClient";

        private readonly DevPartnersEmployeeContext _context;
        private readonly SendEmail _sendEmail;
        private readonly ResponseBadRequest _badRequest;
        private readonly GUIDMethod _guidMethod;

        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserRepository(DevPartnersEmployeeContext context,IMapper mapper, SendEmail sendEmail, UserManager<ApplicationUser> userManager, ResponseBadRequest badRequest, GUIDMethod guidMethod)
        {
            _context = context;
            _mapper = mapper;
            _sendEmail = sendEmail;
            _userManager = userManager;
            _badRequest = badRequest;
            _guidMethod = guidMethod;
        }

        public async Task<CreatedUserModel> NewAccountAsync(AddUpModel model, string uri)
        {

            var email =  _context.Company.Where(a => a.EmailAddress == model.emailAddress).SingleOrDefault();

            if (email == null)
            {

                var user = _mapper.Map<ApplicationUser>(model);
                var asp = _mapper.Map<AspNetUser>(user);
                var compa = _mapper.Map<Company>(model);
                _context.Company.Add(compa);
                _context.SaveChanges();

                asp.CompanyId = compa.CompanyId;
                //asp.DateCreated = DateTime.UtcNow;
                //asp.CategoryId = model.CategoryId;
                //asp.PositionId = model.PositionId;
                //asp.JobTypeId = model.JobTypeId;

                _context.AspNetUser.Add(asp);
                _context.SaveChanges();
                //var company = _mapper.Map<Company>(model);
                // //var roleResult = await _userManager.AddToRoleAsync(user, Role);
                // //var claimResult = await _userManager.AddClaimAsync(user, new Claim(Claim, "True"));

                // //if (!roleResult.Succeeded || !claimResult.Succeeded)
                // //{

                // //    await _context.ErrorLogs.AddAsync(new ErrorLogs
                // //    {
                // //        ErrorMessage = string.Join(" xx | xx ", "gffd")
                // //    });

                // //    return null;
                // //}
                // ////Update UserId

                 var mapper = _mapper.Map<CreatedUserModel>(user);
                //mapper.Token = await GenerateEmailConfirmation(model.emailAddress, "", uri);
                //// mapper.GUID = _guidMethod.GetGUIByUserId(user.Id);

                // mapper.Claim = new ClaimType
                // {
                //     Value = "True",
                //     Type = Claim
                // };

                // mapper.Role = Role;

                return mapper;

            }

            return null;
        }

        public async Task<string> GenerateEmailConfirmation(string userEmail, string referenceCode, string uri)
        {
            var com = _context.Company.Where(a => a.EmailAddress == userEmail).FirstOrDefault();
            var user = _context.AspNetUser.Where(a => a.CompanyId == com.CompanyId).SingleOrDefault();
            var appUser = _mapper.Map<ApplicationUser>(user);

           
                var token = await _userManager.GenerateEmailConfirmationTokenAsync(appUser);

                var company = _context.Company.Find(userEmail);
                var userGuid = (from cn in _context.AspNetUser
                                where company.EmailAddress == userEmail
                                select cn.Guid.Value.ToString()).FirstOrDefault();

                var fullName = (from cn in _context.AspNetUser
                                where company.EmailAddress == userEmail
                                select cn.FirstName + " " + cn.LastName).FirstOrDefault();

                var confirmUrl = "http://" + uri + $"/user/verification?guid={userGuid}&referenceCode={referenceCode}&token={token}&isFinalize=true";
                await _sendEmail.SendNow("Verify your account", "VerificationEmail-Template", userEmail, true, fullName, confirmUrl.Replace("api/", ""), uri, "", "", "");

                return token;
           
        }

        public void UpdateUser(UpdateInfoModel model, int id)
        {
            var user = _context.AspNetUser.Find(id);
            user.Address = model.Address;
            user.BirthDate = model.BirthDate;
            user.FirstName = model.FirstName;
            user.MiddleName = model.MiddleName;
            user.LastName = model.LastName;
            user.UserName = model.UserName;
            user.Password = model.Password;
            user.Gender = model.Gender;

            var my = _mapper.Map<AspNetUser>(model);

            _context.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            _context.SaveChanges();
        }

    }
}
