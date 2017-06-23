using DPEP.Common.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DPEP.Common.BLL.Interfaces
{
    public interface IStatusRepository
    {
        IEnumerable<Status> GetAllStatus();
        Status GetStatus(int id);
        void AddStatus(Status Status);
        void UpdateStatus(Status Status);
        void RemoveStatus(int id);
    }
}
