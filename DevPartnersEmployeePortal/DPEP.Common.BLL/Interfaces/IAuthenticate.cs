﻿using DPEP.Common.DAL.Model;
using System.Threading.Tasks;

namespace DPEP.Common.BLL.Interfaces
{
    public interface IAuthenticate
    {
        Task<CreatedUserModel> AddNewUser(AddUpModel model);
        Task<UserModel> LoginThenReturnUser(LoginModel login);
        Task SignOut();
    }
}
