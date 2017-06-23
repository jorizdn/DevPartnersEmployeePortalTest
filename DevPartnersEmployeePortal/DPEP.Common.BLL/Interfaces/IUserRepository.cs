﻿using DPEP.Common.DAL.Entities;
using DPEP.Common.DAL.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DPEP.Common.BLL.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<AspNetUser> GetAllUsers();
        IEnumerable<AddEmployeeModel> GetEmployees();
        AspNetUser GetUser(int id);
        void AddUser(AddEmployeeModel user);
        void UpdateUser(AspNetUser user);
        void RemoveUser(int id);
    }
}
