using AutoMapper;
using DPEP.Common.BLL.Interfaces;
using DPEP.Common.DAL.Identity;
using DPEP.Common.DAL.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DPEP.Common.BLL.Repositories
{
    internal class Authenticate : IAuthenticate
    {
        private readonly string _claim = "IsAdmin";
        private readonly SignInManager<ApplicationUser> _manager;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _accessor;
        private readonly string _role = "Client";

        private readonly RoleManager<IdentityRole<int>> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;
        public Authenticate(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole<int>> roleManager,
            SignInManager<ApplicationUser> manager, IMapper mapper, IHttpContextAccessor accessor)
        {

            _userManager = userManager;
            _roleManager = roleManager;
            _manager = manager;
            _mapper = mapper;
            _accessor = accessor;
        }

        public async Task<CreatedUserModel> AddNewUser(AddEmployeeModel model)
        {
            return null;
        }

        public async Task SignOut()
        {

            await _manager.SignOutAsync();
        }

        public async Task<UserModel> LoginThenReturnUser([FromBody] LoginModel login)
        {

            var email = login.Email;

            var user = await _userManager.FindByEmailAsync(email);

            if (user != null)
            {

                var signin = await _manager.PasswordSignInAsync(user.UserName, login.Password, login.RememberMe, lockoutOnFailure: false);

                if (signin.Succeeded && user.IsActive)
                {

                    var mapped = _mapper.Map<UserModel>(user);

                    return mapped;
                }
            }

            return null;
        }

        private async Task AddNewRole()
        {

            if (!await _roleManager.RoleExistsAsync(_role))
            {

                var role = new IdentityRole<int>(_role);

                role.Claims.Add(new IdentityRoleClaim<int>
                {
                    ClaimValue = "False",
                    ClaimType = "IsAdmin"
                });

                await _roleManager.CreateAsync(role);
            }

        }
    }
}
