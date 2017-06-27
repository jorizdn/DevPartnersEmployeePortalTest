using AutoMapper;
using DPEP.Common.DAL.Entities;
using DPEP.Common.DAL.Identity;
using DPEP.Common.DAL.Model;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace DPEP.Common.BLL.ConfigServices
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<ApplicationUser, UserModel>();
            CreateMap<AccountModel, ApplicationUser>()
               .ForMember(c => c.CreatedDate, f => f.ResolveUsing(c => DateTime.UtcNow))
               .ForMember(c => c.UserName, f => f.ResolveUsing(c => c.Email.Split('@')[0]))
               .ForMember(c => c.IsActive, f => f.ResolveUsing(c => true));
            CreateMap<AddEmployeeModel, AspNetUser>();
            CreateMap<AddEmployeeModel, Company>()
                .ForMember(dest => dest.CompanyCode, opt => opt.MapFrom(src => src.employeeID))
                .ForMember(dest => dest.EmailAddress, opt => opt.MapFrom(src => src.emailAddress));
            CreateMap<AddEmployeeModel, ApplicationUser>()
               .ForMember(c => c.CreatedDate, f => f.ResolveUsing(c => DateTime.UtcNow))
               .ForMember(c => c.UserName, f => f.ResolveUsing(c => c.emailAddress.Split('@')[0]))
               .ForMember(c => c.IsActive, f => f.ResolveUsing(c => true));
            CreateMap<IOptions<AppSettingModel>, AppSettingModel>();
            CreateMap<ApplicationUser, CreatedUserModel>();
            CreateMap<ApplicationUser, UserModel>();
        }
    }

    public static class MapperConfigService
    {
        public static IServiceCollection RegisterMapper(this IServiceCollection services)
        {
            services.AddAutoMapper();

            return services;
        }
    }
}
