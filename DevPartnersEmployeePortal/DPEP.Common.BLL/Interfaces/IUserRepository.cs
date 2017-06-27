﻿using DPEP.Common.DAL.Entities;
using DPEP.Common.DAL.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DPEP.Common.BLL.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<AspNetUser> GetAllUsers();
        AspNetUser GetUser(int id);
        void AddUser(AddEmployeeModel user);
        void RemoveUser(int id);
        Task<string> GenerateEmail(string userEmail, string uri);
    }
}
