using DPEP.Common.DAL.Entities;
using DPEP.Common.DAL.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DPEP.Common.BLL.Interfaces
{
    public interface IUserRepository
    {
        Task<CreatedUserModel> NewAccountAsync(AddUpModel model, string user);
        Task<string> GenerateEmailConfirmation(string userEmail, string referenceCode, string uri);
    }
}
