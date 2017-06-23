using DPEP.Common.BLL.Interfaces;
using DPEP.Common.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DPEP.Common.BLL.Repositories
{
    public class StatusRepository : IStatusRepository
    {
        private readonly DevPartnersEmployeeContext _context;

        public StatusRepository(DevPartnersEmployeeContext context)
        {
            _context = context;
        }

        public void AddStatus(Status Status)
        {
            _context.Status.Add(Status);
            _context.SaveChanges();
        }

        public IEnumerable<Status> GetAllStatus()
        {
            return _context.Status;
        }

        public Status GetStatus(int id)
        {
            return _context.Status.Find(id);
        }

        public void RemoveStatus(int id)
        {
            _context.Status.Remove(_context.Status.Find(id));
            _context.SaveChanges();
        }

        public void UpdateStatus(Status Status)
        {
            _context.Entry(Status).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
