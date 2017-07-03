using AutoMapper;
using DPEP.Common.DAL.Entities;
using System;
using System.Linq;

namespace DPEP.Common.BLL.Methods
{
    public class GUIDMethod
    {
        private readonly DevPartnersEmployeeContext _context;
        private readonly IMapper _mapper;

        public GUIDMethod(DevPartnersEmployeeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        public string GetUserIdByGUID(string guid)
        {
            try
            {
                return (from u in _context.AspNetUser
                        where u.Guid == Guid.Parse(guid)
                        select u.AspNetUserId).FirstOrDefault().ToString();
            }
            catch (Exception e)
            {
                return "";
            }
        }

        public string GetGUIByUserId(int userId)
        {
            try
            {
                return (from u in _context.AspNetUser
                        where u.AspNetUserId == userId
                        select u.Guid).FirstOrDefault().ToString();
            }
            catch (Exception e)
            {
                return "";
            }
        }

    }
}
